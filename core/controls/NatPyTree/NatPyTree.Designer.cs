
namespace NATPY.core.controls.NatPyTree
{
    partial class NatPyTree
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("natpy.py");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("core.py");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("main.py");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("core", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("django.py");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("python.py");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("flask.py");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("compiller.py");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("web", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Nat.py", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode9});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Узел7";
            treeNode1.Text = "natpy.py";
            treeNode2.Name = "Узел8";
            treeNode2.Text = "core.py";
            treeNode3.Name = "Узел9";
            treeNode3.Text = "main.py";
            treeNode4.Name = "Узел2";
            treeNode4.Text = "core";
            treeNode5.Name = "Узел10";
            treeNode5.Text = "django.py";
            treeNode6.Name = "Узел11";
            treeNode6.Text = "python.py";
            treeNode7.Name = "Узел12";
            treeNode7.Text = "flask.py";
            treeNode8.Name = "Узел13";
            treeNode8.Text = "compiller.py";
            treeNode9.Name = "Узел4";
            treeNode9.Text = "web";
            treeNode10.Name = "Узел0";
            treeNode10.Text = "Nat.py";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.treeView1.Size = new System.Drawing.Size(165, 371);
            this.treeView1.TabIndex = 0;
            // 
            // NatPyTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Name = "NatPyTree";
            this.Size = new System.Drawing.Size(165, 371);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}
