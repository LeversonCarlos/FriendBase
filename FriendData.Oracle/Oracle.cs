using System;
using System.Data;
using System.Data.Common;
using FS.Data;
using System.Data.OracleClient;

namespace FS.Data
{
	public class Oracle: Common.Data
   {

      #region NEW
      public Oracle()	
		{
			this.InitializeConnection += Base_InitializeConnection; 
         this.InitializeAdapter += Base_InitializeAdapter; 
         this.InitializeCommand += Base_InitializeCommand;
         this.InitializeCommandBuilder += Base_InitializeCommandBuilder;
         this.InitializeSchema += Base_InitializeSchema;
         this.GetConnectionStringParams += Base_GetConnectionStringParams;
         this.GetConnectionStringSteps += Base_GetConnectionStringSteps;
         this.EngineType += Base_EngineType;
      }
      #endregion

      #region METHODS

      #region GetConnectionString
      /*
      public static string GetConnectionString(string DataSource, string UserID, string Password, string DataBase)
      {
         return GetConnectionString(DataSource, UserID, Password, DataBase, 1521);
       }
      */ 
      public static string GetConnectionString(string DataSource, string UserID, string Password, string DataBase, Int16 Port)
      {
         string strRET = string.Empty;
         //strRET += "Data Source=" + DataSource + ";";

         strRET +=
            "Data Source = " +
            "(" +
               "DESCRIPTION = "+
               "("+
                  "ADDRESS = "+
                  "(PROTOCOL = TCP)"+
                  "(HOST = " + DataSource + ")"+
                  "(PORT = " + Port.ToString() + ")"+
                ")" + 
             "";

         if (!string.IsNullOrEmpty(DataBase))
         {
            //strRET += "(" +"CONNECT_DATA=" + "(SID=" + DataBase + ")" + ")" + "";
            strRET +=
               "(" +
                  "CONNECT_DATA = " +
                  "(SERVICE_NAME = " + DataBase + ")" +
                ")" +
               "";
         }
         strRET += "); ";

         strRET +=
            "User Id=" + UserID + ";" +
            "Password=" + Password + ";" +
            "Integrated Security=no;" + 
            "";

         return strRET;
       }
      #endregion
      
      #endregion

      #region PROPERTIES 

         #region UserID
         private string tmp_UserID;
         private string UserID
         {
            get 
            {
               if (string.IsNullOrEmpty(tmp_UserID))
               {
                  tmp_UserID = this.GetConnectionStringParam("USER ID");
               }
               return tmp_UserID;
            }
         }
         #endregion

      #endregion

      #region EVENTS

         #region Base_EngineType
         private void Base_EngineType(ref FS.Data.Common.Engine.Type Value)
         {
            Value.Key = "oracle";
            Value.Description = "Oracle";
            Value.Icon = Resources.Icon;
         }
         #endregion

         #region Base_InitializeConnection
         private void Base_InitializeConnection(ref System.Data.Common.DbConnection Value)
            {
               Value = new OracleConnection(this.ConnectionString);
             }
         #endregion
      
         #region Base_InitializeAdapter
            private void Base_InitializeAdapter(ref System.Data.Common.DbDataAdapter Value)
            {
               Value = new OracleDataAdapter();
             }
         #endregion
      
         #region Base_InitializeCommand
            private void Base_InitializeCommand(ref System.Data.Common.DbCommand Value)
            {
               Value = new OracleCommand();
             }
         #endregion

