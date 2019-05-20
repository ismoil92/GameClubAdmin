namespace GameClubAdmin
{ 
    partial class UserControlBarTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNameGoods = new System.Windows.Forms.ComboBox();
            this.textBoxAmountGoods = new System.Windows.Forms.TextBox();
            this.buttonSelectGoods = new System.Windows.Forms.Button();
            this.buttonTotalSum = new System.Windows.Forms.Button();
            this.labelTotalSum = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewTempOutcomes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempOutcomes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Меню";
            // 
            // comboBoxNameGoods
            // 
            this.comboBoxNameGoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNameGoods.FormattingEnabled = true;
            this.comboBoxNameGoods.Location = new System.Drawing.Point(108, 20);
            this.comboBoxNameGoods.Name = "comboBoxNameGoods";
            this.comboBoxNameGoods.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNameGoods.TabIndex = 1;
            // 
            // textBoxAmountGoods
            // 
            this.textBoxAmountGoods.Location = new System.Drawing.Point(129, 61);
            this.textBoxAmountGoods.Name = "textBoxAmountGoods";
            this.textBoxAmountGoods.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmountGoods.TabIndex = 2;
            this.textBoxAmountGoods.TextChanged += new System.EventHandler(this.textBoxAmountGoods_TextChanged);
            this.textBoxAmountGoods.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAmountGoods_KeyDown);
            this.textBoxAmountGoods.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAmountGoods_KeyPress);
            // 
            // buttonSelectGoods
            // 
            this.buttonSelectGoods.Location = new System.Drawing.Point(18, 58);
            this.buttonSelectGoods.Name = "buttonSelectGoods";
            this.buttonSelectGoods.Size = new System.Drawing.Size(84, 23);
            this.buttonSelectGoods.TabIndex = 3;
            this.buttonSelectGoods.Text = "Заказать";
            this.buttonSelectGoods.UseVisualStyleBackColor = true;
            this.buttonSelectGoods.Click += new System.EventHandler(this.buttonSelectGoods_Click);
            // 
            // buttonTotalSum
            // 
            this.buttonTotalSum.Location = new System.Drawing.Point(18, 190);
            this.buttonTotalSum.Name = "buttonTotalSum";
            this.buttonTotalSum.Size = new System.Drawing.Size(97, 41);
            this.buttonTotalSum.TabIndex = 5;
            this.buttonTotalSum.Text = "Сумма";
            this.buttonTotalSum.UseVisualStyleBackColor = true;
            this.buttonTotalSum.Click += new System.EventHandler(this.buttonTotalSum_Click);
            // 
            // labelTotalSum
            // 
            this.labelTotalSum.AutoSize = true;
            this.labelTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalSum.Location = new System.Drawing.Point(149, 199);
            this.labelTotalSum.Name = "labelTotalSum";
            this.labelTotalSum.Size = new System.Drawing.Size(0, 22);
            this.labelTotalSum.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(129, 211);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Visible = false;
            // 
            // dataGridViewTempOutcomes
            // 
            this.dataGridViewTempOutcomes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTempOutcomes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4,
            this.Column6});
            this.dataGridViewTempOutcomes.Location = new System.Drawing.Point(260, 39);
            this.dataGridViewTempOutcomes.Name = "dataGridViewTempOutcomes";
            this.dataGridViewTempOutcomes.RowHeadersVisible = false;
            this.dataGridViewTempOutcomes.Size = new System.Drawing.Size(595, 150);
            this.dataGridViewTempOutcomes.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(446, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Заказ Клиентов из бара";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(646, 201);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(97, 38);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(758, 201);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(97, 38);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "RoomName";
            this.Column2.HeaderText = "Бар";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 91;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "Name";
            this.Column3.HeaderText = "Меню";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "Price";
            this.Column5.HeaderText = "Цена";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Amount";
            this.Column4.HeaderText = "Количество";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 123;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "DateOrder";
            this.Column6.HeaderText = "Дата";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // UserControlBarTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewTempOutcomes);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelTotalSum);
            this.Controls.Add(this.buttonTotalSum);
            this.Controls.Add(this.buttonSelectGoods);
            this.Controls.Add(this.textBoxAmountGoods);
            this.Controls.Add(this.comboBoxNameGoods);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UserControlBarTable";
            this.Size = new System.Drawing.Size(877, 247);
            this.Load += new System.EventHandler(this.UserControlBarTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempOutcomes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNameGoods;
        private System.Windows.Forms.TextBox textBoxAmountGoods;
        private System.Windows.Forms.Button buttonSelectGoods;
        private System.Windows.Forms.Button buttonTotalSum;
        private System.Windows.Forms.Label labelTotalSum;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridViewTempOutcomes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
