using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using FS.Data;

namespace FS.Data
{
   public class MsSQL : Common.Data
   {

      #region NEW
      public MsSQL()	
		{
         this.EngineType += Base_EngineType;
         this.GetConnectionStringParams += Base_GetConnectionStringParams;
         this.GetConnectionStringSteps += Base_GetConnectionStringSteps;
			this.InitializeConnection += Base_InitializeConnection; 
         this.InitializeAdapter += Base_InitializeAdapter; 
         this.InitializeCommand += Base_InitializeCommand;
         this.InitializeCommandBuilder += Base_InitializeCommandBuilder;
         this.InitializeSchema += Base_InitializeSchema;
         this.InitializeScript += Base_InitializeScript;
       }
      #endregion

      #region METHODS

      #region GetConnectionString
      public static string GetConnectionString(string DataSource, string UserID, string Password)
      {
         return GetConnectionString(DataSource, UserID, Password, "master");
       }
      public static string GetConnectionString(string DataSource, string UserID, string Password, string DataBase)
         {
            string strRET = string.Empty;

            strRET +=
               "Data Source=" + DataSource + ";" +
               "Initial Catalog=" + DataBase  + ";" +
               "User Id=" + UserID  + ";" +
               "Password=" + Password + ";" + 
               "";

            return strRET;
         }
         #endregion
      
      #endregion

      #region PROPERTIES

      #region DataBase
      private string tmp_DataBase;
      private string DataBase
      {
         get
         {
            if (string.IsNullOrEmpty(tmp_DataBase))
            {
               tmp_DataBase = this.GetConnectionStringParam("Initial Catalog");
            }
            return tmp_DataBase;
         }
      }
      #endregion

      #endregion

      #region EVENTS

      #region Base_EngineType
      private void Base_EngineType(ref FS.Data.Common.Engine.Type Value)
      {
         Value.Key = "sqlserver";
         Value.Description = "SQL Server";
         Value.Icon = Resources.Icon;
       }
      #endregion

      #region Base_GetConnectionStringSteps
      private void Base_GetConnectionStringSteps(ref System.Collections.ArrayList Value)
      {
         Value = new System.Collections.ArrayList();
         Value.Add(new object[] { "Server", "Inform the server you want to connect" });
         Value.Add(new object[] { "Auth", "Set your authentication identification" });
         Value.Add(new object[] { "DataBase", "Chose the database from the server" });
       }
      #endregion

      #region Base_GetConnectionStringParams
      private void Base_GetConnectionStringParams(ref Common.ConnKeys Value)
      {
         Value = new Common.ConnKeys();
         Value.Add("DataSource", string.Empty.GetType(), "Server");
         Value.Add("UserID", string.Empty.GetType(), "Auth");
         Value.Add("Password", string.Empty.GetType(), "Auth").Required = false;
         Value.Add("DataBase", string.Empty.GetType(), "DataBase", "master").Required = false;
       }
      #endregion

      
      #region Base_InitializeConnection
         private void Base_InitializeConnection(ref System.Data.Common.DbConnection Value)
         {
            Value = new SqlConnection(this.ConnectionString);
          }
      #endregion
   
      #region Base_InitializeAdapter
         private void Base_InitializeAdapter(ref System.Data.Common.DbDataAdapter Value)
         {
            Value = new SqlDataAdapter();
          }
      #endregion
      
      #region Base_InitializeCommand
      private void Base_InitializeCommand(ref System.Data.Common.DbCommand Value)
      {
         Value = new SqlCommand();
       }
      #endregion

      #region Base_InitializeCommandBuilder
      private void Base_InitializeCommandBuilder(ref System.Data.Common.DbCommandBuilder Value)
      {
         Value = new SqlCommandBuilder();
       }
      #endregion


