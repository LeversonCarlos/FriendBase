using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Data.Common.Engine
{
   public class Types
   {

      #region GetTypes
      public static Type[] GetTypes()
      {
         System.Collections.ArrayList aArrayList = new System.Collections.ArrayList();
         string sPath = System.IO.Directory.GetCurrentDirectory();
         foreach (string sFilePath in System.IO.Directory.GetFiles(sPath, "FriendData*.dll"))
         {
            string sFileName = System.IO.Path.GetFileNameWithoutExtension(sFilePath);
            if (sFileName.ToUpper() != "FriendData".ToUpper())
            {
               aArrayList.Add(GetTypeByFileName(sFileName));
             }
         }

         return ((Type[])aArrayList.ToArray(System.Type.GetType("FS.Data.Common.Engine.Type")));
       }
      #endregion

      #region GetTypeByFileName
      private static Type GetTypeByFileName(string sFileName)
      {
         Type oType = null;
         FS.Data.Common.Data oData = null;
         try
         {
            string sTypeName = sFileName.Replace("FriendData", "FS.Data.");
            oData = FS.Data.Common.Abstracter.GetDataByTypeName(sTypeName);
            oType = oData.GetEngineType();
            oType.TypeName = sTypeName; 
          }
         catch 
         {
          }
         finally
         {
            oData.Dispose();
            oData = null;
         }
         return oType;
       }
      #endregion

   }
}
