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
