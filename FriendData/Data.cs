using System;
using System.Data;
using System.Data.Common;

namespace FS.Data.Common
{
	
   public abstract class Data:IDisposable
   {
      public Data() {}
      
      #region PROPERTIES 
      
         #region ConnectionString
         private string tmp_ConnectionString;
         public string ConnectionString
         {
            get {return tmp_ConnectionString;}
            set 
            {
               tmp_ConnectionString = value;
               //tmp_UserID = string.Empty;
               /*
               try
               {
                  string[] aConnStr = tmp_ConnectionString.Split(';');
                  foreach (string sConnStr in aConnStr)
                  {
                     string[] aItemConnStr = sConnStr.Trim().Split('=');
                     if (aItemConnStr.GetValue(0).ToString().ToUpper() == "USER ID")
                     {
                        tmp_UserID = aItemConnStr.GetValue(1).ToString();
                        break;
                      }
                   }
                }
               catch { }
                */ 
             }
          }
         #endregion

         #region ConnectionStringParams
         protected delegate void ConnectionStringParamsEventHandler(ref ConnKeys Value);
         protected event ConnectionStringParamsEventHandler GetConnectionStringParams;
         private ConnKeys tmp_ConnectionStringParams;
         public ConnKeys ConnectionStringParams
         {
            get
            {
               if (tmp_ConnectionStringParams == null )
               {
                  tmp_ConnectionStringParams = new ConnKeys();
                  tmp_ConnectionStringParams.Add("Server", string.Empty.GetType());
                  tmp_ConnectionStringParams.Add("UserID", string.Empty.GetType());
                  tmp_ConnectionStringParams.Add("Password", string.Empty.GetType());
                  this.GetConnectionStringParams(ref tmp_ConnectionStringParams);
                }
                return tmp_ConnectionStringParams;
             }
          }
         #endregion

         #region ConnectionStringSteps
         protected delegate void ConnectionStringStepsEventHandler(ref System.Collections.ArrayList Value);
         protected event ConnectionStringStepsEventHandler GetConnectionStringSteps;
         private System.Collections.ArrayList tmp_ConnectionStringSteps;
         public System.Collections.ArrayList ConnectionStringSteps
         {
            get
            {
               if (tmp_ConnectionStringSteps == null)
               {
                  tmp_ConnectionStringSteps = new System.Collections.ArrayList();
                  tmp_ConnectionStringSteps.Add(new object[] {"General", "Type the connection values"});
                  this.GetConnectionStringSteps(ref tmp_ConnectionStringSteps);
               }
               return tmp_ConnectionStringSteps;
            }
         }
         #endregion

         #region Connection
         protected delegate void InitializeConnectionEventHandler(ref DbConnection Value);
         protected event InitializeConnectionEventHandler InitializeConnection;
         private DbConnection tmp_Connection;
         protected DbConnection Connection
         {
            get 
            {
               if (tmp_Connection == null)
               {
                  InitializeConnection(ref tmp_Connection);
                  this.Open();
                }
            return tmp_Connection;
            }
          }
         #endregion 
      
         #region Transaction
         private InnerTransaction tmp_Transaction;
         public InnerTransaction Transaction
         {
            get
            {
               if (tmp_Transaction==null)
               {
                  tmp_Transaction = new InnerTransaction();
                }  
               return tmp_Transaction;
             }
          }
         #endregion

         #region Schema
         private InnerSchema tmp_Schema;
         public InnerSchema Schema
         {
            [System.Diagnostics.DebuggerStepThrough()] 
            get
            {
               if (tmp_Schema == null)
               {
                  tmp_Schema = new InnerSchema();
                  tmp_Schema.InitializeSchema += Base_InitializeSchema; 
               }
               return tmp_Schema;
            }
         }
         #endregion

         #region Scripts
         private InnerScripts tmp_Scripts;
         public InnerScripts Scripts
         {
            [System.Diagnostics.DebuggerStepThrough()]
            get
            {
               if (tmp_Scripts == null)
               {
                  tmp_Scripts = new InnerScripts();
                  tmp_Scripts.InitializeScript += Base_InitializeScript; 
               }
               return tmp_Scripts;
            }
         }
         #endregion

         #region Delimiter
         protected delegate void GetDelimiterEventHandler(ref string value);
         protected event GetDelimiterEventHandler GetDelimiter;
         public string Delimiter
         {
            get
            {
               string sReturn = ";";
               if (this.GetDelimiter != null)
               {
                  this.GetDelimiter(ref sReturn);
                }
               return sReturn;
             }
          }
         /*
            private string tmp_Delimiter = ";";
            public string Delimiter
            {
               get {return tmp_Delimiter;}
               set {tmp_Delimiter = value;}
             }
         */ 
         #endregion

