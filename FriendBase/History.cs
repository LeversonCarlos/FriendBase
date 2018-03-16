using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FS.Base
{
   internal class History
   {

      #region FileName
      private string sFileName = string.Empty;
      private string FileName
      {
         get
         {
            if (string.IsNullOrEmpty(sFileName))
            {
               string sDirectorySeparator = System.IO.Path.DirectorySeparatorChar.ToString();
               sFileName = System.Windows.Forms.Application.ExecutablePath; 
               sFileName = System.IO.Path.GetDirectoryName(sFileName);
               sFileName += (sFileName.EndsWith(sDirectorySeparator) ? string.Empty : sDirectorySeparator);
               sFileName += "CFG.History.xml";
             }
            return sFileName;
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
                  if(System.IO.File.Exists(this.FileName))
                  {
                     oDataset.ReadXml(this.FileName, XmlReadMode.IgnoreSchema);
                   }
                }
             }
            catch 
            {
               this.InitializeDataset();
             }
            return this.oDataset;
          } 
       }
      #endregion

      #region HistoryTable
      DataTable HistoryTable
      {
         get{ return this.Dataset.Tables["History"];}
       }
      #endregion


      #region InitializeDataset
      private void InitializeDataset()
      {
         oDataset = new DataSet("History");
         oDataset.Tables.Add("History");
         oDataset.Tables["History"].Columns.Add("Path", string.Empty.GetType());
         oDataset.Tables["History"].Columns.Add("Date", string.Empty.GetType());
       }
      #endregion

      #region Save
      internal bool Save()
      {
         bool bRet = false;
         try
         {
            if(System.IO.File.Exists(this.FileName))
            {
               System.IO.File.Delete(this.FileName);
             }
            this.Dataset.WriteXml(this.FileName, XmlWriteMode.IgnoreSchema);
            if(System.IO.File.Exists(this.FileName))
            {
               bRet = true;
             }
          }
         catch(Exception ex) {throw ex;}
         return bRet;
       }
      #endregion

      #region GetFiles
      internal string[] GetFiles()
      {
         System.Collections.ArrayList aList = null;
         try
         {
            aList = new System.Collections.ArrayList();
            foreach(DataRow oRow in this.HistoryTable.Select("'1'='1'", "Date desc"))
            {
               aList.Add(oRow["Path"].ToString());
             }
          }
         catch(Exception ex){throw ex;}

         if (aList==null) 
         {
            return new string[]{};
          }
         else
         { 
            return ((string[])aList.ToArray(String.Empty.GetType())) ;
          }
         
       }
      #endregion

      #region Add
      internal delegate void NewItemEventHandler(string FileName, Int32 Index);
      internal event NewItemEventHandler NewItem;
      internal void Add(string sFileName)
      {
         DataRow oRow = null;
         try
         {
            DataRow[] oRows = this.HistoryTable.Select("Path='" + sFileName + "'");
            if (oRows !=null && oRows.Length != 0)
            {
               oRow = ((DataRow)oRows.GetValue(0));
               oRow["Date"] = DateTime.Now.ToString("yyyyMMddHHmmss");
             }
            else
            {
               oRow = this.HistoryTable.NewRow();
               oRow["Path"] = sFileName;
               oRow["Date"] = DateTime.Now.ToString("yyyyMMddHHmmss");
               this.HistoryTable.Rows.InsertAt(oRow, 0);
               if (this.NewItem != null)
               {
                  this.NewItem(sFileName, 1);
                } 
             }
          }
         catch(Exception ex){throw ex;}
       }
      #endregion

      #region Clear
      internal void Clear()
      {
         this.HistoryTable.Clear();
       }
      #endregion

    }
}
