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
         //this.InitializeConnection += Base_InitializeConnection;
         //this.InitializeAdapter += Base_InitializeAdapter;
         //this.InitializeCommand += Base_InitializeCommand;
         //this.InitializeCommandBuilder += Base_InitializeCommandBuilder;
         //this.InitializeSchema += Base_InitializeSchema;
         //this.InitializeScript += Base_InitializeScript;
      }
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
         Value.Add("FilePath", string.Empty.GetType(), "Path");
      }
      #endregion



      #endregion

   }
}