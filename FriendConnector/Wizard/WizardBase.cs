using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FS.Connector.Wizard
{
   internal class WizardBase: FS.Wizard.WizardBase
   {

      #region NEW
      internal WizardBase(): base()
      {
         this.BaseValidating += Base_WizardValidating;
       }
      #endregion

      #region PROPERTIES 

      #region ConnItem
      protected cItem ConnItem
      {
         get { return ((WizardForm)this.ParentForm).ConnItem; }
       }
      #endregion

      #endregion

      #region METHODS

      #region AddControl
      Int16 iLeft = 200;
      Int16 iTop = 60;
      internal void AddControl(FS.Data.Common.ConnKey oConnKey)
      {
         Label oLabel = new Label();
         oLabel.Text = oConnKey.Key;
         oLabel.Left = (iLeft - 120);
         oLabel.Top = iTop;
         this.Controls.Add(oLabel);

         TextBox oTextbox = new TextBox();
         oTextbox.Tag = oConnKey;
         oTextbox.Text = oConnKey.ToValueString();
         oTextbox.Left = iLeft;
         oTextbox.Top = iTop;
         oTextbox.Width = 200;
         oTextbox.TabIndex = 0;
         if ("PASSWORD;PASS;PWS".Contains(oConnKey.Key.ToUpper()))
         {
            oTextbox.PasswordChar = char.Parse("*");
          }
         oTextbox.TextChanged += Textbox_TextChanged;
         this.Controls.Add(oTextbox);

         iTop += 30;
       }
      #endregion

      #endregion

      #region EVENTS

      #region Base_WizardValidating
      protected event ValidatingEventHandler WizardValidating;
      internal void Base_WizardValidating(ref bool Valid, ref string Msg)
      {
         try
         {
            
            foreach (Control oControl in this.Controls)
            {
               if (oControl.GetType()== typeof(TextBox) )
               {
                  FS.Data.Common.ConnKey oConnKey = ((FS.Data.Common.ConnKey)oControl.Tag);
                  if (oConnKey != null)
                  {
                     if (oConnKey.Required)
                     {
                        if (string.IsNullOrEmpty(oConnKey.ToValueString()))
                        {
                           Valid = false;
                           Msg = oConnKey.Key + " is required";
                           oControl.Focus();
                           break;
                        }
                     }
                  }
                }
             }

            if (Valid == true)
            {
               if (this.WizardValidating != null)
               {
                  this.WizardValidating(ref Valid, ref Msg);
                }
            }
         }
         catch (Exception ex) { throw ex; }
       }
      #endregion

      #region Textbox_TextChanged
      private void Textbox_TextChanged(object sender, EventArgs e)
      {
         FS.Data.Common.ConnKey oConnKey = null;
         TextBox oTextBox = null;
         try
         {
            oTextBox = ((TextBox)sender);
            oConnKey = ((FS.Data.Common.ConnKey)oTextBox.Tag);
            oConnKey.Value = oTextBox.Text;
            this.ConnItem.AddKey(oConnKey.Key, oConnKey.GetValue());
         }
         catch { }
         finally
         {
            oConnKey = null;
            oTextBox = null;
         }
       }
      #endregion

      #endregion

    }
}
