namespace JWIT_C_
{
    partial class SpeakerProfile
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
            btnAddSpeaker = new Button();
            btnUpdateSpeaker = new Button();
            btnRemoveSpeaker = new Button();
            btnSearchSpeaker = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAddSpeaker
            // 
            btnAddSpeaker.BackColor = SystemColors.ActiveCaption;
            btnAddSpeaker.Location = new Point(29, 36);
            btnAddSpeaker.Name = "btnAddSpeaker";
            btnAddSpeaker.Size = new Size(225, 34);
            btnAddSpeaker.TabIndex = 0;
            btnAddSpeaker.Text = "Add Speaker";
            btnAddSpeaker.UseVisualStyleBackColor = false;
            btnAddSpeaker.Click += button1_Click;
            // 
            // btnUpdateSpeaker
            // 
            btnUpdateSpeaker.BackColor = SystemColors.ActiveCaption;
            btnUpdateSpeaker.Location = new Point(260, 36);
            btnUpdateSpeaker.Name = "btnUpdateSpeaker";
            btnUpdateSpeaker.Size = new Size(216, 34);
            btnUpdateSpeaker.TabIndex = 1;
            btnUpdateSpeaker.Text = "Update Speaker";
            btnUpdateSpeaker.UseVisualStyleBackColor = false;
            btnUpdateSpeaker.Click += btnUpdateSpeaker_Click;
            // 
            // btnRemoveSpeaker
            // 
            btnRemoveSpeaker.BackColor = SystemColors.ActiveCaption;
            btnRemoveSpeaker.Location = new Point(482, 36);
            btnRemoveSpeaker.Name = "btnRemoveSpeaker";
            btnRemoveSpeaker.Size = new Size(209, 34);
            btnRemoveSpeaker.TabIndex = 2;
            btnRemoveSpeaker.Text = "Remove Speaker";
            btnRemoveSpeaker.UseVisualStyleBackColor = false;
            // 
            // btnSearchSpeaker
            // 
            btnSearchSpeaker.BackColor = SystemColors.ActiveBorder;
            btnSearchSpeaker.Location = new Point(72, 132);
            btnSearchSpeaker.Name = "btnSearchSpeaker";
            btnSearchSpeaker.Size = new Size(214, 34);
            btnSearchSpeaker.TabIndex = 3;
            btnSearchSpeaker.Text = "Search for Speakers";
            btnSearchSpeaker.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(292, 132);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(399, 31);
            textBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(622, 178);
            label1.Name = "label1";
            label1.Size = new Size(69, 25);
            label1.TabIndex = 5;
            label1.Text = "Degree";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(471, 178);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 6;
            label2.Text = "Company";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(292, 178);
            label3.Name = "label3";
            label3.Size = new Size(127, 25);
            label3.TabIndex = 7;
            label3.Text = "Subject Matter";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(318, 273);
            label4.Name = "label4";
            label4.Size = new Size(115, 32);
            label4.TabIndex = 8;
            label4.Text = "Speakers";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 330);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(662, 326);
            dataGridView1.TabIndex = 15;
            // 
            // SpeakerProfile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(754, 686);
            Controls.Add(dataGridView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(btnSearchSpeaker);
            Controls.Add(btnRemoveSpeaker);
            Controls.Add(btnUpdateSpeaker);
            Controls.Add(btnAddSpeaker);
            Name = "SpeakerProfile";
            Text = "SpeakerProfile";
            Load += SpeakerProfile_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddSpeaker;
        private Button btnUpdateSpeaker;
        private Button btnRemoveSpeaker;
        private Button btnSearchSpeaker;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView1;
    }
}