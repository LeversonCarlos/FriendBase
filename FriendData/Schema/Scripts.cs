using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FS.Data.Common
{
   #region Common

   public delegate void InitializeScriptEventHandler(ref string value, ScriptTypeEnum ScriptType, object[] objects);

   public enum ScriptTypeEnum
   {
      TABLE = 1,
      VIEW = 2,
      PROCEDURE = 3,
      FUNCTION = 4, 
      differenceTABLE = 5
    }

   #endregion

   public class InnerScripts
   {

      #region NEW 
      internal InnerScripts() { }
      #endregion

      #region METHODS

      #region GetScript
      internal event InitializeScriptEventHandler InitializeScript;
      private string GetScript(ScriptTypeEnum ScriptType, object[] objects)
      {
         string sReturn = string.Empty;
         this.InitializeScript(ref sReturn, ScriptType, objects);
         return sReturn;
       }
      #endregion

      #region GetTable
      public string GetTable(DataRow Table, DataTable Columns)
      {
         object[] objects = new object[]{Table, Columns};
         return this.GetScript(ScriptTypeEnum.TABLE, objects);
       }
      #endregion

      #region GetTableDifferences
      public string GetTableDifferences(DataRow NewTable, DataTable NewColumns, DataRow OldTable, DataTable OldColumns)
      {
         object[] objects = new object[]{NewTable, NewColumns, OldTable, OldColumns};
         return this.GetScript(ScriptTypeEnum.differenceTABLE, objects);
       }
      #endregion

      #endregion

    }
}
