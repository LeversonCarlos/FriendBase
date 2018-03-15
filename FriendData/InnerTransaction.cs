using System;
using System.Data.Common;

namespace FS.Data.Common
{
   public class InnerTransaction
   {

      #region NEW 
      internal InnerTransaction() { }
      #endregion

      #region Connection
      protected delegate void GetConnectionEventHandler(ref DbConnection Value);
      protected event GetConnectionEventHandler GetConnection;
      private DbConnection Connection
      {
         get
         {
            DbConnection objReturn = null;
            GetConnection(ref objReturn);
            return objReturn;
          }
       }
      #endregion
      
      #region Transaction
      DbTransaction tmp_Transaction;
      private DbTransaction Transaction
      {
         get{return tmp_Transaction;}
         set{tmp_Transaction = value;}
      }
      #endregion
      
      #region isOpened
      public bool isOpened
      {
         get
         {
            if (this.Transaction == null)
            {
               return false;
             }
            else
            {
               return true;
             }
          }
       }
      #endregion
      
      #region Begin
      public bool Begin()
      {
         bool blnReturn = false;
         try
         {
            if (this.isOpened){blnReturn=true;}
            else
            {
               this.Transaction = this.Connection.BeginTransaction();
             }
          }
         catch (Exception ex)
         {
            throw new Exception("BeginTransaction: " + ex.Message);
          }
         return blnReturn;
       }
      #endregion
      
      #region Commit
      public void Commit()
      {
         try
         {
            if (this.isOpened)
            {
               this.Transaction.Commit();
             }
          }
         catch (Exception ex)
         {
            throw new Exception("CommitTransaction: " + ex.Message);
          }
         finally
         {
            if (this.isOpened)
            {
               this.Transaction.Dispose();
               this.Transaction = null;
             }
          }
       }
      #endregion
      
      #region Rollback
      public void Rollback()
      {
         try
         {
            if (this.isOpened)
            {
               this.Transaction.Rollback();
             }
          }
         catch (Exception ex)
         {
            throw new Exception("RollbackTransaction: " + ex.Message);
          }
         finally
         {
            if (this.isOpened)
            {
               this.Transaction.Dispose();
               this.Transaction = null;
             }
          }
       }
      #endregion
      
   }
}
