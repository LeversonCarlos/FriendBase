using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FS.Connector.Wizard
{
   internal partial class WizardBase_OLD : UserControl
   {
      #region NEW
      internal WizardBase_OLD()
      {
         InitializeComponent();
      }
      #endregion

      #region PROPERTIES 

      #region Title
      public string Title
      {
         get { return TitleLabel.Text; }
         set { TitleLabel.Text = value; }
       }
      #endregion

      #region ConnItem
      protected cItem ConnItem
      {
         get
         {
            return ((WizardForm)this.ParentForm).ConnItem;
         }
      }
      #endregion

      #endregion

      #region METHODS

      #region Initialize
      internal void Initialize()
      {
         objTimer.Enabled = true;
         objTimer.Start();
       }
      #endregion

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

      #region isValid
      protected delegate void ValidatingEventHandler(ref bool Valid, ref string Msg);
      protected new event ValidatingEventHandler Validating;
      internal bool isValid()
      {
         bool Valid = true;
         string Msg = string.Empty;

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
               this.Validating(ref Valid, ref Msg);
            }
         }
         catch { Valid = true; }
         if (!Valid && !string.IsNullOrEmpty(Msg))
         {
            MessageBox.Show(Msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          }

         return Valid;
       }
      #endregion

      #endregion

      #region EVENTS

      #region Timer_Tick
      protected delegate void InitializingEventHandler();
      protected event InitializingEventHandler Initializing;
      private void objTimer_Tick(object sender, EventArgs e)
      {
         ((Timer)sender).Stop();
         ((Timer)sender).Enabled = false;
         try
         {
            this.Initializing();
         }
         catch { }
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
