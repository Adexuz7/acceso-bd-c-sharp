
namespace futbol_AndresGalvan
{
    partial class EquiposLigaForm
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
            this.equiposLigaDataGridView = new System.Windows.Forms.DataGridView();
            this.codLigaTextBox = new System.Windows.Forms.TextBox();
            this.nomLigaTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.equiposLigaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // codLigaLabel
            // 
            this.codLigaLabel.AutoSize = true;
            this.codLigaLabel.Location = new System.Drawing.Point(9, 15);
            this.codLigaLabel.Name = "codLigaLabel";
            this.codLigaLabel.Size = new System.Drawing.Size(43, 13);
            this.codLigaLabel.TabIndex = 0;
            this.codLigaLabel.Text = "Código:";
            // 
            // nomLigaLabel
            // 
            this.nomLigaLabel.AutoSize = true;
            this.nomLigaLabel.Location = new System.Drawing.Point(164, 15);
            this.nomLigaLabel.Name = "nomLigaLabel";
            this.nomLigaLabel.Size = new System.Drawing.Size(47, 13);
            this.nomLigaLabel.TabIndex = 1;
            this.nomLigaLabel.Text = "Nombre:";
            // 
            // equiposLigaDataGridView
            // 
            this.equiposLigaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equiposLigaDataGridView.Location = new System.Drawing.Point(12, 38);
            this.equiposLigaDataGridView.Name = "equiposLigaDataGridView";
            this.equiposLigaDataGridView.Size = new System.Drawing.Size(776, 400);
            this.equiposLigaDataGridView.TabIndex = 2;
            // 
            // codLigaTextBox
            // 
            this.codLigaTextBox.Location = new System.Drawing.Point(58, 12);
            this.codLigaTextBox.Name = "codLigaTextBox";
            this.codLigaTextBox.ReadOnly = true;
            this.codLigaTextBox.Size = new System.Drawing.Size(100, 20);
            this.codLigaTextBox.TabIndex = 3;
            // 
            // nomLigaTextBox
            // 
            this.nomLigaTextBox.Location = new System.Drawing.Point(217, 12);
            this.nomLigaTextBox.Name = "nomLigaTextBox";
            this.nomLigaTextBox.ReadOnly = true;
            this.nomLigaTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomLigaTextBox.TabIndex = 4;
            // 
            // EquiposLigaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nomLigaTextBox);
            this.Controls.Add(this.codLigaTextBox);
            this.Controls.Add(this.equiposLigaDataGridView);
            this.Controls.Add(this.nomLigaLabel);
            this.Controls.Add(this.codLigaLabel);
            this.Name = "EquiposLigaForm";
            this.Text = "EquiposLiga (Andrés Galván García)";
            ((System.ComponentModel.ISupportInitialize)(this.equiposLigaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label codLigaLabel;
        private System.Windows.Forms.Label nomLigaLabel;
        private System.Windows.Forms.DataGridView equiposLigaDataGridView;
        private System.Windows.Forms.TextBox codLigaTextBox;
        private System.Windows.Forms.TextBox nomLigaTextBox;
    }
}