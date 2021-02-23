
namespace futbol_AndresGalvan
{
    partial class UpsertLigaForm
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
            this.codLigaLabel = new System.Windows.Forms.Label();
            this.nomLigaLabel = new System.Windows.Forms.Label();
            this.codLigaTextBox = new System.Windows.Forms.TextBox();
            this.nomLigaTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // codLigaLabel
            // 
            this.codLigaLabel.AutoSize = true;
            this.codLigaLabel.Location = new System.Drawing.Point(12, 9);
            this.codLigaLabel.Name = "codLigaLabel";
            this.codLigaLabel.Size = new System.Drawing.Size(43, 13);
            this.codLigaLabel.TabIndex = 0;
            this.codLigaLabel.Text = "Código:";
            // 
            // nomLigaLabel
            // 
            this.nomLigaLabel.AutoSize = true;
            this.nomLigaLabel.Location = new System.Drawing.Point(12, 48);
            this.nomLigaLabel.Name = "nomLigaLabel";
            this.nomLigaLabel.Size = new System.Drawing.Size(47, 13);
            this.nomLigaLabel.TabIndex = 1;
            this.nomLigaLabel.Text = "Nombre:";
            // 
            // codLigaTextBox
            // 
            this.codLigaTextBox.Location = new System.Drawing.Point(15, 25);
            this.codLigaTextBox.Name = "codLigaTextBox";
            this.codLigaTextBox.Size = new System.Drawing.Size(317, 20);
            this.codLigaTextBox.TabIndex = 2;
            // 
            // nomLigaTextBox
            // 
            this.nomLigaTextBox.Location = new System.Drawing.Point(15, 64);
            this.nomLigaTextBox.Name = "nomLigaTextBox";
            this.nomLigaTextBox.Size = new System.Drawing.Size(317, 20);
            this.nomLigaTextBox.TabIndex = 3;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 90);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(317, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Guardar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // UpsertLigaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 121);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nomLigaTextBox);
            this.Controls.Add(this.codLigaTextBox);
            this.Controls.Add(this.nomLigaLabel);
            this.Controls.Add(this.codLigaLabel);
            this.Name = "UpsertLigaForm";
            this.Text = "Liga (Andrés Galván García)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label codLigaLabel;
        private System.Windows.Forms.Label nomLigaLabel;
        private System.Windows.Forms.TextBox codLigaTextBox;
        private System.Windows.Forms.TextBox nomLigaTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}