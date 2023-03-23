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
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            playerItemName = new TextBox();
            playerItemQuantity = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            shopItemQuantity = new NumericUpDown();
            shopItemName = new TextBox();
            errorText = new Label();
            exchangeButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)playerItemQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shopItemQuantity).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(93, 52);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(286, 185);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(561, 52);
            dataGridView2.Margin = new Padding(4, 3, 4, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(286, 185);
            dataGridView2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 2;
            label1.Text = "Player items";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(558, 30);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 3;
            label2.Text = "Shop items";
            // 
            // playerItemName
            // 
            playerItemName.Location = new Point(93, 305);
            playerItemName.Margin = new Padding(4, 3, 4, 3);
            playerItemName.Name = "playerItemName";
            playerItemName.Size = new Size(116, 23);
            playerItemName.TabIndex = 4;
            // 
            // playerItemQuantity
            // 
            playerItemQuantity.Location = new Point(93, 354);
            playerItemQuantity.Margin = new Padding(4, 3, 4, 3);
            playerItemQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            playerItemQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            playerItemQuantity.Name = "playerItemQuantity";
            playerItemQuantity.Size = new Size(140, 23);
            playerItemQuantity.TabIndex = 5;
            playerItemQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 286);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 6;
            label3.Text = "Item name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 336);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 7;
            label4.Text = "Quantity";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(786, 336);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 11;
            label5.Text = "Quantity";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(775, 286);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(64, 15);
            label6.TabIndex = 10;
            label6.Text = "Item name";
            // 
            // shopItemQuantity
            // 
            shopItemQuantity.Location = new Point(700, 354);
            shopItemQuantity.Margin = new Padding(4, 3, 4, 3);
            shopItemQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            shopItemQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            shopItemQuantity.Name = "shopItemQuantity";
            shopItemQuantity.Size = new Size(140, 23);
            shopItemQuantity.TabIndex = 9;
            shopItemQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // shopItemName
            // 
            shopItemName.Location = new Point(723, 305);
            shopItemName.Margin = new Padding(4, 3, 4, 3);
            shopItemName.Name = "shopItemName";
            shopItemName.Size = new Size(116, 23);
            shopItemName.TabIndex = 8;
            // 
            // errorText
            // 
            errorText.AutoSize = true;
            errorText.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            errorText.ForeColor = Color.DarkRed;
            errorText.Location = new Point(93, 411);
            errorText.Margin = new Padding(4, 0, 4, 0);
            errorText.Name = "errorText";
            errorText.Size = new Size(0, 16);
            errorText.TabIndex = 13;
            // 
            // exchangeButton
            // 
            exchangeButton.Location = new Point(378, 320);
            exchangeButton.Name = "exchangeButton";
            exchangeButton.Size = new Size(179, 46);
            exchangeButton.TabIndex = 14;
            exchangeButton.Text = "EXCHANGE";
            exchangeButton.UseVisualStyleBackColor = true;
            exchangeButton.Click += exchangeButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(933, 519);
            Controls.Add(exchangeButton);
            Controls.Add(errorText);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(shopItemQuantity);
            Controls.Add(shopItemName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(playerItemQuantity);
            Controls.Add(playerItemName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)playerItemQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)shopItemQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label errorText;
        private Button exchangeButton;
    }
}