      #endregion
      
      #region METHODS 
      
         #region Dispose
         private bool disposed = false;

         public void Dispose()
         {
            Dispose(true);
            GC.SuppressFinalize(this);
          }
      
         private void Dispose(bool disposing)
         {
            if(!this.disposed) 
            {
             }
            disposed = true;
         
            if (tmp_Transaction == null) {tmp_Transaction = null;}
            if( tmp_Schema == null){tmp_Schema = null;}
            if( tmp_Scripts == null){tmp_Scripts = null;}
            if (tmp_Connection != null)
            {
               this.Close();
               tmp_Connection.Dispose();
               tmp_Connection = null;
             }
          }
      
      #endregion

         #region TryConnection
         public bool TryConnection()
         {
            string sErrMsg = string.Empty;
            return TryConnection(ref sErrMsg);
          }
         public bool TryConnection(ref string sErrMsg)
         {
            bool bReturn = false;
            try
            {
               if (this.Connection != null)
               {
                  //this.Open();
                  if (tmp_Connection.State == System.Data.ConnectionState.Open)
                  {
                     bReturn = true;
                   }
                  this.Close();
                }
             }
            catch (Exception ex)
            {
               sErrMsg = ex.Message;
             }
            return bReturn;
         }
         #endregion

         #region Open
         public void Open()
         {
            if (tmp_Connection != null)
            {
               if (tmp_Connection.State != System.Data.ConnectionState.Open)
               {
                  tmp_Connection.Open();
               }
            }
         }
         #endregion

         #region Close
         public void Close()
         {
            if (tmp_Connection != null)
            {
               if (tmp_Connection.State != System.Data.ConnectionState.Closed)
               {
                  tmp_Connection.Close();
               }
            }
         }
         #endregion

         #region GetConnectionString
         public static string GetConnectionString() { return string.Empty; }
         #endregion

         #region GetConnectionStringParam
            protected string GetConnectionStringParam(string Key) 
            {
               string sRET = string.Empty;
               try
               {
                  string[] aConnStr = tmp_ConnectionString.Split(';');
                  foreach (string sConnStr in aConnStr)
                  {
                     string[] aItemConnStr = sConnStr.Trim().Split('=');
                     if (aItemConnStr.GetValue(0).ToString().ToUpper() == Key.ToUpper())
                     {
                        sRET = aItemConnStr.GetValue(1).ToString();
                        break;
                     }
                  }
               }
               catch { }
               return sRET; 
             }
         #endregion

         #region GetAdapter
         protected delegate void InitializeAdapterEventHandler(ref DbDataAdapter Value);
         protected event InitializeAdapterEventHandler InitializeAdapter;
         public DbDataAdapter GetAdapter(DbCommand SelectCommand)
         {
            DbDataAdapter objAdapter = null;
            System.Type objType = null;
            System.Reflection.PropertyInfo objPropertyInfo = null;

            try
            {
               InitializeAdapter(ref objAdapter);
               if (objAdapter != null)
               {
                  if (SelectCommand != null)
                  {
                     //SelectCommand.Connection = this.Connection;

                     objType = objAdapter.GetType();
                     if (objType != null)
                     {

                        //((object)objAdapter).SelectCommand = SelectCommand;
                        objPropertyInfo = objType.GetProperty("SelectCommand", SelectCommand.GetType());
                        objPropertyInfo.SetValue(objAdapter, SelectCommand, null);

                      }
                   }
               
                }
             }
            catch (Exception ex)
            {
               throw new Exception("GetAdapter: " + ex.Message);
             }
            finally
            {
               if (objType != null) {objType = null;}
               if (objPropertyInfo != null) {objPropertyInfo = null;}
             }
         
            return objAdapter;
          }
         #endregion

         #region GetAdapter
         public DbDataAdapter GetAdapter(DbCommand SelectCommand, bool BuildCommands)
         {
            DbDataAdapter objAdapter = null;
            DbCommandBuilder objCommandBuilder = null;

            try
            {
               objAdapter = this.GetAdapter(SelectCommand);
               if (objAdapter != null)
               {
                  if (BuildCommands == true)
                  {
                     InitializeCommandBuilder(ref objCommandBuilder);
                     if (objCommandBuilder != null)
                     {
                        objCommandBuilder.DataAdapter = objAdapter;
                        objAdapter.InsertCommand = objCommandBuilder.GetInsertCommand();
                        objAdapter.UpdateCommand = objCommandBuilder.GetUpdateCommand();
                        objAdapter.DeleteCommand = objCommandBuilder.GetDeleteCommand();

                      }

                  }

               }
            }
            catch (Exception ex)
            {
               throw new Exception("GetAdapter: " + ex.Message);
            }
            finally
            {
            }

            return objAdapter;
         }
         #endregion