      #region Base_InitializeSchema
      private void Base_InitializeSchema(ref DataTable Value, Common.SchemaTypeEnum SchemaType, string ObjectName, bool FullData)
      {
         DbCommand objCommand = null;
         try
         {
            objCommand = this.GetCommand();

            if (SchemaType == Common.SchemaTypeEnum.TABLES)
               { objCommand.CommandText = Base_InitializeSchema_TABLES(ObjectName, FullData); }
            else if (SchemaType == Common.SchemaTypeEnum.COLUMNS)
               { objCommand.CommandText = Base_InitializeSchema_COLUMNS(ObjectName, FullData); }
            else if (SchemaType == Common.SchemaTypeEnum.INDEXES)
               { objCommand.CommandText = Base_InitializeSchema_INDEXES(ObjectName, FullData); }
            else if (SchemaType == Common.SchemaTypeEnum.VIEWS)
               { objCommand.CommandText = Base_InitializeSchema_VIEWS(ObjectName, FullData); }
            else if (SchemaType == Common.SchemaTypeEnum.PROCEDURES)
               { objCommand.CommandText = Base_InitializeSchema_PROCEDURES(ObjectName, FullData); }
            else if (SchemaType == Common.SchemaTypeEnum.FUNCTIONS)
               { objCommand.CommandText = Base_InitializeSchema_FUNCTIONS(ObjectName, FullData); }

            Value = this.GetDataTable(objCommand);
         }
         catch (Exception ex) {throw ex;}
         finally
         {
            if (objCommand != null)
            {
               objCommand.Dispose();
               objCommand = null;
            }
         }
      }
      #endregion

      #region Base_InitializeSchema_TABLES
      private string Base_InitializeSchema_TABLES(string ObjectName, bool FullData)
      {
         string sAdditionalColumns = string.Empty;
         if (FullData == true)
         {
            sAdditionalColumns = ", " +
               "IDENT_SEED(TABLE_NAME) As ObjectIdentitySeed, " +
               "null As ObjectEngine, " + 
               "null As ObjectCollation" + 
               "";
          }

         return "" +
         "SELECT " +
            "TABLE_NAME As ObjectName, " +
            "TABLE_SCHEMA As ObjectSchema" +
            sAdditionalColumns + " " + 
         "FROM information_schema.TABLES " +
         "WHERE " +
            "TABLE_CATALOG = '" + this.DataBase + "' And " +
            "TABLE_TYPE = 'BASE TABLE' And " +
            "TABLE_NAME not in ('sysdiagrams', 'dtproperties') " + 
            (string.IsNullOrEmpty(ObjectName) ? "" : "And TABLE_NAME like '" + ObjectName + "'") +
         "ORDER BY " +
            "TABLE_NAME Asc " +
         "";

       }
      #endregion

