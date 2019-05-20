namespace GameClubAdmin
{
    partial class AddGoodsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButtonDrink = new System.Windows.Forms.RadioButton();
            this.radioButtonGoods = new System.Windows.Forms.RadioButton();
            this.textBoxDrink = new System.Windows.Forms.TextBox();
            this.textBoxGoods = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Название";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(133, 23);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(132, 73);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 2;
            this.textBoxPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            this.textBoxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPrice_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Количество";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(133, 117);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmount.TabIndex = 3;
            this.textBoxAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(70, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Цена";
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(16, 271);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(106, 36);
            this.buttonInsert.TabIndex = 6;
            this.buttonInsert.Text = "Сохранить";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 313);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Visible = false;
            // 
            // radioButtonDrink
            // 
            this.radioButtonDrink.AutoSize = true;
            this.radioButtonDrink.Checked = true;
            this.radioButtonDrink.Location = new System.Drawing.Point(8, 33);
            this.radioButtonDrink.Name = "radioButtonDrink";
            this.radioButtonDrink.Size = new System.Drawing.Size(75, 17);
            this.radioButtonDrink.TabIndex = 4;
            this.radioButtonDrink.TabStop = true;
            this.radioButtonDrink.Text = "Напитки";
            this.radioButtonDrink.UseVisualStyleBackColor = true;
            this.radioButtonDrink.CheckedChanged += new System.EventHandler(this.radioButtonDrink_CheckedChanged);
            // 
            // radioButtonGoods
            // 
            this.radioButtonGoods.AutoSize = true;
            this.radioButtonGoods.Location = new System.Drawing.Point(8, 75);
            this.radioButtonGoods.Name = "radioButtonGoods";
            this.radioButtonGoods.Size = new System.Drawing.Size(83, 17);
            this.radioButtonGoods.TabIndex = 5;
            this.radioButtonGoods.Text = "Продукты";
            this.radioButtonGoods.UseVisualStyleBackColor = true;
            this.radioButtonGoods.CheckedChanged += new System.EventHandler(this.radioButtonGoods_CheckedChanged);
            // 
            // textBoxDrink
            // 
            this.textBoxDrink.Location = new System.Drawing.Point(100, 33);
            this.textBoxDrink.Name = "textBoxDrink";
            this.textBoxDrink.ReadOnly = true;
            this.textBoxDrink.Size = new System.Drawing.Size(100, 20);
            this.textBoxDrink.TabIndex = 10;
            this.textBoxDrink.Text = "Напитки";
            // 
            // textBoxGoods
            // 
            this.textBoxGoods.Location = new System.Drawing.Point(100, 75);
            this.textBoxGoods.Name = "textBoxGoods";
            this.textBoxGoods.ReadOnly = true;
            this.textBoxGoods.Size = new System.Drawing.Size(100, 20);
            this.textBoxGoods.TabIndex = 11;
            this.textBoxGoods.Text = "Продукты";
            this.textBoxGoods.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonDrink);
            this.groupBox1.Controls.Add(this.textBoxGoods);
            this.groupBox1.Controls.Add(this.radioButtonGoods);
            this.groupBox1.Controls.Add(this.textBoxDrink);
            this.groupBox1.Location = new System.Drawing.Point(16, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 102);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // AddGoodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 339);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddGoodsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товары";
            this.Load += new System.EventHandler(this.AddGoodsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBoxDrink;
        private System.Windows.Forms.TextBox textBoxGoods;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton radioButtonDrink;
        public System.Windows.Forms.RadioButton radioButtonGoods;
    }
}