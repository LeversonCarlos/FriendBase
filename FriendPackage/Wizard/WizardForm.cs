using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FS.Package.Wizard
{
   internal class WizardForm: FS.Wizard.WizardForm
   {

      #region NEW
      internal WizardForm():base()
      {
       }
      #endregion

      #region PROPERTIES

      #region Data
      internal delegate void GetDataEventHandler(ref FS.Data.Common.Data value);
      internal event GetDataEventHandler GetData;
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
      internal delegate void GetPackageEventHandler(ref Package value);
      internal event GetPackageEventHandler GetPackage;
      private Package Package
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

      #region Initialize
      internal void Initialize()
      {
         WizardObjects oWizardObjects = null;
         try
         {
            this.TabControl.TabPages.Clear();

            oWizardObjects = new WizardTables(); 
            oWizardObjects.GetData += new GetDataEventHandler(this.Wizard_GetData);
            oWizardObjects.GetPackage += new GetPackageEventHandler(this.Wizard_GetPackage);
            AddWizardPage(oWizardObjects);

            oWizardObjects = new WizardViews(); 
            oWizardObjects.GetData += new GetDataEventHandler(this.Wizard_GetData);
            oWizardObjects.GetPackage += new GetPackageEventHandler(this.Wizard_GetPackage);
            AddWizardPage(oWizardObjects);

            oWizardObjects = new WizardProcedures(); 
            oWizardObjects.GetData += new GetDataEventHandler(this.Wizard_GetData);
            oWizardObjects.GetPackage += new GetPackageEventHandler(this.Wizard_GetPackage);
            AddWizardPage(oWizardObjects);

            oWizardObjects = new WizardFunctions(); 
            oWizardObjects.GetData += new GetDataEventHandler(this.Wizard_GetData);
            oWizardObjects.GetPackage += new GetPackageEventHandler(this.Wizard_GetPackage);
            AddWizardPage(oWizardObjects);

            oWizardObjects = new WizardDatas(); 
            oWizardObjects.GetData += new GetDataEventHandler(this.Wizard_GetData);
            oWizardObjects.GetPackage += new GetPackageEventHandler(this.Wizard_GetPackage);
            AddWizardPage(oWizardObjects);

            WizardSave oWizardSave = new WizardSave(); 
            oWizardSave.GetData += new GetDataEventHandler(this.Wizard_GetData);
            oWizardSave.GetPackage += new GetPackageEventHandler(this.Wizard_GetPackage);
            AddWizardPage(oWizardSave);

            this.WizardIndex = 0;
         }
         catch(Exception ex){throw ex;}

       }
      #endregion

      #endregion

      #region EVENTS 

      #region Wizard_GetData
      private void Wizard_GetData(ref FS.Data.Common.Data value)
      {
         value = this.Data;
       }
      #endregion

      #region Wizard_GetPackage
      private void Wizard_GetPackage(ref Package value)
      {
         value = this.Package;
       }
      #endregion

      #endregion

    }
}
