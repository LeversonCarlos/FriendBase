using System;
using System.Data;

namespace FS.Data.Common
{

   #region Common

   public delegate void InitializeSchemaEventHandler(ref DataTable Value, SchemaTypeEnum SchemaType, string ObjectName, bool FullData);

   public enum SchemaTypeEnum
   {
      DATABASES = 1,
      TABLES = 2,
      COLUMNS = 3, 
      INDEXES = 4,
      VIEWS = 5,
      VIEW = 6,
      PROCEDURES = 7,
      PROCEDURE = 8,
      FUNCTIONS = 9,
      FUNCTION = 10
   }

   #endregion

   public class InnerSchema
   {

      #region NEW 
      internal InnerSchema() { }
      #endregion

      #region METHODS

      #region GetSchema
      internal event InitializeSchemaEventHandler InitializeSchema;
      private DataTable GetSchema(SchemaTypeEnum SchemaType, string ObjectName, bool FullData)
      {
         DataTable objReturn = null;
         this.InitializeSchema(ref objReturn, SchemaType, ObjectName, FullData);
         return objReturn;
       }
      #endregion

      #region GetDatabases
      public DataTable GetDatabases()
      {
         return this.GetSchema(SchemaTypeEnum.DATABASES, string.Empty, false);
      }
      #endregion

      #region GetTables
      public DataTable GetTable(string TableName)
      {
         return this.GetTables(TableName, true);
       }
      public DataTable GetTables(bool FullData)
      {
         return this.GetTables(string.Empty, FullData);
       }
      public DataTable GetTables(string TableName, bool FullData)
      {
         return this.GetSchema(SchemaTypeEnum.TABLES, TableName, FullData);
       }
      #endregion

      #region GetColumns
      public DataTable GetColumns(string TableName)
      {
         return this.GetColumns(TableName, false);
       }
      public DataTable GetColumns(string TableName, bool FullData)
      {
         return this.GetSchema(SchemaTypeEnum.COLUMNS, TableName, FullData);
       }
      #endregion

      #region GetIndexes
      public DataTable GetIndexes(string TableName)
      {
         return this.GetIndexes(TableName);
       }
      public DataTable GetIndexes(string TableName, bool FullData)
      {
         return this.GetSchema(SchemaTypeEnum.INDEXES, TableName, FullData);
      }
      #endregion

      #region GetViews
      public DataTable GetView(string ViewName)
      {
         return this.GetViews(ViewName, true);
       }
      public DataTable GetViews(bool FullData)
      {
         return this.GetViews(string.Empty, FullData);
       }
      public DataTable GetViews(string ViewName, bool FullData)
      {
         return this.GetSchema(SchemaTypeEnum.VIEWS, ViewName, FullData);
       }
      #endregion

      #region GetProcedures
      public DataTable GetProcedure(string ProcedureName)
      {
         return this.GetProcedures(ProcedureName, true);
       }
      public DataTable GetProcedures(bool FullData)
      {
         return this.GetProcedures(string.Empty, FullData);
       }
      public DataTable GetProcedures(string ProcedureName, bool FullData)
      {
         return this.GetSchema(SchemaTypeEnum.PROCEDURES, ProcedureName, FullData);
       }
      #endregion

      #region GetFunctions
      public DataTable GetFunction(string FunctionName)
      {
         return this.GetFunctions(FunctionName, true);
       }
      public DataTable GetFunctions(bool FullData)
      {
         return this.GetFunctions(string.Empty, FullData);
       }
      public DataTable GetFunctions(string FunctionName, bool FullData)
      {
         return this.GetSchema(SchemaTypeEnum.FUNCTIONS, FunctionName, FullData);
       }
      #endregion

      #endregion

   }
}
