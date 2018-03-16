namespace FS.Base
{
   partial class MainForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.oSplit = new System.Windows.Forms.SplitContainer();
         this.oNavigator = new FS.Base.UI.Navigator();
         this.oTabs = new FS.Base.UI.Tabs();
         this.oToolNav = new System.Windows.Forms.ToolStrip();
         this.oToolNavShowHide = new System.Windows.Forms.ToolStripButton();
         this.oToolNavSep1 = new System.Windows.Forms.ToolStripSeparator();
         this.oToolNavRegister = new System.Windows.Forms.ToolStripSplitButton();
         this.oToolNavSep2 = new System.Windows.Forms.ToolStripSeparator();
         this.oToolFileNew = new System.Windows.Forms.ToolStripButton();
         this.oToolFileOpen = new System.Windows.Forms.ToolStripSplitButton();
         this.oToolFileOpenHistoryHeader = new System.Windows.Forms.ToolStripMenuItem();
         this.oToolFileOpenSep1 = new System.Windows.Forms.ToolStripSeparator();
         this.oToolFileOpenClearHistory = new System.Windows.Forms.ToolStripMenuItem();
         this.oToolFileSave = new System.Windows.Forms.ToolStripSplitButton();
         this.oToolFileSaveItem = new System.Windows.Forms.ToolStripMenuItem();
         this.oToolFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
         this.oToolEditor = new System.Windows.Forms.ToolStrip();
         this.oToolEditorShowHideQuery = new System.Windows.Forms.ToolStripButton();
         this.oToolEditorShowHideResults = new System.Windows.Forms.ToolStripButton();
         this.oToolEditorSep1 = new System.Windows.Forms.ToolStripSeparator();
         this.oToolEditorConnections = new System.Windows.Forms.ToolStripDropDownButton();
         this.oToolEditorConnectionsNone = new System.Windows.Forms.ToolStripMenuItem();
         this.oToolEditorSep2 = new System.Windows.Forms.ToolStripSeparator();
         this.oToolEditorStop = new System.Windows.Forms.ToolStripButton();
         this.oStatusStrip = new System.Windows.Forms.StatusStrip();
         this.stbLabelMsg = new System.Windows.Forms.ToolStripStatusLabel();
         this.stbLabelRunning = new System.Windows.Forms.ToolStripProgressBar();
         this.stbLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
         this.stbLabelRowCount = new System.Windows.Forms.ToolStripStatusLabel();
         this.stbLabelLine = new System.Windows.Forms.ToolStripStatusLabel();
         this.stbLabelColumn = new System.Windows.Forms.ToolStripStatusLabel();
         this.oContainer = new System.Windows.Forms.ToolStripContainer();
         this.oOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
         this.oSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
         this.oToolEditorExec = new System.Windows.Forms.ToolStripSplitButton();
         this.oToolEditorExecScript = new System.Windows.Forms.ToolStripMenuItem();
         this.oSplit.Panel1.SuspendLayout();
         this.oSplit.Panel2.SuspendLayout();
         this.oSplit.SuspendLayout();
         this.oToolNav.SuspendLayout();
         this.oToolEditor.SuspendLayout();
         this.oStatusStrip.SuspendLayout();
         this.oContainer.BottomToolStripPanel.SuspendLayout();
         this.oContainer.ContentPanel.SuspendLayout();
         this.oContainer.TopToolStripPanel.SuspendLayout();
         this.oContainer.SuspendLayout();
         this.SuspendLayout();
         // 
         // oSplit
         // 
         this.oSplit.BackColor = System.Drawing.SystemColors.ControlDark;
         this.oSplit.Dock = System.Windows.Forms.DockStyle.Fill;
         this.oSplit.Location = new System.Drawing.Point(0, 0);
         this.oSplit.Name = "oSplit";
         // 
         // oSplit.Panel1
         // 
         this.oSplit.Panel1.Controls.Add(this.oNavigator);
         this.oSplit.Panel1MinSize = 200;
         // 
         // oSplit.Panel2
         // 
         this.oSplit.Panel2.Controls.Add(this.oTabs);
         this.oSplit.Size = new System.Drawing.Size(865, 376);
         this.oSplit.SplitterDistance = 292;
         this.oSplit.TabIndex = 0;
         // 
         // oNavigator
         // 
         this.oNavigator.BackColor = System.Drawing.SystemColors.Control;
         this.oNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
         this.oNavigator.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.oNavigator.Location = new System.Drawing.Point(0, 0);
         this.oNavigator.Name = "oNavigator";
         this.oNavigator.Size = new System.Drawing.Size(292, 376);
         this.oNavigator.TabIndex = 0;
         this.oNavigator.DataConnect += new FS.Base.UI.Navigator.DataEventHandler(this.Navigator_DataConnect);
         this.oNavigator.DataUnconnect += new FS.Base.UI.Navigator.DataEventHandler(this.Navigator_DataUnconnect);
         this.oNavigator.DataProperties += new FS.Base.UI.Navigator.DataEventHandler(this.Navigator_DataProperties);
         this.oNavigator.DataExport += new FS.Base.UI.Navigator.DataPackageEventHandler(this.Navigator_DataExport);
         this.oNavigator.DataImport += new FS.Base.UI.Navigator.DataPackageEventHandler(this.Navigator_DataImport);
         this.oNavigator.DataEditor += new FS.Base.UI.Navigator.DataEventHandler(this.Navigator_DataEditor);
         this.oNavigator.DataRefresh += new FS.Base.UI.Navigator.DataEventHandler(this.Navigator_DataRefresh);
         this.oNavigator.DataRename += new FS.Base.UI.Navigator.DataEventHandler(this.Navigator_DataRename);
         this.oNavigator.DataRemove += new FS.Base.UI.Navigator.DataEventHandler(this.Navigator_DataRemove);
         // 
         // oTabs
         // 
         this.oTabs.Dock = System.Windows.Forms.DockStyle.Fill;
         this.oTabs.Location = new System.Drawing.Point(0, 0);
         this.oTabs.Name = "oTabs";
         this.oTabs.Size = new System.Drawing.Size(569, 376);
         this.oTabs.TabIndex = 0;
         this.oTabs.TabChanged += new FS.Base.UI.Tabs.TabChangedEventHandler(this.Tabs_TabChanged);
         // 
         // oToolNav
         // 
         this.oToolNav.Dock = System.Windows.Forms.DockStyle.None;
         this.oToolNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolNavShowHide,
            this.oToolNavSep1,
            this.oToolNavRegister,
            this.oToolNavSep2,
            this.oToolFileNew,
            this.oToolFileOpen,
            this.oToolFileSave});
         this.oToolNav.Location = new System.Drawing.Point(3, 0);
         this.oToolNav.Name = "oToolNav";
         this.oToolNav.Size = new System.Drawing.Size(215, 25);
         this.oToolNav.TabIndex = 1;
         // 
         // oToolNavShowHide
         // 
         this.oToolNavShowHide.CheckOnClick = true;
         this.oToolNavShowHide.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.oToolNavShowHide.Image = ((System.Drawing.Image)(resources.GetObject("oToolNavShowHide.Image")));
         this.oToolNavShowHide.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolNavShowHide.Name = "oToolNavShowHide";
         this.oToolNavShowHide.Size = new System.Drawing.Size(23, 22);
         this.oToolNavShowHide.ToolTipText = "[F4] Show/Hide Navigator";
         this.oToolNavShowHide.Click += new System.EventHandler(this.ToolNav_ShowHide);
         // 
         // oToolNavSep1
         // 
         this.oToolNavSep1.Name = "oToolNavSep1";
         this.oToolNavSep1.Size = new System.Drawing.Size(6, 25);
         // 
         // oToolNavRegister
         // 
         this.oToolNavRegister.Image = ((System.Drawing.Image)(resources.GetObject("oToolNavRegister.Image")));
         this.oToolNavRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolNavRegister.Name = "oToolNavRegister";
         this.oToolNavRegister.Size = new System.Drawing.Size(81, 22);
         this.oToolNavRegister.Text = "Register";
         this.oToolNavRegister.ButtonClick += new System.EventHandler(this.ToolNav_Register);
         // 
         // oToolNavSep2
         // 
         this.oToolNavSep2.Name = "oToolNavSep2";
         this.oToolNavSep2.Size = new System.Drawing.Size(6, 25);
         // 
         // oToolFileNew
         // 
         this.oToolFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.oToolFileNew.Image = ((System.Drawing.Image)(resources.GetObject("oToolFileNew.Image")));
         this.oToolFileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolFileNew.Name = "oToolFileNew";
         this.oToolFileNew.Size = new System.Drawing.Size(23, 22);
         this.oToolFileNew.ToolTipText = "[CTRL+N] New";
         this.oToolFileNew.Click += new System.EventHandler(this.ToolFile_New);
         // 
         // oToolFileOpen
         // 
         this.oToolFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.oToolFileOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolFileOpenHistoryHeader,
            this.oToolFileOpenSep1,
            this.oToolFileOpenClearHistory});
         this.oToolFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("oToolFileOpen.Image")));
         this.oToolFileOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolFileOpen.Name = "oToolFileOpen";
         this.oToolFileOpen.Size = new System.Drawing.Size(32, 22);
         this.oToolFileOpen.ToolTipText = "[CTRL+O] Open script file";
         this.oToolFileOpen.ButtonClick += new System.EventHandler(this.ToolFile_Open);
         // 
         // oToolFileOpenHistoryHeader
         // 
         this.oToolFileOpenHistoryHeader.Enabled = false;
         this.oToolFileOpenHistoryHeader.Name = "oToolFileOpenHistoryHeader";
         this.oToolFileOpenHistoryHeader.Size = new System.Drawing.Size(152, 22);
         this.oToolFileOpenHistoryHeader.Text = "History";
         // 
         // oToolFileOpenSep1
         // 
         this.oToolFileOpenSep1.Name = "oToolFileOpenSep1";
         this.oToolFileOpenSep1.Size = new System.Drawing.Size(149, 6);
         // 
         // oToolFileOpenClearHistory
         // 
         this.oToolFileOpenClearHistory.Name = "oToolFileOpenClearHistory";
         this.oToolFileOpenClearHistory.Size = new System.Drawing.Size(152, 22);
         this.oToolFileOpenClearHistory.Text = "Clear History";
         this.oToolFileOpenClearHistory.Click += new System.EventHandler(this.ToolFile_Open_ClearHistory);
         // 
         // oToolFileSave
         // 
         this.oToolFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.oToolFileSave.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolFileSaveItem,
            this.oToolFileSaveAs});
         this.oToolFileSave.Image = ((System.Drawing.Image)(resources.GetObject("oToolFileSave.Image")));
         this.oToolFileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolFileSave.Name = "oToolFileSave";
         this.oToolFileSave.Size = new System.Drawing.Size(32, 22);
         this.oToolFileSave.ToolTipText = "[CTRL+S] Save the script file";
         this.oToolFileSave.ButtonClick += new System.EventHandler(this.ToolFile_SaveItem);
         // 
         // oToolFileSaveItem
         // 
         this.oToolFileSaveItem.Name = "oToolFileSaveItem";
         this.oToolFileSaveItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this.oToolFileSaveItem.Size = new System.Drawing.Size(152, 22);
         this.oToolFileSaveItem.Text = "Save";
         this.oToolFileSaveItem.Click += new System.EventHandler(this.ToolFile_SaveItem);
         // 
         // oToolFileSaveAs
         // 
         this.oToolFileSaveAs.Name = "oToolFileSaveAs";
         this.oToolFileSaveAs.Size = new System.Drawing.Size(152, 22);
         this.oToolFileSaveAs.Text = "Save As...";
         this.oToolFileSaveAs.Click += new System.EventHandler(this.ToolFile_SaveAs);
         // 
         // oToolEditor
         // 
         this.oToolEditor.Dock = System.Windows.Forms.DockStyle.None;
         this.oToolEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolEditorShowHideQuery,
            this.oToolEditorShowHideResults,
            this.oToolEditorSep1,
            this.oToolEditorConnections,
            this.oToolEditorSep2,
            this.oToolEditorExec,
            this.oToolEditorStop});
         this.oToolEditor.Location = new System.Drawing.Point(219, 0);
         this.oToolEditor.Name = "oToolEditor";
         this.oToolEditor.Size = new System.Drawing.Size(306, 25);
         this.oToolEditor.TabIndex = 3;
         // 
         // oToolEditorShowHideQuery
         // 
         this.oToolEditorShowHideQuery.Checked = true;
         this.oToolEditorShowHideQuery.CheckOnClick = true;
         this.oToolEditorShowHideQuery.CheckState = System.Windows.Forms.CheckState.Checked;
         this.oToolEditorShowHideQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.oToolEditorShowHideQuery.Image = ((System.Drawing.Image)(resources.GetObject("oToolEditorShowHideQuery.Image")));
         this.oToolEditorShowHideQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolEditorShowHideQuery.Name = "oToolEditorShowHideQuery";
         this.oToolEditorShowHideQuery.Size = new System.Drawing.Size(23, 22);
         this.oToolEditorShowHideQuery.ToolTipText = "[CTRL+E] Show/Hide Editor";
         this.oToolEditorShowHideQuery.CheckedChanged += new System.EventHandler(this.ToolEditor_ShowHideQuery);
         // 
         // oToolEditorShowHideResults
         // 
         this.oToolEditorShowHideResults.CheckOnClick = true;
         this.oToolEditorShowHideResults.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.oToolEditorShowHideResults.Image = ((System.Drawing.Image)(resources.GetObject("oToolEditorShowHideResults.Image")));
         this.oToolEditorShowHideResults.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolEditorShowHideResults.Name = "oToolEditorShowHideResults";
         this.oToolEditorShowHideResults.Size = new System.Drawing.Size(23, 22);
         this.oToolEditorShowHideResults.ToolTipText = "[CTRL+R] Show/Hide Result Grid";
         this.oToolEditorShowHideResults.CheckedChanged += new System.EventHandler(this.ToolEditor_ShowHideResults);
         // 
         // oToolEditorSep1
         // 
         this.oToolEditorSep1.Name = "oToolEditorSep1";
         this.oToolEditorSep1.Size = new System.Drawing.Size(6, 25);
         // 
         // oToolEditorConnections
         // 
         this.oToolEditorConnections.AutoSize = false;
         this.oToolEditorConnections.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolEditorConnectionsNone});
         this.oToolEditorConnections.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolEditorConnections.Name = "oToolEditorConnections";
         this.oToolEditorConnections.Size = new System.Drawing.Size(150, 22);
         this.oToolEditorConnections.Text = "[Select Connection]";
         // 
         // oToolEditorConnectionsNone
         // 
         this.oToolEditorConnectionsNone.Name = "oToolEditorConnectionsNone";
         this.oToolEditorConnectionsNone.Size = new System.Drawing.Size(199, 22);
         this.oToolEditorConnectionsNone.Text = "[No Active Connection]";
         // 
         // oToolEditorSep2
         // 
         this.oToolEditorSep2.Name = "oToolEditorSep2";
         this.oToolEditorSep2.Size = new System.Drawing.Size(6, 25);
         // 
         // oToolEditorStop
         // 
         this.oToolEditorStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.oToolEditorStop.Image = ((System.Drawing.Image)(resources.GetObject("oToolEditorStop.Image")));
         this.oToolEditorStop.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolEditorStop.Name = "oToolEditorStop";
         this.oToolEditorStop.Size = new System.Drawing.Size(23, 22);
         this.oToolEditorStop.Text = "ToolStripButton2";
         this.oToolEditorStop.ToolTipText = "Stop the executing process";
         // 
         // oStatusStrip
         // 
         this.oStatusStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.oStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbLabelMsg,
            this.stbLabelRunning,
            this.stbLabelTime,
            this.stbLabelRowCount,
            this.stbLabelLine,
            this.stbLabelColumn});
         this.oStatusStrip.Location = new System.Drawing.Point(0, 0);
         this.oStatusStrip.Name = "oStatusStrip";
         this.oStatusStrip.Size = new System.Drawing.Size(865, 22);
         this.oStatusStrip.TabIndex = 6;
         // 
         // stbLabelMsg
         // 
         this.stbLabelMsg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.stbLabelMsg.Name = "stbLabelMsg";
         this.stbLabelMsg.Size = new System.Drawing.Size(810, 17);
         this.stbLabelMsg.Spring = true;
         this.stbLabelMsg.Text = "Msg";
         this.stbLabelMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // stbLabelRunning
         // 
         this.stbLabelRunning.Name = "stbLabelRunning";
         this.stbLabelRunning.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
         this.stbLabelRunning.Size = new System.Drawing.Size(70, 16);
         this.stbLabelRunning.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
         this.stbLabelRunning.Visible = false;
         // 
         // stbLabelTime
         // 
         this.stbLabelTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.stbLabelTime.ForeColor = System.Drawing.SystemColors.GrayText;
         this.stbLabelTime.Name = "stbLabelTime";
         this.stbLabelTime.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
         this.stbLabelTime.Size = new System.Drawing.Size(10, 17);
         // 
         // stbLabelRowCount
         // 
         this.stbLabelRowCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.stbLabelRowCount.ForeColor = System.Drawing.SystemColors.GrayText;
         this.stbLabelRowCount.Name = "stbLabelRowCount";
         this.stbLabelRowCount.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
         this.stbLabelRowCount.Size = new System.Drawing.Size(10, 17);
         // 
         // stbLabelLine
         // 
         this.stbLabelLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.stbLabelLine.ForeColor = System.Drawing.SystemColors.GrayText;
         this.stbLabelLine.Name = "stbLabelLine";
         this.stbLabelLine.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
         this.stbLabelLine.Size = new System.Drawing.Size(10, 17);
         // 
         // stbLabelColumn
         // 
         this.stbLabelColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.stbLabelColumn.ForeColor = System.Drawing.SystemColors.GrayText;
         this.stbLabelColumn.Name = "stbLabelColumn";
         this.stbLabelColumn.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
         this.stbLabelColumn.Size = new System.Drawing.Size(10, 17);
         // 
         // oContainer
         // 
         // 
         // oContainer.BottomToolStripPanel
         // 
         this.oContainer.BottomToolStripPanel.Controls.Add(this.oStatusStrip);
         // 
         // oContainer.ContentPanel
         // 
         this.oContainer.ContentPanel.Controls.Add(this.oSplit);
         this.oContainer.ContentPanel.Size = new System.Drawing.Size(865, 376);
         this.oContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.oContainer.LeftToolStripPanelVisible = false;
         this.oContainer.Location = new System.Drawing.Point(0, 0);
         this.oContainer.Name = "oContainer";
         this.oContainer.RightToolStripPanelVisible = false;
         this.oContainer.Size = new System.Drawing.Size(865, 423);
         this.oContainer.TabIndex = 7;
         this.oContainer.Text = "toolStripContainer1";
         // 
         // oContainer.TopToolStripPanel
         // 
         this.oContainer.TopToolStripPanel.Controls.Add(this.oToolNav);
         this.oContainer.TopToolStripPanel.Controls.Add(this.oToolEditor);
         // 
         // oOpenFileDialog
         // 
         this.oOpenFileDialog.Filter = "SQL Script Files|*.sql|All Files|*.*";
         this.oOpenFileDialog.Title = "Select the script file to open";
         // 
         // oSaveFileDialog
         // 
         this.oSaveFileDialog.Filter = "SQL Script Files|*.sql|All Files|*.*";
         this.oSaveFileDialog.Title = "Type the Script File Name";
         // 
         // oToolEditorExec
         // 
         this.oToolEditorExec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.oToolEditorExec.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oToolEditorExecScript});
         this.oToolEditorExec.Image = ((System.Drawing.Image)(resources.GetObject("oToolEditorExec.Image")));
         this.oToolEditorExec.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.oToolEditorExec.Name = "oToolEditorExec";
         this.oToolEditorExec.Size = new System.Drawing.Size(32, 22);
         this.oToolEditorExec.ToolTipText = "[F5] Execute";
         this.oToolEditorExec.ButtonClick += new System.EventHandler(this.ToolEditor_Exec);
         // 
         // oToolEditorExecScript
         // 
         this.oToolEditorExecScript.Name = "oToolEditorExecScript";
         this.oToolEditorExecScript.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
         this.oToolEditorExecScript.Size = new System.Drawing.Size(193, 22);
         this.oToolEditorExecScript.Text = "Execute Script";
         this.oToolEditorExecScript.Click += new System.EventHandler(this.ToolEditor_Exec);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(865, 423);
         this.Controls.Add(this.oContainer);
         this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.KeyPreview = true;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "FriendBase [alfa]";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
         this.oSplit.Panel1.ResumeLayout(false);
         this.oSplit.Panel2.ResumeLayout(false);
         this.oSplit.ResumeLayout(false);
         this.oToolNav.ResumeLayout(false);
         this.oToolNav.PerformLayout();
         this.oToolEditor.ResumeLayout(false);
         this.oToolEditor.PerformLayout();
         this.oStatusStrip.ResumeLayout(false);
         this.oStatusStrip.PerformLayout();
         this.oContainer.BottomToolStripPanel.ResumeLayout(false);
         this.oContainer.BottomToolStripPanel.PerformLayout();
         this.oContainer.ContentPanel.ResumeLayout(false);
         this.oContainer.TopToolStripPanel.ResumeLayout(false);
         this.oContainer.TopToolStripPanel.PerformLayout();
         this.oContainer.ResumeLayout(false);
         this.oContainer.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      internal System.Windows.Forms.ToolStrip oToolNav;
      internal System.Windows.Forms.ToolStripButton oToolNavShowHide;
      internal System.Windows.Forms.ToolStripSeparator oToolNavSep1;
      internal System.Windows.Forms.ToolStripSplitButton oToolNavRegister;
      internal System.Windows.Forms.ToolStripSeparator oToolNavSep2;
      internal System.Windows.Forms.ToolStripButton oToolFileNew;
      internal System.Windows.Forms.ToolStripSplitButton oToolFileSave;
      internal System.Windows.Forms.ToolStripMenuItem oToolFileSaveItem;
      internal System.Windows.Forms.ToolStripMenuItem oToolFileSaveAs;
      private System.Windows.Forms.SplitContainer oSplit;
      private FS.Base.UI.Tabs oTabs;
      private FS.Base.UI.Navigator oNavigator;
      internal System.Windows.Forms.ToolStrip oToolEditor;
      internal System.Windows.Forms.ToolStripButton oToolEditorShowHideQuery;
      internal System.Windows.Forms.ToolStripButton oToolEditorShowHideResults;
      internal System.Windows.Forms.ToolStripSeparator oToolEditorSep1;
      private System.Windows.Forms.ToolStripDropDownButton oToolEditorConnections;
      private System.Windows.Forms.ToolStripMenuItem oToolEditorConnectionsNone;
      internal System.Windows.Forms.ToolStripSeparator oToolEditorSep2;
      internal System.Windows.Forms.ToolStripButton oToolEditorStop;
      internal System.Windows.Forms.StatusStrip oStatusStrip;
      internal System.Windows.Forms.ToolStripStatusLabel stbLabelMsg;
      private System.Windows.Forms.ToolStripProgressBar stbLabelRunning;
      internal System.Windows.Forms.ToolStripStatusLabel stbLabelTime;
      internal System.Windows.Forms.ToolStripStatusLabel stbLabelRowCount;
      internal System.Windows.Forms.ToolStripStatusLabel stbLabelLine;
      internal System.Windows.Forms.ToolStripStatusLabel stbLabelColumn;
      private System.Windows.Forms.ToolStripContainer oContainer;
      internal System.Windows.Forms.ToolStripSplitButton oToolFileOpen;
      private System.Windows.Forms.ToolStripMenuItem oToolFileOpenHistoryHeader;
      private System.Windows.Forms.ToolStripSeparator oToolFileOpenSep1;
      private System.Windows.Forms.ToolStripMenuItem oToolFileOpenClearHistory;
      private System.Windows.Forms.OpenFileDialog oOpenFileDialog;
      private System.Windows.Forms.SaveFileDialog oSaveFileDialog;
      internal System.Windows.Forms.ToolStripSplitButton oToolEditorExec;
      private System.Windows.Forms.ToolStripMenuItem oToolEditorExecScript;
   }
}

