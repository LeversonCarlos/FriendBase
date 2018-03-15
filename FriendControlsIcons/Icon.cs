using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Base
{
   public class Icon
   {

      #region GetIcon
      public static System.Drawing.Icon GetIcon(string key)
      {
         return ((System.Drawing.Icon)Resources.ResourceManager.GetObject(key, System.Globalization.CultureInfo.CurrentUICulture));
       }
      #endregion

   }
}