         #region GetCommandBuilder
         protected delegate void InitializeCommandBuilderEventHandler(ref DbCommandBuilder Value);
         protected event InitializeCommandBuilderEventHandler InitializeCommandBuilder;
         public DbCommandBuilder GetCommandBuilder()
         {
            DbCommandBuilder objCommandBuilder = null;
            InitializeCommandBuilder(ref objCommandBuilder);
            return objCommandBuilder;
         }
         #endregion
      
         #region GetCommand
            protected delegate void InitializeCommandEventHandler(ref DbCommand Value);
            protected event InitializeCommandEventHandler InitializeCommand;
            public DbCommand GetCommand()
            {
               DbCommand objCommand = null;
               InitializeCommand(ref objCommand);
               if (objCommand != null) 
               {
                  objCommand.Connection = this.Connection;
                }
               return objCommand;
             }
         #endregion

         #region GetDataSet
      
            public System.Data.DataSet GetDataSet(DbCommand SelectCommand) {return this.GetDataSet(SelectCommand, 0, 0);}
      
            public System.Data.DataSet GetDataSet(DbDataAdapter Adapter) {return this.GetDataSet(Adapter, 0, 0);}
      
            public System.Data.DataSet GetDataSet(DbCommand SelectCommand, Byte PageSize, Int16 ActualPage)
            {
               System.Data.DataSet objDataSet = null;
               DbDataAdapter objAdapter = null;
         
               try
               {
                  objAdapter = this.GetAdapter(SelectCommand);
                  objDataSet = this.GetDataSet(objAdapter, PageSize, ActualPage);
                }
               catch (Exception ex) { throw ex; }
               finally
               {
                  if (objAdapter != null) {objAdapter.Dispose();objAdapter=null;}
                }

               return objDataSet;
             }
      
            public System.Data.DataSet GetDataSet(DbDataAdapter Adapter, Byte PageSize, Int16 ActualPage)
            {
               System.Data.DataSet objDataSet = null;
         
               try
               {
                  if (Adapter != null)
                  {
                     objDataSet = new System.Data.DataSet();
                     if (PageSize == 0)
                     {
                        Adapter.Fill(objDataSet);
                      }
                     else
                     {
                        objDataSet = null;
                      }
                   }
                }
               catch (Exception ex) { throw ex; }

               return objDataSet;
             }
      
         #endregion
      
         #region GetDataTable
            public System.Data.DataTable GetDataTable(DbCommand SelectCommand)
            {
               System.Data.DataTable objDataTable = null;
               System.Data.DataSet objDataSet = null;
               try
               {
                  objDataSet = this.GetDataSet(SelectCommand);
                  if (objDataSet != null)
                  {
                     if (objDataSet.Tables.Count > 0)
                     {
                        objDataTable = objDataSet.Tables[0].Copy();
                      }
                   }
                }
               catch(Exception ex)
               {
                  throw new Exception("GetDataTable: " + ex.Message);
                }
               finally
               {
                  if (objDataSet != null){objDataSet.Dispose();objDataSet=null;}
                }
               return objDataTable;
             }
         #endregion

         #region GetDataTable
            public System.Data.DataTable GetDataTable(DbCommand SelectCommand, string TableName)
            {
               System.Data.DataTable objDataTable = null;
               DbDataAdapter objAdapter = null;
               try
               {
                  objAdapter = this.GetAdapter(SelectCommand);
                  objDataTable = new DataTable(TableName);
                  objAdapter.Fill(objDataTable);

               }
               catch (Exception ex)
               {
                  throw new Exception("GetDataTable: " + ex.Message);
               }
               finally
               {
                  if (objAdapter != null) { objAdapter.Dispose(); objAdapter = null; }
               }
               return objDataTable;
            }
         #endregion

         #region GetDataRow
         public System.Data.DataRow GetDataRow(DbCommand SelectCommand)
         {
               System.Data.DataRow objDataRow = null;
               System.Data.DataTable objDataTable = null;
               try
               {
                  objDataTable = this.GetDataTable(SelectCommand);
                  if (objDataTable != null)
                  {
                     if (objDataTable.Rows.Count > 0)
                     {
                        objDataRow = objDataTable.Rows[0];
                      }
                   }
                }
               catch(Exception ex)
               {
                  throw new Exception("GetDataRow: " + ex.Message);
                }
               finally
               {
                  if (objDataTable != null){objDataTable.Dispose();objDataTable=null;}
                }
               return objDataRow;
          }
         #endregion
      
