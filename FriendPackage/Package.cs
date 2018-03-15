using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FS.Package
{

   internal class Package
   {

      #region NEW
      internal Package()
      {
       }
      #endregion

      #region PROPERTIES

      #region Connector
      internal delegate void GetConnectorEventHandler(ref string value);
      internal event GetConnectorEventHandler GetConnector;
      internal string Connector
      {
         get
         {
            string sConnector = string.Empty;
            if (this.GetConnector != null)
            {
               this.GetConnector(ref sConnector);
             }
            return sConnector;
          }
       }
      #endregion

      #region FileName
      private string sFileName = string.Empty;
      internal string FileName
      {
         get{return sFileName;}
         set{sFileName=value;}
       }
      #endregion

      #region FilePath
      private string sFilePath = string.Empty;
      internal string FilePath
      {
         get
         {
            if (string.IsNullOrEmpty(sFilePath) && !string.IsNullOrEmpty(this.FileName))
            {
               string sDirectorySeparator = System.IO.Path.DirectorySeparatorChar.ToString();
               sFilePath = System.Windows.Forms.Application.ExecutablePath; 
               sFilePath = System.IO.Path.GetDirectoryName(sFilePath);
               sFilePath += (sFilePath.EndsWith(sDirectorySeparator) ? string.Empty : sDirectorySeparator);
               sFilePath += "CFG.Package."; 
               sFilePath += this.Connector.Replace(":","").Replace(" ","").Replace("/","").Replace("*","").Replace("?","").Replace("<","").Replace(">","").Replace("|","") + "."; 
               sFilePath += this.FileName + ".xml";
             }
            return sFilePath;
          }
       }
      #endregion

      #region Dataset
      private DataSet oDataset = null;
      private DataSet Dataset
      {
         get
         {
            try
            {
               if (oDataset == null)
               {
                  this.InitializeDataset();
                  if(!string.IsNullOrEmpty(this.FilePath) && System.IO.File.Exists(this.FilePath))
                  {
                     oDataset.ReadXml(this.FilePath, XmlReadMode.IgnoreSchema);
                   }
                }
             }
            catch {this.InitializeDataset();}
            return this.oDataset;
          } 
       }
      #endregion

      #region ObjectsTable
      internal DataTable ObjectsTable
      {
         get{return this.Dataset.Tables["Objects"];}
       }
      #endregion

      #endregion

      #region METHODS

      #region InitializeDataset
      private void InitializeDataset()
      {
         oDataset = new DataSet("Package");
         DataTable oTypes = new DataTable("Objects");
         oTypes.Columns.Add("Type", string.Empty.GetType());
         oTypes.Columns.Add("Status", Int16.MinValue.GetType());
         oTypes.Columns.Add("Name", string.Empty.GetType());
         oDataset.Tables.Add(oTypes);
       }
      #endregion

      #region AddNew
      internal void AddNew(string Type)
      {
         this.AddNew(Type, 1, string.Empty);
       }
      internal void AddNew(string Type, string Name)
      {
         this.AddNew(Type, 2, Name);
       }
      internal void AddNew(string Type, Int16 Status, string Name)
      {
         DataRow oROW = this.ObjectsTable.NewRow();
         oROW["Type"] = Type;
         oROW["Status"] = Status;
         oROW["Name"] = Name;
         this.ObjectsTable.Rows.Add(oROW);
       }
      #endregion 

      #region Save
      internal bool Save()
      {
         bool bRet = false;
         try
         {
            if ( string.IsNullOrEmpty(this.FilePath))
            {
               throw new Exception("Invalid File Name");
             }

            if (System.IO.File.Exists(this.FilePath))
            {
               System.IO.File.Delete(this.FilePath);
             }

            this.Dataset.WriteXml(this.FilePath, XmlWriteMode.IgnoreSchema);

            if (System.IO.File.Exists(this.FilePath))
            {
               bRet = true;
             }

          }
         catch(Exception ex){throw ex;}
         return bRet;
       }
      #endregion

      #endregion

    }
}
