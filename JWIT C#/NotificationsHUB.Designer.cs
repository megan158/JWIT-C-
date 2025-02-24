namespace JWIT_C_
{
    partial class NotificationsHUB
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
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSchedule = new Button();
            btnProfiles = new Button();
            monthCalendar1 = new MonthCalendar();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(168, 38);
            label1.TabIndex = 0;
            label1.Text = "Main Menu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(243, 152);
            label3.Name = "label3";
            label3.Size = new Size(164, 28);
            label3.TabIndex = 2;
            label3.Text = "Current Speaker";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(473, 152);
            label4.Name = "label4";
            label4.Size = new Size(154, 28);
            label4.TabIndex = 3;
            label4.Text = "Future Speaker";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(218, 363);
            label5.Name = "label5";
            label5.Size = new Size(213, 32);
            label5.TabIndex = 4;
            label5.Text = "Speaker Schedule";
            // 
            // btnSchedule
            // 
            btnSchedule.BackColor = SystemColors.ActiveCaption;
            btnSchedule.Location = new Point(55, 79);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(231, 34);
            btnSchedule.TabIndex = 5;
            btnSchedule.Text = "Schedule";
            btnSchedule.UseVisualStyleBackColor = false;
            // 
            // btnProfiles
            // 
            btnProfiles.BackColor = SystemColors.ActiveCaption;
            btnProfiles.Location = new Point(345, 79);
            btnProfiles.Name = "btnProfiles";
            btnProfiles.Size = new Size(229, 34);
            btnProfiles.TabIndex = 6;
            btnProfiles.Text = "Profiles";
            btnProfiles.UseVisualStyleBackColor = false;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(167, 404);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(35, 203);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(592, 132);
            dataGridView1.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 152);
            label2.Name = "label2";
            label2.Size = new Size(133, 28);
            label2.TabIndex = 1;
            label2.Text = "Past Speaker";
            // 
            // NotificationsHUB
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 673);
            Controls.Add(dataGridView1);
            Controls.Add(monthCalendar1);
            Controls.Add(btnProfiles);
            Controls.Add(btnSchedule);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NotificationsHUB";
            Text = "NotificationsHUB";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSchedule;
        private Button btnProfiles;
        private MonthCalendar monthCalendar1;
        private DataGridView dataGridView1;
        private Label label2;
    }
}