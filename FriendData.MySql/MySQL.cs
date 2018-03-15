using System;
using System.Data;
using System.Data.Common;
using FS.Data;
using MySql.Data.MySqlClient;

namespace FS.Data
{
   public class MySQL : Common.Data
   {

      #region NEW
      public MySQL()	
		{
			this.InitializeConnection += Base_InitializeConnection; 
         this.InitializeAdapter += Base_InitializeAdapter; 
         this.InitializeCommand += Base_InitializeCommand;
         this.InitializeCommandBuilder += Base_InitializeCommandBuilder;
         this.InitializeSchema += Base_InitializeSchema;
         this.GetConnectionStringParams += Base_GetConnectionStringParams;
         this.GetConnectionStringSteps += Base_GetConnectionStringSteps;
         this.InnerExecuteScript += Base_InnerExecuteScript;
         this.EngineType += Base_EngineType;
      }
      #endregion

      #region METHODS

      #region GetConnectionString
      public static string GetConnectionString(string DataSource, string UserID, string Password, string DataBase, Int16 Port)
      {
         string strRET = string.Empty;

         strRET +=
            "Server=" + DataSource + ";" +
            "Port=" + Port + ";" +
            "Database=" + DataBase + ";" +
            "User ID=" + UserID + ";" +
            "Password=" + Password + ";" +
            "use procedure bodies=false;" +
            "pooling=false;" +
            "Allow User Variables=True;" + 
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
               tmp_DataBase = this.GetConnectionStringParam("Database");
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
            Value.Key = "mysql";
            Value.Description = "MySQL";
            Value.Icon = Resources.Icon;
         }
         #endregion
      
         #region Base_InitializeConnection
            private void Base_InitializeConnection(ref System.Data.Common.DbConnection Value)
            {
               Value = new MySqlConnection(this.ConnectionString);
             }
         #endregion
      
         #region Base_InitializeAdapter
            private void Base_InitializeAdapter(ref System.Data.Common.DbDataAdapter Value)
            {
               Value = new MySqlDataAdapter();
             }
         #endregion
      
         #region Base_InitializeCommand
            private void Base_InitializeCommand(ref System.Data.Common.DbCommand Value)
            {
               Value = new MySqlCommand();
             }
         #endregion

         #region Base_InitializeCommandBuilder
            private void Base_InitializeCommandBuilder(ref System.Data.Common.DbCommandBuilder Value)
            {
               Value = new MySqlCommandBuilder();
            }
         #endregion

