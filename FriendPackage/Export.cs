using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FS.Package
{
   public class Export: Base
   {

      #region NEW
      public Export()
      {
       }
      #endregion

      #region METHODS

      #region Show
      public bool Show(bool All)
      {
         this.Package = new Package();
         this.Package.AddNew("TABLEs");
         this.Package.AddNew("VIEWs");
         this.Package.AddNew("PROCEDUREs");
         this.Package.AddNew("FUNCTIONs");
         this.Package.AddNew("DATAs");
         return Execute();
       }
      public bool Show(string FileName)
      {
         this.Package = new Package();
         this.Package.FileName = FileName;
         return this.Show();
       }
      public bool Show()
      {
         bool bRet = false;
         try
         {
            if (this.Package == null)
            {
               this.Package = new Package();
             }

            this.Wizard.Initialize();
            if (this.Wizard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               bRet = this.Execute();
             }
          }
         catch(Exception ex){throw ex;}
         return bRet;
       }
      #endregion

      #region Execute
      private bool Execute()
      {
         bool bRet = false;
         try
         {
            //STEP 1
            this.Progress.Open();
            this.Progress.StepStart();
            this.Types = new System.Data.DataSet("Types");
            this.Progress.StepFinish();

            //STEP 2
            this.Progress.StepStart();
            this.Execute_TABLEs();
            this.Progress.StepFinish();

            //STEP 3
            this.Progress.StepStart();
            this.Execute_VIEWSs();
            this.Progress.StepFinish();

            //STEP 4
            this.Progress.StepStart();
            this.Execute_PROCEDUREs();
            this.Progress.StepFinish();

            //STEP 5
            this.Progress.StepStart();
            this.Execute_FUNCTIONs();
            this.Progress.StepFinish();

            //STEP 6
            this.Progress.StepStart();
            this.Execute_DATAs();
            this.Progress.StepFinish();

            //STEP 7
            this.Progress.StepStart();
            this.WriteXml(this.Types, "CFG_PACKAGE_OBJECTS");
            bRet = this.Execute_ZIP();
            this.Progress.StepFinish();
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
            if (this.Types != null)
            {
               this.Types.Dispose();
               this.Types = null;
             }
            this.Progress.Close();
          }
         return bRet;
       }
      #endregion

      #region Execute_TABLEs
      private void Execute_TABLEs()
      {
         Int16 iStrategy = 0;
         DataView oDataView = null;
         DataTable oObjects = null;

         try
         {
            iStrategy = this.GetExportStrategyByType("TABLEs", ref oDataView);
            if (iStrategy == 0)
               {return;}
            else
            {
               if (iStrategy == 1)
                  {oObjects = this.Data.Schema.GetTables(true);}
               else if (iStrategy == 2)
               {
                  oObjects = oDataView.ToTable();
                  oObjects.Columns["Name"].ColumnName = "ObjectName";
                }

               this.Progress.ProgressStart(oObjects.Rows.Count);
               foreach(DataRow oRow in oObjects.Rows)
               {
                  DataTable oRET = null; 
                  this.Progress.Progress();

                  //TABLE
                  oRET = this.Data.Schema.GetTable(oRow["ObjectName"].ToString());
                  if (oRET != null)
                  {
                     oRET.TableName = "TABLEs";
                     if (!this.Types.Tables.Contains("TABLEs")) {this.Types.Tables.Add(oRET.Copy());}
                     else {this.Types.Merge(oRET.Copy());}
                     oRET.Dispose();
                     oRET = null;
                   }

                  //COLUMNS
                  oRET = this.Data.Schema.GetColumns(oRow["ObjectName"].ToString(), true);
                  if (oRET != null)
                  {
                     oRET.TableName = "TABLEsCOLUMNs";
                     if (!this.Types.Tables.Contains("TABLEsCOLUMNs")) {this.Types.Tables.Add(oRET.Copy());}
                     else {this.Types.Merge(oRET.Copy());}
                     oRET.Dispose();
                     oRET = null;
                   }

                  //INDEXES
                  oRET = this.Data.Schema.GetIndexes(oRow["ObjectName"].ToString(), true);
                  if (oRET != null)
                  {
                     oRET.TableName = "TABLEsINDEXEs";
                     if (!this.Types.Tables.Contains("TABLEsINDEXEs")) {this.Types.Tables.Add(oRET.Copy());}
                     else {this.Types.Merge(oRET.Copy());}
                     oRET.Dispose();
                     oRET = null;
                   }

                  //CONSTRAINTS
                  //TODO

                }
             }

          }
         catch(Exception ex){throw ex;}
         finally
         {
            if (oObjects != null)
            {
               oObjects.Dispose();
               oObjects = null;
             }
            if (oDataView != null)
            {
               oDataView.Dispose();
               oDataView = null;
             }
          }

       }
      #endregion

      #region Execute_VIEWSs
      private void Execute_VIEWSs()
      {
         Int16 iStrategy = 0;
         DataView oDataView = null;
         DataTable oObjects = null;

         try
         {
            iStrategy = this.GetExportStrategyByType("VIEWs", ref oDataView);
            if (iStrategy == 0)
               {return;}
            else
            {
               if (iStrategy == 1)
                  {oObjects = this.Data.Schema.GetViews(true);}
               else if (iStrategy == 2)
               {
                  this.Progress.ProgressStart(oDataView.Count);
                  foreach(DataRowView oRow in oDataView)
                  {
                     this.Progress.Progress();
                     DataTable oRet = this.Data.Schema.GetView(oRow["Name"].ToString());
                     if (oRet != null)
                     {
                        if (oObjects == null) {oObjects = oRet.Copy();}
                        else {oObjects.Merge(oRet);}
                        oRet.Dispose();
                      }
                     oRet = null;
                   }
                }
               oObjects.TableName = "VIEWs";
               this.Types.Tables.Add(oObjects);
             }

          }
         catch(Exception ex){throw ex;}
         finally
         {
            if (oObjects != null)
            {
               oObjects.Dispose();
               oObjects = null;
             }
            if (oDataView != null)
            {
               oDataView.Dispose();
               oDataView = null;
             }
          }

       }
      #endregion

      #region Execute_PROCEDUREs
      private void Execute_PROCEDUREs()
      {
         Int16 iStrategy = 0;
         DataView oDataView = null;
         DataTable oObjects = null;

         try
         {
            iStrategy = this.GetExportStrategyByType("PROCEDUREs", ref oDataView);
            if (iStrategy == 0)
               {return;}
            else
            {
               if (iStrategy == 1)
                  {oObjects = this.Data.Schema.GetProcedures(true);}
               else if (iStrategy == 2)
               {
                  this.Progress.ProgressStart(oDataView.Count);
                  foreach(DataRowView oRow in oDataView)
                  {
                     this.Progress.Progress();
                     DataTable oRet = this.Data.Schema.GetProcedure(oRow["Name"].ToString());
                     if (oRet != null)
                     {
                        if (oObjects == null) {oObjects = oRet.Copy();}
                        else {oObjects.Merge(oRet);}
                        oRet.Dispose();
                      }
                     oRet = null;
                   }
                }
               oObjects.TableName = "PROCEDUREs";
               this.Types.Tables.Add(oObjects);
             }

          }
         catch(Exception ex){throw ex;}
         finally
         {
            if (oObjects != null)
            {
               oObjects.Dispose();
               oObjects = null;
             }
            if (oDataView != null)
            {
               oDataView.Dispose();
               oDataView = null;
             }
          }

       }
      #endregion

      #region Execute_FUNCTIONs
      private void Execute_FUNCTIONs()
      {
         Int16 iStrategy = 0;
         DataView oDataView = null;
         DataTable oObjects = null;

         try
         {
            iStrategy = this.GetExportStrategyByType("FUNCTIONS", ref oDataView);
            if (iStrategy == 0)
               {return;}
            else
            {
               if (iStrategy == 1)
                  {oObjects = this.Data.Schema.GetFunctions(true);}
               else if (iStrategy == 2)
               {
                  this.Progress.ProgressStart(oDataView.Count);
                  foreach(DataRowView oRow in oDataView)
                  {
                     this.Progress.Progress();
                     DataTable oRet = this.Data.Schema.GetFunction(oRow["Name"].ToString());
                     if (oRet != null)
                     {
                        if (oObjects == null) {oObjects = oRet.Copy();}
                        else {oObjects.Merge(oRet);}
                        oRet.Dispose();
                      }
                     oRet = null;
                   }
                }
               oObjects.TableName = "FUNCTIONs";
               this.Types.Tables.Add(oObjects);
             }

          }
         catch(Exception ex){throw ex;}
         finally
         {
            if (oObjects != null)
            {
               oObjects.Dispose();
               oObjects = null;
             }
            if (oDataView != null)
            {
               oDataView.Dispose();
               oDataView = null;
             }
          }

       }
      #endregion

      #region Execute_DATAs
      private void Execute_DATAs()
      {
         Int16 iStrategy = 0;
         DataView oDataView = null;
         DataTable oObjects = null;

         try
         {
            iStrategy = this.GetExportStrategyByType("DATAs", ref oDataView);
            if (iStrategy == 0)
               {return;}
            else
            {
               if (iStrategy == 1)
                  {oObjects = this.Data.Schema.GetTables(false);}
               else if (iStrategy == 2)
               {
                  oObjects = oDataView.ToTable();
                  oObjects.Columns["Name"].ColumnName = "ObjectName";
                }

               for (Int32 iCol = (oObjects.Columns.Count-1); iCol >=0; iCol--)
               {
                  if (oObjects.Columns[iCol].ColumnName != "ObjectName")
                  {
                     oObjects.Columns.RemoveAt(iCol);
                   }
                }

               this.Progress.ProgressStart(oObjects.Rows.Count);
               foreach(DataRow oRow in oObjects.Rows)
               {
                  this.Progress.Progress();
                  System.Data.Common.DbCommand oCommand = null;
                  DataTable oDataTable = null;
                  DataSet oDataSet = null;

                  try
                  {
                     oCommand = this.Data.GetCommand();
                     oCommand.CommandText = "SELECT * FROM " + oRow["ObjectName"].ToString() + "";

                     oDataTable = this.Data.GetDataTable(oCommand);
                     oDataTable.TableName = oRow["ObjectName"].ToString();

                     oDataSet = new DataSet(oRow["ObjectName"].ToString() + "Dataset");
                     oDataSet.Tables.Add(oDataTable);
                     this.WriteXml(oDataSet, oRow["ObjectName"].ToString());
                   }
                  catch(Exception ex){throw ex;}
                  finally
                  {
                     if (oDataSet != null)
                     {
                        oDataSet.Dispose();
                        oDataSet=null;
                      }
                     if (oDataTable != null)
                     {
                        oDataTable.Dispose();
                        oDataTable=null;
                      }
                     if (oCommand != null)
                     {
                        oCommand.Dispose();
                        oCommand=null;
                      }
                   }
                }

               oObjects.TableName = "DATAs";
               this.Types.Tables.Add(oObjects);
             }

          }
         catch(Exception ex){throw ex;}
         finally
         {
            if (oObjects != null)
            {
               oObjects.Dispose();
               oObjects = null;
             }
            if (oDataView != null)
            {
               oDataView.Dispose();
               oDataView = null;
             }
          }

       }
      #endregion

      #region Execute_ZIP
      private bool Execute_ZIP()
      {
         bool bRet = false;
         fs.Common.ZIP.ZIP oZIP = null;
         try
         {
            oZIP = new fs.Common.ZIP.ZIP(this.FilePath);
            oZIP.Create(this.WorkingFolder);

            string[] aFiles = System.IO.Directory.GetFiles(this.WorkingFolder);
            this.Progress.ProgressStart(aFiles.Length);
            foreach(string sFile in aFiles)
            {
               this.Progress.Progress();
               oZIP.AddFile(sFile);
             }
            bRet = oZIP.Save();
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

      #region WriteXml
      private void WriteXml(DataSet oDataSet, string sName)
      {
         string sXmlPath = string.Empty;
         System.Xml.XmlWriterSettings oSettings = null;
         System.Xml.XmlWriter oXmlWriter = null;

         try
         {
            sXmlPath = this.WorkingFolder + sName + ".xml";

            oSettings = new System.Xml.XmlWriterSettings();
            oSettings.Indent = false;
            oSettings.CheckCharacters = false;

            //System.IO.MemoryStream oMemoryStream = new System.IO.MemoryStream(); 
            //oXmlWriter = System.Xml.XmlWriter.Create(oMemoryStream, oSettings);
            oXmlWriter = System.Xml.XmlWriter.Create(sXmlPath, oSettings);
            oDataSet.WriteXml(oXmlWriter);
            oXmlWriter.Flush();
            oXmlWriter.Close();
          }
         catch(Exception ex){throw ex;}
         finally
         {
            oSettings = null;
            oXmlWriter = null;
          }
       }
      #endregion 

      #region GetExportStrategyByType
      private Int16 GetExportStrategyByType(string sType, ref DataView oDataView)
      {
         Int16 iRet = 0;
         try
         {
            oDataView = new DataView();
            oDataView.Table = this.Package.ObjectsTable;
            oDataView.RowFilter = "Type = '" + sType + "'";
            oDataView.Sort = "Name";

            if (oDataView.Count == 1 && ((Int16)oDataView[0].Row["Status"]) == 0)
            {
               iRet = 0;
             }
            else if (oDataView.Count == 1 && ((Int16)oDataView[0].Row["Status"]) == 1)
            {
               iRet = 1;
             }
            else if (oDataView.Count != 0 && ((Int16)oDataView[0].Row["Status"]) == 2)
            {
               iRet = 2;
             }
          }
         catch(Exception ex){throw ex;}
         return iRet;
       }
      #endregion

      #endregion

      #region PROPERTIES

      #region Package
      private Package oPackage = null;
      private Package Package
      {
         get{return oPackage;}
         set
         {
            oPackage = value;
            oPackage.GetConnector += new Package.GetConnectorEventHandler(Package_GetConnector);
          }
       }
      #endregion

      #region Wizard
      private Wizard.WizardForm oWizard = null;
      private Wizard.WizardForm Wizard
      {
         get
         {
            if (oWizard == null)
            {
               oWizard = new FS.Package.Wizard.WizardForm();
               oWizard.GetData += new Wizard.WizardForm.GetDataEventHandler(this.Wizard_GetData);
               oWizard.GetPackage += new Wizard.WizardForm.GetPackageEventHandler(this.Wizard_GetPackage);
             }
            return oWizard;
          }
       }
      #endregion

      #region Types
      private DataSet oTypes = null;
      private DataSet Types
      {
         get{return oTypes;}
         set{oTypes=value;}
       }
      #endregion 

      #endregion

      #region EVENTS 

      #region Wizard_GetData
      private void Wizard_GetData(ref FS.Data.Common.Data oData)
      {
         oData = this.Data;
       }
      #endregion

      #region Wizard_GetPackage
      private void Wizard_GetPackage(ref Package value)
      {
         value = this.Package;
       }
      #endregion

      #region Package_GetConnector
      private void Package_GetConnector(ref string value)
      {
         value = this.Connector;
       }
      #endregion

      #endregion

   }

}
