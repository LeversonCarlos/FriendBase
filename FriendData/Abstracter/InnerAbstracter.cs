using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Data.Common
{
   internal class InnerAbstracter : IDisposable
   {

      #region NEW
      internal InnerAbstracter(string strTypeName)
      {
         this.TypeName = strTypeName;
       }
      #endregion

      #region PROPERTIES 

         #region TypeName
         private string tmp_TypeName;
         private string TypeName
         {
            get { return tmp_TypeName; }
            set { tmp_TypeName = value; }
          }
         #endregion

         #region FileName
         private string FileName
         {
            get
            {
               string objRET = this.TypeName;
               objRET = objRET.Replace("FS", "Friend");
               objRET = objRET.Replace(".", "");
               objRET = objRET.Replace(" ", "");
               objRET += ".dll";

               string strFullPath = System.Reflection.Assembly.GetEntryAssembly().Location;
               strFullPath = System.IO.Path.GetDirectoryName(strFullPath);
               if (! strFullPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
               {
                  strFullPath += System.IO.Path.DirectorySeparatorChar;
                }
               return strFullPath + objRET;
             }
          }
         #endregion

      #endregion

      #region METHODS 

         #region GetData
         internal FS.Data.Common.Data GetData()
         {
            System.Reflection.Assembly objAssembly = null;
            FS.Data.Common.Data objData = null;
            try
            {
               if (System.IO.File.Exists(this.FileName))
               {
                  objAssembly = System.Reflection.Assembly.LoadFrom(this.FileName);
                  objData = (FS.Data.Common.Data)objAssembly.CreateInstance(this.TypeName);
                }
             }
            catch { }
            finally
            {
               objAssembly = null;
             }
            return objData;
          }
         #endregion

         #region GetData
         internal FS.Data.Common.Data GetData(FS.Data.Common.ConnKeys oConnKeys)
         {
            FS.Data.Common.Data objData = this.GetData();
            if (objData != null)
            {
               objData.ConnectionString = this.GetConnectionString(oConnKeys, objData);
            }
            return objData;
         }
         #endregion

         #region GetConnKeys
         internal FS.Data.Common.ConnKeys GetConnKeys()
         {
            FS.Data.Common.ConnKeys oConnKeys = null;
            FS.Data.Common.Data objData = null;
            try
            {
               objData = this.GetData();
               oConnKeys = objData.ConnectionStringParams;
            }
            catch { }
            finally
            {
               if (objData != null)
               {
                  objData.Dispose();
                  objData = null;
               }
            }
            return oConnKeys;
          }
         #endregion

      /*
         #region GetConnectionString
         public string GetConnectionString(cItemKeys oKeys)
         {
            string strRET = string.Empty;
            FS.Data.Common.Data objData = null;
            try
            {
               objData = this.GetData();
               strRET = this.GetConnectionString(oKeys, objData);
             }
            catch { }
            finally
            {
               if (objData != null)
               {
                  objData.Dispose();
                  objData = null;
               }
             }
            return strRET;
          }
         #endregion
       */ 

         #region GetConnectionString
         private string GetConnectionString(FS.Data.Common.ConnKeys oConnKeys, FS.Data.Common.Data objData)
         {
            string sRET = string.Empty;
            System.Reflection.MethodInfo oMehodInfo = null;

            try
            {
               if (objData != null)
               {
                  oMehodInfo = objData.GetType().GetMethod("GetConnectionString", oConnKeys.ToTypeArray());
                  sRET = (string)oMehodInfo.Invoke(objData, oConnKeys.ToValueArray());
               }
               
             }
            catch(System.Exception ex) { throw ex; }
            finally
            {
               oMehodInfo = null;
             }
            return sRET;
          }
         #endregion

         #region Dispose
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
               /*
               if (tmp_Data != null)
               {
                  tmp_Data.Dispose();
                  tmp_Data = null;
                }
               */
             }
             disposed = true;
          }
         #endregion

      #endregion

       }
}