      #region Base_InitializeSchema_COLUMNS
      private string Base_InitializeSchema_COLUMNS(string ObjectName, bool FullData)
      {

         return "" +
            "SELECT " +
               "tCOLUMNS.TABLE_NAME As TableName, " +
               "tCOLUMNS.ORDINAL_POSITION As ColumnID, " +
               "tCOLUMNS.COLUMN_NAME As ColumnName, " +
               "tCOLUMNS.DATA_TYPE As TypeName, " +
               "tCOLUMNS.CHARACTER_MAXIMUM_LENGTH As TypeSize, " +
               "tCOLUMNS.COLLATION_NAME As ColumnCollation, " +
               "cast((case when tCOLUMNS.IS_NULLABLE='YES' then 1 else 0 end) as smallint) As isNullable, " +
               "/*(case when (sysColumns.STATUS & 128)=128 then 1 else 0 end)*/ Null As isIdentity, " +
               "cast((case when coalesce(tUSAGE.ORDINAL_POSITION,0)<>0 then 1 else 0 end) as smallint) As isPrimaryKey " +
            "FROM information_schema.COLUMNS tCOLUMNS " +
               "LEFT JOIN information_schema.TABLE_CONSTRAINTS tCONSTRAINTS On " +
               "(" +
                  "tCONSTRAINTS.TABLE_CATALOG = tCOLUMNS.TABLE_CATALOG And " + 
                  "tCONSTRAINTS.TABLE_NAME = tCOLUMNS.TABLE_NAME And " + 
                  "tCONSTRAINTS.CONSTRAINT_TYPE = 'PRIMARY KEY' " + 
                ")" + 
               "LEFT JOIN information_schema.KEY_COLUMN_USAGE tUSAGE On " +
               "(" +
                  "tUSAGE.CONSTRAINT_CATALOG = tCONSTRAINTS.CONSTRAINT_CATALOG And " + 
                  "tUSAGE.CONSTRAINT_NAME = tCONSTRAINTS.CONSTRAINT_NAME And " + 
                  "tUSAGE.TABLE_NAME = tCOLUMNS.TABLE_NAME And " + 
                  "tUSAGE.COLUMN_NAME = tCOLUMNS.COLUMN_NAME " + 
                ")" +
            "WHERE " +
               "tCOLUMNS.TABLE_CATALOG = '" + this.DataBase + "' And " +
               "tCOLUMNS.TABLE_NAME = '" + ObjectName + "' " +
            "ORDER BY " +
               "tCOLUMNS.ORDINAL_POSITION " +
            "";

         /*
         return "" +
         "SELECT " +
            "sysObjects.NAME TableName, " +
            "sysColumns.NAME ColumnName, " +
            "sysTypes.NAME + " +
               "Case " +
               "When sysTypes.Name In ('VARCHAR', 'CHAR') " +
               "Then '(' + lTrim(str(sysColumns.LENGTH)) + ')' " +
               "Else '' " +
               "End [Type], " +
            "sysTypes.NAME TypeName, " +
            "sysColumns.LENGTH [Length], " +
            "sysColumns.ISNULLABLE As isNullable, " +
            "(case when (sysColumns.STATUS & 128)=128 then 1 else 0 end) As isIdentity, " +
            "sysColumns.COLORDER ColumnID, " +
            "coalesce(sysIndexKeys.KEYNO,0) PrimaryKeyID " +
         "FROM sysColumns " +
            "INNER JOIN sysObjects On (sysColumns.ID = sysObjects.ID) " +
            "INNER JOIN sysTypes On (sysTypes.xType = sysColumns.xType) " +
            "LEFT JOIN sysIndexes On " +
            "(" +
               "sysIndexes.ID = sysObjects.ID And " +
               "(sysIndexes.Status & 2048) = 2048 " +
             ") " +
            "LEFT JOIN sysIndexKeys On " +
            "(" +
               "sysIndexKeys.ID = sysIndexes.ID And " +
               "sysIndexKeys.indID = sysIndexes.indID And " +
               "sysIndexKeys.colID = sysColumns.colID " +
             ") " +
         "WHERE " +
            "sysObjects.XTYPE ='U' " +
            (string.IsNullOrEmpty(ObjectName) ? "" : "And sysObjects.NAME like '" + ObjectName + "'") +
         "ORDER BY " +
            "sysObjects.NAME, " +
            "sysColumns.COLORDER " +
         "";
         */

      }
      #endregion

      #region Base_InitializeSchema_INDEXES
      private string Base_InitializeSchema_INDEXES(string ObjectName, bool FullData)
      {

         return "" +
            "SELECT " +
               "obj.Name As TableName, " +
               "ind.Name As IndexName, " +
               "(" +
                  "case " +
                  "when ind.is_unique=1 then 'UNIQUE KEY' " +
                  "else 'KEY' " +
                  "end " +
                ") As IndexType, " +
               "col.Name As ColumnName " +
            "FROM sys.Indexes ind " +
               "INNER JOIN sys.objects obj on (obj.object_id = ind.object_id And obj.Type = 'U') " +
               "LEFT JOIN sys.index_columns indcol On (indcol.object_id = ind.object_id And indcol.index_id = ind.index_id) " +
               "LEFT JOIN sys.columns col On (col.object_id = indcol.object_id And col.column_id = indcol.column_id) " +
            "WHERE " +
               "obj.Name = '" + ObjectName + "' And " +
               "ind.is_primary_key <> 1 And " + 
               "ind.Type <> 0 " + 
            "ORDER BY " +
               "obj.Name, " +
               "ind.Name, " + 
               "indcol.key_ordinal " + 
            "";

      }
      #endregion

