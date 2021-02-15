
namespace futbol_AndresGalvan
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RowCountLabel = new System.Windows.Forms.Label();
            this.SelectTableLabel = new System.Windows.Forms.Label();
            this.selectTableComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.modifyButton = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 376);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RowCountLabel
            // 
            this.RowCountLabel.AutoSize = true;
            this.RowCountLabel.Location = new System.Drawing.Point(12, 420);
            this.RowCountLabel.Name = "RowCountLabel";
            this.RowCountLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RowCountLabel.Size = new System.Drawing.Size(76, 13);
            this.RowCountLabel.TabIndex = 1;
            this.RowCountLabel.Text = "Nº de registros";
            this.RowCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RowCountLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // SelectTableLabel
            // 
            this.SelectTableLabel.AutoSize = true;
            this.SelectTableLabel.Location = new System.Drawing.Point(9, 9);
            this.SelectTableLabel.Name = "SelectTableLabel";
            this.SelectTableLabel.Size = new System.Drawing.Size(37, 13);
            this.SelectTableLabel.TabIndex = 2;
            this.SelectTableLabel.Text = "Tabla:";
            // 
            // selectTableComboBox
            // 
            this.selectTableComboBox.FormattingEnabled = true;
            this.selectTableComboBox.Location = new System.Drawing.Point(52, 6);
            this.selectTableComboBox.Name = "selectTableComboBox";
            this.selectTableComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectTableComboBox.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(713, 415);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Borrar";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(632, 415);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 5;
            this.modifyButton.Text = "Modificar";
            this.modifyButton.UseVisualStyleBackColor = true;
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(551, 415);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 6;
            this.insertButton.Text = "Insertar";
            this.insertButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Andrés Galván García";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.selectTableComboBox);
            this.Controls.Add(this.SelectTableLabel);
            this.Controls.Add(this.RowCountLabel);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Acceso a SQL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label RowCountLabel;
        private System.Windows.Forms.Label SelectTableLabel;
        private System.Windows.Forms.ComboBox selectTableComboBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Label label1;
    }
}

