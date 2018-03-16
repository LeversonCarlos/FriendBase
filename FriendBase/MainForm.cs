using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FS.Base
{
   public partial class MainForm : Form
   {

      #region NEW
      public MainForm()
      {
         InitializeComponent();
         this.InitializeControls();
      }
      #endregion

      #region PROPERTIES

      #region Connector
      private FS.Connector.Connector tmp_Connector;
      private FS.Connector.Connector Connector
      {
         get
         {
            if (tmp_Connector == null)
            {
               string sFileName = this.GetRootFolder(true);
               sFileName += "CFG.Connections.xml";
               tmp_Connector = new FS.Connector.Connector(sFileName);
               tmp_Connector.WizardTitle = this.Text;
            }
            return tmp_Connector;
         }
      }
      #endregion

      #region History
      private History oHistory = null;
      private History History
      {
         get
         {
            if (oHistory == null)
            {
               oHistory = new History();
               oHistory.NewItem += new History.NewItemEventHandler(History_NewItem);
             }
            return oHistory;
          }
       }
      #endregion

      #region DataCollection
      private System.Collections.SortedList tmp_DataCollection = null;
      private System.Collections.SortedList DataCollection
      {
         get
         {
            if (tmp_DataCollection == null)
            {
               tmp_DataCollection = new System.Collections.SortedList();
             }
            return tmp_DataCollection;
          }
       }
      #endregion

      #region Data
      private FS.Data.Common.Data Data(string Name)
      {
         return ((FS.Data.Common.Data)this.DataCollection[Name]);
       }
      #endregion

      #region CommonResult

      private struct CommonResult
      {
         public bool Cancel;
         public string ErrorMsg;
         public UI.Controls.TreeNode Node; 
         public FS.Data.Common.Data Data;
         public DataTable[] Tables;
         public UI.Editor Editor; 
         public DataSet DataSet;
         public Int64 StartTicks;
         public bool UseScriptExecution;
         public Int32 AffectedRows;
       }

      private object[] GetCommonResult(UI.Editor oEditor, DataSet oDataSet, Int64 iStartTicks, bool bUseScriptExecution, Int32 iAffectedRows)
      {
         return this.GetCommonResult(false, string.Empty, null, null, null, oEditor, oDataSet, iStartTicks, bUseScriptExecution, iAffectedRows);
       }

      private object[] GetCommonResult(UI.Controls.TreeNode oNode, DataTable[] oTables)
      {
         return this.GetCommonResult(false, string.Empty, oNode, null, oTables, null, null, Int64.MinValue, false, Int32.MinValue);
       }

      private object[] GetCommonResult(UI.Controls.TreeNode oNode, FS.Data.Common.Data oData)
      {
         return this.GetCommonResult(false, string.Empty, oNode, oData, null, null, null, Int64.MinValue, false, Int32.MinValue);
       }

      private object[] GetCommonResult(bool bCancel)
      {
         return this.GetCommonResult(bCancel, string.Empty);
       }

      private object[] GetCommonResult(bool bCancel, string sErrorMsg)
      {
         return this.GetCommonResult(bCancel, sErrorMsg, null, null, null, null, null, Int64.MinValue, false, Int32.MinValue);
       }

      private object[] GetCommonResult(bool bCancel, string sErrorMsg, UI.Controls.TreeNode oNode, FS.Data.Common.Data oData, DataTable[] oTables, UI.Editor oEditor, DataSet oDataSet, Int64 iStartTicks, bool bUseScriptExecution, Int32 iAffectedRows)
      {
         return new object[] { bCancel, sErrorMsg, oNode, oData, oTables, oEditor, oDataSet, iStartTicks, bUseScriptExecution, iAffectedRows };
       }

      private CommonResult GetCommonResult(object[] oResult)
      {
         CommonResult oRet = new CommonResult();
         oRet.Cancel = ((bool)oResult.GetValue(0));
         oRet.ErrorMsg = ((string)oResult.GetValue(1));
         oRet.Node = ((UI.Controls.TreeNode)oResult.GetValue(2));
         oRet.Data = ((FS.Data.Common.Data)oResult.GetValue(3));
         oRet.Tables = ((DataTable[])oResult.GetValue(4));
         oRet.Editor = ((UI.Editor)oResult.GetValue(5));
         oRet.DataSet = ((DataSet)oResult.GetValue(6));
         oRet.StartTicks = ((Int64)oResult.GetValue(7));
         oRet.UseScriptExecution = ((bool)oResult.GetValue(8));
         oRet.AffectedRows = ((Int32)oResult.GetValue(9));
         return oRet;
       }

      #endregion

      #endregion

      #region METHODS

      #region InitializeControls
      private void InitializeControls()
      {
         this.StartPosition = FormStartPosition.Manual;
         this.WindowState = FormWindowState.Normal;
         this.Location = new Point(30, 30);
         this.Width = (Screen.PrimaryScreen.WorkingArea.Width - 60);
         this.Height = (Screen.PrimaryScreen.WorkingArea.Height - 60);
         this.oSplit.SplitterDistance = ((int)(this.Width * 0.2));
         this.stbLabelMsg.Text=string.Empty;

         this.InitializeControls_Title();
         this.InitializeControls_Toolbar();
         this.InitializeControls_Engine();
         this.InitializeControls_Connections();
         this.InitializeControls_History();
      }
      #endregion

      #region InitializeControls_Title
      private void InitializeControls_Title()
      {
         string[] aVersion = Application.ProductVersion.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);

         this.Text = Application.ProductName;
         this.Text += " - ";
         this.Text += "v";
         this.Text += aVersion.GetValue(0).ToString();
         this.Text += ".";
         this.Text += aVersion.GetValue(1).ToString();
         this.Text += System.Convert.ToChar(96 + System.Convert.ToInt16(aVersion.GetValue(2))).ToString();

       }
      #endregion

      #region InitializeControls_Toolbar
      private void InitializeControls_Toolbar()
      {
         this.oToolNav.Top = 0;
         this.oToolNav.Left = 0;
         this.oToolFileSave.Enabled=false;
         this.oToolNavShowHide.Checked = true;
         this.oToolNavShowHide.Image = FS.Base.Icon.GetIcon("Navigator").ToBitmap();
         this.oToolNavRegister.Image = FS.Base.Icon.GetIcon("Connectors").ToBitmap();
         this.oToolFileNew.Image = FS.Base.Icon.GetIcon("FileNew").ToBitmap();
         this.oToolFileOpen.Image = FS.Base.Icon.GetIcon("FileOpen").ToBitmap();
         this.oToolFileSave.Image = FS.Base.Icon.GetIcon("FileSave").ToBitmap();

         this.oToolEditor.Top = 0;
         this.oToolEditor.Left = (this.oToolNav.Width + 15);
         this.oToolEditor.Visible = false;
         this.oToolEditorShowHideQuery.Image = FS.Base.Icon.GetIcon("Editor").ToBitmap();
         this.oToolEditorShowHideResults.Image = FS.Base.Icon.GetIcon("Table").ToBitmap();
         this.oToolEditorExec.Image = FS.Base.Icon.GetIcon("QuerieExec").ToBitmap();
         this.oToolEditorStop.Image = FS.Base.Icon.GetIcon("QuerieStop").ToBitmap();
      }
      #endregion

      #region InitializeControls_Engines
      private void InitializeControls_Engine()
      {
         this.oToolNavRegister.DropDownItems.Clear();
         this.oNavigator.Nodes.Clear();
         this.oNavigator.InitializeIcons();

         FS.Data.Common.Engine.Type[] aType = FS.Data.Common.Engine.Types.GetTypes();
         foreach (FS.Data.Common.Engine.Type oType in aType)
         {
            ToolStripMenuItem oMenuItem = new ToolStripMenuItem(oType.Description);
            oMenuItem.ToolTipText = oType.TypeName;
            oMenuItem.Click += new System.EventHandler(this.ToolNav_Register_Engine);

            FS.Base.UI.Controls.TreeNode oTreeNode = new FS.Base.UI.Controls.TreeNode(oType.Description);
            oTreeNode.ToolTipText = oType.TypeName;
            oTreeNode.Name = oType.TypeName;
            oTreeNode.Type = UI.Controls.NodeTypeEnum.Engine;

            if (oType.Icon != null)
            {
               this.oNavigator.Icons.Add(oType.TypeName, oType.Icon);
               oMenuItem.Image = oType.Icon.ToBitmap();
               oTreeNode.ImageKey = oType.TypeName;
               oTreeNode.SelectedImageKey = oType.TypeName;
             }

            this.oToolNavRegister.DropDownItems.Add(oMenuItem);
            this.oNavigator.Nodes.Add(oTreeNode);
            oTreeNode.NodeFont = new Font(oTreeNode.TreeView.Font.FontFamily, oTreeNode.TreeView.Font.Size, FontStyle.Bold);

         }

       }
      #endregion

      #region InitializeControls_Connections
      private void InitializeControls_Connections()
      {
         try
         {
            foreach (FS.Connector.cItem oItem in this.Connector.Items)
            {
               this.oNavigator.AddNewNode(oItem.Name, oItem.Name, UI.Controls.NodeTypeEnum.Database, oItem, this.oNavigator.Nodes[oItem.Type]);
               this.oNavigator.Nodes[oItem.Type].Expand();
             }
          }
          catch (Exception ex) {this.MessageError(ex.Message);}
       }
      #endregion

      #region InitializeControls_History
      private void InitializeControls_History()
      {
         try
         {
            if (this.History != null)
            {
               string[] aFiles = this.History.GetFiles();
               foreach(string sFile in aFiles)
               {
                  this.History_NewItem(sFile);
                }
             }
          }
         catch (Exception ex) {this.MessageError(ex.Message);}
       }
      #endregion

      #region MessageError
      private void MessageError(string sMessage)
      {
         MessageBox.Show(sMessage, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
      #endregion

      #region WaitStart
      private void WaitStart()
      {
         this.Cursor = Cursors.WaitCursor;
         this.stbLabelRunning.Visible=true;
       }
      #endregion

      #region WaitFinish
      private void WaitFinish()
      {
         this.Cursor = Cursors.Default;
         this.stbLabelRunning.Visible=false;
      }
      #endregion

      #region FileOpen
      private void FileOpen(string FileName)
      {
         string sText = string.Empty;
         System.IO.StreamReader oStreamReader = null;
         try
         {
            if (!string.IsNullOrEmpty(FileName) )
            {
               if (!System.IO.File.Exists(FileName))
               {
                  MessageBox.Show("File not found", this.Text,  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  return;
                }
               oStreamReader = new System.IO.StreamReader(FileName, Encoding.Default);
               sText = oStreamReader.ReadToEnd();

               if (!string.IsNullOrEmpty(sText))
               {

                  if (this.oTabs.SelectedEditor == null)
                  {
                     this.oTabs.AddNewPage(System.IO.Path.GetFileNameWithoutExtension(FileName), this.oToolEditorConnections.DropDownItems[0].Text, sText);
                   }
                  else
                  {
                     this.oTabs.SelectedEditor.QueryText = sText;
                   }
                  this.oTabs.SelectedEditor.FileName = FileName;
                  this.History.Add(FileName);

                }
             }
          }
         catch (Exception ex) {this.MessageError(ex.Message);}
         finally
         {
            if (oStreamReader != null)
            {
               oStreamReader.Dispose();
               oStreamReader = null;
             }
          }
       }
      #endregion

      #region FileSave
      private void FileSave(string FileName)
      {
         string sText = string.Empty;
         System.IO.StreamWriter oStreamWriter = null;
         try
         {
            if (!string.IsNullOrEmpty(FileName) && this.oTabs.SelectedEditor != null)
            {
               if (System.IO.File.Exists(FileName))
               {
                  System.IO.File.Delete(FileName);
                }

               sText = this.oTabs.SelectedEditor.QueryText;
               oStreamWriter = new System.IO.StreamWriter(FileName, false, Encoding.Default);
               oStreamWriter.Write(sText);
               oStreamWriter.Flush();
               oStreamWriter.Close();

               this.oTabs.SelectedEditor.FileName = FileName;
               this.History.Add(FileName);
             }
          }
         catch (Exception ex) {this.MessageError(ex.Message);}
         finally
         {
            if (oStreamWriter != null)
            {
               oStreamWriter.Dispose();
               oStreamWriter = null;
             }
          }
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

      #region EVENTS

      #region MainForm_KeyUp
      private void MainForm_KeyUp(object sender, KeyEventArgs e)
      {
         if(e.KeyCode == Keys.F4)
         {
            oToolNavShowHide.Checked = !oToolNavShowHide.Checked;
            this.ToolNav_ShowHide(null, null);
          }

         else if(e.KeyCode == Keys.F5 && e.Control == false)
         {
            this.ToolEditor_Exec(this.oToolEditorExec, null);
          }

         else if(e.KeyCode == Keys.Tab && e.Control)
         {
            if (e.Shift) {this.oTabs.SelectPreviousTab();}
            else {this.oTabs.SelectNextTab();}
          }

         else if(e.KeyCode == Keys.E && e.Control)
         {
            if (this.oTabs.SelectedEditor != null)
            {
               this.oToolEditorShowHideQuery.Checked = !this.oToolEditorShowHideQuery.Checked;
               this.ToolEditor_ShowHideQuery(null, null);
             }
          }

         else if(e.KeyCode == Keys.R && e.Control)
         {
            if (this.oTabs.SelectedEditor != null)
            {
               this.oToolEditorShowHideResults.Checked = !this.oToolEditorShowHideResults.Checked;
               this.ToolEditor_ShowHideResults(null, null);
             }
          }

         else if(e.KeyCode == Keys.N && e.Control)
         {
            this.ToolFile_New(null, null);
          }

         else if(e.KeyCode == Keys.O && e.Control)
         {
            this.ToolFile_Open(null, null);
          }

         else if(e.KeyCode == Keys.S && e.Control)
         {
            if (this.oTabs.SelectedEditor != null)
            {
               this.ToolFile_SaveItem(null, null);
             }
          }

       }
      #endregion

      #region MainForm_FormClosing
      private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
      {
         try
         {
            this.History.Save();
          }
         catch (Exception ex) { this.MessageError(ex.Message); }
       }
      #endregion

      #region ToolNav_ShowHide
      private void ToolNav_ShowHide(object sender, EventArgs e)
      {
         oSplit.Panel1Collapsed = (!oToolNavShowHide.Checked);
       }
      #endregion

      #region ToolNav_Register
      private void ToolNav_Register(object sender, EventArgs e)
      {
         FS.Connector.cItem oItem = null;
         try
         {
            oItem = this.Connector.New();
            if (oItem != null)
            {
               this.Connector.Items.Add(oItem);
               this.Connector.Save();

               this.oNavigator.AddNewNode(oItem.Name, oItem.Name, UI.Controls.NodeTypeEnum.Database, oItem, this.oNavigator.Nodes[oItem.Type]);
               this.oNavigator.Nodes[oItem.Type].Expand();

             }
          }
          catch (Exception ex) { this.MessageError(ex.Message); }
       }
      #endregion

      #region ToolNav_Register_Engine
      private void ToolNav_Register_Engine(object sender, EventArgs e)
      {
         FS.Connector.cItem oItem = null;
         try
         {
            oItem = this.Connector.New(((ToolStripMenuItem)sender).ToolTipText);
            if (oItem != null)
            {
               this.Connector.Items.Add(oItem);
               this.Connector.Save();

               this.oNavigator.AddNewNode(oItem.Name, oItem.Name, UI.Controls.NodeTypeEnum.Database, oItem, this.oNavigator.Nodes[oItem.Type]);
               this.oNavigator.Nodes[oItem.Type].Expand();

             }
          }
          catch (Exception ex) { this.MessageError(ex.Message); }
       }
      #endregion

      #region ToolFile_New
      private void ToolFile_New(object sender, EventArgs e)
      {
         oTabs.AddNewPage("New Query", this.oToolEditorConnections.Text, string.Empty);
       }
      #endregion

      #region ToolFile_Open
      private void ToolFile_Open(object sender, EventArgs e)
      {
         try
         {
            this.oOpenFileDialog.Title = "Select the script file to open";
            this.oOpenFileDialog.Filter = "SQL Script Files|*.sql|All Files|*.*";
            if (string.IsNullOrEmpty(this.oOpenFileDialog.InitialDirectory))
            {
               this.oOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             }
            if (this.oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
               this.oOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.oOpenFileDialog.FileName);
               this.FileOpen(this.oOpenFileDialog.FileName);
             }
          }
         catch (Exception ex) {this.MessageError(ex.Message);}
       }
      #endregion

      #region ToolFile_Open_History
      private void ToolFile_Open_History(object sender, EventArgs e)
      {
         this.FileOpen(((ToolStripMenuItem)sender).ToolTipText);
       }
      #endregion

      #region ToolFile_Open_ClearHistory
      private void ToolFile_Open_ClearHistory(object sender, EventArgs e)
      {
         if (MessageBox.Show("Clear History of Recent Opened Files", this.Text,  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
         {
            this.ToolFile_Open_ClearHistory();
            this.History.Clear();
          }
       }
      private void ToolFile_Open_ClearHistory()
      {
         try
         {
            System.Collections.ArrayList aMenus = new System.Collections.ArrayList();
            aMenus.Add(this.oToolFileOpenHistoryHeader.Name);
            aMenus.Add(this.oToolFileOpenSep1.Name);
            aMenus.Add(this.oToolFileOpenClearHistory.Name);
            for (Int32 iMenu = (this.oToolFileOpen.DropDownItems.Count-1); iMenu >=0; iMenu--)
            {
               if (!aMenus.Contains(this.oToolFileOpen.DropDownItems[iMenu].Name))
               {
                  this.oToolFileOpen.DropDownItems[iMenu].Click -= new System.EventHandler(this.ToolFile_Open_History);
                  this.oToolFileOpen.DropDownItems.RemoveAt(iMenu);
                }
             }
          }
         catch (Exception ex) {this.MessageError(ex.Message);}
       }
      #endregion

      #region ToolFile_SaveItem
      private void ToolFile_SaveItem(object sender, EventArgs e)
      {
         if (string.IsNullOrEmpty(this.oTabs.SelectedEditor.FileName))
         {
            this.ToolFile_SaveAs(sender, e);
          }
         else
         {
            this.FileSave(this.oTabs.SelectedEditor.FileName);
          }
       }
      #endregion

      #region ToolFile_SaveAs
      private void ToolFile_SaveAs(object sender, EventArgs e)
      {
         try
         {
            this.oSaveFileDialog.Title = "Type the Script File Name";
            this.oSaveFileDialog.Filter = "SQL Script Files|*.sql|All Files|*.*";
            if (string.IsNullOrEmpty(this.oSaveFileDialog.InitialDirectory))
            {
               this.oSaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             }
            this.oSaveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".sql";
            if (this.oSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
               this.oSaveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.oSaveFileDialog.FileName);
               this.FileSave(this.oSaveFileDialog.FileName);
             }
          }
         catch (Exception ex) {this.MessageError(ex.Message);}
       }
      #endregion


      #region Navigator_DataConnect

      private void Navigator_DataConnect(UI.Controls.TreeNode oNode)
      {
         BackgroundWorker oWorker = null;
         try
         {
            if (oNode.Connector != null)
            {
               this.WaitStart();
               oWorker = new BackgroundWorker();
               oWorker.DoWork += new DoWorkEventHandler(Navigator_DataConnect_DoWork);
               oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Navigator_DataConnect_RunWorkerCompleted);
               oWorker.RunWorkerAsync(oNode);
            }
         }
         catch (Exception ex) { this.MessageError(ex.Message); }
       }

      private void Navigator_DataConnect_DoWork(object sender, DoWorkEventArgs e)
      {
         UI.Controls.TreeNode oNode = null;
         FS.Data.Common.Data oData = null;
         string sErrMsg = string.Empty;

         try
         {
            oNode = ((UI.Controls.TreeNode)e.Argument);
            
            //GET DATA OBJECT
            oData = ((FS.Connector.cItem)oNode.Connector).GetData();
            if (!oData.TryConnection(ref sErrMsg))
            {
               e.Result = this.GetCommonResult(true, sErrMsg);
             }
            else
            {
               e.Result = this.GetCommonResult(oNode, oData);
             }
          }
         catch (Exception ex)
         {
            if (oData != null)
            {
               oData.Dispose();
               oData = null;
             }
            e.Result = this.GetCommonResult(true, ex.Message);
          }
       }

      private void Navigator_DataConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         CommonResult oResult = new CommonResult();
         UI.Controls.TreeNode oNode = null;
         FS.Data.Common.Data oData = null;

         try
         {
            oResult = this.GetCommonResult(((object[])e.Result));

            if ( oResult.Cancel == true )
            {
               throw new Exception( oResult.ErrorMsg );
             }

            else
            {
               // GET RESULTS VARIABLES
               oNode = oResult.Node;
               oData = oResult.Data;

               //REMOVE DATA IF ALREADY EXISTS
               this.Navigator_DataUnconnect(oNode);
               if (this.oToolEditorConnections.DropDownItems.ContainsKey("oToolEditorConnectionsNone"))
               {
                  this.oToolEditorConnections.DropDownItems.RemoveByKey("oToolEditorConnectionsNone");
                }
               ToolStripItem oMenu = this.oToolEditorConnections.DropDownItems.Add(oNode.Text, this.oNavigator.Icons[oNode.Parent.ImageKey]);
               oMenu.Name = "oToolEditorConnections" + oNode.Name;
               oMenu.Click += new System.EventHandler(this.ToolEditor_Connections);
               this.DataCollection.Add(oNode.Name, oData);

               //UPDATE NAVIGATOR
               oNode.Nodes.Clear();
               this.oNavigator.AddNewNode(UI.Controls.NodeTypeEnum.Editor, oNode);
               this.oNavigator.AddNewNode(UI.Controls.NodeTypeEnum.Tables, oNode);
               this.oNavigator.AddNewNode(UI.Controls.NodeTypeEnum.Views, oNode);
               this.oNavigator.AddNewNode(UI.Controls.NodeTypeEnum.Procedures, oNode);
               this.oNavigator.AddNewNode(UI.Controls.NodeTypeEnum.Functions, oNode);
               oNode.OnOff = true;
               oNode.Expand();
            }

          }
         catch (Exception ex) { this.MessageError(ex.Message); }
         finally
         {
            ((BackgroundWorker)sender).Dispose();
            sender=null;
            this.WaitFinish();
          }
       }

      #endregion

      #region Navigator_DataUnconnect
      private void Navigator_DataUnconnect(UI.Controls.TreeNode oNode)
      {
         try
         {
            if (this.DataCollection.Contains(oNode.Name))
            {
               this.Data(oNode.Name).Dispose();
               this.DataCollection.Remove(oNode.Name);

               ToolStripItem oMenu = this.oToolEditorConnections.DropDownItems["oToolEditorConnections" + oNode.Name];
               if (oMenu != null)
               {
                  oMenu.Click -= new System.EventHandler(this.ToolEditor_Connections);
                  this.oToolEditorConnections.DropDownItems.Remove(oMenu);
                }

               oNode.Nodes.Clear();
               oNode.OnOff = false;
               oNode.Collapse();
             }

            if (this.oToolEditorConnections.DropDownItems.Count==0)
            {
               this.oToolEditorConnections.DropDownItems.Add("[No Active Connection]").Name = "oToolEditorConnectionsNone";
             }

            if (this.oToolEditorConnections.Text == oNode.Text)
            {
               this.oToolEditorConnections.Text = "[Select Connection]";
               this.oToolEditorConnections.Image = null;
             }

          }
         catch (Exception ex) { this.MessageError(ex.Message); }
       }
      #endregion

      #region Navigator_DataProperties
      private void Navigator_DataProperties(UI.Controls.TreeNode oNode)
      {
         if (((FS.Connector.cItem)oNode.Connector).ShowEditForm() == DialogResult.OK)
         {
            this.Connector.Save();
            if (oNode.OnOff)
            {
               this.Data(oNode.Name).Dispose();
               this.DataCollection[oNode.Name] = ((FS.Connector.cItem)oNode.Connector).GetData();
             }
          }
       }
      #endregion

      #region Navigator_DataExport
      private void Navigator_DataExport(UI.Controls.TreeNode oNode, string Wizard)
      {
         FS.Package.Export oExport = null;

         try
         {

            //SELECT THE FILE NAME TO SAVE
            string sFilePath = string.Empty;
            this.oSaveFileDialog.Title = "Type the Package file name";
            this.oSaveFileDialog.Filter = "Friend Base Package Files|*.fbp|All Files|*.*";
            if (string.IsNullOrEmpty(this.oSaveFileDialog.InitialDirectory))
            {
               this.oSaveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             }
            this.oSaveFileDialog.FileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".fbp";
            if (this.oSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
               this.oSaveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.oSaveFileDialog.FileName);
               sFilePath = this.oSaveFileDialog.FileName;
             }
            else
            {
               return;
             }

            // INITIALIZE EXPORT
            this.WaitStart();
            oExport = new FS.Package.Export();
            oExport.Connector = oNode.GetParentNodeByType(UI.Controls.NodeTypeEnum.Database).Name;
            oExport.Data = this.Data(oExport.Connector);
            oExport.FilePath = sFilePath;

            bool bRet = false;
            switch (Wizard)
            {
               case "[ALL]":
                  bRet = oExport.Show(true);
                  break;
               case "":
                  bRet = oExport.Show();
                  break;
               default:
                  bRet = oExport.Show(Wizard);
                  break;
             }

            if (bRet)
            {
               MessageBox.Show("Export Packaged Successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
          }
         catch(Exception ex){this.MessageError(ex.Message);}
         finally
         {
            this.WaitFinish();
            oExport = null;
          }
       }
      #endregion

      #region Navigator_DataImport
      private void Navigator_DataImport(UI.Controls.TreeNode oNode, string Wizard)
      {
         FS.Package.Import oImport = null;

         try
         {
            string sFilePath = string.Empty;
            this.oOpenFileDialog.Title = "Select the Package file to open";
            this.oOpenFileDialog.Filter = "Friend Base Package Files|*.fbp|All Files|*.*";
            if (string.IsNullOrEmpty(this.oOpenFileDialog.InitialDirectory))
            {
               this.oOpenFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             }

            if (this.oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
               this.oOpenFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.oOpenFileDialog.FileName);
               sFilePath = this.oOpenFileDialog.FileName;
             }
            else
            {
               return;
             }

            // INITIALIZE EXPORT
            this.WaitStart();
            oImport = new FS.Package.Import();
            oImport.Connector = oNode.GetParentNodeByType(UI.Controls.NodeTypeEnum.Database).Name;
            oImport.Data = this.Data(oImport.Connector);
            oImport.FilePath = sFilePath;

            if (oImport.Execute())
            {
               MessageBox.Show("Package Imported Successfully", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
             }

          }
         catch (Exception ex) {this.MessageError(ex.Message);}
         finally
         {
            this.WaitFinish();
            oImport = null;
          }
       }
      #endregion

      #region Navigator_DataRename
      private void Navigator_DataRename(UI.Controls.TreeNode oNode)
      {
         if (oNode.Name != oNode.Text)
         {
            ((FS.Connector.cItem)oNode.Connector).Rename(oNode.Text);
            this.Connector.Save();
            if (oNode.OnOff)
            {
               this.DataCollection.Add(oNode.Text, this.DataCollection[oNode.Name]);
               //this.DataCollection.Remove(oNode.Name);
             }
            oNode.Name = oNode.Text;
          }
       }
      #endregion

      #region Navigator_DataRemove
      private void Navigator_DataRemove(UI.Controls.TreeNode oNode)
      {
         try
         {
            if (MessageBox.Show("Do you want to remove this connection", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
               this.Connector.Items.Remove(((FS.Connector.cItem)oNode.Connector));
               this.Connector.Save();
               this.oNavigator.Nodes.Remove(oNode);
            }
          }
         catch(Exception ex){this.MessageError(ex.Message);}
       }
      #endregion

      #region Navigator_DataEditor
      private void Navigator_DataEditor(UI.Controls.TreeNode oNode)
      {
         if (oNode.Type == FS.Base.UI.Controls.NodeTypeEnum.Editor)
         {
            this.oTabs.AddNewPage("New Query", oNode.GetParentNodeByType(UI.Controls.NodeTypeEnum.Database).Name);
          }

         else
         {
            DataTable oRows = null;
            string sColumnName = string.Empty;
            try
            {
               string sText = string.Empty;
               string sConnectionName = oNode.GetParentNodeByType(UI.Controls.NodeTypeEnum.Database).Name;
               switch (oNode.Type)
               {
                  case FS.Base.UI.Controls.NodeTypeEnum.Table:
                     sText = "SELECT * " + Environment.NewLine + "FROM " + oNode.Text + "";
                     break;
                  case FS.Base.UI.Controls.NodeTypeEnum.View:
                     oRows = this.Data(sConnectionName).Schema.GetView(oNode.Text);
                     break;
                  case FS.Base.UI.Controls.NodeTypeEnum.Procedure:
                     oRows = this.Data(sConnectionName).Schema.GetProcedure(oNode.Text);
                     break;
                  case FS.Base.UI.Controls.NodeTypeEnum.Function:
                     oRows = this.Data(sConnectionName).Schema.GetFunction(oNode.Text);
                     break;
                }

               if (oRows != null && oRows.Rows.Count != 0)
               {
                  sText = oRows.Rows[0]["ObjectDefinition"].ToString();
                }

               if (!string.IsNullOrEmpty(sText))
               {
                  this.oTabs.AddNewPage(oNode.Text, sConnectionName, sText);
                }

             }
            catch (Exception ex) { this.MessageError(ex.Message); }
            finally
            {
               if (oRows != null)
               {
                  oRows.Dispose();
                  oRows = null;
               }
             }
         }
       }
      #endregion

      #region Navigator_DataRefresh

      private void Navigator_DataRefresh(UI.Controls.TreeNode oNode)
      {
         BackgroundWorker oWorker = null;
         try
         {
            this.WaitStart();
            oWorker = new BackgroundWorker();
            oWorker.DoWork += new DoWorkEventHandler(Navigator_DataRefresh_DoWork);
            oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Navigator_DataRefresh_RunWorkerCompleted);
            oWorker.RunWorkerAsync(oNode);
         }
         catch (Exception ex) { this.MessageError(ex.Message); }
       }

      private void Navigator_DataRefresh_DoWork(object sender, DoWorkEventArgs e)
      {
         UI.Controls.TreeNode oNode = null;
         string sConnectionName = string.Empty;

         try
         {
            oNode = ((UI.Controls.TreeNode)e.Argument);
            sConnectionName = oNode.GetParentNodeByType(UI.Controls.NodeTypeEnum.Database).Name;
            e.Result = null;

            switch (oNode.Type)
            {
               case FS.Base.UI.Controls.NodeTypeEnum.Table:
                  DataTable oTable = this.Data(sConnectionName).Schema.GetTable(oNode.Text);
                  DataTable oColumns = this.Data(sConnectionName).Schema.GetColumns(oNode.Text, true);
                  DataTable oIndexes = this.Data(sConnectionName).Schema.GetIndexes(oNode.Text, true);
                  e.Result = this.GetCommonResult(oNode, new DataTable[] {oTable, oColumns, oIndexes});
                  break;

               case FS.Base.UI.Controls.NodeTypeEnum.Tables:
                  e.Result = this.GetCommonResult(oNode, new DataTable[] {this.Data(sConnectionName).Schema.GetTables(false)});
                  break;

               case FS.Base.UI.Controls.NodeTypeEnum.Views:
                  e.Result = this.GetCommonResult(oNode, new DataTable[] {this.Data(sConnectionName).Schema.GetViews(false)});
                  break;

               case FS.Base.UI.Controls.NodeTypeEnum.Procedures:
                  e.Result = this.GetCommonResult(oNode, new DataTable[] {this.Data(sConnectionName).Schema.GetProcedures(false)});
                  break;

               case FS.Base.UI.Controls.NodeTypeEnum.Functions:
                  e.Result = this.GetCommonResult(oNode, new DataTable[] {this.Data(sConnectionName).Schema.GetFunctions(false)});
                  break;
             }

            if (e.Result == null) {e.Result = this.GetCommonResult(true);}
          }
         catch (Exception ex) 
         { 
            e.Result = this.GetCommonResult(true, ex.Message);
          }
       }

      private void Navigator_DataRefresh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         CommonResult oResult = new CommonResult();
         UI.Controls.TreeNode oNode = null;

         try
         {
            oResult = this.GetCommonResult(((object[])e.Result));
            if (oResult.Cancel == true)
            {
               if (! string.IsNullOrEmpty( oResult.ErrorMsg ))
               {
                  throw new Exception( oResult.ErrorMsg );
                }
             }

            else
            {
               oNode = oResult.Node;

               switch (oNode.Type)
               {
                  case FS.Base.UI.Controls.NodeTypeEnum.Table:
                     this.Navigator_DataRefresh_RunWorkerCompleted_Table(oNode, ((DataTable)oResult.Tables.GetValue(0)), ((DataTable)oResult.Tables.GetValue(1)), ((DataTable)oResult.Tables.GetValue(2)));
                     break;

                  case FS.Base.UI.Controls.NodeTypeEnum.Tables:
                     this.Navigator_DataRefresh_RunWorkerCompleted_Common(oNode, UI.Controls.NodeTypeEnum.Table, ((DataTable)oResult.Tables.GetValue(0)));
                     break;

                  case FS.Base.UI.Controls.NodeTypeEnum.Views:
                     this.Navigator_DataRefresh_RunWorkerCompleted_Common(oNode, UI.Controls.NodeTypeEnum.View, ((DataTable)oResult.Tables.GetValue(0)));
                     break;

                  case FS.Base.UI.Controls.NodeTypeEnum.Procedures:
                     this.Navigator_DataRefresh_RunWorkerCompleted_Common(oNode, UI.Controls.NodeTypeEnum.Procedure, ((DataTable)oResult.Tables.GetValue(0)));
                     break;

                  case FS.Base.UI.Controls.NodeTypeEnum.Functions:
                     this.Navigator_DataRefresh_RunWorkerCompleted_Common(oNode, UI.Controls.NodeTypeEnum.Function, ((DataTable)oResult.Tables.GetValue(0)));
                     break;
               }

             }
          }
         catch (Exception ex) { this.MessageError(ex.Message); }
         finally
         {
            ((BackgroundWorker)sender).Dispose();
            sender=null;
            this.WaitFinish();
          }
       }

      private void Navigator_DataRefresh_RunWorkerCompleted_Common(UI.Controls.TreeNode oNode, UI.Controls.NodeTypeEnum eInnerType, DataTable oDataTable)
      {
         try
         {
            oNode.Nodes.Clear();
            if (oDataTable != null && oDataTable.Rows.Count != 0)
            {
               foreach (DataRow oROW in oDataTable.Rows)
               {
                  string sText = oROW["ObjectName"].ToString();
                  this.oNavigator.AddNewNode(string.Empty, sText, eInnerType, null, oNode);
                }
               oNode.Expand();
             }

          }
         catch(Exception ex){throw ex;}
       }

      private void Navigator_DataRefresh_RunWorkerCompleted_Table(UI.Controls.TreeNode oNode, DataTable oTable, DataTable oColumns, DataTable oIndexes)
      {
         FS.Base.UI.Controls.TreeNode oTreeNode = null;
         try
         {
            oNode.Nodes.Clear();

            // COLUMNS
            oTreeNode = this.oNavigator.AddNewNode(string.Empty, "Columns", FS.Base.UI.Controls.NodeTypeEnum.TableColumns, null, oNode);
            if (oColumns != null && oColumns.Rows.Count != 0)
            {
               foreach (DataRow oROW in oColumns.Rows)
               {
                  string sColumnName = oROW["ColumnName"].ToString();
                  string sType = oROW["TypeName"].ToString();
                  if (!oROW.IsNull("TypeSize") && !string.IsNullOrEmpty(oROW["TypeSize"].ToString()))
                  {
                     sType += "(" + oROW["TypeSize"].ToString() + ")";
                  }
                  FS.Base.UI.Controls.TreeNode oColumnNode = this.oNavigator.AddNewNode(sColumnName, sColumnName + " - " + sType, FS.Base.UI.Controls.NodeTypeEnum.TableColumn, null, oTreeNode);

                  oColumnNode.ImageKey = "ColumnNull";
                  if ( Convert.ToInt16(oROW["isPrimaryKey"]) == 1 ) { oColumnNode.ImageKey = "ColumnPrimary"; }
                  else if ( Convert.ToInt16(oROW["isNullable"]) != 1 ) { oColumnNode.ImageKey = "ColumnNotNull"; }
                  oColumnNode.SelectedImageKey = oColumnNode.ImageKey;
                }
             }

            // INDEXES
            oTreeNode = this.oNavigator.AddNewNode(string.Empty, "Indexes", FS.Base.UI.Controls.NodeTypeEnum.TableIndexes, null, oNode);
            if (oIndexes != null && oIndexes.Rows.Count != 0)
            {
               string sIndexName = string.Empty;
               FS.Base.UI.Controls.TreeNode oIndexNode = null;
               foreach (DataRow oROW in oIndexes.Rows)
               {
                  if (sIndexName != oROW["IndexName"].ToString() | string.IsNullOrEmpty(sIndexName))
                  {
                     sIndexName = oROW["IndexName"].ToString();
                     oIndexNode = this.oNavigator.AddNewNode(string.Empty, sIndexName, FS.Base.UI.Controls.NodeTypeEnum.TableIndex, null, oTreeNode);

                     oIndexNode.ImageKey = "Index";
                     if (oROW["IndexType"].ToString() == "UNIQUE KEY") { oIndexNode.ImageKey = "IndexUnique"; }
                     else if (oROW["IndexType"].ToString() == "FULTEXT KEY") { oIndexNode.ImageKey = "IndexFullText"; }
                     oIndexNode.SelectedImageKey = oIndexNode.ImageKey;

                     oIndexNode.ToolTipText = "|";
                  }

                  oIndexNode.ToolTipText += " " + oROW["ColumnName"].ToString() + " |";
                }
             }

            // TRIGGERS
            this.oNavigator.AddNewNode(string.Empty, "Triggers", FS.Base.UI.Controls.NodeTypeEnum.TableTriggers, null, oNode);

            //EXPAND
            oNode.Expand();
          }
         catch(Exception ex){throw ex;}
       }

      #endregion


      #region ToolEditor_ShowHideQuery
      private void ToolEditor_ShowHideQuery(object sender, EventArgs e)
      {
         if (this.oTabs.SelectedEditor != null)
         {
            this.oTabs.SelectedEditor.QueryVisible = this.oToolEditorShowHideQuery.Checked;
          }
      }
      #endregion

      #region ToolEditor_ShowHideResults
      private void ToolEditor_ShowHideResults(object sender, EventArgs e)
      {
         if (this.oTabs.SelectedEditor != null)
         {
            this.oTabs.SelectedEditor.ResultsVisible = this.oToolEditorShowHideResults.Checked;
          }
       }
      #endregion

      #region ToolEditor_Connections
      private void ToolEditor_Connections(object sender, EventArgs e)
      {
         if (this.oTabs.SelectedEditor != null)
         {
            ToolStripItem oMenu = ((ToolStripItem)sender);
            this.oToolEditorConnections.Text = oMenu.Text;
            this.oToolEditorConnections.Image = oMenu.Image;
            this.oTabs.SelectedEditor.ConnectionName = oMenu.Text;
          }
       }
      #endregion

      #region ToolEditor_Exec

      private void ToolEditor_Exec(object sender, EventArgs e)
      {
         BackgroundWorker oWorker = null;
         try
         {
            if (this.oTabs.SelectedEditor != null)
            {
               Int64 iStartTicks = DateTime.Now.Ticks;
               string sConnectionName = this.oTabs.SelectedEditor.ConnectionName;

               if (string.IsNullOrEmpty(sConnectionName) || sConnectionName == "[Select Connection]" || sConnectionName == "[No Active Connection]")
               {
                  MessageBox.Show("No Active Connection", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                  return;
                }

               bool bUseScriptExecution = false;
               if (((ToolStripItem)sender).Name == "oToolEditorExecScript") 
               {
                  bUseScriptExecution=true;
                }

               this.WaitStart();
               oWorker = new BackgroundWorker();
               oWorker.DoWork += new DoWorkEventHandler(ToolEditor_Exec_DoWork);
               oWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ToolEditor_Exec_RunWorkerCompleted);
               oWorker.RunWorkerAsync( new object[] {this.oTabs.SelectedEditor, 
                                                     sConnectionName, 
                                                     this.oTabs.SelectedEditor.QueryTextSelected, 
                                                     iStartTicks, bUseScriptExecution});
             }
         }
         catch (Exception ex) { this.MessageError(ex.Message); }
       }

      private void ToolEditor_Exec_DoWork(object sender, DoWorkEventArgs e)
      {
         FS.Base.UI.Editor oEditor = null;
         string sConnectionName = string.Empty;
         string sQueryTextSelected = string.Empty;
         System.Data.Common.DbCommand oCommand = null;

         try
         {
            object[] aArguments = ((object[])e.Argument);
            oEditor = ((UI.Editor)aArguments.GetValue(0));
            sConnectionName = ((string)aArguments.GetValue(1));
            sQueryTextSelected = ((string)aArguments.GetValue(2));
            Int64 iStartTicks = ((Int64)aArguments.GetValue(3));
            bool bUseScriptExecution = ((bool)aArguments.GetValue(4));

            if (!string.IsNullOrEmpty(sConnectionName) && sConnectionName != "[Select Connection]")
            {

               if (bUseScriptExecution == true)
               {
                  Int32 iAffectedRows = 0;
                  bool bExecuteScript = this.Data(sConnectionName).ExecuteScript(sQueryTextSelected, ref iAffectedRows);
                  e.Result = this.GetCommonResult(oEditor, null, iStartTicks, bUseScriptExecution, iAffectedRows);
               }

               else
               {
                  DataSet oDataset = null;
                  oCommand = this.Data(sConnectionName).GetCommand();
                  oCommand.CommandText = sQueryTextSelected;
                  oDataset = this.Data(sConnectionName).GetDataSet(oCommand);
                  e.Result = this.GetCommonResult(oEditor, oDataset, iStartTicks, false, 0);
                }

             }

          }
         catch (Exception ex)
         {
            e.Result = this.GetCommonResult(true, ex.Message);
          }
         finally
         {
            if (oCommand != null)
            {
               oCommand.Dispose();
               oCommand = null;
             }
          }
       }

      private void ToolEditor_Exec_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         CommonResult oResult = new CommonResult();
         try
         {
            oResult = this.GetCommonResult(((object[])e.Result));

            if ( oResult.Cancel )
            {
               if (! string.IsNullOrEmpty( oResult.ErrorMsg ))
               {
                  throw new Exception( oResult.ErrorMsg );
                }
             }

            Int64 iStartTicks = oResult.StartTicks;
            oResult.Editor.ResultsDataset = oResult.DataSet;

            this.oToolEditorShowHideResults.Checked = (oResult.DataSet != null && oResult.DataSet.Tables.Count>0);
            this.ToolEditor_ShowHideResults(null, null);

            Int64 iFinishTicks = DateTime.Now.Ticks;
            oResult.Editor.setElapsedTime(new DateTime(iFinishTicks - iStartTicks));

            if (oResult.UseScriptExecution == true)
            {
               string sMsg = "Query executed with sucess.";
               if (oResult.AffectedRows != 0)
               {
                  sMsg += (char)13;
                  sMsg += oResult.AffectedRows.ToString() + " affected rows";
               }
               MessageBox.Show(sMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Tabs_TabChanged(oResult.Editor);
            oResult.Editor.Focus();

          }
         catch (Exception ex) { this.MessageError(ex.Message); }
         finally
         {
            ((BackgroundWorker)sender).Dispose();
            sender=null;
            this.WaitFinish();
          }
       }

      #endregion


      #region Tabs_TabChanged
      private void Tabs_TabChanged(UI.Editor oTabEditor)
      {
         this.oToolEditor.Visible = false;
         this.oToolEditorConnections.Text = "[Select Connection]";
         this.oToolEditorConnections.Image = null;
         this.oToolEditorConnections.TextAlign = ContentAlignment.MiddleCenter;
         this.stbLabelRowCount.Text=string.Empty;
         this.stbLabelTime.Text = string.Empty;
         this.oToolFileSave.Enabled=false;

         if (oTabEditor!=null)
         {
            this.oToolEditor.Visible = true;
            ToolStripItem oMenu = this.oToolEditorConnections.DropDownItems["oToolEditorConnections" + oTabEditor.ConnectionName];
            if (oMenu != null)
            {
               this.oToolEditorConnections.Text = oMenu.Text;
               this.oToolEditorConnections.Image = oMenu.Image;
               this.oToolEditorConnections.TextAlign = ContentAlignment.MiddleLeft;
             }

            this.oToolEditorShowHideQuery.Checked = oTabEditor.QueryVisible;
            this.oToolEditorShowHideResults.Checked = oTabEditor.ResultsVisible;

            this.stbLabelRowCount.Text = oTabEditor.ResultsRowCount;
            this.stbLabelTime.Text = oTabEditor.getElapsedTime();
            this.oToolFileSave.Enabled=true;
          }

       }
      #endregion

      #region History_NewItem 
      private void History_NewItem(string FileName)
      {
         this.History_NewItem(FileName, (this.oToolFileOpen.DropDownItems.Count-2));
       }
      private void History_NewItem(string FileName, Int32 Index)
      {
         ToolStripMenuItem oMenu = null;
         try
         {
            oMenu = new ToolStripMenuItem();
            oMenu.Text = System.IO.Path.GetFileNameWithoutExtension(FileName);
            oMenu.ToolTipText = FileName;
            oMenu.Click += new EventHandler(this.ToolFile_Open_History);
            this.oToolFileOpen.DropDownItems.Insert(Index, oMenu);
          }
         catch (Exception ex) {this.MessageError(ex.Message);}
       }
      #endregion

      #endregion

    }
}
