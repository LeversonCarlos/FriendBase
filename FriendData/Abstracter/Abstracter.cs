using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Data.Common
{
   public class Abstracter 
   {

      #region GetDataByTypeName
      public static FS.Data.Common.Data GetDataByTypeName(string sTypeName)
      {
         FS.Data.Common.Data oRet = null;
         InnerAbstracter oInnerAbstracter = null;

         try
         {
            oInnerAbstracter = new InnerAbstracter(sTypeName);
            oRet = oInnerAbstracter.GetData();
          }
         catch 
         {
          }
         finally
         {
            if (oInnerAbstracter != null)
            {
               oInnerAbstracter.Dispose();
               oInnerAbstracter = null;
             }
          }

          return oRet;
       }
      #endregion

      #region GetDataByTypeName
      public static FS.Data.Common.Data GetDataByTypeName(string sTypeName, FS.Data.Common.ConnKeys oConnKeys)
      {
         FS.Data.Common.Data oRet = null;
         InnerAbstracter oInnerAbstracter = null;

         try
         {
            oInnerAbstracter = new InnerAbstracter(sTypeName);
            oRet = oInnerAbstracter.GetData(oConnKeys);
         }
         catch 
         {
         }
         finally
         {
            if (oInnerAbstracter != null)
            {
               oInnerAbstracter.Dispose();
               oInnerAbstracter = null;
            }
         }

         return oRet;
      }
      #endregion

      #region GetConnKeys
      public static FS.Data.Common.ConnKeys GetConnKeys(string sTypeName)
      {
         FS.Data.Common.ConnKeys oConnKeys = null;
         FS.Data.Common.Data oData = null;
         try
         {
            oData = GetDataByTypeName(sTypeName);
            oConnKeys = oData.ConnectionStringParams;
         }
         catch { }
         finally
         {
            if (oData != null)
            {
               oData.Dispose();
               oData = null;
            }
         }
         return oConnKeys;
      }
      #endregion

   }
}