         #region Base_InitializeSchema
         private void Base_InitializeSchema(ref DataTable Value, Common.SchemaTypeEnum SchemaType, string ObjectName, bool FullData)
         {
            DbCommand objCommand = null;
            try
            {
               if (SchemaType == Common.SchemaTypeEnum.DATABASES)
               {
                  Value = Base_InitializeSchema_DATABASES();
                }
               else
               {
                  objCommand = this.GetCommand();

                  if (SchemaType == Common.SchemaTypeEnum.TABLES)
                     {objCommand.CommandText = Base_InitializeSchema_TABLES(ObjectName, FullData); }
                  else if (SchemaType == Common.SchemaTypeEnum.COLUMNS)
                     { objCommand.CommandText = Base_InitializeSchema_COLUMNS(ObjectName, FullData); }
                  else if (SchemaType == Common.SchemaTypeEnum.INDEXES)
                     { objCommand.CommandText = Base_InitializeSchema_INDEXES(ObjectName, FullData); }
                  else if (SchemaType == Common.SchemaTypeEnum.VIEWS)
                     {objCommand.CommandText = Base_InitializeSchema_VIEWS(ObjectName, FullData);}
                  else if (SchemaType == Common.SchemaTypeEnum.PROCEDURES)
                  { objCommand.CommandText = Base_InitializeSchema_PROCEDURES(ObjectName, FullData); }
                  else if (SchemaType == Common.SchemaTypeEnum.FUNCTIONS)
                     {objCommand.CommandText = Base_InitializeSchema_FUNCTIONS(ObjectName, FullData);}

                  Value = this.GetDataTable(objCommand);
                }
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
         private DataTable Base_InitializeSchema_DATABASES()
         {
            DataTable oTable = null;
            DbCommand objCommand = null;
            try
            {
               objCommand = this.GetCommand();
               objCommand.CommandText = "SHOW SCHEMAS";
               oTable = this.GetDataTable(objCommand);
               //oTable.Columns["Database"].ColumnName = "Database";
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
             return oTable;
          }
         #endregion

         #region Base_InitializeSchema_TABLES
         private string Base_InitializeSchema_TABLES(string ObjectName, bool FullData)
         {
            string sAdditionalColumns = string.Empty;
            if (FullData == true)
            {
               sAdditionalColumns = ", " +
                  "AUTO_INCREMENT As ObjectIdentitySeed, " +
                  "ENGINE As ObjectEngine, " +
                  "TABLE_COLLATION As ObjectCollation" +
                  "";
             }

            return "" +
            "SELECT " +
               "TABLE_NAME As ObjectName, " + 
               "TABLE_SCHEMA As ObjectSchema" +
               sAdditionalColumns + " " +
            "FROM information_schema.TABLES " +
            "WHERE " +
               "TABLE_SCHEMA = '" + this.DataBase + "' And " +
               "TABLE_TYPE = 'BASE TABLE' " +
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
                  "TABLE_NAME As TableName, " +
                  "ORDINAL_POSITION As ColumnID, " +
                  "COLUMN_NAME As ColumnName, " +
                  "DATA_TYPE As TypeName, " +
                  "CHARACTER_MAXIMUM_LENGTH As TypeSize, " +
                  "COLLATION_NAME As ColumnCollation, " +
                  "(case when IS_NULLABLE='YES' then 1 else 0 end) As isNullable, " +
                  "(case when EXTRA='auto_increment' then 1 else 0 end) As isIdentity, " +
                  "(case when COLUMN_KEY='PRI' then 1 else 0 end) As isPrimaryKey " +
               "FROM information_schema.COLUMNS " +
               "WHERE " +
                  "TABLE_SCHEMA = '" + this.DataBase + "' And " +
                  "TABLE_NAME = '" + ObjectName + "' " +
               "ORDER BY " +
                  "ORDINAL_POSITION " +
               "";
         }
         #endregion

         #region Base_InitializeSchema_INDEXES
         private string Base_InitializeSchema_INDEXES(string ObjectName, bool FullData)
         {
            return "" +
               "SELECT " +
                  "Stats.TABLE_NAME As TableName, " +
                  "Stats.INDEX_NAME As IndexName, " +
                  "(" +
                     "case " +
                     "when coalesce(Constraints.CONSTRAINT_TYPE,'') like '%KEY' then Constraints.CONSTRAINT_TYPE " +
                     "when coalesce(Stats.INDEX_TYPE,'')='FULLTEXT' then 'FULTEXT KEY' " +
                     "when coalesce(Constraints.CONSTRAINT_TYPE,'') = 'UNIQUE' then 'UNIQUE KEY' " +
                     "else 'KEY' " +
                     "end " + 
                   ") As IndexType, " +
                  "Stats.COLUMN_NAME As ColumnName " +
               "FROM information_schema.STATISTICS Stats " +
                  "LEFT JOIN information_schema.TABLE_CONSTRAINTS Constraints On " +
                  "(" +
                     "Constraints.TABLE_SCHEMA = Stats.TABLE_SCHEMA And " +
                     "Constraints.TABLE_NAME = Stats.TABLE_NAME And " +
                     "Constraints.CONSTRAINT_NAME = Stats.INDEX_NAME " + 
                   ") " +
               "WHERE " +
                  "Stats.TABLE_SCHEMA = '" + this.DataBase + "' And " +
                  "Stats.TABLE_NAME = '" + ObjectName + "' And " +
                  "coalesce(Constraints.CONSTRAINT_TYPE,'') <> 'PRIMARY KEY' And " + 
                  "coalesce(Constraints.CONSTRAINT_TYPE,'') <> 'FOREIGN KEY' " +
               "ORDER BY " +
                  "Stats.INDEX_NAME Asc, " +
                  "Stats.SEQ_IN_INDEX Asc " + 
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
               "TABLE_SCHEMA = '" + this.DataBase + "' " +
               (string.IsNullOrEmpty(ObjectName) ? "" : "And TABLE_NAME like '" + ObjectName + "' ") +
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
                  "ROUTINE_SCHEMA = '" + this.DataBase + "' And " +
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
                  "ROUTINE_SCHEMA = '" + this.DataBase + "' And " +
                  "ROUTINE_TYPE = 'FUNCTION' " +
                  (string.IsNullOrEmpty(ObjectName) ? "" : "And ROUTINE_NAME like '" + ObjectName + "'") +
               "ORDER BY " +
                  "ROUTINE_NAME Asc " +
               "";
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
            Value.Add("DataBase", string.Empty.GetType(), "DataBase", "information_schema").Required = false;
            Value.Add("Port", Int16.MinValue.GetType(), "Server", 3306);
          }
         #endregion

         #region Base_InnerExecuteScript

         private void Base_InnerExecuteScript(string Script, ref Int32 AffectedRows, ref bool Executed)
         {
            try
            {

               while (! string.IsNullOrEmpty(Script))
               {

                  int iPosInitial = 0;
                  int iPosFinal = 0;
                  string sDelimiter = this.Base_InnerExecuteScript_GetDelimiter(Script, 0, ref iPosInitial, ref iPosFinal);

                  Script = Script.Substring(iPosFinal);
                  if (!string.IsNullOrEmpty(Script))
                  {

                     iPosFinal = Script.ToUpper().IndexOf("DELIMITER ");
                     if (iPosFinal == -1) { iPosFinal = Script.Length; }

                     string sInnerScript = Script.Substring(0, iPosFinal);
                     if (!this.Base_InnerExecuteScript_IsEmpty(sInnerScript))
                     {

                        int iAffectedRows = 0;
                        if (this.Base_InnerExecuteScript_Execute(sInnerScript, sDelimiter, ref iAffectedRows) == true)
                        {
                           AffectedRows += iAffectedRows;
                           Executed = true;
                         }

                      }

                     Script = Script.Substring(iPosFinal);

                   }
                }

             }
            catch (Exception ex) { throw ex; }
          }

         private void Base_InnerExecuteScript_2(string Script, ref Int32 AffectedRows, ref bool Executed)
         {
            try
            {

               int iPosInitial = 0; 
               int iPosFinal = 0;

               string sDelimiter = this.Base_InnerExecuteScript_GetDelimiter(Script, 0, ref iPosInitial, ref iPosFinal);
               if (string.IsNullOrEmpty(sDelimiter)) {return; }

               string sInnerScript = Script; //.Substring(iCommandInitial);
               if (string.IsNullOrEmpty(sInnerScript)) { Executed = true; return; }

               string[] aInnerScript = sInnerScript.Split(new string[] {"DELIMITER " + sDelimiter}, StringSplitOptions.None );

               foreach (string sExecScript in aInnerScript)
               {
                  if (!this.Base_InnerExecuteScript_IsEmpty(sExecScript))
                  {
                     Int32 iExecAffectedRows = 0;
                     if (this.Base_InnerExecuteScript_Execute(sExecScript, sDelimiter, ref iExecAffectedRows) == true)
                     {
                        AffectedRows += iExecAffectedRows;
                        Executed = true;
                     }
                   }
                }
               

             }
            catch (Exception ex) { throw ex; }
          }

         private string Base_InnerExecuteScript_GetDelimiter(string Script, int iPosStart, ref int iPosInitial, ref int iPosFinal)
         {
            string sDelimiter = string.Empty;
            try
            {
               iPosInitial = Script.ToUpper().IndexOf("DELIMITER ", iPosStart);
               if (iPosInitial == -1) { return sDelimiter; }
               iPosInitial += ((string)"DELIMITER ").Length;

               iPosFinal = Script.ToUpper().IndexOfAny(new char[] {(char)32, (char)13, (char)10 }, iPosInitial);
               if (iPosFinal == -1) { iPosFinal = Script.Length; }

               sDelimiter = Script.Substring(iPosInitial, (iPosFinal - iPosInitial));

             }
            catch (Exception ex) { throw ex; }
            return sDelimiter;
          }

         private bool Base_InnerExecuteScript_IsEmpty(string Script)
         {
            bool bReturn = false;
            try
            {
               Script = Script.ToUpper().Replace("DELIMITER", string.Empty);
               Script = Script.Replace(" ", string.Empty);
               Script = Script.Replace(Convert.ToString((char)10), string.Empty);
               Script = Script.Replace(Convert.ToString((char)13), string.Empty);
               bReturn = (string.IsNullOrEmpty(Script));
            }
            catch (Exception ex) { throw ex; }
            return bReturn;
         }

         private bool Base_InnerExecuteScript_Execute(string Script, string sDelimiter, ref int iAffectedRows)
         {
            bool bReturn = false;
            MySqlScript oScript = null;
            try
            {

               //this.Base_InnerExecuteScript(Script, ref iAffectedRows, ref bReturn);
               if (bReturn == false)
               {
                  try
                  {
                     oScript = new MySqlScript();
                     oScript.Connection = new MySqlConnection(this.ConnectionString);
                     oScript.Connection.Open();
                     oScript.Query = Script;
                     oScript.Delimiter = sDelimiter;// Convert.ToString((char)255);
                     iAffectedRows = oScript.Execute();
                     bReturn = true;
                  }
                  catch (Exception exInner) { throw new Exception(exInner.Message + (char)13 + (char)13 + Script);}
               }

            }
            catch (Exception ex) { throw ex; }
            finally
            {
               if (oScript != null)
               {
                  oScript.Connection.Dispose();
                  oScript = null;
                }
             }
            return bReturn;
          }

         #endregion

      #endregion

   }
}