      #region Base_InitializeSchema_VIEWS
      private string Base_InitializeSchema_VIEWS(string ObjectName, bool FullData)
      {
         string sAdditionalColumns = string.Empty;
         if (FullData == true)
         {
            sAdditionalColumns = ", VIEW_DEFINITION As ObjectDefinition";
         }

         return "" +
         "SELECT " +
            "TABLE_NAME As ObjectName, " +
            "TABLE_SCHEMA As ObjectSchema" +
            sAdditionalColumns + " " + 
         "FROM information_schema.VIEWS " +
         "WHERE " +
            "TABLE_CATALOG = '" + this.DataBase + "' " +
            (string.IsNullOrEmpty(ObjectName) ? "" : "And TABLE_NAME like '" + ObjectName + "'") +
         "ORDER BY " +
            "TABLE_NAME Asc " +
         "";
       }
      #endregion

      #region Base_InitializeSchema_PROCEDURES
      private string Base_InitializeSchema_PROCEDURES(string ObjectName, bool FullData)
      {
         string sAdditionalColumns = string.Empty;
         if (FullData == true)
         {
            sAdditionalColumns = ", ROUTINE_DEFINITION As ObjectDefinition";
          }

         return "" +
         "SELECT " +
            "ROUTINE_NAME As ObjectName, " + 
            "ROUTINE_SCHEMA As ObjectSchema" +
            sAdditionalColumns + " " + 
         "FROM information_schema.ROUTINES " +
         "WHERE " +
            "ROUTINE_CATALOG = '" + this.DataBase + "' And " +
            "ROUTINE_TYPE = 'PROCEDURE' " +
            (string.IsNullOrEmpty(ObjectName) ? "" : "And ROUTINE_NAME like '" + ObjectName + "'") +
         "ORDER BY " +
            "ROUTINE_NAME Asc " +
         "";
       }
      #endregion

      #region Base_InitializeSchema_FUNCTIONS
      private string Base_InitializeSchema_FUNCTIONS(string ObjectName, bool FullData)
      {
         string sAdditionalColumns = string.Empty;
         if (FullData == true)
         {
            sAdditionalColumns = ", ROUTINE_DEFINITION As ObjectDefinition";
         }

         return "" +
         "SELECT " +
            "ROUTINE_NAME As ObjectName, " + 
            "ROUTINE_SCHEMA As ObjectSchema" +
            sAdditionalColumns + " " + 
         "FROM information_schema.ROUTINES " +
         "WHERE " +
            "ROUTINE_CATALOG = '" + this.DataBase + "' And " +
            "ROUTINE_TYPE = 'FUNCTION' " +
            (string.IsNullOrEmpty(ObjectName) ? "" : "And ROUTINE_NAME like '" + ObjectName + "'") +
         "ORDER BY " +
            "ROUTINE_NAME Asc " +
         "";
       }
      #endregion


      #region Base_InitializeScript
      private void Base_InitializeScript(ref string value, Common.ScriptTypeEnum ScriptType, object[] objects)
      {
         try
         {

            if (ScriptType == Common.ScriptTypeEnum.TABLE)
               { value = this.Base_InitializeScript_TABLE(objects); }
            else if (ScriptType == Common.ScriptTypeEnum.differenceTABLE)
               { value = this.Base_InitializeScript_differenceTABLE(objects); }

          }
         catch (Exception ex) {throw ex;}
         finally
         {
          }
       }
      #endregion

