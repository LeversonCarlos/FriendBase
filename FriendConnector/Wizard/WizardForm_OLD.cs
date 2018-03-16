using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FS.Connector.Wizard
{
   internal partial class WizardForm : Form
   {

      #region NEW
      internal delegate void GetWizardPropertiesEventHandler(WizardForm sender);
      internal WizardForm()
      {
         InitializeComponent();
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

      #region TabControl
      internal System.Windows.Forms.TabControl TabControl
      {
         get { return tmp_TabControl; }
      }
      #endregion

      #region CurrentWizardTab
      WizardBase_OLD CurrentWizardTab
      {
         get
         {
            return ((WizardBase_OLD)this.TabControl.TabPages[this.WizardIndex].Controls[0]);
          }
       }
      #endregion

      #region WizardIndex
      private Int32 WizardIndex
      {
         get { return this.TabControl.SelectedIndex; }
         set
         {
            this.Cursor = Cursors.WaitCursor;

            this.TabControl.SelectedIndex = value;
            this.CurrentWizardTab.Initialize();

            this.PreviousButton.Enabled = (this.TabControl.SelectedIndex > 0);
            this.NextButton.Enabled = (this.TabControl.SelectedIndex <= this.WizardPages);
            if ((this.TabControl.SelectedIndex + 1) == this.WizardPages && this.WizardPages != 1)
            {
               this.NextButton.Text = "Confirm";
             }
            else
            {
               this.NextButton.Text = "Next >";
             }

            this.Cursor = Cursors.Default;
          }
      }
      #endregion

      #region WizardPages
      private Int32 WizardPages
      {
         get { return this.TabControl.TabPages.Count; }
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
         //((WizardBase)this.TabControl.TabPages[this.TabControl.SelectedIndex].Controls[0]).Initialize();

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
               WizardBase_OLD oWizardBase = new WizardBase_OLD();
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

      #region AddWizardPage
      private void AddWizardPage(WizardBase_OLD oWizardBase)
      {
         System.Windows.Forms.TabPage oTabPage = new System.Windows.Forms.TabPage();
         oTabPage.Controls.Add(oWizardBase);
         oTabPage.Controls[0].Location = new System.Drawing.Point(0, 0);
         oTabPage.Controls[0].Dock = System.Windows.Forms.DockStyle.Fill;
         this.TabControl.Controls.Add(oTabPage);
       }
      #endregion

      #endregion

      #region EVENTS

      #region NavPanel_Paint
      private void NavPanel_Paint(object sender, PaintEventArgs e)
      {
         Graphics oGraphics = this.NavPanel.CreateGraphics();
         oGraphics.DrawLine(System.Drawing.Pens.Gray, new System.Drawing.Point(0, 1), new System.Drawing.Point( this.NavPanel.Width , 1));
         oGraphics.DrawLine(System.Drawing.Pens.White, new System.Drawing.Point(0, 2), new System.Drawing.Point(this.NavPanel.Width, 2));
      }
      #endregion

      #region CancelingButton_Click
      private void CancelingButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }
      #endregion

      #region PreviousButton_Click
      private void PreviousButton_Click(object sender, EventArgs e)
      {
         this.WizardIndex -= 1;
       }
      #endregion

      #region NextButton_Click
      //internal delegate void WizardChangedEventHandler();
      //internal event WizardChangedEventHandler WizardChanged;
      private void NextButton_Click(object sender, EventArgs e)
      {
         if (this.CurrentWizardTab.isValid())
         {
            if (this.NextButton.Text == "Confirm")
            {
               this.DialogResult = DialogResult.OK;
               this.Close();
               //this.WizardChanged();
             }
            else
            {
               this.WizardIndex += 1;
             }
          }
       }
      #endregion

      private void Base_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.None)
         {
            e.Cancel = true;
          }
       }

      #endregion

   }
}