
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SP_ObtenerContratoFutbolista = new System.Windows.Forms.TabPage();
            this.codDNIoNIELabel = new System.Windows.Forms.Label();
            this.codDNIoNIETextBox = new System.Windows.Forms.TextBox();
            this.sPdataGridView = new System.Windows.Forms.DataGridView();
            this.executeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SP_ObtenerContratoFutbolista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sPdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(710, 312);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // RowCountLabel
            // 
            this.RowCountLabel.AutoSize = true;
            this.RowCountLabel.Location = new System.Drawing.Point(13, 354);
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
            this.SelectTableLabel.Location = new System.Drawing.Point(13, 15);
            this.SelectTableLabel.Name = "SelectTableLabel";
            this.SelectTableLabel.Size = new System.Drawing.Size(37, 13);
            this.SelectTableLabel.TabIndex = 2;
            this.SelectTableLabel.Text = "Tabla:";
            // 
            // selectTableComboBox
            // 
            this.selectTableComboBox.FormattingEnabled = true;
            this.selectTableComboBox.Location = new System.Drawing.Point(56, 12);
            this.selectTableComboBox.Name = "selectTableComboBox";
            this.selectTableComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectTableComboBox.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(460, 10);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Borrar";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(379, 10);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 5;
            this.modifyButton.Text = "Modificar";
            this.modifyButton.UseVisualStyleBackColor = true;
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(298, 10);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 6;
            this.insertButton.Text = "Insertar";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Andrés Galván García";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.SP_ObtenerContratoFutbolista);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.insertButton);
            this.tabPage1.Controls.Add(this.modifyButton);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.deleteButton);
            this.tabPage1.Controls.Add(this.RowCountLabel);
            this.tabPage1.Controls.Add(this.SelectTableLabel);
            this.tabPage1.Controls.Add(this.selectTableComboBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SP_ObtenerContratoFutbolista
            // 
            this.SP_ObtenerContratoFutbolista.Controls.Add(this.executeButton);
            this.SP_ObtenerContratoFutbolista.Controls.Add(this.sPdataGridView);
            this.SP_ObtenerContratoFutbolista.Controls.Add(this.codDNIoNIETextBox);
            this.SP_ObtenerContratoFutbolista.Controls.Add(this.codDNIoNIELabel);
            this.SP_ObtenerContratoFutbolista.Location = new System.Drawing.Point(4, 22);
            this.SP_ObtenerContratoFutbolista.Name = "SP_ObtenerContratoFutbolista";
            this.SP_ObtenerContratoFutbolista.Padding = new System.Windows.Forms.Padding(3);
            this.SP_ObtenerContratoFutbolista.Size = new System.Drawing.Size(768, 400);
            this.SP_ObtenerContratoFutbolista.TabIndex = 1;
            this.SP_ObtenerContratoFutbolista.Text = "SP_ObtenerContratoFutbolista";
            this.SP_ObtenerContratoFutbolista.UseVisualStyleBackColor = true;
            // 
            // codDNIoNIELabel
            // 
            this.codDNIoNIELabel.AutoSize = true;
            this.codDNIoNIELabel.Location = new System.Drawing.Point(6, 11);
            this.codDNIoNIELabel.Name = "codDNIoNIELabel";
            this.codDNIoNIELabel.Size = new System.Drawing.Size(59, 13);
            this.codDNIoNIELabel.TabIndex = 0;
            this.codDNIoNIELabel.Text = "DNI o NIE:";
            // 
            // codDNIoNIETextBox
            // 
            this.codDNIoNIETextBox.Location = new System.Drawing.Point(71, 8);
            this.codDNIoNIETextBox.Name = "codDNIoNIETextBox";
            this.codDNIoNIETextBox.Size = new System.Drawing.Size(100, 20);
            this.codDNIoNIETextBox.TabIndex = 1;
            // 
            // sPdataGridView
            // 
            this.sPdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sPdataGridView.Location = new System.Drawing.Point(6, 35);
            this.sPdataGridView.Name = "sPdataGridView";
            this.sPdataGridView.Size = new System.Drawing.Size(756, 332);
            this.sPdataGridView.TabIndex = 2;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(177, 6);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 23);
            this.executeButton.TabIndex = 3;
            this.executeButton.Text = "Ejecutar";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Acceso a SQL";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.SP_ObtenerContratoFutbolista.ResumeLayout(false);
            this.SP_ObtenerContratoFutbolista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sPdataGridView)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage SP_ObtenerContratoFutbolista;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.DataGridView sPdataGridView;
        private System.Windows.Forms.TextBox codDNIoNIETextBox;
        private System.Windows.Forms.Label codDNIoNIELabel;
    }
}

