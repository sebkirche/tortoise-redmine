namespace TortoiseIssueList
{
    partial class MyIssuesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyIssuesForm));
            this.listeDemandes = new System.Windows.Forms.ListView();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.gbxSearch = new System.Windows.Forms.GroupBox();
            this.panelExpert = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatut = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.btAbout = new System.Windows.Forms.ToolStripDropDownButton();
            this.btPointage = new System.Windows.Forms.Button();
            this.btOurvirRedmine = new System.Windows.Forms.Button();
            this.btDescription = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btCocher = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.gbxSearch.SuspendLayout();
            this.panelExpert.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listeDemandes
            // 
            this.listeDemandes.CheckBoxes = true;
            this.listeDemandes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listeDemandes.FullRowSelect = true;
            this.listeDemandes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listeDemandes.Location = new System.Drawing.Point(0, 0);
            this.listeDemandes.Name = "listeDemandes";
            this.listeDemandes.Size = new System.Drawing.Size(589, 407);
            this.listeDemandes.TabIndex = 0;
            this.listeDemandes.UseCompatibleStateImageBehavior = false;
            this.listeDemandes.View = System.Windows.Forms.View.Details;
            this.listeDemandes.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSearch.Location = new System.Drawing.Point(3, 16);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(417, 23);
            this.tbxSearch.TabIndex = 0;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // gbxSearch
            // 
            this.gbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSearch.Controls.Add(this.tbxSearch);
            this.gbxSearch.Controls.Add(this.panelExpert);
            this.gbxSearch.Location = new System.Drawing.Point(0, 2);
            this.gbxSearch.Name = "gbxSearch";
            this.gbxSearch.Size = new System.Drawing.Size(589, 46);
            this.gbxSearch.TabIndex = 3;
            this.gbxSearch.TabStop = false;
            this.gbxSearch.Text = "Recherche";
            // 
            // panelExpert
            // 
            this.panelExpert.Controls.Add(this.btNext);
            this.panelExpert.Controls.Add(this.btCocher);
            this.panelExpert.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelExpert.Location = new System.Drawing.Point(420, 16);
            this.panelExpert.Name = "panelExpert";
            this.panelExpert.Size = new System.Drawing.Size(166, 27);
            this.panelExpert.TabIndex = 0;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(150, 46);
            this.webBrowser1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listeDemandes);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Size = new System.Drawing.Size(589, 407);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatut,
            this.progressBar,
            this.btAbout});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 495);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatut
            // 
            this.labelStatut.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.labelStatut.Name = "labelStatut";
            this.labelStatut.Size = new System.Drawing.Size(41, 17);
            this.labelStatut.Text = "Statut";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.SteelBlue;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(300, 16);
            // 
            // btAbout
            // 
            this.btAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btAbout.Image = global::TortoiseIssueList.Properties.Resources.messagebox_info;
            this.btAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAbout.Name = "btAbout";
            this.btAbout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btAbout.ShowDropDownArrow = false;
            this.btAbout.Size = new System.Drawing.Size(20, 20);
            this.btAbout.Text = "A propos";
            this.btAbout.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // btPointage
            // 
            this.btPointage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPointage.Enabled = false;
            this.btPointage.Image = global::TortoiseIssueList.Properties.Resources.Redmine_web_pointage;
            this.btPointage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPointage.Location = new System.Drawing.Point(85, 467);
            this.btPointage.Name = "btPointage";
            this.btPointage.Size = new System.Drawing.Size(81, 25);
            this.btPointage.TabIndex = 9;
            this.btPointage.Text = "      &Pointage";
            this.btPointage.UseVisualStyleBackColor = true;
            this.btPointage.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btOurvirRedmine
            // 
            this.btOurvirRedmine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOurvirRedmine.Enabled = false;
            this.btOurvirRedmine.Image = global::TortoiseIssueList.Properties.Resources.Redmine_web;
            this.btOurvirRedmine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOurvirRedmine.Location = new System.Drawing.Point(0, 467);
            this.btOurvirRedmine.Name = "btOurvirRedmine";
            this.btOurvirRedmine.Size = new System.Drawing.Size(79, 25);
            this.btOurvirRedmine.TabIndex = 8;
            this.btOurvirRedmine.Text = "     &Redmine";
            this.btOurvirRedmine.UseVisualStyleBackColor = true;
            this.btOurvirRedmine.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btDescription
            // 
            this.btDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDescription.Image = global::TortoiseIssueList.Properties.Resources.text;
            this.btDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDescription.Location = new System.Drawing.Point(172, 467);
            this.btDescription.Name = "btDescription";
            this.btDescription.Size = new System.Drawing.Size(89, 25);
            this.btDescription.TabIndex = 2;
            this.btDescription.Text = "&Description";
            this.btDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDescription.UseVisualStyleBackColor = true;
            this.btDescription.Click += new System.EventHandler(this.button1_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Image = global::TortoiseIssueList.Properties.Resources.button_ok;
            this.btOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOk.Location = new System.Drawing.Point(428, 467);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(80, 25);
            this.btOk.TabIndex = 0;
            this.btOk.Text = "   &Valider";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.okButton_Click);
            // 
            // btNext
            // 
            this.btNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btNext.Image = global::TortoiseIssueList.Properties.Resources.next_nav1;
            this.btNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNext.Location = new System.Drawing.Point(5, 3);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 21);
            this.btNext.TabIndex = 1;
            this.btNext.Text = "   &Suivant";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btCocher
            // 
            this.btCocher.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btCocher.Image = global::TortoiseIssueList.Properties.Resources.ok_tbl;
            this.btCocher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCocher.Location = new System.Drawing.Point(86, 3);
            this.btCocher.Name = "btCocher";
            this.btCocher.Size = new System.Drawing.Size(75, 21);
            this.btCocher.TabIndex = 0;
            this.btCocher.Text = "  &Cocher";
            this.btCocher.UseVisualStyleBackColor = true;
            this.btCocher.Click += new System.EventHandler(this.btCocher_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Image = global::TortoiseIssueList.Properties.Resources.cancel;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(514, 467);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 25);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "     A&nnuler";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // MyIssuesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 517);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btPointage);
            this.Controls.Add(this.btOurvirRedmine);
            this.Controls.Add(this.btDescription);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gbxSearch);
            this.Controls.Add(this.btCancel);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "MyIssuesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Demandes Redmine";
            this.Shown += new System.EventHandler(this.MyIssuesForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyIssuesForm_FormClosing);
            this.Load += new System.EventHandler(this.MyIssuesForm_Load);
            this.gbxSearch.ResumeLayout(false);
            this.gbxSearch.PerformLayout();
            this.panelExpert.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ListView listeDemandes;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btDescription;
        private System.Windows.Forms.Button btCocher;
        private System.Windows.Forms.Panel panelExpert;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Button btOurvirRedmine;
        private System.Windows.Forms.Button btPointage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatut;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripDropDownButton btAbout;
    }
}