         #region GetDataValue
         public object GetDataValue(DbCommand SelectCommand)
         {
               object objDataValue = null;
               System.Data.DataRow objDataRow = null;
               try
               {
                  objDataValue = SelectCommand.ExecuteScalar();
                  /*
                  objDataRow = this.GetDataRow(SelectCommand);
                  if (objDataRow != null)
                  {
                     if (! objDataRow.IsNull(0))
                     {
                        objDataValue = objDataRow[0];
                      }
                   }
                  */
                }
               catch(Exception ex)
               {
                  throw new Exception("GetDataValue: " + ex.Message);
                }
               finally
               {
                  if (objDataRow != null){objDataRow=null;}
                }
               return objDataValue;
          }
         #endregion

         #region GetDataValue
         public object GetDataValue(string Query)
         {
            object oRET = null;
            DbCommand SelectCommand = null;
            try
            {
               SelectCommand = this.GetCommand();
               SelectCommand.CommandText = Query;
               oRET = this.GetDataValue(SelectCommand);
             }
            catch (Exception ex) { throw ex; }
            finally
            {
               if (SelectCommand != null)
               {
                  SelectCommand.Dispose();
                  SelectCommand = null;
                }
             }
            return oRET;
          }
         #endregion

         #region ExecuteCommand
         public Int32 ExecuteCommand(DbCommand SelectCommand)
            {
               Int32 objReturn = 0;
               try
               {
                  objReturn = SelectCommand.ExecuteNonQuery();
                }
               catch(Exception ex)
               {
                  throw new Exception("ExecuteCommand: " + ex.Message);
                }
               return objReturn;
             }
         #endregion

         #region ExecuteScript
      
            protected delegate void InnerExecuteScriptEventHandler(string Script, ref Int32 AffectedRows, ref bool Executed);
            protected event InnerExecuteScriptEventHandler InnerExecuteScript;
            public bool ExecuteScript(string Script, ref Int32 AffectedRows)
            {
               //Int32 iReturn = 0;
               bool bReturn = false;
               DbCommand objCommand = null;
               AffectedRows = 0;

               try
               {

                  if (this.InnerExecuteScript != null)
                  {
                     this.InnerExecuteScript(Script, ref AffectedRows, ref bReturn);
                     System.Windows.Forms.Application.DoEvents();
                   }

                  if (!bReturn)
                  {
                     try
                     {
                        objCommand = this.GetCommand();
                        objCommand.CommandText = Script;
                        objCommand.Connection.Open();
                        AffectedRows = objCommand.ExecuteNonQuery();
                        objCommand.Connection.Close();
                        bReturn = true;
                     }
                     catch (Exception ex)
                     {
                        throw new Exception("ExecuteScript: " + ex.Message + (char)13 + (char)13 + Script);
                     }

                   }

                }
               catch(Exception ex) {throw ex;}
               finally
               {
                  if (objCommand != null){objCommand.Dispose(); objCommand=null;}
                }

               return bReturn;
             }

            public bool ExecuteScript(string Script, char Delimiter, ref Int32 AffectedRows)
            {
               bool iReturn = false;
               AffectedRows = 0;
               foreach(string ItemScript in Script.Split(Delimiter))
               {
                  Int32 iAffectedRows = 0;
                  if (this.ExecuteScript(ItemScript, ref iAffectedRows) == true)
                  {
                     AffectedRows += iAffectedRows;
                   }
                }
               return iReturn;
             }
      
         #endregion

         #region GetEngineType
         protected delegate void EngineTypeEventHandler(ref Engine.Type Value);
         protected event EngineTypeEventHandler EngineType;
         public Engine.Type GetEngineType()
         {
            Engine.Type oType = new Engine.Type();
            if (this.EngineType != null)
            {
               this.EngineType(ref oType);
             }
            return oType;
          }
         #endregion

         /*
         #region GetDataReader
         public DbDataReader GetDataReader(DbCommand SelectCommand)
         {
            try
            {
               return SelectCommand.ExecuteReader();
             }
            catch (Exception ex) {throw ex;}
          }
         #endregion
         */ 

      #endregion

      #region EVENTS

      #region Base_InitializeSchema
      //protected delegate void InitializeSchemaEventHandler(ref DataTable Value, SchemaTypeEnum SchemaType, string ObjectName, bool FullData);
      protected event InitializeSchemaEventHandler InitializeSchema;
      private void Base_InitializeSchema(ref DataTable Value, SchemaTypeEnum SchemaType, string ObjectName, bool FullData)
      {
         this.InitializeSchema(ref Value, SchemaType, ObjectName, FullData);
       }
      #endregion

      #region Base_InitializeScript
      protected event InitializeScriptEventHandler InitializeScript;
      private void Base_InitializeScript(ref string value, ScriptTypeEnum ScriptType, object[] objects)
      {
         this.InitializeScript(ref value, ScriptType, objects);
       }
      #endregion

      #endregion

   }
}
