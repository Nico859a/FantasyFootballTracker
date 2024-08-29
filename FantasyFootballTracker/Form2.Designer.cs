namespace FantasyFootballTracker
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewWatchlist = new DataGridView();
            labWatchlist = new Label();
            btnRemove = new CustomButton();
            labAverageGrade = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWatchlist).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewWatchlist
            // 
            dataGridViewWatchlist.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewWatchlist.BackgroundColor = Color.DarkGray;
            dataGridViewWatchlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewWatchlist.GridColor = Color.BlueViolet;
            dataGridViewWatchlist.Location = new Point(51, 112);
            dataGridViewWatchlist.Name = "dataGridViewWatchlist";
            dataGridViewWatchlist.Size = new Size(697, 256);
            dataGridViewWatchlist.TabIndex = 0;
            // 
            // labWatchlist
            // 
            labWatchlist.Anchor = AnchorStyles.Top;
            labWatchlist.AutoSize = true;
            labWatchlist.Font = new Font("RODE Noto Sans Hindi B", 18F, FontStyle.Bold);
            labWatchlist.Location = new Point(337, 52);
            labWatchlist.Name = "labWatchlist";
            labWatchlist.Size = new Size(126, 33);
            labWatchlist.TabIndex = 1;
            labWatchlist.Text = "Watchlist";
            labWatchlist.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemove.BackColor = Color.MediumSlateBlue;
            btnRemove.BackgroundColor = Color.MediumSlateBlue;
            btnRemove.BorderColor = Color.PaleVioletRed;
            btnRemove.BorderRadius = 40;
            btnRemove.BorderSize = 0;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("RODE Noto Sans Hindi B", 9F, FontStyle.Bold);
            btnRemove.ForeColor = Color.WhiteSmoke;
            btnRemove.Location = new Point(51, 374);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(150, 40);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.TextColor = Color.WhiteSmoke;
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // labAverageGrade
            // 
            labAverageGrade.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labAverageGrade.AutoSize = true;
            labAverageGrade.Font = new Font("RODE Noto Sans Hindi B", 9.75F, FontStyle.Bold);
            labAverageGrade.Location = new Point(626, 388);
            labAverageGrade.Name = "labAverageGrade";
            labAverageGrade.Size = new Size(0, 18);
            labAverageGrade.TabIndex = 3;
            labAverageGrade.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(788, 450);
            Controls.Add(labAverageGrade);
            Controls.Add(btnRemove);
            Controls.Add(labWatchlist);
            Controls.Add(dataGridViewWatchlist);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewWatchlist).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewWatchlist;
        private Label labWatchlist;
        private CustomButton btnRemove;
        private Label labAverageGrade;
    }
}