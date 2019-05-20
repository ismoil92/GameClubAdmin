namespace GameClubAdmin
{ 
    partial class UpdatePriceTimeForm
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPriceTime = new System.Windows.Forms.TextBox();
            this.textBoxTypeTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(25, 106);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(78, 30);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(55, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Цена";
            // 
            // textBoxPriceTime
            // 
            this.textBoxPriceTime.Location = new System.Drawing.Point(116, 70);
            this.textBoxPriceTime.Name = "textBoxPriceTime";
            this.textBoxPriceTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxPriceTime.TabIndex = 2;
            this.textBoxPriceTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPriceTime_KeyPress);
            // 
            // textBoxTypeTime
            // 
            this.textBoxTypeTime.Location = new System.Drawing.Point(116, 22);
            this.textBoxTypeTime.Name = "textBoxTypeTime";
            this.textBoxTypeTime.Size = new System.Drawing.Size(100, 20);
            this.textBoxTypeTime.TabIndex = 1;
            this.textBoxTypeTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTypeTime_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Категория";
            // 
            // UpdatePriceTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 143);
            this.Controls.Add(this.textBoxTypeTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPriceTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UpdatePriceTimeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение цены игрового клуба";
            this.Load += new System.EventHandler(this.UpdatePriceTimeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPriceTime;
        private System.Windows.Forms.TextBox textBoxTypeTime;
        private System.Windows.Forms.Label label2;
    }
}