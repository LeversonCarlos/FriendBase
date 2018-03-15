using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FS.Package
{
   public class Import: Base
   {

      //#region NEW
      //public Import()
      //{
      // }
      //#endregion

      #region METHODS

      #region Execute
      public bool Execute()
      {
         bool bRet = false;
         try
         {
            //STEP 1
            this.Execute_UNZIP();
            if (this.Types == null)
            {
               throw new Exception("Invalid configuration for this package.");
             }

            //STEP 2
            this.Execute_TABLEs();

          }
         catch(Exception ex){throw ex;}
         finally
         {
            if (! string.IsNullOrEmpty(sWorkingFolder) && System.IO.Directory.Exists(sWorkingFolder))
            {
               try
               {
                  System.IO.Directory.Delete(sWorkingFolder,true);
                }
               catch{}
             }
          }
         return bRet;
       }
      #endregion

      #region Execute_UNZIP
      private bool Execute_UNZIP()
      {
         bool bRet = false;
         fs.Common.ZIP.ZIP oZIP = null;
         try
         {
            oZIP = new fs.Common.ZIP.ZIP(this.FilePath);
            oZIP.Extract(this.WorkingFolder);
          }
         catch(Exception ex){throw ex;}
         finally
         {
            oZIP.Dispose();
            oZIP = null;
          }
         return bRet;
       }
      #endregion

      #region Execute_TABLEs
      private void Execute_TABLEs()
      {
         try
         {
            if ( this.Types.Tables.Contains("TABLEs") && this.Types.Tables["TABLEs"].Rows.Count != 0 )
            {

               DataView dvColumns = new DataView();
               dvColumns.Table = this.Types.Tables["TABLEsCOLUMNs"].Copy();

               foreach(DataRow rwTableSrc in this.Types.Tables["TABLEs"].Rows)
               {
                  string sScript = string.Empty;
                  dvColumns.RowFilter = "TableName = '" + rwTableSrc["ObjectName"].ToString() + "'";

                  DataTable dtCurrentTable = this.Data.Schema.GetTable( rwTableSrc["ObjectName"].ToString() );
                  if (dtCurrentTable == null || dtCurrentTable.Rows.Count == 0)
                     {sScript = this.Data.Scripts.GetTable(rwTableSrc, dvColumns.ToTable());}
                  else
                  {
                     DataTable dtCurrentColumns = this.Data.Schema.GetColumns( rwTableSrc["ObjectName"].ToString(), true );
                     sScript = this.Data.Scripts.GetTableDifferences(rwTableSrc, dvColumns.ToTable(), dtCurrentTable.Rows[0], dtCurrentColumns);
                   }

                  if (!string.IsNullOrEmpty(sScript))
                  {
                     System.Windows.Forms.MessageBox.Show(sScript);
                   }
                }
               dvColumns.Dispose();
               dvColumns=null;
             }
          }
         catch(Exception ex){throw ex;}
       }
      #endregion

      #endregion

      #region PROPERTIES

      #region Types
      private DataSet oTypes = null;
      private DataSet Types
      {
         get
         {
            if (oTypes==null)
            {
               this.FilePath = this.WorkingFolder + "CFG_PACKAGE_OBJECTS" + ".xml";
               if (System.IO.File.Exists(this.FilePath))
               {
                  oTypes = new DataSet("Types");
                  oTypes.ReadXml(this.FilePath);
                }
             }
            return oTypes;
          }
       }
      #endregion 

      #endregion 

    }
}
