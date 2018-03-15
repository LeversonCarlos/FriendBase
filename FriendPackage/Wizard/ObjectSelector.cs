using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FS.Package.Wizard
{
   internal partial class ObjectSelector : UserControl
   {

      #region NEW
      internal ObjectSelector()
      {
         InitializeComponent();
         this.TypeSelectionChange(false);
      }
      #endregion

      #region METHODS

      #region TypeSelectionChange
      private void TypeSelectionChange(bool Enable)
      {
         this.oListSelected.Enabled=Enable;
         this.oListAvailable.Enabled=Enable;
         this.btnSelectAll.Enabled=Enable;
         this.btnSelect.Enabled=Enable;
         this.btnRemove.Enabled=Enable;
         this.btnRemoveAll.Enabled=Enable;
       }
      #endregion

      #region SelectionChange
      private void SelectionChange(ListBox oListBox, bool Selected)
      {
         if (oListBox.SelectedIndex != -1)
         {
            ((DataRowView)oListBox.SelectedItem).Row["Selected"] = Selected;
          }
       }
      #endregion

      #region SelectionAllChange
      private void SelectionAllChange(ListBox oListBox, bool Selected)
      {
         if (oListBox.Items.Count != 0)
         {
            foreach(DataRowView oROW in ((DataView)oListBox.DataSource) )
            {
               oROW["Selected"] = Selected;
             }
          }
       }
      #endregion

      #endregion

      #region EVENTS

      #region TypeSelection_All
      private void TypeSelection_All(object sender, EventArgs e)
      {
         this.TypeSelectionChange(false);
       }
      #endregion

      #region TypeSelection_None
      private void TypeSelection_None(object sender, EventArgs e)
      {
         this.TypeSelectionChange(false);
       }
      #endregion

      #region TypeSelection_Custom
      private void TypeSelection_Custom(object sender, EventArgs e)
      {
         this.TypeSelectionChange(true);
       }
      #endregion


      #region btnSelect_Click
      private void btnSelect_Click(object sender, EventArgs e)
      {
         this.SelectionChange(oListAvailable, true);
       }
      #endregion

      #region btnSelect_Click
      private void btnRemove_Click(object sender, EventArgs e)
      {
         this.SelectionChange(oListSelected, false);
       }
      #endregion

      #region btnSelectAll_Click
      private void btnSelectAll_Click(object sender, EventArgs e)
      {
         this.SelectionAllChange(this.oListAvailable, true);
       }
      #endregion

      #region btnRemoveAll_Click
      private void btnRemoveAll_Click(object sender, EventArgs e)
      {
         this.SelectionAllChange(this.oListSelected, false);
       }
      #endregion

      #endregion



    }
}
