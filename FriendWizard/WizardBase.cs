using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FS.Wizard
{
   public partial class WizardBase : UserControl
   {

      #region NEW
      public WizardBase()
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

      #endregion

      #region METHODS

      #region Initialize
      internal void Initialize()
      {
         objTimer.Enabled = true;
         objTimer.Start();
       }
      #endregion

      #region isValid
      protected delegate void ValidatingEventHandler(ref bool Valid, ref string Msg);
      protected event ValidatingEventHandler BaseValidating;
      internal bool isValid()
      {
         bool Valid = true;
         string Msg = string.Empty;

         try
         {
            if (this.BaseValidating != null)
            {
               this.BaseValidating(ref Valid, ref Msg);
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

      #endregion

   }
}
