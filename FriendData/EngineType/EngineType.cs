using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Data.Common.Engine
{
   public class Type
   {

      #region Key
      private string tmp_Key = string.Empty;
      public string Key
      {
         get { return tmp_Key; }
         set { tmp_Key = value; }
      }
      #endregion

      #region TypeName
      private string tmp_TypeName = string.Empty;
      public string TypeName
      {
         get { return tmp_TypeName; }
         set { tmp_TypeName = value; }
       }
      #endregion

      #region Description
      private string tmp_Description = string.Empty;
      public string Description
      {
         get 
         { 
            if (string.IsNullOrEmpty(tmp_Description))
            {
               return tmp_TypeName;
             }
            else
            {
               return tmp_Description; 
             }
         }
         set { tmp_Description = value; }
       }
      #endregion

      #region Icon
      System.Drawing.Icon tmp_Icon = null;
      public System.Drawing.Icon Icon
      {
         get { return tmp_Icon; }
         set { tmp_Icon = value; }
       }
      #endregion

   }
}
