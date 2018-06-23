using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Data
{
   public class Sqlite : Common.Data
   {

      #region NEW
      public Sqlite()
      {
         this.EngineType += Base_EngineType;
         this.GetConnectionStringSteps += Base_GetConnectionStringSteps;
         this.GetConnectionStringParams += Base_GetConnectionStringParams;
         this.InitializeConnection += Base_InitializeConnection;
         this.InitializeAdapter += Base_InitializeAdapter;
         this.InitializeCommand += Base_InitializeCommand;
         this.InitializeCommandBuilder += Base_InitializeCommandBuilder;
         this.InitializeSchema += Base_InitializeSchema;
         //this.InitializeScript += Base_InitializeScript;
      }
      #endregion

      #region METHODS

      #region GetConnectionString
      public static string GetConnectionString(string DataSource)
      {
         string strRET = string.Empty;

         strRET +=
            "Data Source=" + DataSource + ";" +
            "";

         return strRET;
      }
      #endregion

      #endregion

      #region EVENTS

      #region Base_EngineType
      private void Base_EngineType(ref FS.Data.Common.Engine.Type Value)
      {
         Value.Key = "sqlite";
         Value.Description = "SQLite";
         Value.Icon = Resources.Icon;
      }
      #endregion

      #region Base_GetConnectionStringSteps
      private void Base_GetConnectionStringSteps(ref System.Collections.ArrayList Value)
      {
         Value = new System.Collections.ArrayList();
         Value.Add(new object[] { "Path", "Inform the full path for the database file" });
      }
      #endregion

      #region Base_GetConnectionStringParams
      private void Base_GetConnectionStringParams(ref Common.ConnKeys Value)
      {
         Value = new Common.ConnKeys();
         Value.Add("Data Source", string.Empty.GetType(), "Path");
      }
      #endregion


      #region Base_InitializeConnection
      private void Base_InitializeConnection(ref System.Data.Common.DbConnection Value)
      {
         Value = new System.Data.SQLite.SQLiteConnection(this.ConnectionString);
      }
      #endregion

      #region Base_InitializeAdapter
      private void Base_InitializeAdapter(ref System.Data.Common.DbDataAdapter Value)
      {
         Value = new System.Data.SQLite.SQLiteDataAdapter();
      }
      #endregion

      #region Base_InitializeCommand
      private void Base_InitializeCommand(ref System.Data.Common.DbCommand Value)
      {
         Value = new System.Data.SQLite.SQLiteCommand();
      }
      #endregion

      #region Base_InitializeCommandBuilder
      private void Base_InitializeCommandBuilder(ref System.Data.Common.DbCommandBuilder Value)
      {
         Value = new System.Data.SQLite.SQLiteCommandBuilder();
      }
      #endregion


      #region Base_InitializeSchema
      private void Base_InitializeSchema(ref System.Data.DataTable Value, Common.SchemaTypeEnum SchemaType, string ObjectName, bool FullData)
      {
         System.Data.Common.DbCommand objCommand = null;
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
         catch (Exception ex) { throw ex; }
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
         // if (FullData == true) { }
         return "" +
            "select " + 
               "name as ObjectName, " +
               "null As ObjectSchema, " +
               "null As ObjectIdentitySeed, " +
               "null As ObjectEngine, " +
               "null As ObjectCollation " +
            "from sqlite_master " + 
            "where " + 
               "type='table' " +
               (string.IsNullOrEmpty(ObjectName) ? "" : "And name like '" + ObjectName + "%'") + 
            "order by name asc" + 
            "";
      }
      #endregion

      #region Base_InitializeSchema_COLUMNS
      private string Base_InitializeSchema_COLUMNS(string ObjectName, bool FullData)
      {
         using (var cmd = this.GetCommand())
         {
            cmd.CommandText = "pragma table_info(" + ObjectName + ");";
            using (var table = this.GetDataTable(cmd))
            {
               var result = string.Empty;
               foreach (System.Data.DataRow row in table.Rows)
               {
                  result += (string.IsNullOrEmpty(result) ? "" : " union " + Environment.NewLine);
                  result += "select " +
                     "'" + ObjectName + "' As TableName, " +
                     row["cid"] + " As ColumnID, " +
                     "'" + row["name"] + "' As ColumnName, " +
                     "'" + row["type"] + "' As TypeName, " +
                     "null As TypeSize, " +
                     "null As ColumnCollation, " +
                     (row["notnull"].ToString() =="1" ? "0" : "1") + " As isNullable, " +
                     "Null As isIdentity, " +
                     row["pk"] + " As isPrimaryKey " +
                     "";
               }
               return result;
            }
         }
      }
      #endregion

      #region Base_InitializeSchema_INDEXES
      private string Base_InitializeSchema_INDEXES(string ObjectName, bool FullData)
      {
         return "" + 
            "select " +
               "'" + ObjectName + "' As TableName, " +
               "name As IndexName, " +
               "(" +
                  "case " +
                  "when (sql like '% unique index %')=1 then 'UNIQUE KEY' " +
                  "else 'KEY' " +
                  "end " +
                ") As IndexType, " +
               "null As ColumnName " +
            "from sqlite_master " + 
            "where " + 
               "type='index' and " + 
               "tbl_name='" + ObjectName + "' and " + 
               "sql <> ''" + 
            "";
      }
      #endregion

      #region Base_InitializeSchema_VIEWS
      private string Base_InitializeSchema_VIEWS(string ObjectName, bool FullData)
      {
         return null;
         /*
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
         */
      }
      #endregion

      #region Base_InitializeSchema_PROCEDURES
      private string Base_InitializeSchema_PROCEDURES(string ObjectName, bool FullData)
      {
         return null;
      }
      #endregion

      #region Base_InitializeSchema_FUNCTIONS
      private string Base_InitializeSchema_FUNCTIONS(string ObjectName, bool FullData)
      {
         return null;
      }
      #endregion

      #endregion

   }
}