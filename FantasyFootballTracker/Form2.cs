using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantasyFootballTracker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeWatchlistTable();

            dataGridViewWatchlist.KeyDown += DataGridViewWatchlist_KeyDown;
            dataGridViewWatchlist.CellDoubleClick += DataGridViewWatchlist_CellDoubleClick;
        }

        private DataTable watchlistTable;


        private void InitializeWatchlistTable()
        {
            watchlistTable = new DataTable();
            watchlistTable.Columns.Add("Name");
            watchlistTable.Columns.Add("Position");
            watchlistTable.Columns.Add("Games Played", typeof(int));
            watchlistTable.Columns.Add("Points Per Game", typeof(double));
            watchlistTable.Columns.Add("Carries", typeof(int));
            watchlistTable.Columns.Add("Rushing Yards", typeof(int));
            watchlistTable.Columns.Add("Total Touchdowns", typeof(int));
            watchlistTable.Columns.Add("Receptions", typeof(int));
            watchlistTable.Columns.Add("Receiving Yards", typeof(int));
            watchlistTable.Columns.Add("Grade");
            dataGridViewWatchlist.DataSource = watchlistTable;
        }

        public void AddToWatchlist(string name, string position, int gamesPlayed, double pointsPerGame, int carries, int rushingYards, int totalTouchdowns, int receptions, int receivingYards, string grade)
        {
            foreach (DataGridViewRow row in dataGridViewWatchlist.Rows)
            {
                if (row.Cells["Name"].Value != null && row.Cells["Name"].Value.ToString() == name)
                {
                    // Player already exists in the watchlist
                    MessageBox.Show($"{name} is already in the watchlist.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DataRow newRow = watchlistTable.NewRow();
            newRow["Name"] = name;
            newRow["Position"] = position;
            newRow["Games Played"] = gamesPlayed;
            newRow["Points Per Game"] = pointsPerGame;
            newRow["Carries"] = carries;
            newRow["Rushing Yards"] = rushingYards;
            newRow["Total Touchdowns"] = totalTouchdowns;
            newRow["Receptions"] = receptions;
            newRow["Receiving Yards"] = receivingYards;
            newRow["Grade"] = grade;
            watchlistTable.Rows.Add(newRow);

            UpdateAverageGradeLabel();

        }

        private string CalculateAverageGrade(DataGridView watchlistDataGridView)
        {
            double totalGradeValue = 0;
            int validCount = 0;

            foreach (DataGridViewRow row in watchlistDataGridView.Rows)
            {
                string? grade = row.Cells["Grade"].Value?.ToString();

                if (!string.IsNullOrEmpty(grade))
                {
                    validCount++; // only increment for non-null, non-empty grades

                    switch (grade)
                    {
                        case "A":
                            totalGradeValue += 4;
                            break;
                        case "B":
                            totalGradeValue += 3;
                            break;
                        case "C":
                            totalGradeValue += 2;
                            break;
                        case "D":
                            totalGradeValue += 1;
                            break;
                    }
                }
            }

            if (validCount == 0) return "N/A";

            double averageGradeValue = totalGradeValue / validCount;
            string averageGrade;

            if (averageGradeValue >= 3.5)
            {
                averageGrade = "A";
            }
            else if (averageGradeValue >= 2.5)
            {
                averageGrade = "B";
            }
            else if (averageGradeValue >= 1.5)
            {
                averageGrade = "C";
            }
            else
            {
                averageGrade = "D";
            }

            return averageGrade;
        }

        private void UpdateAverageGradeLabel()
        {
            string? averageGrade = CalculateAverageGrade(dataGridViewWatchlist);
            labAverageGrade.Text = $"Average Grade: {averageGrade}";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewWatchlist.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the selected player(s)?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridViewWatchlist.SelectedRows)
                    {
                        dataGridViewWatchlist.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a player to remove from the watchlist.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateAverageGradeLabel();
        }

        private void DataGridViewWatchlist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                if (dataGridViewWatchlist.SelectedRows.Count > 0)
                {
                    var result = MessageBox.Show("Are you sure you want to remove the selected player(s) from the watchlist?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dataGridViewWatchlist.SelectedRows)
                        {
                            dataGridViewWatchlist.Rows.Remove(row);
                        }
                    }
                }
            }

            UpdateAverageGradeLabel();
        }

        private void DataGridViewWatchlist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index
            {
                // Confirm removal
                var result = MessageBox.Show("Are you sure you want to remove the selected player(s) from the watchlist?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Remove the selected row
                    dataGridViewWatchlist.Rows.RemoveAt(e.RowIndex);
                }
            }

            UpdateAverageGradeLabel();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Check if the user is closing the form by clicking the "X" button
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel the close event
                this.Hide();     // Hide the form instead
            }
            else
            {
                base.OnFormClosing(e); // Allow the form to close normally
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

    }
}