      #region Base_InitializeScript_TABLE
      private string Base_InitializeScript_TABLE(object[] objects)
      {
         string sReturn = string.Empty;
         string sReturnColumns = string.Empty;
         string sReturnPK = string.Empty;
         DataRow drTable = null;
         DataTable dtColumns = null;
         try
         {
            drTable = ((DataRow)objects.GetValue(0));
            dtColumns = ((DataTable)objects.GetValue(1));

            foreach(DataRow drColumn in dtColumns.Rows)
            {
               sReturnColumns += (string.IsNullOrEmpty(sReturnColumns) ? string.Empty : ", " + Environment.NewLine);
               sReturnColumns += " [" + drColumn["ColumnName"].ToString() + "] ";

               sReturnColumns += drColumn["TypeName"].ToString();
               if (!drColumn.IsNull("TypeSize") && Convert.ToInt16(drColumn["TypeSize"]) != 0)
               {
                  sReturnColumns += "(";
                  sReturnColumns += Convert.ToInt16(drColumn["TypeSize"]).ToString();
                  sReturnColumns += ")";
                }

               if (Convert.ToInt16(drColumn["isNullable"]) == 0) {sReturnColumns += " not";}
               sReturnColumns += " null";

               if (Convert.ToInt16(drColumn["isPrimaryKey"]) == 1) 
               {
                  sReturnPK += (string.IsNullOrEmpty(sReturnPK) ? string.Empty : ",");
                  sReturnPK += "[" + drColumn["ColumnName"].ToString() + "]";
                }
             }

            sReturn = "CREATE TABLE dbo." + drTable["ObjectName"].ToString() + Environment.NewLine;
            sReturn += "(" + Environment.NewLine;
            sReturn += sReturnColumns;
            if (string.IsNullOrEmpty(sReturnPK))
               {sReturn += Environment.NewLine;}
            else 
               {
                  sReturn += "," + Environment.NewLine;
                  sReturn += " CONSTRAINT ";
                  sReturn += "[PK_" + drTable["ObjectName"].ToString() +"] PRIMARY KEY " + Environment.NewLine;
                  sReturn += " (" + sReturnPK + ")" + Environment.NewLine;
                }
            sReturn += " )" + Environment.NewLine;

          }
         catch (Exception ex) {throw ex;}
         finally
         {
            drTable = null;
            if (dtColumns != null)
            {
               dtColumns.Dispose();
               dtColumns = null;
             }
          }
         return sReturn;
       }
      #endregion 

