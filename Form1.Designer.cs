namespace TDD
{
    partial class FormAvitoCat
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFindCat = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.pictureBoxPhone = new System.Windows.Forms.PictureBox();
            this.pictureBoxCat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCat)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFindCat
            // 
            this.buttonFindCat.Location = new System.Drawing.Point(317, 384);
            this.buttonFindCat.Name = "buttonFindCat";
            this.buttonFindCat.Size = new System.Drawing.Size(172, 23);
            this.buttonFindCat.TabIndex = 0;
            this.buttonFindCat.Text = "Искать котенка";
            this.buttonFindCat.UseVisualStyleBackColor = true;
            this.buttonFindCat.Click += new System.EventHandler(this.buttonFindCat_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(406, 46);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(354, 233);
            this.textBoxInfo.TabIndex = 1;
            // 
            // pictureBoxPhone
            // 
            this.pictureBoxPhone.Location = new System.Drawing.Point(406, 296);
            this.pictureBoxPhone.Name = "pictureBoxPhone";
            this.pictureBoxPhone.Size = new System.Drawing.Size(354, 55);
            this.pictureBoxPhone.TabIndex = 2;
            this.pictureBoxPhone.TabStop = false;
            // 
            // pictureBoxCat
            // 
            this.pictureBoxCat.Location = new System.Drawing.Point(26, 46);
            this.pictureBoxCat.Name = "pictureBoxCat";
            this.pictureBoxCat.Size = new System.Drawing.Size(342, 233);
            this.pictureBoxCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCat.TabIndex = 3;
            this.pictureBoxCat.TabStop = false;
            // 
            // FormAvitoCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxCat);
            this.Controls.Add(this.pictureBoxPhone);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.buttonFindCat);
            this.Name = "FormAvitoCat";
            this.Text = "AvitoCat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAvitoCat_FormClosing);
            this.Load += new System.EventHandler(this.FormAvitoCat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFindCat;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.PictureBox pictureBoxPhone;
        private System.Windows.Forms.PictureBox pictureBoxCat;
    }
}

