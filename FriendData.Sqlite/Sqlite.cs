﻿using System;
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
         return null;
         /*
         return "" +
            "SELECT " +
               "tCOLUMNS.TABLE_NAME As TableName, " +
               "tCOLUMNS.ORDINAL_POSITION As ColumnID, " +
               "tCOLUMNS.COLUMN_NAME As ColumnName, " +
               "tCOLUMNS.DATA_TYPE As TypeName, " +
               "tCOLUMNS.CHARACTER_MAXIMUM_LENGTH As TypeSize, " +
               "tCOLUMNS.COLLATION_NAME As ColumnCollation, " +
               "cast((case when tCOLUMNS.IS_NULLABLE='YES' then 1 else 0 end) as smallint) As isNullable, " +
               "Null As isIdentity, " +
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
            */
      }
      #endregion

      #region Base_InitializeSchema_INDEXES
      private string Base_InitializeSchema_INDEXES(string ObjectName, bool FullData)
      {
         return null;
         /*
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
            */
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