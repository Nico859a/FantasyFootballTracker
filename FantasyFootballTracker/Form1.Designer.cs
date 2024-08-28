namespace FantasyFootballTracker
{
    partial class FantasyForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FantasyForm));
            dataGridView = new DataGridView();
            btnSearch = new CustomButton();
            labSearch = new Label();
            btnWatchlist = new CustomButton();
            labWatchlist = new Label();
            Title = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = Color.DarkGray;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.GridColor = Color.BlueViolet;
            dataGridView.Location = new Point(12, 211);
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(697, 297);
            dataGridView.TabIndex = 1;
            dataGridView.CellMouseDown += DataGridView_CellMouseDown;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.MediumSlateBlue;
            btnSearch.BackgroundColor = Color.MediumSlateBlue;
            btnSearch.BorderColor = Color.PaleVioletRed;
            btnSearch.BorderRadius = 40;
            btnSearch.BorderSize = 0;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Image = (Image)resources.GetObject("btnSearch.Image");
            btnSearch.Location = new Point(55, 137);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 41);
            btnSearch.TabIndex = 2;
            btnSearch.TextColor = Color.White;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // labSearch
            // 
            labSearch.AutoSize = true;
            labSearch.Font = new Font("RODE Noto Sans Hindi B", 9.75F, FontStyle.Bold);
            labSearch.Location = new Point(55, 181);
            labSearch.Name = "labSearch";
            labSearch.Size = new Size(53, 18);
            labSearch.TabIndex = 3;
            labSearch.Text = "Search";
            labSearch.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnWatchlist
            // 
            btnWatchlist.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnWatchlist.BackColor = Color.MediumSlateBlue;
            btnWatchlist.BackgroundColor = Color.MediumSlateBlue;
            btnWatchlist.BorderColor = Color.PaleVioletRed;
            btnWatchlist.BorderRadius = 40;
            btnWatchlist.BorderSize = 0;
            btnWatchlist.FlatAppearance.BorderSize = 0;
            btnWatchlist.FlatStyle = FlatStyle.Flat;
            btnWatchlist.ForeColor = Color.White;
            btnWatchlist.Image = (Image)resources.GetObject("btnWatchlist.Image");
            btnWatchlist.Location = new Point(604, 137);
            btnWatchlist.Name = "btnWatchlist";
            btnWatchlist.Size = new Size(50, 41);
            btnWatchlist.TabIndex = 5;
            btnWatchlist.TextColor = Color.White;
            btnWatchlist.UseVisualStyleBackColor = false;
            btnWatchlist.Click += btnWatchlist_Click;
            // 
            // labWatchlist
            // 
            labWatchlist.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labWatchlist.AutoSize = true;
            labWatchlist.Font = new Font("RODE Noto Sans Hindi B", 9.75F, FontStyle.Bold);
            labWatchlist.Location = new Point(595, 181);
            labWatchlist.Name = "labWatchlist";
            labWatchlist.Size = new Size(71, 18);
            labWatchlist.TabIndex = 6;
            labWatchlist.Text = "Watchlist";
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top;
            Title.AutoSize = true;
            Title.Font = new Font("RODE Noto Sans Hindi B", 18F, FontStyle.Bold);
            Title.Location = new Point(206, 120);
            Title.Name = "Title";
            Title.Size = new Size(306, 33);
            Title.TabIndex = 7;
            Title.Text = "Fantasy Football Tracker";
            Title.TextAlign = ContentAlignment.TopCenter;
            // 
            // FantasyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(721, 705);
            Controls.Add(Title);
            Controls.Add(labWatchlist);
            Controls.Add(btnWatchlist);
            Controls.Add(labSearch);
            Controls.Add(btnSearch);
            Controls.Add(dataGridView);
            Name = "FantasyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fantasy Football";
            Load += FantasyForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView;
        private CustomButton btnSearch;
        private Label labSearch;
        private CustomButton btnWatchlist;
        private Label labWatchlist;
        private Label Title;
    }
}
