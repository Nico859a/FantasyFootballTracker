using CsvHelper;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace FantasyFootballTracker
{
    public partial class FantasyForm : Form
    {
        private Form2 watchlistForm;

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem addPlayerToolStripMenuItem;
        public FantasyForm()
        {
            InitializeComponent();
            LoadPlayerData();

            watchlistForm = new Form2();

            dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
            dataGridView.CellMouseDown += DataGridView_CellMouseDown;
            contextMenuStrip1 = new ContextMenuStrip();
            addPlayerToolStripMenuItem = new ToolStripMenuItem("Add to Watchlist");

            contextMenuStrip1.Items.Add(addPlayerToolStripMenuItem);

            dataGridView.ContextMenuStrip = contextMenuStrip1;

            addPlayerToolStripMenuItem.Click += AddPlayerToolStripMenuItem_Click;
        }

        private void LoadPlayerData()
        {
            string filePath = @"C:\mini-project\ProjectPlayerList.csv";
            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                // Create columns from the first line
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                dt.Columns.Add(new DataColumn("Grade", typeof(string)));

                // Add rows from the remaining lines
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dataWords = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < headerLabels.Length; j++)
                    {
                        dr[j] = dataWords[j];
                    }
                    dt.Rows.Add(dr);
                }
            }

            if (dt.Rows.Count > 0)
            {
                dataGridView.DataSource = dt;
            }

            AddGradesToDataGridView();
        }

        private void AddGradesToDataGridView()
        {

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder

                string name = row.Cells["Name"].Value?.ToString() ?? string.Empty;
                string position = row.Cells["Position"].Value?.ToString() ?? string.Empty;
                int gamesPlayed = Convert.ToInt32(row.Cells["Games Played"].Value ?? 0);
                double pointsPerGame = Convert.ToDouble(row.Cells["Points Per Game"].Value ?? 0.0);
                int carries = Convert.ToInt32(row.Cells["Carries"].Value ?? 0);
                int rushingYards = Convert.ToInt32(row.Cells["Rushing Yards"].Value ?? 0);
                int totalTouchdowns = Convert.ToInt32(row.Cells["Total Touchdowns"].Value ?? 0);
                int receptions = Convert.ToInt32(row.Cells["Receptions"].Value ?? 0);
                int receivingYards = Convert.ToInt32(row.Cells["Receiving Yards"].Value ?? 0);

                FootballPlayer player = new FootballPlayer(name, position, gamesPlayed, pointsPerGame, carries, rushingYards, totalTouchdowns, receptions, receivingYards);

                // Calculate the grade
                string grade = GradePlayer(player);

                // Assign the grade to the grade column in the current row
                row.Cells["Grade"].Value = grade;
            }
            dataGridView.Refresh();
        }

        //This evaluates a player's performance by considering their
        //Points Per Game and Total Touchdowns, with additional adjustments based on
        //their position-specific stats (Rushing Yards for RBs or Receiving Yards
        //for WRs/TEs). The calculated score is then used to assign a grade (A, B, C, or D)
        //that reflects their overall performance.

        private string GradePlayer(FootballPlayer player)
        {
            double pointsPerGameWeight = 0.4;
            double totalTouchdownsWeight = 0.4;
            double rushingYardsWeight = 0.2;
            double receivingYardsWeight = 0.2;

            double score = player.PointsPerGame * pointsPerGameWeight + player.TotalTouchdowns * totalTouchdownsWeight;

            // position-based adjustments
            if (player.Position == "RB")
            {
                score += player.RushingYards * rushingYardsWeight;
            }
            else if (player.Position == "WR" || player.Position == "TE")
            {
                score += player.ReceivingYards * receivingYardsWeight;
            }
            
            string grade = "D";  // default grade

            if (score >= 300)
            {
                grade = "A";
            }
            else if (score >= 200)
            {
                grade = "B";
            }
            else if (score >= 150)
            {
                grade = "C";
            }
            else if (score >= 80)
            {
                grade = "D";
            }

            return grade;
        }
        public List<FootballPlayer> GetPlayersFromDataGridView()
        {
            List<FootballPlayer> players = new List<FootballPlayer>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder

                string name = row.Cells["Name"].Value?.ToString() ?? string.Empty;
                string position = row.Cells["Position"].Value?.ToString() ?? string.Empty;
                int gamesPlayed = Convert.ToInt32(row.Cells["Games Played"].Value ?? 0);
                double pointsPerGame = Convert.ToDouble(row.Cells["Points Per Game"].Value ?? 0.0);
                int carries = Convert.ToInt32(row.Cells["Carries"].Value ?? 0);
                int rushingYards = Convert.ToInt32(row.Cells["Rushing Yards"].Value ?? 0);
                int totalTouchdowns = Convert.ToInt32(row.Cells["Total Touchdowns"].Value ?? 0);
                int receptions = Convert.ToInt32(row.Cells["Receptions"].Value ?? 0);
                int receivingYards = Convert.ToInt32(row.Cells["Receiving Yards"].Value ?? 0);

                players.Add(new FootballPlayer(name, position, gamesPlayed, pointsPerGame, carries, rushingYards, totalTouchdowns, receptions, receivingYards));
            }

            return players;
        }

        private TextBox? txtboxSearch;
        private DataTable? originalDataTable;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtboxSearch == null)
            {
                txtboxSearch = new TextBox
                {
                    Name = "dynamicSearchTextBox",
                    Location = new Point(30, 108),
                    Size = new Size(100, 23)
                };

                this.Controls.Add(txtboxSearch);

                txtboxSearch.Focus();

                txtboxSearch.KeyDown += (s, args) =>
                {
                    if (args.KeyCode == Keys.Enter)
                    {
                        PerformSearch(txtboxSearch.Text.Trim().ToLower());
                    }
                };
            }

            PerformSearch(txtboxSearch.Text.Trim().ToLower());
        }

        private void PerformSearch(string searchQuery)
        {
            try
            {
                // Get the DataTable from the DataGridView's DataSource
                DataTable dt = (DataTable)dataGridView.DataSource;

                // Initialize the original DataTable if it hasn't been set yet
                if (originalDataTable == null)
                {
                    originalDataTable = dt.Copy();
                }

                if (dt != null)
                {
                    DataView dv = dt.DefaultView;

                    if (string.IsNullOrEmpty(searchQuery))
                    {
                        // If the search is empty, reset to the original data
                        dv.RowFilter = string.Empty;
                        dataGridView.DataSource = originalDataTable;
                    }
                    else
                    {
                        dv.RowFilter = string.Format("Name LIKE '%{0}%' OR Position LIKE '%{0}%'", searchQuery);
                        dataGridView.DataSource = dv.ToTable();
                    }

                    // Check if any rows match the filter criteria
                    if (dv.Count == 0 && !string.IsNullOrEmpty(searchQuery))
                    {
                        // No results found, show a message to the user
                        MessageBox.Show("No players found, please try again", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView.DataSource = originalDataTable;
                    }
                }

                // Clear the search box after performing the search
                if (txtboxSearch != null)
                {
                    txtboxSearch.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the DataGridView is always refreshed and focus on the textbox
                if (txtboxSearch != null)
                {
                    txtboxSearch.Focus();
                }
            }
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the details from the selected row
                string name = dataGridView.Rows[e.RowIndex].Cells["Name"].Value.ToString() ?? string.Empty; ;
                string position = dataGridView.Rows[e.RowIndex].Cells["Position"].Value.ToString() ?? string.Empty; ;
                int gamesPlayed = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Games Played"].Value);
                double pointsPerGame = Convert.ToDouble(dataGridView.Rows[e.RowIndex].Cells["Points Per Game"].Value);
                int carries = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Carries"].Value);
                int rushingYards = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Rushing Yards"].Value);
                int totalTouchdowns = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Total Touchdowns"].Value);
                int receptions = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Receptions"].Value);
                int receivingYards = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["Receiving Yards"].Value);
                string grade = dataGridView.Rows[e.RowIndex].Cells["Grade"].Value.ToString() ?? string.Empty; ;

                watchlistForm.AddToWatchlist(name, position, gamesPlayed, pointsPerGame, carries, rushingYards, totalTouchdowns, receptions, receivingYards, grade);

                if (!watchlistForm.Visible)
                {
                    watchlistForm.Show();
                }
            }
        }

        private void btnWatchlist_Click(object sender, EventArgs e)
        {
            if (!watchlistForm.Visible)
            {
                watchlistForm.Show();
            }
            else
            {
                // Bring the existing WatchlistForm to front if it's already open
                watchlistForm.BringToFront();
            }
        }

        private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView.ClearSelection();
                dataGridView.Rows[e.RowIndex].Selected = true;

                if (e.ColumnIndex >= 0)
                {
                    dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
            }
        }

        private void AddPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                string name = selectedRow.Cells["Name"].Value?.ToString() ?? "";
                string position = selectedRow.Cells["Position"].Value?.ToString() ?? "";
                int gamesPlayed = int.TryParse(selectedRow.Cells["Games Played"].Value?.ToString(), out int gp) ? gp : 0;
                double pointsPerGame = double.TryParse(selectedRow.Cells["Points Per Game"].Value?.ToString(), out double ppg) ? ppg : 0.0;
                int carries = int.TryParse(selectedRow.Cells["Carries"].Value?.ToString(), out int car) ? car : 0;
                int rushingYards = int.TryParse(selectedRow.Cells["Rushing Yards"].Value?.ToString(), out int ry) ? ry : 0;
                int totalTouchdowns = int.TryParse(selectedRow.Cells["Total Touchdowns"].Value?.ToString(), out int td) ? td : 0;
                int receptions = int.TryParse(selectedRow.Cells["Receptions"].Value?.ToString(), out int rec) ? rec : 0;
                int receivingYards = int.TryParse(selectedRow.Cells["Receiving Yards"].Value?.ToString(), out int recYds) ? recYds : 0; string grade = selectedRow.Cells["Grade"].Value?.ToString() ?? "";

                if (watchlistForm == null || watchlistForm.IsDisposed)
                {
                    watchlistForm = new Form2();
                    watchlistForm.Show();
                }

                watchlistForm.AddToWatchlist(name, position, gamesPlayed, pointsPerGame, carries, rushingYards, totalTouchdowns, receptions, receivingYards, grade);

                if (watchlistForm.WindowState == FormWindowState.Minimized)
                {
                    watchlistForm.WindowState = FormWindowState.Normal;
                }
                watchlistForm.BringToFront();
            }
            else
            {
                MessageBox.Show("Please select a player add.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void FantasyForm_Load(object sender, EventArgs e)
        {
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
    }
}