      #region Base_InitializeScript_differenceTABLE
      private string Base_InitializeScript_differenceTABLE(object[] objects)
      {
         string sReturn = string.Empty;
         string sColumnsPK = string.Empty;
         string sColumnsChanged = string.Empty;
         string sColumnsAdded = string.Empty;
         string sColumnsRemoved = string.Empty;
         bool bPKsRemove = false;
         bool bPKsAdd = false;
         DataRow drOldTable = null;
         DataTable dtOldColumns = null;
         DataRow drNewTable = null;
         DataTable dtNewColumns = null;

         try
         {
            drNewTable = ((DataRow)objects.GetValue(0));
            dtNewColumns = ((DataTable)objects.GetValue(1));
            drOldTable = ((DataRow)objects.GetValue(2));
            dtOldColumns = ((DataTable)objects.GetValue(3));

            foreach(DataRow drChangedColumn in dtNewColumns.Rows)
            {
               DataRow[] drCurrentColumnArray = dtOldColumns.Select("ColumnName = '" + drChangedColumn["ColumnName"].ToString() + "'" );

               //CHANGED COLUMNS
               if (drCurrentColumnArray != null && drCurrentColumnArray.Length != 0)
               {
                  DataRow drCurrentColumn = ((DataRow)drCurrentColumnArray.GetValue(0));

                  //CHECK PK
                  if (drCurrentColumn["isPrimaryKey"].ToString() != drChangedColumn["isPrimaryKey"].ToString())
                  {
                     if (drCurrentColumn["isPrimaryKey"].ToString()=="1")
                        {bPKsRemove = true;}
                     if (drChangedColumn["isPrimaryKey"].ToString()=="1")
                        {bPKsAdd = true;}
                   }
                  if (drChangedColumn["isPrimaryKey"].ToString()=="1")
                  {
                     sColumnsPK += (string.IsNullOrEmpty(sColumnsPK) ? string.Empty : ",") + drChangedColumn["ColumnName"].ToString();
                   }

                  //CHECK COLUMN
                  if (drCurrentColumn["TypeName"].ToString() != drChangedColumn["TypeName"].ToString() || 
                      drCurrentColumn["TypeSize"].ToString() != drChangedColumn["TypeSize"].ToString() || 
                      drCurrentColumn["ColumnCollation"].ToString() != drChangedColumn["ColumnCollation"].ToString() ||
                      drCurrentColumn["isNullable"].ToString() != drChangedColumn["isNullable"].ToString() )
                  {
                     sColumnsChanged += 
                        //(string.IsNullOrEmpty(sColumnsChanged) ? string.Empty : this.Delimiter + Environment.NewLine) + 
                        "ALTER TABLE dbo." + drNewTable["ObjectName"].ToString() + " ALTER COLUMN " + 
                        drChangedColumn["ColumnName"].ToString() + " " + 
                        drChangedColumn["TypeName"].ToString() + 
                        (Convert.ToInt16(drChangedColumn["TypeSize"])==0 ? string.Empty : "(" + drChangedColumn["TypeSize"].ToString() + ")") + " " + 
                        (string.IsNullOrEmpty(drChangedColumn["ColumnCollation"].ToString()) ? string.Empty : "COLLATE " + drChangedColumn["ColumnCollation"].ToString() + " ") + 
                        (drChangedColumn["isNullable"].ToString()!="1" ? "not " : "") + "null " + 
                        this.Delimiter + Environment.NewLine + 
                        "";
                   }
                }

               // ADDED COLUMNS
               else
               {

                  //CHECK PK
                  if (drChangedColumn["isPrimaryKey"].ToString()=="1")
                  {
                     sColumnsPK += (string.IsNullOrEmpty(sColumnsPK) ? string.Empty : ",") + drChangedColumn["ColumnName"].ToString();
                     bPKsAdd = true;
                   }

                  //CHECK COLUMN
                  sColumnsAdded += 
                     (string.IsNullOrEmpty(sColumnsAdded) ? string.Empty : ", " + Environment.NewLine) + 
                     " " + 
                     drChangedColumn["ColumnName"].ToString() + " " + 
                     drChangedColumn["TypeName"].ToString() + 
                     (drChangedColumn.IsNull("TypeSize") || Convert.ToInt16(drChangedColumn["TypeSize"])==0 ? string.Empty : "(" + drChangedColumn["TypeSize"].ToString() + ")") + " " + 
                     (drChangedColumn["isNullable"].ToString()!="1" ? "not " : "") + "null " + 
                     "";
                }
             }

            //REMOVED COLUMNS
            foreach(DataRow drCurrentColumn in dtOldColumns.Rows)
            {
               if (dtNewColumns.Select("ColumnName = '" + drCurrentColumn["ColumnName"].ToString() + "'" ).Length==0)
               {
                  if (drCurrentColumn["isPrimaryKey"].ToString()=="1")
                  {
                     bPKsRemove = true;
                   }

                  sColumnsRemoved += 
                     //(string.IsNullOrEmpty(sColumnsRemoved) ? string.Empty : this.Delimiter + Environment.NewLine) + 
                     "ALTER TABLE dbo." + drNewTable["ObjectName"].ToString() + " DROP COLUMN " + 
                     drCurrentColumn["ColumnName"].ToString() + " " + 
                     this.Delimiter + Environment.NewLine + 
                     "";
                }
             }

            //RETURN
            sReturn = string.Empty;
            if (! string.IsNullOrEmpty(sColumnsRemoved))
            {
               sReturn += sColumnsRemoved;
             }
            if (! string.IsNullOrEmpty(sColumnsChanged))
            {
               sReturn += sColumnsChanged;
             }
            if (! string.IsNullOrEmpty(sColumnsAdded))
            {
               sReturn += "ALTER TABLE dbo." + drNewTable["ObjectName"].ToString() + " " + 
                  "ADD " + Environment.NewLine + 
                  sColumnsAdded + 
                  this.Delimiter + Environment.NewLine + 
                  "";
             }
            if (bPKsRemove == true)
            {
               sReturn += "ALTER TABLE dbo." + drNewTable["ObjectName"].ToString() + " " + 
                  "DROP CONSTRAINT PK_" + drNewTable["ObjectName"].ToString() + 
                  this.Delimiter + Environment.NewLine;
             }
            if (bPKsAdd == true)
            {
               sReturn += "ALTER TABLE dbo." + drNewTable["ObjectName"].ToString() + " " + 
                  "ADD CONSTRAINT PK_" + drNewTable["ObjectName"].ToString() + 
	               "PRIMARY KEY CLUSTERED (" + sColumnsPK + ") " +
                  this.Delimiter + Environment.NewLine;
             }

          }
         catch (Exception ex) {throw ex;}

         return sReturn;
       }
      #endregion 

      #endregion

   }
}
