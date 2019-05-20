namespace GameClubAdmin
{ 
    partial class UserContrElems
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelTimer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxGoods = new System.Windows.Forms.ComboBox();
            this.textBoxAmountGoods = new System.Windows.Forms.TextBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonTotalSum = new System.Windows.Forms.Button();
            this.labelTotalSum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPriceTime = new System.Windows.Forms.ComboBox();
            this.dataGridViewTempOutcomes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.checkBoxReservation = new System.Windows.Forms.CheckBox();
            this.labelTotalSumByWorker = new System.Windows.Forms.Label();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.labelTimeName = new System.Windows.Forms.Label();
            this.buttonTimeCount = new System.Windows.Forms.Button();
            this.labelTimerCount = new System.Windows.Forms.Label();
            this.buttonTimerCountStop = new System.Windows.Forms.Button();
            this.radioButtonVIPTime = new System.Windows.Forms.RadioButton();
            this.radioButtonLimitedTime = new System.Windows.Forms.RadioButton();
            this.groupBoxTime = new System.Windows.Forms.GroupBox();
            this.groupBoxMenu = new System.Windows.Forms.GroupBox();
            this.groupBoxRooms = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempOutcomes)).BeginInit();
            this.groupBoxTime.SuspendLayout();
            this.groupBoxMenu.SuspendLayout();
            this.groupBoxRooms.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(21, 23);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(96, 29);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(135, 23);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(96, 29);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Стоп";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimer.Location = new System.Drawing.Point(253, 26);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(88, 22);
            this.labelTimer.TabIndex = 2;
            this.labelTimer.Text = "00:00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Меню";
            // 
            // comboBoxGoods
            // 
            this.comboBoxGoods.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGoods.FormattingEnabled = true;
            this.comboBoxGoods.Location = new System.Drawing.Point(110, 31);
            this.comboBoxGoods.Name = "comboBoxGoods";
            this.comboBoxGoods.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGoods.TabIndex = 4;
            // 
            // textBoxAmountGoods
            // 
            this.textBoxAmountGoods.Location = new System.Drawing.Point(131, 76);
            this.textBoxAmountGoods.Name = "textBoxAmountGoods";
            this.textBoxAmountGoods.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmountGoods.TabIndex = 5;
            this.textBoxAmountGoods.TextChanged += new System.EventHandler(this.textBoxAmountGoods_TextChanged);
            this.textBoxAmountGoods.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAmountGoods_KeyDown);
            this.textBoxAmountGoods.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAmountGoods_KeyPress);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(25, 73);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(75, 23);
            this.buttonSelect.TabIndex = 6;
            this.buttonSelect.Text = "Заказать";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonTotalSum
            // 
            this.buttonTotalSum.Location = new System.Drawing.Point(21, 137);
            this.buttonTotalSum.Name = "buttonTotalSum";
            this.buttonTotalSum.Size = new System.Drawing.Size(96, 32);
            this.buttonTotalSum.TabIndex = 7;
            this.buttonTotalSum.Text = "Сумма";
            this.buttonTotalSum.UseVisualStyleBackColor = true;
            this.buttonTotalSum.Click += new System.EventHandler(this.buttonTotalSum_Click);
            // 
            // labelTotalSum
            // 
            this.labelTotalSum.AutoSize = true;
            this.labelTotalSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalSum.Location = new System.Drawing.Point(148, 142);
            this.labelTotalSum.Name = "labelTotalSum";
            this.labelTotalSum.Size = new System.Drawing.Size(0, 22);
            this.labelTotalSum.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Цены кабинок";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(13, 421);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            this.dateTimePicker1.Visible = false;
            // 
            // comboBoxPriceTime
            // 
            this.comboBoxPriceTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriceTime.FormattingEnabled = true;
            this.comboBoxPriceTime.Location = new System.Drawing.Point(153, 34);
            this.comboBoxPriceTime.Name = "comboBoxPriceTime";
            this.comboBoxPriceTime.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPriceTime.TabIndex = 13;
            // 
            // dataGridViewTempOutcomes
            // 
            this.dataGridViewTempOutcomes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTempOutcomes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column5,
            this.Column3,
            this.Column6});
            this.dataGridViewTempOutcomes.Location = new System.Drawing.Point(13, 252);
            this.dataGridViewTempOutcomes.Name = "dataGridViewTempOutcomes";
            this.dataGridViewTempOutcomes.RowHeadersVisible = false;
            this.dataGridViewTempOutcomes.Size = new System.Drawing.Size(567, 150);
            this.dataGridViewTempOutcomes.TabIndex = 14;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "RoomName";
            this.Column4.HeaderText = "Кабинка";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "Название";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.DataPropertyName = "Price";
            this.Column5.HeaderText = "Цена";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Amount";
            this.Column3.HeaderText = "Количество";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 104;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "DateOrder";
            this.Column6.HeaderText = "Дата";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(194, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "Заказ Клиента";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(382, 417);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(96, 32);
            this.buttonUpdate.TabIndex = 16;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(484, 417);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(96, 32);
            this.buttonDelete.TabIndex = 17;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // checkBoxReservation
            // 
            this.checkBoxReservation.AutoSize = true;
            this.checkBoxReservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxReservation.Location = new System.Drawing.Point(10, 78);
            this.checkBoxReservation.Name = "checkBoxReservation";
            this.checkBoxReservation.Size = new System.Drawing.Size(189, 21);
            this.checkBoxReservation.TabIndex = 18;
            this.checkBoxReservation.Text = "Бронировать кабинку";
            this.checkBoxReservation.UseVisualStyleBackColor = true;
            this.checkBoxReservation.CheckedChanged += new System.EventHandler(this.checkBoxReservation_CheckedChanged);
            // 
            // labelTotalSumByWorker
            // 
            this.labelTotalSumByWorker.AutoSize = true;
            this.labelTotalSumByWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalSumByWorker.ForeColor = System.Drawing.Color.Red;
            this.labelTotalSumByWorker.Location = new System.Drawing.Point(132, 79);
            this.labelTotalSumByWorker.Name = "labelTotalSumByWorker";
            this.labelTotalSumByWorker.Size = new System.Drawing.Size(0, 22);
            this.labelTotalSumByWorker.TabIndex = 27;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(135, 109);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(96, 20);
            this.textBoxTime.TabIndex = 33;
            this.textBoxTime.TextChanged += new System.EventHandler(this.textBoxTime_TextChanged);
            this.textBoxTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAmountGoods_KeyPress);
            // 
            // labelTimeName
            // 
            this.labelTimeName.AutoSize = true;
            this.labelTimeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimeName.Location = new System.Drawing.Point(47, 107);
            this.labelTimeName.Name = "labelTimeName";
            this.labelTimeName.Size = new System.Drawing.Size(70, 22);
            this.labelTimeName.TabIndex = 34;
            this.labelTimeName.Text = "Время";
            // 
            // buttonTimeCount
            // 
            this.buttonTimeCount.Location = new System.Drawing.Point(21, 67);
            this.buttonTimeCount.Name = "buttonTimeCount";
            this.buttonTimeCount.Size = new System.Drawing.Size(96, 32);
            this.buttonTimeCount.TabIndex = 35;
            this.buttonTimeCount.Text = "Старт";
            this.buttonTimeCount.UseVisualStyleBackColor = true;
            this.buttonTimeCount.Click += new System.EventHandler(this.buttonTimeCount_Click);
            // 
            // labelTimerCount
            // 
            this.labelTimerCount.AutoSize = true;
            this.labelTimerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimerCount.Location = new System.Drawing.Point(253, 72);
            this.labelTimerCount.Name = "labelTimerCount";
            this.labelTimerCount.Size = new System.Drawing.Size(88, 22);
            this.labelTimerCount.TabIndex = 36;
            this.labelTimerCount.Text = "00:00:00";
            // 
            // buttonTimerCountStop
            // 
            this.buttonTimerCountStop.Location = new System.Drawing.Point(135, 69);
            this.buttonTimerCountStop.Name = "buttonTimerCountStop";
            this.buttonTimerCountStop.Size = new System.Drawing.Size(96, 30);
            this.buttonTimerCountStop.TabIndex = 37;
            this.buttonTimerCountStop.Text = "Стоп";
            this.buttonTimerCountStop.UseVisualStyleBackColor = true;
            this.buttonTimerCountStop.Click += new System.EventHandler(this.buttonTimerCountStop_Click);
            // 
            // radioButtonVIPTime
            // 
            this.radioButtonVIPTime.AutoSize = true;
            this.radioButtonVIPTime.Checked = true;
            this.radioButtonVIPTime.Location = new System.Drawing.Point(21, 24);
            this.radioButtonVIPTime.Name = "radioButtonVIPTime";
            this.radioButtonVIPTime.Size = new System.Drawing.Size(87, 17);
            this.radioButtonVIPTime.TabIndex = 38;
            this.radioButtonVIPTime.TabStop = true;
            this.radioButtonVIPTime.Text = "Время VIP";
            this.radioButtonVIPTime.UseVisualStyleBackColor = true;
            this.radioButtonVIPTime.CheckedChanged += new System.EventHandler(this.radioButtonVIPTime_CheckedChanged);
            // 
            // radioButtonLimitedTime
            // 
            this.radioButtonLimitedTime.AutoSize = true;
            this.radioButtonLimitedTime.Location = new System.Drawing.Point(21, 65);
            this.radioButtonLimitedTime.Name = "radioButtonLimitedTime";
            this.radioButtonLimitedTime.Size = new System.Drawing.Size(109, 17);
            this.radioButtonLimitedTime.TabIndex = 39;
            this.radioButtonLimitedTime.Text = "Задать Время";
            this.radioButtonLimitedTime.UseVisualStyleBackColor = true;
            this.radioButtonLimitedTime.CheckedChanged += new System.EventHandler(this.radioButtonLimitedTime_CheckedChanged);
            // 
            // groupBoxTime
            // 
            this.groupBoxTime.Controls.Add(this.radioButtonVIPTime);
            this.groupBoxTime.Controls.Add(this.radioButtonLimitedTime);
            this.groupBoxTime.Location = new System.Drawing.Point(376, 22);
            this.groupBoxTime.Name = "groupBoxTime";
            this.groupBoxTime.Size = new System.Drawing.Size(136, 100);
            this.groupBoxTime.TabIndex = 40;
            this.groupBoxTime.TabStop = false;
            this.groupBoxTime.Text = "Время";
            // 
            // groupBoxMenu
            // 
            this.groupBoxMenu.Controls.Add(this.comboBoxGoods);
            this.groupBoxMenu.Controls.Add(this.label2);
            this.groupBoxMenu.Controls.Add(this.textBoxAmountGoods);
            this.groupBoxMenu.Controls.Add(this.buttonSelect);
            this.groupBoxMenu.Controls.Add(this.labelTotalSumByWorker);
            this.groupBoxMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxMenu.Location = new System.Drawing.Point(604, 26);
            this.groupBoxMenu.Name = "groupBoxMenu";
            this.groupBoxMenu.Size = new System.Drawing.Size(278, 123);
            this.groupBoxMenu.TabIndex = 41;
            this.groupBoxMenu.TabStop = false;
            this.groupBoxMenu.Text = "Меню";
            // 
            // groupBoxRooms
            // 
            this.groupBoxRooms.Controls.Add(this.label1);
            this.groupBoxRooms.Controls.Add(this.comboBoxPriceTime);
            this.groupBoxRooms.Controls.Add(this.checkBoxReservation);
            this.groupBoxRooms.Location = new System.Drawing.Point(604, 195);
            this.groupBoxRooms.Name = "groupBoxRooms";
            this.groupBoxRooms.Size = new System.Drawing.Size(278, 122);
            this.groupBoxRooms.TabIndex = 42;
            this.groupBoxRooms.TabStop = false;
            this.groupBoxRooms.Text = "Кабинки";
            // 
            // UserContrElems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxRooms);
            this.Controls.Add(this.groupBoxMenu);
            this.Controls.Add(this.groupBoxTime);
            this.Controls.Add(this.buttonTimerCountStop);
            this.Controls.Add(this.labelTimerCount);
            this.Controls.Add(this.buttonTimeCount);
            this.Controls.Add(this.labelTimeName);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewTempOutcomes);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelTotalSum);
            this.Controls.Add(this.buttonTotalSum);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "UserContrElems";
            this.Size = new System.Drawing.Size(902, 465);
            this.Load += new System.EventHandler(this.UserContrElems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTempOutcomes)).EndInit();
            this.groupBoxTime.ResumeLayout(false);
            this.groupBoxTime.PerformLayout();
            this.groupBoxMenu.ResumeLayout(false);
            this.groupBoxMenu.PerformLayout();
            this.groupBoxRooms.ResumeLayout(false);
            this.groupBoxRooms.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxGoods;
        private System.Windows.Forms.TextBox textBoxAmountGoods;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonTotalSum;
        private System.Windows.Forms.Label labelTotalSum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxPriceTime;
        private System.Windows.Forms.DataGridView dataGridViewTempOutcomes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.CheckBox checkBoxReservation;
        private System.Windows.Forms.Label labelTotalSumByWorker;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.Label labelTimeName;
        private System.Windows.Forms.Button buttonTimeCount;
        private System.Windows.Forms.Label labelTimerCount;
        private System.Windows.Forms.Button buttonTimerCountStop;
        private System.Windows.Forms.RadioButton radioButtonVIPTime;
        private System.Windows.Forms.RadioButton radioButtonLimitedTime;
        private System.Windows.Forms.GroupBox groupBoxTime;
        private System.Windows.Forms.GroupBox groupBoxMenu;
        private System.Windows.Forms.GroupBox groupBoxRooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}
