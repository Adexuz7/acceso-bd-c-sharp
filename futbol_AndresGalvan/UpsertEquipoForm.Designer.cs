
namespace futbol_AndresGalvan
{
    partial class UpsertEquipoForm
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
            this.codEquipoLabel = new System.Windows.Forms.Label();
            this.nomEquipoLabel = new System.Windows.Forms.Label();
            this.codLigaLabel = new System.Windows.Forms.Label();
            this.localidadLabel = new System.Windows.Forms.Label();
            this.internacionalLabel = new System.Windows.Forms.Label();
            this.codEquipoTextBox = new System.Windows.Forms.TextBox();
            this.nomEquipoTextBox = new System.Windows.Forms.TextBox();
            this.codLigaTextBox = new System.Windows.Forms.TextBox();
            this.localidadTextBox = new System.Windows.Forms.TextBox();
            this.internacionalCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // codEquipoLabel
            // 
            this.codEquipoLabel.AutoSize = true;
            this.codEquipoLabel.Location = new System.Drawing.Point(12, 9);
            this.codEquipoLabel.Name = "codEquipoLabel";
            this.codEquipoLabel.Size = new System.Drawing.Size(43, 13);
            this.codEquipoLabel.TabIndex = 0;
            this.codEquipoLabel.Text = "Código:";
            // 
            // nomEquipoLabel
            // 
            this.nomEquipoLabel.AutoSize = true;
            this.nomEquipoLabel.Location = new System.Drawing.Point(12, 48);
            this.nomEquipoLabel.Name = "nomEquipoLabel";
            this.nomEquipoLabel.Size = new System.Drawing.Size(47, 13);
            this.nomEquipoLabel.TabIndex = 1;
            this.nomEquipoLabel.Text = "Nombre:";
            // 
            // codLigaLabel
            // 
            this.codLigaLabel.AutoSize = true;
            this.codLigaLabel.Location = new System.Drawing.Point(12, 87);
            this.codLigaLabel.Name = "codLigaLabel";
            this.codLigaLabel.Size = new System.Drawing.Size(30, 13);
            this.codLigaLabel.TabIndex = 2;
            this.codLigaLabel.Text = "Liga:";
            // 
            // localidadLabel
            // 
            this.localidadLabel.AutoSize = true;
            this.localidadLabel.Location = new System.Drawing.Point(12, 126);
            this.localidadLabel.Name = "localidadLabel";
            this.localidadLabel.Size = new System.Drawing.Size(56, 13);
            this.localidadLabel.TabIndex = 3;
            this.localidadLabel.Text = "Localidad:";
            // 
            // internacionalLabel
            // 
            this.internacionalLabel.AutoSize = true;
            this.internacionalLabel.Location = new System.Drawing.Point(12, 165);
            this.internacionalLabel.Name = "internacionalLabel";
            this.internacionalLabel.Size = new System.Drawing.Size(71, 13);
            this.internacionalLabel.TabIndex = 4;
            this.internacionalLabel.Text = "Internacional:";
            // 
            // codEquipoTextBox
            // 
            this.codEquipoTextBox.Location = new System.Drawing.Point(15, 25);
            this.codEquipoTextBox.Name = "codEquipoTextBox";
            this.codEquipoTextBox.Size = new System.Drawing.Size(317, 20);
            this.codEquipoTextBox.TabIndex = 5;
            // 
            // nomEquipoTextBox
            // 
            this.nomEquipoTextBox.Location = new System.Drawing.Point(15, 64);
            this.nomEquipoTextBox.Name = "nomEquipoTextBox";
            this.nomEquipoTextBox.Size = new System.Drawing.Size(317, 20);
            this.nomEquipoTextBox.TabIndex = 6;
            // 
            // codLigaTextBox
            // 
            this.codLigaTextBox.Location = new System.Drawing.Point(15, 103);
            this.codLigaTextBox.Name = "codLigaTextBox";
            this.codLigaTextBox.Size = new System.Drawing.Size(317, 20);
            this.codLigaTextBox.TabIndex = 7;
            // 
            // localidadTextBox
            // 
            this.localidadTextBox.Location = new System.Drawing.Point(15, 142);
            this.localidadTextBox.Name = "localidadTextBox";
            this.localidadTextBox.Size = new System.Drawing.Size(317, 20);
            this.localidadTextBox.TabIndex = 8;
            // 
            // internacionalCheckBox
            // 
            this.internacionalCheckBox.AutoSize = true;
            this.internacionalCheckBox.Location = new System.Drawing.Point(15, 181);
            this.internacionalCheckBox.Name = "internacionalCheckBox";
            this.internacionalCheckBox.Size = new System.Drawing.Size(87, 17);
            this.internacionalCheckBox.TabIndex = 9;
            this.internacionalCheckBox.Text = "Internacional";
            this.internacionalCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 204);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(317, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Guardar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // UpsertEquipoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 243);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.internacionalCheckBox);
            this.Controls.Add(this.localidadTextBox);
            this.Controls.Add(this.codLigaTextBox);
            this.Controls.Add(this.nomEquipoTextBox);
            this.Controls.Add(this.codEquipoTextBox);
            this.Controls.Add(this.internacionalLabel);
            this.Controls.Add(this.localidadLabel);
            this.Controls.Add(this.codLigaLabel);
            this.Controls.Add(this.nomEquipoLabel);
            this.Controls.Add(this.codEquipoLabel);
            this.Name = "UpsertEquipoForm";
            this.Text = "Equipo (Andrés Galván García)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label codEquipoLabel;
        private System.Windows.Forms.Label nomEquipoLabel;
        private System.Windows.Forms.Label codLigaLabel;
        private System.Windows.Forms.Label localidadLabel;
        private System.Windows.Forms.Label internacionalLabel;
        private System.Windows.Forms.TextBox codEquipoTextBox;
        private System.Windows.Forms.TextBox nomEquipoTextBox;
        private System.Windows.Forms.TextBox codLigaTextBox;
        private System.Windows.Forms.TextBox localidadTextBox;
        private System.Windows.Forms.CheckBox internacionalCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}