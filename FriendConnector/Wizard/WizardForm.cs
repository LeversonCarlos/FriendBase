using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FS.Connector.Wizard
{
   internal class WizardForm: FS.Wizard.WizardForm
   {

      #region NEW
      internal WizardForm():base()
      {
       }
      #endregion

      #region PROPERTIES

      #region ConnItem
      internal delegate void GetConnItemEventHandler(ref cItem Value);
      internal event GetConnItemEventHandler GetConnItem;
      internal cItem ConnItem
      {
         get 
         {
            cItem tmp_ConnItem = null;
            this.GetConnItem(ref tmp_ConnItem);
            return tmp_ConnItem; 
          }
      }
      #endregion

      #endregion

      #region METHODS

      #region Initialize
      internal void Initialize()
      {

         AddWizardPage(new TypeSelector());
         this.RefreshWizardPages();
         if (string.IsNullOrEmpty(this.ConnItem.Type))
         {
            this.WizardIndex = 0;
          }
         else
         {
            this.WizardIndex = 1;
          }
       }
      #endregion

      #region RefreshWizardPages
      internal void RefreshWizardPages()
      {
         if (!string.IsNullOrEmpty(this.ConnItem.Type))
         {

            foreach (TabPage oTabPage in this.TabControl.TabPages)
            {
               if (oTabPage != this.TabControl.TabPages[0])
               {
                  this.TabControl.TabPages.Remove(oTabPage);
                }
             }

            System.Collections.ArrayList oConnSteps = this.ConnItem.GetConnSteps();
            foreach (object[] oConnStep in oConnSteps)
            {
               WizardBase oWizardBase = new WizardBase();
               oWizardBase.Title = oConnStep.GetValue(1).ToString();
               string sStepKey = oConnStep.GetValue(0).ToString();

               foreach (FS.Data.Common.ConnKey oConnKey in this.ConnItem.ConnKeys)
               {
                  if (oConnKey.Step == sStepKey)
                  {
                     oWizardBase.AddControl(oConnKey);
                  }
               }
               this.AddWizardPage(oWizardBase);

             }

            if (string.IsNullOrEmpty(this.ConnItem.Name))
            {
               AddWizardPage(new WizardName());
            }

         }

       }
      #endregion

      #endregion

   }
}
