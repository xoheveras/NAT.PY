
namespace NATPY
{
    partial class NatPyEditor
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NatPyEditor));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.codeEditor = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linesBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(42)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.codeEditor, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(448, 401);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // codeEditor
            // 
            this.codeEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(42)))));
            this.codeEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.ForeColor = System.Drawing.Color.White;
            this.codeEditor.Location = new System.Drawing.Point(69, 3);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(378, 395);
            this.codeEditor.TabIndex = 1;
            this.codeEditor.Text = resources.GetString("codeEditor.Text");
            this.codeEditor.TextChanged += new System.EventHandler(this.EditorTextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linesBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 395);
            this.panel1.TabIndex = 2;
            // 
            // linesBox
            // 
            this.linesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(42)))));
            this.linesBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linesBox.ForeColor = System.Drawing.Color.White;
            this.linesBox.Location = new System.Drawing.Point(0, 0);
            this.linesBox.Name = "linesBox";
            this.linesBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linesBox.Size = new System.Drawing.Size(60, 395);
            this.linesBox.TabIndex = 0;
            this.linesBox.Text = "";
            this.linesBox.WordWrap = false;
            // 
            // NatPyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "NatPyEditor";
            this.Size = new System.Drawing.Size(448, 401);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox codeEditor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox linesBox;
    }
}
