using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Package
{
   public class Base: IDisposable
   {

      #region NEW
      public Base()
      {
       }
      #endregion

      #region FilePath
      private string sFilePath = string.Empty;
      public string FilePath
      {
         get{return sFilePath;}
         set{sFilePath=value;}
       }
      #endregion

      #region Connector
      private string sConnector = string.Empty;
      public string Connector
      {
         get{return sConnector;}
         set{sConnector = value;}
       }
      #endregion

      #region Data
      private FS.Data.Common.Data oData = null;
      public FS.Data.Common.Data Data
      {
         get{return oData;}
         set{oData=value;}
       }
      #endregion

      #region WorkingFolder
      protected string sWorkingFolder = string.Empty;
      protected string WorkingFolder
      {
         get
         {
            if (string.IsNullOrEmpty(sWorkingFolder))
            {
               string sDirectorySeparator = System.IO.Path.DirectorySeparatorChar.ToString();
               sWorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
               sWorkingFolder += (sWorkingFolder.EndsWith(sDirectorySeparator) ? string.Empty : sDirectorySeparator);
               sWorkingFolder += "Temp";
               sWorkingFolder += sDirectorySeparator;
               sWorkingFolder += DateTime.Now.ToString("yyyyMMddHHmmssfff");
               System.IO.Directory.CreateDirectory(sWorkingFolder);
               sWorkingFolder += sDirectorySeparator;
             }
            return sWorkingFolder;
          }
       }
      #endregion 

      #region Progress
      private Progress.ProgressClass oProgress;
      internal Progress.ProgressClass Progress
      {
         get
         {
            if (this.oProgress == null)
            {
               this.oProgress = new FS.Package.Progress.ProgressClass();
             }
            return this.oProgress;
          }
       }
      #endregion 

      #region Dispose
      protected delegate void DisposingEventHandler();
      protected event DisposingEventHandler Disposing;
      private bool disposed = false;
      public void Dispose()
      {
         this.Dispose(true);
         GC.SuppressFinalize(this);
       }
      private void Dispose(bool disposing)
      {
         if (!this.disposed)
         {
            if(this.Disposing != null)
            {
               this.Disposing();
             }
          }
         disposed = true;
       }
      #endregion

    } 
}
