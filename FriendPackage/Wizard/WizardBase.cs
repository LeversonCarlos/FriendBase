using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FS.Package.Wizard
{
   internal class WizardBase: FS.Wizard.WizardBase
   {

      #region NEW
      internal WizardBase(): base()
      {
       }
      #endregion

      #region PROPERTIES 

      #region Data
      internal event WizardForm.GetDataEventHandler GetData;
      protected FS.Data.Common.Data Data
      {
         get
         {
            FS.Data.Common.Data oData = null;
            if (this.GetData != null)
            {
               this.GetData(ref oData);
             }
            return oData;
          }
       }
      #endregion

      #region Package
      internal event WizardForm.GetPackageEventHandler GetPackage;
      protected Package Package
      {
         get
         {
            Package oPackage = null;
            if (this.GetPackage != null)
            {
               this.GetPackage(ref oPackage);
             }
            return oPackage;
          }
       }
      #endregion

      #endregion

      #region METHODS

      #endregion

      #region EVENTS

      #endregion

    }
}
