namespace PAB2
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.playerItemName = new System.Windows.Forms.TextBox();
            this.playerItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.shopItemQuantity = new System.Windows.Forms.NumericUpDown();
            this.shopItemName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerItemQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopItemQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(80, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(245, 160);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(481, 45);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(245, 160);
            this.dataGridView2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Shop items";
            // 
            // playerItemName
            // 
            this.playerItemName.Location = new System.Drawing.Point(80, 264);
            this.playerItemName.Name = "playerItemName";
            this.playerItemName.Size = new System.Drawing.Size(100, 20);
            this.playerItemName.TabIndex = 4;
            // 
            // playerItemQuantity
            // 
            this.playerItemQuantity.Location = new System.Drawing.Point(80, 307);
            this.playerItemQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.playerItemQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playerItemQuantity.Name = "playerItemQuantity";
            this.playerItemQuantity.Size = new System.Drawing.Size(120, 20);
            this.playerItemQuantity.TabIndex = 5;
            this.playerItemQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Item name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(674, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(664, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Item name";
            // 
            // shopItemQuantity
            // 
            this.shopItemQuantity.Location = new System.Drawing.Point(600, 307);
            this.shopItemQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.shopItemQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.shopItemQuantity.Name = "shopItemQuantity";
            this.shopItemQuantity.Size = new System.Drawing.Size(120, 20);
            this.shopItemQuantity.TabIndex = 9;
            this.shopItemQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // shopItemName
            // 
            this.shopItemName.Location = new System.Drawing.Point(620, 264);
            this.shopItemName.Name = "shopItemName";
            this.shopItemName.Size = new System.Drawing.Size(100, 20);
            this.shopItemName.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 40);
            this.button1.TabIndex = 12;
            this.button1.Text = "EXCHANGE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorText
            // 
            this.errorText.AutoSize = true;
            this.errorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.errorText.ForeColor = System.Drawing.Color.DarkRed;
            this.errorText.Location = new System.Drawing.Point(80, 356);
            this.errorText.Name = "errorText";
            this.errorText.Size = new System.Drawing.Size(0, 16);
            this.errorText.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.shopItemQuantity);
            this.Controls.Add(this.shopItemName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.playerItemQuantity);
            this.Controls.Add(this.playerItemName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerItemQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopItemQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox playerItemName;
        private System.Windows.Forms.NumericUpDown playerItemQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown shopItemQuantity;
        private System.Windows.Forms.TextBox shopItemName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label errorText;
    }
}