         #region Base_InitializeCommandBuilder
            private void Base_InitializeCommandBuilder(ref System.Data.Common.DbCommandBuilder Value)
            {
               Value = new OracleCommandBuilder();
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
               else if (SchemaType == Common.SchemaTypeEnum.DATABASES)
                  {objCommand.CommandText = Base_InitializeSchema_DATABASES();}
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

         #region Base_InitializeSchema_DATABASES
         private string Base_InitializeSchema_DATABASES()
         {
            return "SELECT null As Database FROM Dual WHERE '1'='2'";
         }
         #endregion

         #region Base_InitializeSchema_TABLES
         private string Base_InitializeSchema_TABLES(string ObjectName, bool FullData)
         {
            if (FullData == true)
            {
               return "" +
                  "SELECT " +
                     "obj.OBJECT_NAME ObjectName, " +
                     "obj.OWNER As ObjectSchema, " +
                     "null As ObjectIdentitySeed, " +
                     "null As ObjectEngine, " +
                     "null As ObjectCollation, " +
                     "depIndex.REFERENCED_NAME As oracle_SequenceName, " +
                     "depIndex.NAME As oracle_IndexName " +
                  "FROM ALL_OBJECTS obj " +
                     "LEFT JOIN ALL_DEPENDENCIES depTable On " +
                     "(" +
                        "depTable.REFERENCED_OWNER = obj.OWNER And " +
                        "depTable.REFERENCED_NAME = obj.OBJECT_NAME And " +
                        "depTable.REFERENCED_TYPE = 'TABLE' And " +
                        "depTable.TYPE = 'TRIGGER' " +
                      ") " +
                     "LEFT JOIN ALL_DEPENDENCIES depIndex On " +
                     "(" +
                        "depIndex.OWNER = depTable.OWNER And " +
                        "depIndex.NAME = depTable.NAME And " +
                        "depIndex.TYPE = depTable.TYPE And " +
                        "depIndex.REFERENCED_TYPE = 'SEQUENCE' " +
                      ") " +
                  "WHERE " +
                     "obj.OBJECT_TYPE = 'TABLE' And " +
                     "obj.OWNER = '" + this.UserID + "' " +
                     (string.IsNullOrEmpty(ObjectName) ? "" : "And obj.OBJECT_NAME like '" + ObjectName + "'") +
                  "ORDER BY " +
                     "obj.OBJECT_NAME" +
                  "";
             }
            else
            {
               return "" +
                  "SELECT " +
                     "obj.OBJECT_NAME ObjectName, " +
                     "obj.OWNER As ObjectSchema " +
                  "FROM ALL_OBJECTS obj " +
                  "WHERE " +
                     "obj.OBJECT_TYPE = 'TABLE' And " +
                     "obj.OWNER = '" + this.UserID + "' " +
                     (string.IsNullOrEmpty(ObjectName) ? "" : "And obj.OBJECT_NAME like '" + ObjectName + "'") +
                  "ORDER BY " +
                     "obj.OBJECT_NAME" +
                  "";
             }
          }
         #endregion

         #region Base_InitializeSchema_COLUMNS
         private string Base_InitializeSchema_COLUMNS(string ObjectName, bool FullData)
         {
            /* 
               "col.DATA_TYPE || " + 
                  "Case " + 
                  "When col.DATA_TYPE In ('DATE') " + 
                  "Then '' " + 
                  "Else " + 
                     "'(' || to_char(col.DATA_LENGTH) || ')' " + 
                  "End Type, " + 
            */

            return "" +
               "SELECT " +
                  "col.TABLE_NAME TableName, " +
                  "col.COLUMN_ID ColumnID, " +
                  "col.COLUMN_NAME ColumnName, " +
                  "col.DATA_TYPE TypeName, " +
                  "col.DATA_LENGTH TypeSize, " +
                  "null As ColumnCollation, " +
                  "cast((case when col.NULLABLE='Y' then 1 else 0 end) as smallint) As isNullable, " +
                  "null isIdentity, " +
                  "cast((case when coalesce(PKsCols.POSITION,0)<>0 then 1 else 0 end) as smallint) As isPrimaryKey " +
               "FROM ALL_TAB_COLUMNS col " +
                  "LEFT JOIN ALL_CONSTRAINTS PKs On " +
                  "(" +
                     "PKs.OWNER = col.OWNER And " + 
                     "PKs.TABLE_NAME = col.TABLE_NAME And " + 
                     "PKs.CONSTRAINT_TYPE = 'P' And " + 
                     "PKs.STATUS = 'ENABLED' " + 
                   ") " + 
                  "LEFT JOIN ALL_CONS_COLUMNS PKsCols On " +
                  "(" +
                     "PKsCols.OWNER = PKs.OWNER And " + 
                     "PKsCols.TABLE_NAME = PKs.TABLE_NAME And " + 
                     "PKsCols.CONSTRAINT_NAME = PKs.CONSTRAINT_NAME And " + 
                     "PKsCols.COLUMN_NAME = col.COLUMN_NAME " + 
                   ") " + 
               "WHERE " +
                  "col.OWNER = '" + this.UserID + "' " +
                  (string.IsNullOrEmpty(ObjectName) ? "" : "And col.TABLE_NAME like '" + ObjectName + "'") +
               "ORDER BY " +
                  "col.TABLE_NAME, " +
                  "col.COLUMN_ID " + 
               "";
         }
         #endregion

         #region Base_InitializeSchema_INDEXES
         private string Base_InitializeSchema_INDEXES(string ObjectName, bool FullData)
         {
            return "" +
            "SELECT " +
               "Ind.TABLE_NAME TableName, " +
               "Ind.INDEX_NAME IndexName, " +
               "(" +
                  "case " +
                  "when Ind.UNIQUENESS = 'UNIQUE' then 'UNIQUE KEY' " +
                  "else 'KEY' " +
                  "end " +
                ") As IndexType, " +
               "IndCol.COLUMN_NAME ColumnName " + 
            "FROM ALL_INDEXES Ind " +
               "INNER JOIN ALL_IND_COLUMNS IndCol On " + 
               "(" +
                  "IndCol.INDEX_OWNER = Ind.OWNER And " + 
                  "IndCol.INDEX_NAME = Ind.INDEX_NAME And " + 
                  "IndCol.TABLE_OWNER = Ind.TABLE_OWNER And " + 
                  "IndCol.TABLE_NAME = Ind.TABLE_NAME " + 
                ") " + 
            "WHERE " +
               "Ind.TABLE_TYPE = 'TABLE' And " + 
               "Ind.OWNER = '" + this.UserID + "' And " +
               "Ind.STATUS = 'VALID' And " +
               "Not Ind.INDEX_NAME Like 'sys_%' " +
               (string.IsNullOrEmpty(ObjectName) ? "" : "And Ind.TABLE_NAME like '" + ObjectName + "' ") +
            "ORDER BY " +
               "Ind.TABLE_NAME, " + 
               "Ind.INDEX_NAME, " + 
               "IndCol.COLUMN_POSITION " + 
            "";
         }
         #endregion

         #region Base_InitializeSchema_VIEWS
         private string Base_InitializeSchema_VIEWS(string ObjectName, bool FullData)
         {
            return null;
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
            Value.Add("DataBase", string.Empty.GetType(), "DataBase");
            Value.Add("Port", Int16.MinValue.GetType(), "Server", 1521);
         }
         #endregion

      #endregion
	
	}
}
