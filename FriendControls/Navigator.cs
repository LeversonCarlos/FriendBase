using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FS.Base.UI
{
   public class Navigator: Control
   {

      #region Initialize 
         private System.Windows.Forms.Panel oFooterPanel;
         private System.Windows.Forms.TreeView oTreeView;
         private System.Windows.Forms.ImageList oImageList;
         private System.ComponentModel.IContainer components;
         private System.Windows.Forms.ContextMenuStrip mData;
         private System.Windows.Forms.ToolStripMenuItem mDataConnect;
         private System.Windows.Forms.ToolStripMenuItem mDataRefresh;
         private System.Windows.Forms.ToolStripMenuItem mDataUnconnect;
         private ToolStripSeparator mDataSep1;
         private ToolStripMenuItem mDataProperties;
      internal ContextMenuStrip mTable;
      internal ToolStripMenuItem mTableOpen;
      internal ToolStripMenuItem mTableDesign;
      internal ToolStripSeparator mTableSep1;
      internal ToolStripMenuItem mTableDetails;
      internal ToolStripSeparator mTableSep2;
      internal ToolStripMenuItem mTableScript;
      internal ToolStripSeparator mTableSep3;
      internal ToolStripMenuItem mTableRename;
      internal ToolStripMenuItem mTableRemove;
      internal ContextMenuStrip mView;
      internal ToolStripMenuItem mViewOpen;
      internal ToolStripSeparator mViewSep1;
      internal ToolStripMenuItem mViewScripts;
      internal ToolStripSeparator mViewSep2;
      internal ToolStripMenuItem mViewRename;
      internal ToolStripMenuItem mViewRemove;
      internal ContextMenuStrip mProc;
      internal ToolStripMenuItem mProcOpen;
      internal ToolStripSeparator mProcSep1;
      internal ToolStripMenuItem mProcScripts;
      internal ToolStripSeparator mProcSep2;
      internal ToolStripMenuItem mProcRename;
      internal ToolStripMenuItem mProcRemove;
      internal ContextMenuStrip mFunc;
      internal ToolStripMenuItem mFuncOpen;
      internal ToolStripSeparator mFuncSep1;
      internal ToolStripMenuItem mFuncScripts;
      internal ToolStripSeparator mFuncSep2;
      internal ToolStripMenuItem mFuncRename;
      internal ToolStripMenuItem mFuncRemove;
      internal ContextMenuStrip mScripts;
      internal ToolStripMenuItem mScriptSelect;
      internal ToolStripSeparator mScriptSep1;
      internal ToolStripMenuItem mScriptCreate;
      internal ToolStripMenuItem mScriptAlter;
      internal ToolStripMenuItem mScriptDrop;
      internal ToolStripSeparator mScriptSep2;
      internal ToolStripMenuItem mScriptInsert;
      internal ToolStripMenuItem mScriptUpdate;
      internal ToolStripMenuItem mScriptDelete;
      internal ContextMenuStrip mObjTypes;
      internal ToolStripMenuItem mObjTypesRefresh;
      internal ToolStripSeparator mObjTypesSep1;
      internal ToolStripMenuItem mObjTypesCreate;
      private ToolStripSeparator mDataSep2;
      private ToolStripMenuItem mDataRename;
      private ToolStripMenuItem mDataRemove;
      private ToolStripMenuItem mDataPackage;
      private ToolStripMenuItem mDataPackageExpAll;
      private ToolStripSeparator mDataPackageExpSep1;
      private ToolStripMenuItem mDataPackageExpCustom;
      private ToolStripMenuItem mDataPackageExpTitle;
      private ToolStripMenuItem mDataPackageImp;
      private ToolStripMenuItem mDataPackageImpSelectFile;
      private ToolStripMenuItem mDataPackageExpSaved;
      private ToolStripMenuItem mDataPackageExpSelectFile;
         private System.Windows.Forms.Panel oHeaderPanel;

         private void InitializeComponent()
         {
            this.components = new System.ComponentModel.Container();
            this.oHeaderPanel = new System.Windows.Forms.Panel();
            this.oFooterPanel = new System.Windows.Forms.Panel();
            this.oTreeView = new System.Windows.Forms.TreeView();
            this.oImageList = new System.Windows.Forms.ImageList(this.components);
            this.mData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mDataConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataUnconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mDataRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataPackageExpAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataPackageExpSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mDataPackageExpCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mDataRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mTableOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mTableDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.mTableSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mTableDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.mTableSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mTableScript = new System.Windows.Forms.ToolStripMenuItem();
            this.mScripts = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mScriptSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mScriptSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mScriptCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.mScriptAlter = new System.Windows.Forms.ToolStripMenuItem();
            this.mScriptDrop = new System.Windows.Forms.ToolStripMenuItem();
            this.mScriptSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mScriptInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mScriptUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.mScriptDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mProcScripts = new System.Windows.Forms.ToolStripMenuItem();
            this.mTableSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.mTableRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mTableRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mFuncScripts = new System.Windows.Forms.ToolStripMenuItem();
            this.mView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mViewOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mViewSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mViewScripts = new System.Windows.Forms.ToolStripMenuItem();
            this.mViewSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mViewRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mViewRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mProc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mProcOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mProcSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mProcSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mProcRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mProcRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mFunc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mFuncOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mFuncSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mFuncSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.mFuncRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mFuncRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mObjTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mObjTypesRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mObjTypesSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.mObjTypesCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataPackageImp = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataPackageImpSelectFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataPackageExpTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataPackageExpSaved = new System.Windows.Forms.ToolStripMenuItem();
            this.mDataPackageExpSelectFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mData.SuspendLayout();
            this.mTable.SuspendLayout();
            this.mScripts.SuspendLayout();
            this.mView.SuspendLayout();
            this.mProc.SuspendLayout();
            this.mFunc.SuspendLayout();
            this.mObjTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // oHeaderPanel
            // 
            this.oHeaderPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.oHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.oHeaderPanel.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.oHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.oHeaderPanel.Name = "oHeaderPanel";
            this.oHeaderPanel.Size = new System.Drawing.Size(250, 22);
            this.oHeaderPanel.TabIndex = 0;
            this.oHeaderPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.HeaderPanel_Paint);
            // 
            // oFooterPanel
            // 
            this.oFooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.oFooterPanel.Location = new System.Drawing.Point(0, 250);
            this.oFooterPanel.Name = "oFooterPanel";
            this.oFooterPanel.Size = new System.Drawing.Size(250, 150);
            this.oFooterPanel.TabIndex = 1;
            // 
            // oTreeView
            // 
            this.oTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oTreeView.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oTreeView.HideSelection = false;
            this.oTreeView.ImageIndex = 0;
            this.oTreeView.ImageList = this.oImageList;
            this.oTreeView.ItemHeight = 18;
            this.oTreeView.Location = new System.Drawing.Point(0, 22);
            this.oTreeView.Margin = new System.Windows.Forms.Padding(1);
            this.oTreeView.Name = "oTreeView";
            this.oTreeView.SelectedImageIndex = 0;
            this.oTreeView.ShowNodeToolTips = true;
            this.oTreeView.ShowRootLines = false;
            this.oTreeView.Size = new System.Drawing.Size(250, 228);
            this.oTreeView.TabIndex = 2;
            this.oTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNode_NodeMouseDoubleClick);
            this.oTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeView_AfterLabelEdit);
            this.oTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.oTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeNode_NodeMouseClick);
            // 
            // oImageList
            // 
            this.oImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.oImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.oImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mData
            // 
            this.mData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDataConnect,
            this.mDataRefresh,
            this.mDataUnconnect,
            this.mDataSep1,
            this.mDataRename,
            this.mDataProperties,
            this.mDataPackage,
            this.mDataSep2,
            this.mDataRemove});
            this.mData.Name = "mData";
            this.mData.Size = new System.Drawing.Size(153, 192);
            // 
            // mDataConnect
            // 
            this.mDataConnect.Name = "mDataConnect";
            this.mDataConnect.Size = new System.Drawing.Size(152, 22);
            this.mDataConnect.Text = "Connect";
            this.mDataConnect.Click += new System.EventHandler(this.mData_Connect);
            // 
            // mDataRefresh
            // 
            this.mDataRefresh.Name = "mDataRefresh";
            this.mDataRefresh.Size = new System.Drawing.Size(152, 22);
            this.mDataRefresh.Text = "Refresh";
            // 
            // mDataUnconnect
            // 
            this.mDataUnconnect.Name = "mDataUnconnect";
            this.mDataUnconnect.Size = new System.Drawing.Size(152, 22);
            this.mDataUnconnect.Text = "Unconnect";
            this.mDataUnconnect.Click += new System.EventHandler(this.mData_Unconnect);
            // 
            // mDataSep1
            // 
            this.mDataSep1.Name = "mDataSep1";
            this.mDataSep1.Size = new System.Drawing.Size(149, 6);
            // 
            // mDataRename
            // 
            this.mDataRename.Name = "mDataRename";
            this.mDataRename.Size = new System.Drawing.Size(152, 22);
            this.mDataRename.Text = "Rename";
            this.mDataRename.Click += new System.EventHandler(this.mData_Rename);
            // 
            // mDataProperties
            // 
            this.mDataProperties.Name = "mDataProperties";
            this.mDataProperties.Size = new System.Drawing.Size(152, 22);
            this.mDataProperties.Text = "Properties";
            this.mDataProperties.Click += new System.EventHandler(this.mData_Properties);
            // 
            // mDataPackage
            // 
            this.mDataPackage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDataPackageExpTitle,
            this.mDataPackageExpAll,
            this.mDataPackageExpCustom,
            this.mDataPackageExpSaved,
            this.mDataPackageExpSep1,
            this.mDataPackageImp,
            this.mDataPackageImpSelectFile});
            this.mDataPackage.Name = "mDataPackage";
            this.mDataPackage.Size = new System.Drawing.Size(152, 22);
            this.mDataPackage.Text = "Package";
            // 
            // mDataPackageExpAll
            // 
            this.mDataPackageExpAll.Name = "mDataPackageExpAll";
            this.mDataPackageExpAll.Size = new System.Drawing.Size(152, 22);
            this.mDataPackageExpAll.Text = "All";
            this.mDataPackageExpAll.Click += new System.EventHandler(this.mData_ExportAll);
            // 
            // mDataPackageExpSep1
            // 
            this.mDataPackageExpSep1.Name = "mDataPackageExpSep1";
            this.mDataPackageExpSep1.Size = new System.Drawing.Size(149, 6);
            // 
            // mDataPackageExpCustom
            // 
            this.mDataPackageExpCustom.Name = "mDataPackageExpCustom";
            this.mDataPackageExpCustom.Size = new System.Drawing.Size(152, 22);
            this.mDataPackageExpCustom.Text = "Custom";
            this.mDataPackageExpCustom.Click += new System.EventHandler(this.mData_ExportCustom);
            // 
            // mDataSep2
            // 
            this.mDataSep2.Name = "mDataSep2";
            this.mDataSep2.Size = new System.Drawing.Size(149, 6);
            // 
            // mDataRemove
            // 
            this.mDataRemove.Name = "mDataRemove";
            this.mDataRemove.Size = new System.Drawing.Size(152, 22);
            this.mDataRemove.Text = "Remove";
            this.mDataRemove.Click += new System.EventHandler(this.mData_Remove);
            // 
            // mTable
            // 
            this.mTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mTableOpen,
            this.mTableDesign,
            this.mTableSep1,
            this.mTableDetails,
            this.mTableSep2,
            this.mTableScript,
            this.mTableSep3,
            this.mTableRename,
            this.mTableRemove});
            this.mTable.Name = "mnuTable";
            this.mTable.Size = new System.Drawing.Size(118, 154);
            // 
            // mTableOpen
            // 
            this.mTableOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mTableOpen.Name = "mTableOpen";
            this.mTableOpen.Size = new System.Drawing.Size(117, 22);
            this.mTableOpen.Text = "Open";
            this.mTableOpen.Click += new System.EventHandler(this.mEditor_Open);
            // 
            // mTableDesign
            // 
            this.mTableDesign.Enabled = false;
            this.mTableDesign.Name = "mTableDesign";
            this.mTableDesign.Size = new System.Drawing.Size(117, 22);
            this.mTableDesign.Text = "Design";
            // 
            // mTableSep1
            // 
            this.mTableSep1.Name = "mTableSep1";
            this.mTableSep1.Size = new System.Drawing.Size(114, 6);
            // 
            // mTableDetails
            // 
            this.mTableDetails.Name = "mTableDetails";
            this.mTableDetails.Size = new System.Drawing.Size(117, 22);
            this.mTableDetails.Text = "Details";
            this.mTableDetails.Click += new System.EventHandler(this.mTable_Details);
            // 
            // mTableSep2
            // 
            this.mTableSep2.Name = "mTableSep2";
            this.mTableSep2.Size = new System.Drawing.Size(114, 6);
            // 
            // mTableScript
            // 
            this.mTableScript.DropDown = this.mScripts;
            this.mTableScript.Name = "mTableScript";
            this.mTableScript.Size = new System.Drawing.Size(117, 22);
            this.mTableScript.Text = "Script";
            // 
            // mScripts
            // 
            this.mScripts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mScriptSelect,
            this.mScriptSep1,
            this.mScriptCreate,
            this.mScriptAlter,
            this.mScriptDrop,
            this.mScriptSep2,
            this.mScriptInsert,
            this.mScriptUpdate,
            this.mScriptDelete});
            this.mScripts.Name = "mnuScripts";
            this.mScripts.OwnerItem = this.mViewScripts;
            this.mScripts.Size = new System.Drawing.Size(119, 170);
            // 
            // mScriptSelect
            // 
            this.mScriptSelect.Name = "mScriptSelect";
            this.mScriptSelect.Size = new System.Drawing.Size(118, 22);
            this.mScriptSelect.Text = "SELECT";
            // 
            // mScriptSep1
            // 
            this.mScriptSep1.Name = "mScriptSep1";
            this.mScriptSep1.Size = new System.Drawing.Size(115, 6);
            // 
            // mScriptCreate
            // 
            this.mScriptCreate.Name = "mScriptCreate";
            this.mScriptCreate.Size = new System.Drawing.Size(118, 22);
            this.mScriptCreate.Text = "CREATE";
            // 
            // mScriptAlter
            // 
            this.mScriptAlter.Name = "mScriptAlter";
            this.mScriptAlter.Size = new System.Drawing.Size(118, 22);
            this.mScriptAlter.Text = "ALTER";
            // 
            // mScriptDrop
            // 
            this.mScriptDrop.Name = "mScriptDrop";
            this.mScriptDrop.Size = new System.Drawing.Size(118, 22);
            this.mScriptDrop.Text = "DROP";
            // 
            // mScriptSep2
            // 
            this.mScriptSep2.Name = "mScriptSep2";
            this.mScriptSep2.Size = new System.Drawing.Size(115, 6);
            // 
            // mScriptInsert
            // 
            this.mScriptInsert.Name = "mScriptInsert";
            this.mScriptInsert.Size = new System.Drawing.Size(118, 22);
            this.mScriptInsert.Text = "INSERT";
            // 
            // mScriptUpdate
            // 
            this.mScriptUpdate.Name = "mScriptUpdate";
            this.mScriptUpdate.Size = new System.Drawing.Size(118, 22);
            this.mScriptUpdate.Text = "UPDATE";
            // 
            // mScriptDelete
            // 
            this.mScriptDelete.Name = "mScriptDelete";
            this.mScriptDelete.Size = new System.Drawing.Size(118, 22);
            this.mScriptDelete.Text = "DELETE";
            // 
            // mProcScripts
            // 
            this.mProcScripts.DropDown = this.mScripts;
            this.mProcScripts.Name = "mProcScripts";
            this.mProcScripts.Size = new System.Drawing.Size(117, 22);
            this.mProcScripts.Text = "Script";
            // 
            // mTableSep3
            // 
            this.mTableSep3.Name = "mTableSep3";
            this.mTableSep3.Size = new System.Drawing.Size(114, 6);
            // 
            // mTableRename
            // 
            this.mTableRename.Name = "mTableRename";
            this.mTableRename.Size = new System.Drawing.Size(117, 22);
            this.mTableRename.Text = "Rename";
            // 
            // mTableRemove
            // 
            this.mTableRemove.Name = "mTableRemove";
            this.mTableRemove.Size = new System.Drawing.Size(117, 22);
            this.mTableRemove.Text = "Remove";
            // 
            // mFuncScripts
            // 
            this.mFuncScripts.DropDown = this.mScripts;
            this.mFuncScripts.Name = "mFuncScripts";
            this.mFuncScripts.Size = new System.Drawing.Size(117, 22);
            this.mFuncScripts.Text = "Script";
            // 
            // mView
            // 
            this.mView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mViewOpen,
            this.mViewSep1,
            this.mViewScripts,
            this.mViewSep2,
            this.mViewRename,
            this.mViewRemove});
            this.mView.Name = "mnuView";
            this.mView.Size = new System.Drawing.Size(118, 104);
            // 
            // mViewOpen
            // 
            this.mViewOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mViewOpen.Name = "mViewOpen";
            this.mViewOpen.Size = new System.Drawing.Size(117, 22);
            this.mViewOpen.Text = "Open";
            this.mViewOpen.Click += new System.EventHandler(this.mEditor_Open);
            // 
            // mViewSep1
            // 
            this.mViewSep1.Name = "mViewSep1";
            this.mViewSep1.Size = new System.Drawing.Size(114, 6);
            // 
            // mViewScripts
            // 
            this.mViewScripts.DropDown = this.mScripts;
            this.mViewScripts.Name = "mViewScripts";
            this.mViewScripts.Size = new System.Drawing.Size(117, 22);
            this.mViewScripts.Text = "Script";
            // 
            // mViewSep2
            // 
            this.mViewSep2.Name = "mViewSep2";
            this.mViewSep2.Size = new System.Drawing.Size(114, 6);
            // 
            // mViewRename
            // 
            this.mViewRename.Name = "mViewRename";
            this.mViewRename.Size = new System.Drawing.Size(117, 22);
            this.mViewRename.Text = "Rename";
            // 
            // mViewRemove
            // 
            this.mViewRemove.Name = "mViewRemove";
            this.mViewRemove.Size = new System.Drawing.Size(117, 22);
            this.mViewRemove.Text = "Remove";
            // 
            // mProc
            // 
            this.mProc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mProcOpen,
            this.mProcSep1,
            this.mProcScripts,
            this.mProcSep2,
            this.mProcRename,
            this.mProcRemove});
            this.mProc.Name = "mnuProc";
            this.mProc.Size = new System.Drawing.Size(118, 104);
            // 
            // mProcOpen
            // 
            this.mProcOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mProcOpen.Name = "mProcOpen";
            this.mProcOpen.Size = new System.Drawing.Size(117, 22);
            this.mProcOpen.Text = "Open";
            this.mProcOpen.Click += new System.EventHandler(this.mEditor_Open);
            // 
            // mProcSep1
            // 
            this.mProcSep1.Name = "mProcSep1";
            this.mProcSep1.Size = new System.Drawing.Size(114, 6);
            // 
            // mProcSep2
            // 
            this.mProcSep2.Name = "mProcSep2";
            this.mProcSep2.Size = new System.Drawing.Size(114, 6);
            // 
            // mProcRename
            // 
            this.mProcRename.Name = "mProcRename";
            this.mProcRename.Size = new System.Drawing.Size(117, 22);
            this.mProcRename.Text = "Rename";
            // 
            // mProcRemove
            // 
            this.mProcRemove.Name = "mProcRemove";
            this.mProcRemove.Size = new System.Drawing.Size(117, 22);
            this.mProcRemove.Text = "Remove";
            // 
            // mFunc
            // 
            this.mFunc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mFuncOpen,
            this.mFuncSep1,
            this.mFuncScripts,
            this.mFuncSep2,
            this.mFuncRename,
            this.mFuncRemove});
            this.mFunc.Name = "ContextMenuStrip1";
            this.mFunc.Size = new System.Drawing.Size(118, 104);
            // 
            // mFuncOpen
            // 
            this.mFuncOpen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mFuncOpen.Name = "mFuncOpen";
            this.mFuncOpen.Size = new System.Drawing.Size(117, 22);
            this.mFuncOpen.Text = "Open";
            this.mFuncOpen.Click += new System.EventHandler(this.mEditor_Open);
            // 
            // mFuncSep1
            // 
            this.mFuncSep1.Name = "mFuncSep1";
            this.mFuncSep1.Size = new System.Drawing.Size(114, 6);
            // 
            // mFuncSep2
            // 
            this.mFuncSep2.Name = "mFuncSep2";
            this.mFuncSep2.Size = new System.Drawing.Size(114, 6);
            // 
            // mFuncRename
            // 
            this.mFuncRename.Name = "mFuncRename";
            this.mFuncRename.Size = new System.Drawing.Size(117, 22);
            this.mFuncRename.Text = "Rename";
            // 
            // mFuncRemove
            // 
            this.mFuncRemove.Name = "mFuncRemove";
            this.mFuncRemove.Size = new System.Drawing.Size(117, 22);
            this.mFuncRemove.Text = "Remove";
            // 
            // mObjTypes
            // 
            this.mObjTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mObjTypesRefresh,
            this.mObjTypesSep1,
            this.mObjTypesCreate});
            this.mObjTypes.Name = "mnuTables";
            this.mObjTypes.Size = new System.Drawing.Size(136, 54);
            // 
            // mObjTypesRefresh
            // 
            this.mObjTypesRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mObjTypesRefresh.Name = "mObjTypesRefresh";
            this.mObjTypesRefresh.Size = new System.Drawing.Size(135, 22);
            this.mObjTypesRefresh.Text = "Refresh";
            this.mObjTypesRefresh.Click += new System.EventHandler(this.mObjType_Refresh);
            // 
            // mObjTypesSep1
            // 
            this.mObjTypesSep1.Name = "mObjTypesSep1";
            this.mObjTypesSep1.Size = new System.Drawing.Size(132, 6);
            // 
            // mObjTypesCreate
            // 
            this.mObjTypesCreate.Name = "mObjTypesCreate";
            this.mObjTypesCreate.Size = new System.Drawing.Size(135, 22);
            this.mObjTypesCreate.Text = "Create New";
            // 
            // mDataPackageImp
            // 
            this.mDataPackageImp.Enabled = false;
            this.mDataPackageImp.Name = "mDataPackageImp";
            this.mDataPackageImp.Size = new System.Drawing.Size(152, 22);
            this.mDataPackageImp.Text = "Import";
            // 
            // mDataPackageImpSelectFile
            // 
            this.mDataPackageImpSelectFile.Name = "mDataPackageImpSelectFile";
            this.mDataPackageImpSelectFile.Size = new System.Drawing.Size(152, 22);
            this.mDataPackageImpSelectFile.Text = "Select File";
            this.mDataPackageImpSelectFile.Click += new System.EventHandler(this.mData_Import);
            // 
            // mDataPackageExpTitle
            // 
            this.mDataPackageExpTitle.Enabled = false;
            this.mDataPackageExpTitle.Name = "mDataPackageExpTitle";
            this.mDataPackageExpTitle.Size = new System.Drawing.Size(152, 22);
            this.mDataPackageExpTitle.Text = "Export";
            // 
            // mDataPackageExpSaved
            // 
            this.mDataPackageExpSaved.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mDataPackageExpSelectFile});
            this.mDataPackageExpSaved.Name = "mDataPackageExpSaved";
            this.mDataPackageExpSaved.Size = new System.Drawing.Size(152, 22);
            this.mDataPackageExpSaved.Text = "Saved Configs";
            // 
            // mDataPackageExpSelectFile
            // 
            this.mDataPackageExpSelectFile.Name = "mDataPackageExpSelectFile";
            this.mDataPackageExpSelectFile.Size = new System.Drawing.Size(152, 22);
            this.mDataPackageExpSelectFile.Text = "Select File";
            // 
            // Navigator
            // 
            this.Controls.Add(this.oTreeView);
            this.Controls.Add(this.oFooterPanel);
            this.Controls.Add(this.oHeaderPanel);
            this.Name = "Navigator";
            this.Size = new System.Drawing.Size(250, 400);
            this.mData.ResumeLayout(false);
            this.mTable.ResumeLayout(false);
            this.mScripts.ResumeLayout(false);
            this.mView.ResumeLayout(false);
            this.mProc.ResumeLayout(false);
            this.mFunc.ResumeLayout(false);
            this.mObjTypes.ResumeLayout(false);
            this.ResumeLayout(false);

         }

      #endregion

      #region METHODS 

      #region NEW
      public Navigator()
      {
         this.InitializeComponent();
         this.oFooterPanel.Height = Convert.ToInt32( Convert.ToDouble(this.Height) * 0.25);
       }
      #endregion

      #region InitializeIcons
      public void InitializeIcons()
      {
         this.oImageList.Images.Clear();
         this.oImageList.Images.Add("DatabaseOff", FS.Base.Icon.GetIcon("DatabaseOff"));
         this.oImageList.Images.Add("DatabaseOn", FS.Base.Icon.GetIcon("DatabaseOn"));
         this.oImageList.Images.Add("Editor", FS.Base.Icon.GetIcon("Editor"));
         this.oImageList.Images.Add("Tables", FS.Base.Icon.GetIcon("Tables"));
         this.oImageList.Images.Add("Table", FS.Base.Icon.GetIcon("Table"));
         this.oImageList.Images.Add("Views", FS.Base.Icon.GetIcon("Views"));
         this.oImageList.Images.Add("View", FS.Base.Icon.GetIcon("View"));
         this.oImageList.Images.Add("Procedures", FS.Base.Icon.GetIcon("Procedures"));
         this.oImageList.Images.Add("Procedure", FS.Base.Icon.GetIcon("Procedure"));
         this.oImageList.Images.Add("Functions", FS.Base.Icon.GetIcon("Functions"));
         this.oImageList.Images.Add("Function", FS.Base.Icon.GetIcon("Function"));
         this.oImageList.Images.Add("Directory", FS.Base.Icon.GetIcon("Directory"));
         this.oImageList.Images.Add("ColumnNull", FS.Base.Icon.GetIcon("ColumnNull"));
         this.oImageList.Images.Add("ColumnNotNull", FS.Base.Icon.GetIcon("ColumnNotNull"));
         this.oImageList.Images.Add("ColumnPrimary", FS.Base.Icon.GetIcon("ColumnPrimary"));
         this.oImageList.Images.Add("Index", FS.Base.Icon.GetIcon("Index"));
         this.oImageList.Images.Add("IndexFullText", FS.Base.Icon.GetIcon("IndexFullText"));
         this.oImageList.Images.Add("IndexUnique", FS.Base.Icon.GetIcon("IndexUnique"));

         this.mDataConnect.Image = FS.Base.Icon.GetIcon("Connect").ToBitmap();
         this.mDataUnconnect.Image = FS.Base.Icon.GetIcon("Unconnect").ToBitmap();
         this.mDataRefresh.Image = FS.Base.Icon.GetIcon("Refresh").ToBitmap();
         this.mObjTypesRefresh.Image = FS.Base.Icon.GetIcon("Refresh").ToBitmap();

         this.mTableOpen.Image = FS.Base.Icon.GetIcon("Table").ToBitmap();
         this.mTableDesign.Image = FS.Base.Icon.GetIcon("Design").ToBitmap();
         this.mTableRename.Image = FS.Base.Icon.GetIcon("Rename").ToBitmap();
         this.mTableRemove.Image = FS.Base.Icon.GetIcon("Remove").ToBitmap();
         this.mViewOpen.Image = FS.Base.Icon.GetIcon("Table").ToBitmap();
         this.mViewRename.Image = FS.Base.Icon.GetIcon("Rename").ToBitmap();
         this.mViewRemove.Image = FS.Base.Icon.GetIcon("Remove").ToBitmap();
         this.mProcOpen.Image = FS.Base.Icon.GetIcon("Table").ToBitmap();
         this.mProcRename.Image = FS.Base.Icon.GetIcon("Rename").ToBitmap();
         this.mProcRemove.Image = FS.Base.Icon.GetIcon("Remove").ToBitmap();
         this.mFuncOpen.Image = FS.Base.Icon.GetIcon("Table").ToBitmap();
         this.mFuncRename.Image = FS.Base.Icon.GetIcon("Rename").ToBitmap();
         this.mFuncRemove.Image = FS.Base.Icon.GetIcon("Remove").ToBitmap();
      }
      #endregion

      #region GetContextMenu
      private System.Windows.Forms.ContextMenuStrip GetContextMenu()
      {
         switch (this.SelectedNode.Type)
         {
            case FS.Base.UI.Controls.NodeTypeEnum.Engine:
               return null;

            case FS.Base.UI.Controls.NodeTypeEnum.Database:
               this.mDataConnect.Enabled = (!this.SelectedNode.OnOff);
               this.mDataRefresh.Enabled = (!this.mDataConnect.Enabled);
               this.mDataUnconnect.Enabled = (!this.mDataConnect.Enabled);
               this.mDataPackage.Enabled = (!this.mDataConnect.Enabled);
               return this.mData;

            case FS.Base.UI.Controls.NodeTypeEnum.Tables:
            case FS.Base.UI.Controls.NodeTypeEnum.Views:
            case FS.Base.UI.Controls.NodeTypeEnum.Procedures:
            case FS.Base.UI.Controls.NodeTypeEnum.Functions:
               return this.mObjTypes;

            case FS.Base.UI.Controls.NodeTypeEnum.Table:
               this.mScriptSelect.Visible = true;
               this.mScriptSep1.Visible = true;
               this.mScriptAlter.Enabled = false;
               this.mScriptSep2.Visible = true;
               this.mScriptInsert.Visible = true;
               this.mScriptUpdate.Visible = true;
               this.mScriptDelete.Visible = true;
               return this.mTable;

            case FS.Base.UI.Controls.NodeTypeEnum.View:
               this.mScriptSelect.Visible = false;
               this.mScriptSep1.Visible = false;
               this.mScriptAlter.Enabled = true;
               this.mScriptSep2.Visible = false;
               this.mScriptInsert.Visible = false;
               this.mScriptUpdate.Visible = false;
               this.mScriptDelete.Visible = false;
               return this.mView;

            case FS.Base.UI.Controls.NodeTypeEnum.Procedure:
               this.mScriptSelect.Visible = false;
               this.mScriptSep1.Visible = false;
               this.mScriptAlter.Enabled = true;
               this.mScriptSep2.Visible = false;
               this.mScriptInsert.Visible = false;
               this.mScriptUpdate.Visible = false;
               this.mScriptDelete.Visible = false;
               return this.mProc;

            case FS.Base.UI.Controls.NodeTypeEnum.Function:
               this.mScriptSelect.Visible = false;
               this.mScriptSep1.Visible = false;
               this.mScriptAlter.Enabled = true;
               this.mScriptSep2.Visible = false;
               this.mScriptInsert.Visible = false;
               this.mScriptUpdate.Visible = false;
               this.mScriptDelete.Visible = false;
               return this.mFunc;

            default:
               return null;
         }
      }
      #endregion

      #region AddNewNode
      public FS.Base.UI.Controls.TreeNode AddNewNode(Controls.NodeTypeEnum eType, TreeNode oParentNode)
      {
         string sDescription = string.Empty;
         switch (eType)
         {
            case UI.Controls.NodeTypeEnum.Editor:
               sDescription = "Editor";
               break;
            case UI.Controls.NodeTypeEnum.Tables:
               sDescription = "Tables";
               break;
            case UI.Controls.NodeTypeEnum.Views:
               sDescription = "Views";
               break;
            case UI.Controls.NodeTypeEnum.Procedures:
               sDescription = "Procedures";
               break;
            case UI.Controls.NodeTypeEnum.Functions:
               sDescription = "Functions";
               break;
            default:
               sDescription = string.Empty;
               break;
          }
         return this.AddNewNode(string.Empty, sDescription, eType, null, oParentNode);
       }
      public FS.Base.UI.Controls.TreeNode AddNewNode(string sName, string sDescription, Controls.NodeTypeEnum eType, object oConnector, TreeNode oParentNode)
      {
         FS.Base.UI.Controls.TreeNode oTreeNode = null;
         try
         {
            oTreeNode = new FS.Base.UI.Controls.TreeNode(sDescription);
            oTreeNode.Name = sName;
            oTreeNode.Type = eType;
            oTreeNode.OnOff = false;
            oTreeNode.Connector = oConnector;
            if (oParentNode == null)
            {
               this.oTreeView.Nodes.Add(oTreeNode);
             }
            else
            {
               oParentNode.Nodes.Add(oTreeNode);
             }
         }
         catch (Exception ex) {throw ex;}
         return oTreeNode;
      }
      #endregion

      #region GetRootFolder
      private string GetRootFolder()
      {
         return this.GetRootFolder(false);
       }
      private string GetRootFolder(bool IncludeSeparator)
      {
         string sSep = System.IO.Path.DirectorySeparatorChar.ToString();
         string sPath = System.Windows.Forms.Application.ExecutablePath; 
         sPath = System.IO.Path.GetDirectoryName(sPath);
         if (IncludeSeparator)
         {
            sPath += (sPath.EndsWith(sSep) ? string.Empty : sSep);
          }
         return sPath;
       }
      #endregion

      #endregion

      #region PROPERTIES

      #region Nodes
      public System.Windows.Forms.TreeNodeCollection Nodes
      {
         get
         {
            if (!this.DesignMode)
            {
               return this.oTreeView.Nodes;
             }
            return null;
          }
       }
      #endregion 

      #region SelectedNode
      public FS.Base.UI.Controls.TreeNode SelectedNode
      {
         get { return ((FS.Base.UI.Controls.TreeNode)this.oTreeView.SelectedNode); }
       }
      #endregion

      #region Icons
      public System.Windows.Forms.ImageList.ImageCollection Icons
      {
         get
         {
            if (!this.DesignMode)
            {
               return this.oImageList.Images;
            }
            return null;
         }
      }
      #endregion

      #endregion

      #region EVENTS

      #region HeaderPanel_Paint
      private void HeaderPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
      {
         e.Graphics.DrawString("Navigator", this.Font, System.Drawing.SystemBrushes.InactiveCaptionText, new System.Drawing.PointF(5, 5));
       }
      #endregion

      #region TreeView_AfterSelect
      private void TreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
      {
         oTreeView.SelectedNode = e.Node;
         this.oTreeView.LabelEdit = (this.SelectedNode.Type== FS.Base.UI.Controls.NodeTypeEnum.Database);
       }
      #endregion

      #region TreeNode_NodeMouseClick
      private void TreeNode_NodeMouseClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
      {
         oTreeView.SelectedNode = e.Node;
         if (e.Button == System.Windows.Forms.MouseButtons.Right)
         {
            System.Windows.Forms.ContextMenuStrip oContextMenu = this.GetContextMenu();
            if (oContextMenu != null)
            {
               System.Drawing.Point oPoint = new System.Drawing.Point(e.Node.Bounds.X + oTreeView.Left+5, e.Node.Bounds.Y + oTreeView.Top + 15);
               oContextMenu.Show(this, oPoint);
            }
          }
       }
      #endregion

      #region TreeNode_NodeMouseDoubleClick
      private void TreeNode_NodeMouseDoubleClick(object sender, System.Windows.Forms.TreeNodeMouseClickEventArgs e)
      {
         switch (this.SelectedNode.Type)
         {
            case FS.Base.UI.Controls.NodeTypeEnum.Database:
               if (!this.SelectedNode.OnOff)
               {
                  this.mData_Connect(sender, null);
               }
               break;

            case FS.Base.UI.Controls.NodeTypeEnum.Tables:
            case FS.Base.UI.Controls.NodeTypeEnum.Views:
            case FS.Base.UI.Controls.NodeTypeEnum.Procedures:
            case FS.Base.UI.Controls.NodeTypeEnum.Functions:
               this.mData_Refresh();
                  break;

            case FS.Base.UI.Controls.NodeTypeEnum.Editor:
            case FS.Base.UI.Controls.NodeTypeEnum.Table:
            case FS.Base.UI.Controls.NodeTypeEnum.View:
            case FS.Base.UI.Controls.NodeTypeEnum.Procedure:
            case FS.Base.UI.Controls.NodeTypeEnum.Function:
               this.mData_Editor();
               break;
          }
       }
      #endregion


      #region mData_Connect
      public event DataEventHandler DataConnect;
      private void mData_Connect(object sender, EventArgs e)
      {

         for (Int32 iMenu = (mDataPackageExpSaved.DropDownItems.Count-1); iMenu>0; iMenu--)
         {
            mDataPackageExpSaved.DropDownItems.RemoveAt(iMenu);
          } 

         if (this.DataConnect != null)
         {
            this.DataConnect(this.SelectedNode);

            string sSearch = this.SelectedNode.Text.Replace(":","").Replace(" ","").Replace("/","").Replace("*","").Replace("?","").Replace("<","").Replace(">","").Replace("|","");
            string[] oConfigs = System.IO.Directory.GetFiles(this.GetRootFolder(), "CFG.Package." + sSearch + ".*.xml", System.IO.SearchOption.AllDirectories);

            if (oConfigs.Length>0)
            {
               mDataPackageExpSaved.DropDownItems.Add(new ToolStripSeparator());
               foreach(string sConfig in oConfigs)
               {
                  string sText = System.IO.Path.GetFileNameWithoutExtension(sConfig);
                  sText = sText.Replace("CFG.Package." + sSearch + ".","");
                  ToolStripItem oMenu = mDataPackageExpSaved.DropDownItems.Add(sText);
                  oMenu.Tag = sConfig;
                  oMenu.Click += new EventHandler(this.mData_ExportSaved);
                }
             }

          }
       }
      #endregion

      #region mData_Unconnect
      public delegate void DataEventHandler(Controls.TreeNode oNode);
      public event DataEventHandler DataUnconnect;
      private void mData_Unconnect(object sender, EventArgs e)
      {
         if (this.DataUnconnect != null)
         {
            this.DataUnconnect(this.SelectedNode);
          }
       }
      #endregion

      #region mData_Properties
      public event DataEventHandler DataProperties;
      private void mData_Properties(object sender, EventArgs e)
      {
         if (this.DataProperties != null)
         {
            this.DataProperties(this.SelectedNode);
          }
       }
      #endregion

      #region mData_Export

      public delegate void DataPackageEventHandler(UI.Controls.TreeNode oTreeNode, string Wizard);
      public event DataPackageEventHandler DataExport;

      private void mData_ExportAll(object sender, EventArgs e)
      {
         if (this.DataExport != null)
         {
            this.DataExport(this.SelectedNode, "[ALL]");
          }
       }

      private void mData_ExportCustom(object sender, EventArgs e)
      {
         if (this.DataExport != null)
         {
            this.DataExport(this.SelectedNode, string.Empty);
          }
       }

      private void mData_ExportSaved(object sender, EventArgs e)
      {
         if (this.DataExport != null)
         {
            this.DataExport(this.SelectedNode, ((ToolStripItem)sender).Text);
          }
       }

      #endregion

      #region mData_Import
      public event DataPackageEventHandler DataImport;
      private void mData_Import(object sender, EventArgs e)
      {
         if (this.DataImport != null)
         {
            this.DataImport(this.SelectedNode, string.Empty);
          }
       }
      #endregion

      #region mData_Editor
      public event DataEventHandler DataEditor;
      private void mData_Editor()
      {
         if (this.DataEditor != null)
         {
            this.DataEditor(this.SelectedNode);
          }
      }
      #endregion

      #region mData_Refresh
      public event DataEventHandler DataRefresh;
      private void mData_Refresh()
      {
         if (this.DataRefresh != null)
         {
            this.DataRefresh(this.SelectedNode);
          }
       }
      #endregion

      #region mData_Rename
      public event DataEventHandler DataRename;
      private void mData_Rename(object sender, EventArgs e)
      {
         this.SelectedNode.BeginEdit();
       }
      private void TreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
      {
         if (!e.CancelEdit && !string.IsNullOrEmpty(e.Label))
         {
            if (this.DataRename != null)
            {
               this.SelectedNode.Text = e.Label;
               this.DataRename(this.SelectedNode);
             }
          }
       }
      #endregion

      #region mData_Remove
      public event DataEventHandler DataRemove;
      private void mData_Remove(object sender, EventArgs e)
      {
         if (this.SelectedNode.OnOff)
         {
            this.mData_Unconnect(null, null);
          }
         if (!this.SelectedNode.OnOff)
         {
            if (this.DataRemove != null)
            {
               this.DataRemove(this.SelectedNode);
             }
          }
       }
      #endregion

      #region mObjType_Refresh
      private void mObjType_Refresh(object sender, EventArgs e)
      {
         this.TreeNode_NodeMouseDoubleClick(sender, null);
       }
      #endregion

      #region
      private void mEditor_Open(object sender, EventArgs e)
      {
         this.mData_Editor();
       }
      #endregion

      #region mTable_Details
      private void mTable_Details(object sender, EventArgs e)
      {
         if (this.DataRefresh != null)
         {
            this.DataRefresh(this.SelectedNode);
          }
      }
      #endregion

      #endregion

   }
}
