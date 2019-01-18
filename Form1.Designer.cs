namespace langToExcel {
    partial class Form1 {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.langPathText = new System.Windows.Forms.TextBox();
            this.loadLangBtn = new System.Windows.Forms.Button();
            this.langPreview = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.convertXlsBtn = new System.Windows.Forms.Button();
            this.formatHeader = new System.Windows.Forms.CheckBox();
            this.scaleColumns = new System.Windows.Forms.CheckBox();
            this.openWhenFinished = new System.Windows.Forms.CheckBox();
            this.treeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // langPathText
            // 
            resources.ApplyResources(this.langPathText, "langPathText");
            this.langPathText.Name = "langPathText";
            this.langPathText.ReadOnly = true;
            // 
            // loadLangBtn
            // 
            resources.ApplyResources(this.loadLangBtn, "loadLangBtn");
            this.loadLangBtn.Name = "loadLangBtn";
            this.loadLangBtn.UseVisualStyleBackColor = true;
            this.loadLangBtn.Click += new System.EventHandler(this.loadLangBtn_Click);
            // 
            // langPreview
            // 
            this.langPreview.FormattingEnabled = true;
            this.langPreview.Items.AddRange(new object[] {
            resources.GetString("langPreview.Items")});
            resources.ApplyResources(this.langPreview, "langPreview");
            this.langPreview.Name = "langPreview";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // convertXlsBtn
            // 
            resources.ApplyResources(this.convertXlsBtn, "convertXlsBtn");
            this.convertXlsBtn.Name = "convertXlsBtn";
            this.convertXlsBtn.UseVisualStyleBackColor = true;
            this.convertXlsBtn.Click += new System.EventHandler(this.convertXlsBtn_Click);
            // 
            // formatHeader
            // 
            resources.ApplyResources(this.formatHeader, "formatHeader");
            this.formatHeader.Checked = true;
            this.formatHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.formatHeader.Name = "formatHeader";
            this.formatHeader.UseVisualStyleBackColor = true;
            // 
            // scaleColumns
            // 
            resources.ApplyResources(this.scaleColumns, "scaleColumns");
            this.scaleColumns.Checked = true;
            this.scaleColumns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scaleColumns.Name = "scaleColumns";
            this.scaleColumns.UseVisualStyleBackColor = true;
            // 
            // openWhenFinished
            // 
            resources.ApplyResources(this.openWhenFinished, "openWhenFinished");
            this.openWhenFinished.Name = "openWhenFinished";
            this.openWhenFinished.UseVisualStyleBackColor = true;
            // 
            // treeView
            // 
            resources.ApplyResources(this.treeView, "treeView");
            this.treeView.Name = "treeView";
            this.treeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseDoubleClick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.openWhenFinished);
            this.Controls.Add(this.scaleColumns);
            this.Controls.Add(this.formatHeader);
            this.Controls.Add(this.convertXlsBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.langPreview);
            this.Controls.Add(this.loadLangBtn);
            this.Controls.Add(this.langPathText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox langPathText;
        private System.Windows.Forms.Button loadLangBtn;
        private System.Windows.Forms.ListBox langPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button convertXlsBtn;
        private System.Windows.Forms.CheckBox formatHeader;
        private System.Windows.Forms.CheckBox scaleColumns;
        private System.Windows.Forms.CheckBox openWhenFinished;
        private System.Windows.Forms.TreeView treeView;
    }
}

