using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FS.Connector.Wizard
{
   internal partial class WizardName : FS.Connector.Wizard.WizardBase
   {
      #region NEW
      internal WizardName():base()
      {
         InitializeComponent();
         this.Initializing += Base_Initializing;
         this.WizardValidating += Base_WizardValidating;
       }
      #endregion

      #region EVENTS

      #region Base_Initializing
      private void Base_Initializing()
      {
         this.NameTextbox.Text = this.ConnItem.Name;
       }
      #endregion

      #region Base_WizardValidating
      private void Base_WizardValidating(ref bool Valid, ref string Msg)
      {
         if (string.IsNullOrEmpty(this.NameTextbox.Text))
         {
            Valid = false;
            Msg = "Inform a valid name for this connection";
         }
         else
         {
            Valid = true;
            Msg = string.Empty;
            this.ConnItem.NameSet(this.NameTextbox.Text);
         }
      }
      #endregion

      #endregion

   }
}
