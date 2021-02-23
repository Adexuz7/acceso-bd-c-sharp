
namespace futbol_AndresGalvan
{
    partial class UpsertFutbolistaForm
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
            this.codDNIoNIELabel = new System.Windows.Forms.Label();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nacionalidadLabel = new System.Windows.Forms.Label();
            this.codDNIoNIEtextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.nacionalidadTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // codDNIoNIELabel
            // 
            this.codDNIoNIELabel.AutoSize = true;
            this.codDNIoNIELabel.Location = new System.Drawing.Point(12, 9);
            this.codDNIoNIELabel.Name = "codDNIoNIELabel";
            this.codDNIoNIELabel.Size = new System.Drawing.Size(59, 13);
            this.codDNIoNIELabel.TabIndex = 0;
            this.codDNIoNIELabel.Text = "DNI o NIE:";
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(12, 48);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(47, 13);
            this.nombreLabel.TabIndex = 1;
            this.nombreLabel.Text = "Nombre:";
            // 
            // nacionalidadLabel
            // 
            this.nacionalidadLabel.AutoSize = true;
            this.nacionalidadLabel.Location = new System.Drawing.Point(12, 87);
            this.nacionalidadLabel.Name = "nacionalidadLabel";
            this.nacionalidadLabel.Size = new System.Drawing.Size(72, 13);
            this.nacionalidadLabel.TabIndex = 2;
            this.nacionalidadLabel.Text = "Nacionalidad:";
            // 
            // codDNIoNIEtextBox
            // 
            this.codDNIoNIEtextBox.Location = new System.Drawing.Point(15, 25);
            this.codDNIoNIEtextBox.Name = "codDNIoNIEtextBox";
            this.codDNIoNIEtextBox.Size = new System.Drawing.Size(317, 20);
            this.codDNIoNIEtextBox.TabIndex = 3;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(15, 64);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(317, 20);
            this.nombreTextBox.TabIndex = 4;
            // 
            // nacionalidadTextBox
            // 
            this.nacionalidadTextBox.Location = new System.Drawing.Point(15, 103);
            this.nacionalidadTextBox.Name = "nacionalidadTextBox";
            this.nacionalidadTextBox.Size = new System.Drawing.Size(317, 20);
            this.nacionalidadTextBox.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 129);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(317, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Guardar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // UpsertFutbolistaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 164);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nacionalidadTextBox);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.codDNIoNIEtextBox);
            this.Controls.Add(this.nacionalidadLabel);
            this.Controls.Add(this.nombreLabel);
            this.Controls.Add(this.codDNIoNIELabel);
            this.Name = "UpsertFutbolistaForm";
            this.Text = "Futbolista (Andrés Galván García)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label codDNIoNIELabel;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label nacionalidadLabel;
        private System.Windows.Forms.TextBox codDNIoNIEtextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.TextBox nacionalidadTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}