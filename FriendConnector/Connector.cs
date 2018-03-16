using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Connector
{

   public class Connector: IDisposable
   {

      #region METHODS 
		
         #region NEW
      	public Connector(string ConfigFileName)
      	{
			   this.FileName = ConfigFileName;
       	 }
         #endregion

         #region Save
         public void Save()
         {
            this.Dataset.WriteXml(this.FileName, System.Data.XmlWriteMode.IgnoreSchema);
          }
         #endregion

         #region New
         public cItem New()
         {
            return this.New(string.Empty);
          }
         public cItem New(string sEngineType)
         {
            cItem oConnItem = new cItem();
            oConnItem.GetWizardProperties += new Wizard.WizardForm.GetWizardPropertiesEventHandler(Items_GetWizardProperties);

            if (!string.IsNullOrEmpty(sEngineType))
            {
               oConnItem.TypeSet(sEngineType);
             }

            if (oConnItem.ShowEditForm() == System.Windows.Forms.DialogResult.Cancel)
            {
               oConnItem.Dispose();
               oConnItem = null;
             }
            else
            {
               oConnItem.GetWizardProperties -= new Wizard.WizardForm.GetWizardPropertiesEventHandler(Items_GetWizardProperties);
             }

            return oConnItem;
          }
         #endregion

         #region Dispose
         private bool disposed = false;
         public void Dispose()
         {
             this.Dispose(true);
             GC.SuppressFinalize(this);
          }
         private void Dispose(bool disposing)
         {
             if (!this.disposed)
             {
                if (tmp_Items != null)
                {
                   tmp_Items.Clear();
                   tmp_Items = null;
                }
                if (tmp_Dataset != null)
                {
                   tmp_Dataset.Dispose();
                   tmp_Dataset = null;
                 }
             }
             disposed = true;
          }
         #endregion

      #endregion

      #region PROPERTIES

         #region FileName
         private string tmp_FileName;
		   private string FileName
		   {
			   get{return tmp_FileName;}
			   set{tmp_FileName=value;}
		    }
		   #endregion

         #region WizardTitle
         private string sWizardTitle = "Wizard";
         public string WizardTitle
         {
            get{return sWizardTitle;}
            set{sWizardTitle=value;}
          }
         #endregion


         #region Items
         private cItems tmp_Items;
		   public cItems Items
		   {
			   get
			   {
				   if (tmp_Items==null)
				   {
					   tmp_Items =  new cItems();
                  tmp_Items.ItemChanged += Items_ItemChanged;
                  tmp_Items.ItemRenamed += Items_ItemRenamed;
                  tmp_Items.ItemRemoved += Items_ItemRemoved; 
                  tmp_Items.GetWizardProperties += Items_GetWizardProperties; 
					   this.ItemsLoad();
			 	    }
				   return tmp_Items;
             }
          }
         #endregion
		
         #region Dataset
		   private System.Data.DataSet tmp_Dataset;
		   private System.Data.DataSet Dataset
		   {
			   get 
			   {
				   if (tmp_Dataset == null)
				   {
					   if (System.IO.File.Exists(this.FileName))
					   {
						   try
						   {
							   tmp_Dataset = GetEmptyDataset();
							   tmp_Dataset.ReadXml(this.FileName);//, System.Data.XmlReadMode.IgnoreSchema);
						    }
						   catch{}
                   }
                }
               if (tmp_Dataset == null)
				   {
					   tmp_Dataset = GetEmptyDataset();
                }
               return tmp_Dataset;
             }
          }
         #endregion

         #region Dataset Column Names 

            #region DatasetConnStr
            string tmp_DatasetConnStr;
	         string DatasetConnStr
	         {
		         get
		         {
			         if (string.IsNullOrEmpty(tmp_DatasetConnStr))
			         {
				         tmp_DatasetConnStr = Encrypt("ConnStr");
			          }
			         return tmp_DatasetConnStr;
		          }
	          }
	         #endregion
		
		      #region DatasetNameColumn
		      string tmp_DatasetNameColumn;
		      string DatasetNameColumn
		      {
			      get
			      {
				      if (string.IsNullOrEmpty(tmp_DatasetNameColumn))
				      {
					      tmp_DatasetNameColumn = Encrypt("Name");
				       }
				      return tmp_DatasetNameColumn;
			       }
		       }
		      #endregion
		
		      #region DatasetContentColumn
		      string tmp_DatasetContentColumn;
		      string DatasetContentColumn
		      {
			      get
			      {
				      if (string.IsNullOrEmpty(tmp_DatasetContentColumn))
				      {
					      tmp_DatasetContentColumn = Encrypt("Content");
				       }
				      return tmp_DatasetContentColumn;
			       }
		       }
		      #endregion

         #endregion

      #endregion

      #region EVENTS

         #region Items_ItemChanged
         private void Items_ItemChanged(cItem sender)
		   {
            string sName = Encrypt(sender.Name);
            System.Data.DataRow oROW = this.Dataset.Tables[DatasetConnStr].Rows.Find(sName);
            bool NewRow = false;
            if (oROW == null)
            {
               NewRow = true;
               oROW = this.Dataset.Tables[DatasetConnStr].NewRow();
               oROW[DatasetNameColumn] = sName;
            }
			   oROW[DatasetContentColumn] = sender.ToContent();
            if (NewRow)
            {
               this.Dataset.Tables[DatasetConnStr].Rows.Add(oROW);
             }
		    }
		   #endregion

         #region Items_ItemRenamed
         internal event cItem.ItemRenamedEventHandler ItemRenamed;
         private void Items_ItemRenamed(cItem sender, string NewName)
         {
            string sName = Encrypt(sender.Name);
            System.Data.DataRow oROW = this.Dataset.Tables[DatasetConnStr].Rows.Find(sName);
            if (oROW != null)
            {
               oROW[DatasetNameColumn] = Encrypt(NewName);
               oROW[DatasetContentColumn] = sender.ToContent();
               sender.NameSet(NewName);
             }
          }
         #endregion

         #region Items_ItemRemoved
         private void Items_ItemRemoved(cItem sender)
         {
            string sName = Encrypt(sender.Name);
            System.Data.DataRow oROW = this.Dataset.Tables[DatasetConnStr].Rows.Find(sName);
            if (oROW != null)
            {
               oROW.Delete();
            }
          }
         #endregion

         #region Items_GetWizardProperties
         private void Items_GetWizardProperties(FS.Wizard.WizardForm sender)
         {
            sender.Text = this.WizardTitle;
          }
         #endregion

      #endregion

      #region FUNCTIONS

         #region GetEmptyDataset
         System.Data.DataSet GetEmptyDataset()
         {
            System.Data.DataSet objRET;
            objRET = new System.Data.DataSet(Encrypt("CFG"));

            System.Data.DataTable objTable = objRET.Tables.Add(DatasetConnStr);
            objTable.Columns.Add(DatasetNameColumn, string.Empty.GetType());
            //objTable.Columns.Add(DatasetTypeColumn, string.Empty.GetType());
            objTable.Columns.Add(DatasetContentColumn, string.Empty.GetType());

            objTable.PrimaryKey = new System.Data.DataColumn[] { objTable.Columns[DatasetNameColumn] };

            return objRET;
         }
         #endregion

         #region ItemsLoad
         private void ItemsLoad()
         {
            this.Items.Clear();
            if (this.Dataset.Tables.Contains(DatasetConnStr))
            {
               foreach (System.Data.DataRow oROW in this.Dataset.Tables[DatasetConnStr].Rows)
               {
                  //string sName = Decrypt(oROW[DatasetNameColumn]);
                  string sContent = oROW[DatasetContentColumn].ToString();
                  this.Items.Add(sContent, true);
               }
            }
         }
         #endregion
		
		   #region Encrypt
		   private string Encrypt(object Value)
		   {
            return FS.Common.Type.Encrypt(Value);
		    }
		   #endregion
   		
		   #region Decrypt
		   private string Decrypt(object Value)
		   {
            return FS.Common.Type.Decrypt(Value);
		    }
		   #endregion

      #endregion

    }
	
}
