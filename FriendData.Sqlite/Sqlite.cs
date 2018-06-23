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
         //this.InitializeSchema += Base_InitializeSchema;
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

      #endregion

   }
}