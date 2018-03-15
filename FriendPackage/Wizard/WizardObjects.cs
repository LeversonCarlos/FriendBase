using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FS.Package.Wizard
{
   internal class WizardObjects: WizardBase
   {

      #region Initialize
      private ObjectSelector oObjectSelector;
      private void InitializeComponent()
      {
         this.SuspendLayout();
         oObjectSelector=new ObjectSelector();
         // 
         // oObjectSelector
         // 
         this.oObjectSelector.Location = new System.Drawing.Point(7, 20);
         this.oObjectSelector.Name = "oObjectSelector";
         this.oObjectSelector.Size = new System.Drawing.Size(484, 222);
         this.oObjectSelector.TabIndex = 1;
         // 
         // WizardViews
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.Controls.Add(this.oObjectSelector);
         this.Name = "WizardViews";
         this.Controls.SetChildIndex(this.oObjectSelector, 0);
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      #region NEW
      internal WizardObjects():base()
      {
         this.InitializeComponent();
         this.Initializing += Base_Initializing;
         this.BaseValidating += Base_Validating;
       }
      #endregion

      #region METHODS

      #region RefreshDataTable
      private void RefreshDataTable()
      {
         try
         {
            this.RefreshDataTable_UnselectAll();
            this.RefreshDataTable_SelectFromPackage();

            this.oObjectSelector.oListAvailable.DataSource = this.DataTableAvailable;
            this.oObjectSelector.oListAvailable.DisplayMember = "ObjectName";
            this.oObjectSelector.oListAvailable.ValueMember = "ObjectName";

            this.oObjectSelector.oListSelected.DataSource = this.DataTableSelected;
            this.oObjectSelector.oListSelected.DisplayMember = "ObjectName";
            this.oObjectSelector.oListSelected.ValueMember = "ObjectName"; 

          }
         catch(Exception ex) {throw ex;}
       }
      #endregion

      #region RefreshDataTable_UnselectAll
      private void RefreshDataTable_UnselectAll()
      {
         foreach (DataRow oROW in this.DataTable.Rows)
         {
            oROW["Selected"] = false;
          }
       }
      #endregion

      #region RefreshDataTable_SelectFromPackage
      private void RefreshDataTable_SelectFromPackage()
      {
         if (this.DataTablePackage.Count == 0 || ((Int16)this.DataTablePackage[0].Row["Status"]) == 0)
         {
            this.oObjectSelector.optSelectionNone.Checked = true;
          }
         else if (this.DataTablePackage.Count == 1 && ((Int16)this.DataTablePackage[0].Row["Status"]) == 1)
         {
            this.oObjectSelector.optSelectionAll.Checked = true;
          }
         else if (this.DataTablePackage.Count != 0 && ((Int16)this.DataTablePackage[0].Row["Status"]) == 2)
         {
            this.oObjectSelector.optSelectionCustom.Checked = true;
            foreach (DataRowView oRowView in this.DataTablePackage)
            {
               DataRow oRow = this.DataTable.Rows.Find(oRowView["Name"].ToString());
               if (oRow != null)
               {
                  oRow["Selected"] = true;
                }
             }
          }
       }
      #endregion

      #endregion

      #region PROPERTIES

      #region ObjectType
      protected delegate void GetObjectTypeEventHandler(ref string value);
      protected event GetObjectTypeEventHandler GetObjectType;
      private string sObjectType = string.Empty;
      private string ObjectType
      {
         get
         {
            if (string.IsNullOrEmpty(sObjectType))
            {
               if (this.GetObjectType != null)
               {
                  this.GetObjectType(ref sObjectType);
                }
             }
            return sObjectType;
          }
       }
      #endregion

      #region DataTable
      protected delegate void GetDataTableEventHandler(ref DataTable oDataTable);
      protected event GetDataTableEventHandler GetDataTable;
      private DataTable oDataTable = null;
      internal DataTable DataTable
      {
         get
         {
            if (oDataTable == null && this.GetDataTable != null)
            {
               this.GetDataTable(ref oDataTable);
               oDataTable.Columns.Add("Selected", true.GetType());
               oDataTable.PrimaryKey = new DataColumn[] {oDataTable.Columns["ObjectName"]};
             }
            return oDataTable;
          }
       }
      #endregion

      #region DataTableAvailable
      private DataView DataTableAvailable
      {
         get
         {
            DataView oDataView = new DataView();
            oDataView.Table = this.DataTable;
            oDataView.RowFilter = "Selected = 0";
            oDataView.Sort="ObjectName";
            return oDataView;
          }
       }
      #endregion

      #region DataTableSelected
      private DataView DataTableSelected
      {
         get
         {
            DataView oDataView = new DataView();
            oDataView.Table = this.DataTable;
            oDataView.RowFilter = "Selected = 1";
            oDataView.Sort="ObjectName";
            return oDataView;
          }
       }
      #endregion

      #region DataTablePackage
      private DataView DataTablePackage
      {
         get
         {
            DataView oDataView = new DataView();
            oDataView.Table = this.Package.ObjectsTable;
            oDataView.RowFilter = "Type = '" + this.ObjectType + "'";
            oDataView.Sort = "Name";
            return oDataView;
          }
       }
      #endregion

      #endregion

      #region EVENTS

      #region Base_Initializing
      private void Base_Initializing()
      {
         if (this.oDataTable == null)
         {
            this.RefreshDataTable();
         }
       }
      #endregion

      #region Base_Validating
      //protected event ValidatingEventHandler WizardValidating;
      internal void Base_Validating(ref bool Valid, ref string Msg)
      {
         try
         {

            //CLEAR CURRENT SELECTION
            foreach (DataRowView oRowView in this.DataTablePackage)
            {
               oRowView.Delete();
             }

            if (this.oObjectSelector.optSelectionNone.Checked)
            {
               string NONE = "TODO";
             }
            else if (this.oObjectSelector.optSelectionAll.Checked)
            {
               this.Package.AddNew(this.ObjectType);
             }
            else if (this.DataTableSelected.Count != 0)
            {
               foreach (DataRowView oRow in this.DataTableSelected)
               {
                  this.Package.AddNew(this.ObjectType, oRow["ObjectName"].ToString());
                }
             }

          }
         catch (Exception ex) { Valid=false; Msg=ex.ToString(); }
       }
      #endregion

      #endregion

    }
}
