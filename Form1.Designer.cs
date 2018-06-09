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
            this.SuspendLayout();
            // 
            // buttonFindCat
            // 
            this.buttonFindCat.Location = new System.Drawing.Point(317, 384);
            this.buttonFindCat.Name = "buttonFindCat";
            this.buttonFindCat.Size = new System.Drawing.Size(172, 23);
            this.buttonFindCat.TabIndex = 0;
            this.buttonFindCat.Text = "Подобрать котенка";
            this.buttonFindCat.UseVisualStyleBackColor = true;
            this.buttonFindCat.Click += new System.EventHandler(this.buttonFindCat_Click);
            // 
            // FormAvitoCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonFindCat);
            this.Name = "FormAvitoCat";
            this.Text = "AvitoCat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAvitoCat_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFindCat;
    }
}

