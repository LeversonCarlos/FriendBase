using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FS.Wizard
{
   public partial class WizardForm : Form
   {

      public delegate void GetWizardPropertiesEventHandler(WizardForm sender);

      #region NEW
      public WizardForm()
      {
         InitializeComponent();
       }
      #endregion

      #region PROPERTIES

      #region TabControl
      protected System.Windows.Forms.TabControl TabControl
      {
         get { return tmp_TabControl; }
       }
      #endregion

      #region CurrentWizardTab
      protected WizardBase CurrentWizardTab
      {
         get
         {
            return ((WizardBase)this.TabControl.TabPages[this.WizardIndex].Controls[0]);
          }
       }
      #endregion

      #region WizardIndex
      protected Int32 WizardIndex
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

      #region AddWizardPage
      protected void AddWizardPage(WizardBase oWizardBase)
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

      #region Base_FormClosing
      private void Base_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (e.CloseReason == CloseReason.None)
         {
            e.Cancel = true;
          }
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
      private void NextButton_Click(object sender, EventArgs e)
      {
         if (this.CurrentWizardTab.isValid())
         {
            if (this.NextButton.Text == "Confirm")
            {
               this.DialogResult = DialogResult.OK;
               this.Close();
             }
            else
            {
               this.WizardIndex += 1;
             }
          }
       }
      #endregion

      #endregion

   }
}