using System.Drawing;
using System.Windows.Forms;

namespace Proyecto_Calculadora
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtDisplay;
        private DataGridView dgvOperaciones;
        private TableLayoutPanel panelBotones;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.dgvOperaciones = new System.Windows.Forms.DataGridView();
            this.panelBotones = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.txtDisplay.Location = new System.Drawing.Point(12, 12);
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.ReadOnly = true;
            this.txtDisplay.Size = new System.Drawing.Size(336, 39);
            this.txtDisplay.TabIndex = 0;
            this.txtDisplay.Text = "0";
            this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvOperaciones
            // 
            this.dgvOperaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperaciones.Location = new System.Drawing.Point(12, 396);
            this.dgvOperaciones.Name = "dgvOperaciones";
            this.dgvOperaciones.Size = new System.Drawing.Size(324, 120);
            this.dgvOperaciones.TabIndex = 2;
            this.dgvOperaciones.Visible = false;
            // 
            // panelBotones
            // 
            this.panelBotones.ColumnCount = 4;
            this.panelBotones.ColumnStyles.Clear();
            this.panelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelBotones.Location = new System.Drawing.Point(12, 70);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.RowCount = 6;
            this.panelBotones.RowStyles.Clear();
            this.panelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.panelBotones.Size = new System.Drawing.Size(336, 320);
            this.panelBotones.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(360, 540);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.dgvOperaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora - Proyecto DS4";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

