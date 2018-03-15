using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Package.Wizard
{
   internal class WizardDatas: WizardObjects
   {

      #region NEW
      internal WizardDatas():base()
      {
         this.Title = "Including Tables Data";
         this.GetDataTable += new GetDataTableEventHandler(this.Base_GetDataTable);
         this.GetObjectType += new GetObjectTypeEventHandler(this.Base_GetObjectType);
       }
      #endregion

      #region Base_GetObjectType
      private void Base_GetObjectType(ref string value)
      {
         value = "DATAs";
       }
      #endregion

      #region Base_GetDataTable
      private void Base_GetDataTable(ref System.Data.DataTable oDataTable)
      {
         oDataTable = this.Data.Schema.GetTables(false);
       }
      #endregion

    }
}
