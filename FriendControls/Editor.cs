using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Base.UI
{
   public class Editor: Control
   {

      #region Initialize

      private FS.Base.UI.Controls.TextPanel oTextPanel;
      private FS.Base.UI.Controls.ResultsPanel oResultsPanel;
      private System.Windows.Forms.SplitContainer oSplit;

      private void InitializeComponent()
      {
         this.oSplit = new System.Windows.Forms.SplitContainer();
         this.oTextPanel = new FS.Base.UI.Controls.TextPanel();
         this.oResultsPanel = new FS.Base.UI.Controls.ResultsPanel();

         this.oSplit.Panel1.SuspendLayout();
         this.oSplit.Panel2.SuspendLayout();
         this.oSplit.SuspendLayout();
         this.SuspendLayout();
         // 
         // oSplit
         // 
         this.oSplit.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this.oSplit.Dock = System.Windows.Forms.DockStyle.Fill;
         this.oSplit.Location = new System.Drawing.Point(0, 0);
         this.oSplit.Name = "oSplit";
         this.oSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // oSplit.Panel1
         // 
         this.oSplit.Panel1.Controls.Add(this.oTextPanel);
         // 
         // oSplit.Panel2
         // 
         this.oSplit.Panel2.Controls.Add(this.oResultsPanel);
         this.oSplit.Panel2Collapsed = true;
         this.oSplit.Size = new System.Drawing.Size(530, 289);
         this.oSplit.SplitterDistance = 168;
         this.oSplit.TabIndex = 0;
         // 
         // oTextPanel
         // 
         this.oTextPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.oTextPanel.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.oTextPanel.Location = new System.Drawing.Point(0, 0);
         this.oTextPanel.Name = "oTextPanel";
         this.oTextPanel.Size = new System.Drawing.Size(530, 289);
         this.oTextPanel.TabIndex = 0;
         // 
         // oResultsPanel
         // 
         this.oResultsPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this.oResultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.oResultsPanel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.oResultsPanel.Location = new System.Drawing.Point(0, 0);
         this.oResultsPanel.Name = "oResultsPanel";
         this.oResultsPanel.ResultsDataset = null;
         this.oResultsPanel.Size = new System.Drawing.Size(530, 117);
         this.oResultsPanel.TabIndex = 0;
         // 
         // Editor
         // 
         this.Controls.Add(this.oSplit);
         this.Name = "Editor";
         this.Size = new System.Drawing.Size(530, 289);
         this.oSplit.Panel1.ResumeLayout(false);
         this.oSplit.Panel1.PerformLayout();
         this.oSplit.Panel2.ResumeLayout(false);
         this.oSplit.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      #region NEW
      internal Editor()
      {
         this.InitializeComponent();
       }
      #endregion


      #region ConnectionName
      private string tmp_ConnectionName = string.Empty;
      public string ConnectionName
      {
         get { return tmp_ConnectionName; }
         set { tmp_ConnectionName = value; }
       }
      #endregion

      #region FileName
      private string tmp_FileName = string.Empty;
      public string FileName
      {
         get { return tmp_FileName; }
         set 
         { 
            tmp_FileName = value; 
            this.Title = System.IO.Path.GetFileNameWithoutExtension(tmp_FileName);
          }
       }
      #endregion

      #region Title
      public string Title
      {
         get{ return this.TabPage.Title;}
         set{this.TabPage.Title=value;}
       }
      #endregion


      #region QueryText
      public string QueryText
      {
         get { return this.oTextPanel.QueryText; }
         set { this.oTextPanel.QueryText = value; this.oTextPanel.Invalidate(); }
       }
      #endregion

      #region QueryTextSelected
      public string QueryTextSelected
      {
         get {return this.oTextPanel.QueryTextSelected;}
      }
      #endregion


      #region QueryVisible
      public bool QueryVisible
      {
         get { return !this.oSplit.Panel1Collapsed; }
         set { this.oSplit.Panel1Collapsed = !value; }
       }
      #endregion

      #region ResultsVisible
      public bool ResultsVisible
      {
         get {return !this.oSplit.Panel2Collapsed; }
         set {this.oSplit.Panel2Collapsed = !value;}
      }
      #endregion

      #region ResultsDataset
      public System.Data.DataSet ResultsDataset
      {
         get { return this.oResultsPanel.ResultsDataset; }
         set 
         {
            this.oResultsPanel.ResultsDataset = value;
          }
       }
      #endregion

      #region ResultsRowCount
      public string ResultsRowCount
      {
         get
         {
            if (string.IsNullOrEmpty(this.oResultsPanel.ResultsRowCount))
            {
               return string.Empty;
             }
            else
            {
               return "ROWs: " + this.oResultsPanel.ResultsRowCount;
             }
         }
       }
      #endregion


      #region Focus
      public void Focus()
      {
         this.oTextPanel.Focus();
       }
      #endregion

      #region ElapsedTime
      DateTime tmp_ElapsedTime = DateTime.MinValue;
      public void setElapsedTime(DateTime ElapsedTime)
      {
         tmp_ElapsedTime = ElapsedTime;
       }
      public string getElapsedTime()
      {
         string sReturn =string.Empty;
         if (tmp_ElapsedTime != DateTime.MinValue)
         {
            Int32 iElapsedTime = 0;
            iElapsedTime += tmp_ElapsedTime.Second;
            iElapsedTime += (tmp_ElapsedTime.Minute *60);
            iElapsedTime += (tmp_ElapsedTime.Hour *60 *60);

            sReturn = "SEGs: " + iElapsedTime.ToString();
          }
         return sReturn;
       }
      #endregion

      #region TabPage
      Crownwood.Magic.Controls.TabPage tmp_TabPage;
      internal Crownwood.Magic.Controls.TabPage TabPage
      {
         get { return tmp_TabPage; }
         set{tmp_TabPage=value;}
       }
      #endregion

    }
}
