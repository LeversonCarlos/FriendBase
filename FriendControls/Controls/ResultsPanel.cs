using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FS.Base.UI.Controls
{
   internal partial class ResultsPanel : UserControl
   {

      #region NEW
      internal ResultsPanel()
      {
         InitializeComponent();
      }
      #endregion

      #region ResultsDataset
      private System.Data.DataSet tmp_ResultsDataset = null;
      public System.Data.DataSet ResultsDataset
      {
         get { return tmp_ResultsDataset; }
         set 
         {
            this.tmp_ResultsRowCount = string.Empty;
            tmp_ResultsDataset = value;
            this.tabControl.TabPages.Clear();
            if (tmp_ResultsDataset != null && tmp_ResultsDataset.Tables.Count>0)
            {
               foreach(DataTable oTable in tmp_ResultsDataset.Tables)
               {
                  DataGridView oGrid = new DataGridView();
                  oGrid.DataBindingComplete +=  new DataGridViewBindingCompleteEventHandler(this.ResultsDataGrid_BindingComplete);
                  oGrid.DataSource = oTable;
                  oGrid.BorderStyle = BorderStyle.None;
                  oGrid.AllowUserToAddRows=false;
                  oGrid.AllowUserToDeleteRows=false;
                  oGrid.EditMode= DataGridViewEditMode.EditProgrammatically;
                  oGrid.BackgroundColor= SystemColors.Control;
                  oGrid.Dock = DockStyle.Fill;

                  string sText = ((Int32)(this.tabControl.TabPages.Count +1)).ToString("00");
                  Crownwood.Magic.Controls.TabPage oTabPage = new Crownwood.Magic.Controls.TabPage(sText, oGrid);
                  this.tabControl.TabPages.Add(oTabPage);

                  if(!string.IsNullOrEmpty(this.tmp_ResultsRowCount))
                  {
                     this.tmp_ResultsRowCount += "|";
                   }
                  this.tmp_ResultsRowCount += oTable.Rows.Count.ToString();

                }
             }
          }
       }
      #endregion

      #region ResultsRowCount
      private string tmp_ResultsRowCount;
      internal string ResultsRowCount
      {
         get{return tmp_ResultsRowCount;}
       }
      #endregion

      #region ResultsDataGrid_BindingComplete
      private void ResultsDataGrid_BindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
      {
         ((DataGridView)sender).AutoResizeColumns( DataGridViewAutoSizeColumnsMode.AllCells);
         ((DataGridView)sender).DataBindingComplete -=  new DataGridViewBindingCompleteEventHandler(this.ResultsDataGrid_BindingComplete);
       }
      #endregion

    }
}
