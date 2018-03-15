using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Package.Progress
{
   internal class ProgressClass
   {

      #region Form
      private ProgressForm oForm;
      private ProgressForm Form
      {
         get
         {
            if (oForm == null)
            {
               oForm = new ProgressForm();
             }
            return oForm;
          }
       }
      #endregion

      #region Step
      private Int16 iStep = 0;
      internal Int16 Step
      {
         get{return iStep;}
         set{iStep = value;}
      }
      #endregion


      #region Open
      internal void Open()
      {
         OpenEventHandler oDelegate = new OpenEventHandler(this.OpenDelegate);
         oDelegate.Invoke();
       }
      internal delegate void OpenEventHandler();
      private void OpenDelegate()
      {
         //this.Form.Owner = oOwner;
         this.Form.Show();
       }

      #endregion

      #region Close
      internal void Close()
      {
         //this.Form.Owner = oOwner;
         this.Form.Hide();
         this.Form.Close();
         this.Form.Dispose();
         this.oForm = null;
       }
      #endregion

      #region StepStart
      internal void StepStart()
      {
         try
         {
            this.Step += 1;
            SetCheckboxPropEventHandler oDelegate = new SetCheckboxPropEventHandler(this.SetCheckboxPropDelegate);
            oDelegate.Invoke(true, false);
          }
         catch(Exception ex){throw ex;}
      }
      #endregion

      #region ProgressStart
      internal void ProgressStart(Int32 iMaximum)
      {
         try
         {
            this.Form.oProgressBar.Value = 0;
            this.Form.oProgressBar.Maximum = iMaximum;
          }
         catch(Exception ex){throw ex;}
      }
      #endregion

      #region Progress
      internal void Progress()
      {
         try
         {
            this.Form.oProgressBar.Value += 1;
          }
         catch(Exception ex){throw ex;}
      }
      #endregion

      #region StepFinish
      internal void StepFinish()
      {
         try
         {
            SetCheckboxPropEventHandler oDelegate = new SetCheckboxPropEventHandler(this.SetCheckboxPropDelegate);
            oDelegate.Invoke(false, true);
            this.Form.oProgressBar.Value = 0;
          }
         catch(Exception ex){throw ex;}
      }
      #endregion

      #region SetCheckboxProp
      internal delegate void SetCheckboxPropEventHandler(bool Bold, bool Checked);
      private void SetCheckboxPropDelegate(bool Bold, bool Checked)
      {
         System.Windows.Forms.CheckBox[] aCheckBox;
         aCheckBox = new System.Windows.Forms.CheckBox[] {this.Form.CheckOpen, this.Form.CheckTables, this.Form.CheckViews, this.Form.CheckProcedures, this.Form.CheckFunctions,this.Form.CheckData, this.Form.CheckClose};

         System.Windows.Forms.CheckBox oCheckBox;
         oCheckBox = ((System.Windows.Forms.CheckBox)aCheckBox.GetValue(this.Step-1));

         oCheckBox.Checked = Checked;
         oCheckBox.Font = new System.Drawing.Font(oCheckBox.Font.FontFamily, oCheckBox.Font.Size, System.Drawing.FontStyle.Bold);
         this.Form.Refresh();
       }
      #endregion

   }
}
