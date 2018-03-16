using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FS.Connector.Wizard
{
   internal partial class TypeSelector : FS.Connector.Wizard.WizardBase
   {

      #region NEW
      internal TypeSelector():base()
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
         this.oListView.Items.Clear();
         this.oImageList.Images.Clear();

         FS.Data.Common.Engine.Type[] aType = FS.Data.Common.Engine.Types.GetTypes();
         foreach (FS.Data.Common.Engine.Type oType in aType)
         {
            ListViewItem oItem = new ListViewItem(oType.Description);
            oItem.ToolTipText = oType.TypeName;
            if (oType.Icon != null)
            {
               this.oImageList.Images.Add(oType.Icon);
               oItem.ImageIndex = this.oImageList.Images.Count - 1;
             }

            if (this.ConnItem.Type == oType.TypeName)
            {
               oItem.Selected = true;
             }
            this.oListView.Items.Add(oItem);
         }

      /*
         this.objListbox.Items.Clear();
         string sPath = System.IO.Directory.GetCurrentDirectory();
         foreach(string sFilePath in System.IO.Directory.GetFiles(sPath,"FriendData*.dll"))
         {
            string sFileName = System.IO.Path.GetFileNameWithoutExtension(sFilePath);
            if (sFileName.ToUpper() != "FriendData".ToUpper())
            {
               string sItem = sFileName.Replace("FriendData", "FS.Data.");
               this.objListbox.Items.Add(sItem);
               if (this.ConnItem.Type == sItem)
               {
                  this.objListbox.SelectedIndex = this.objListbox.Items.Count - 1;
                }
            }
          }
      */
      }
      #endregion

      #region Base_WizardValidating
      private void Base_WizardValidating(ref bool Valid, ref string Msg)
      {
         if (oListView.SelectedItems.Count == 0)
         {
            Valid = false;
            Msg = "Select a valid data type from the list";
          }
         else
         {
            Valid = true;
            Msg = string.Empty;
            this.ConnItem.TypeSet(oListView.SelectedItems[0].ToolTipText);
            ((WizardForm)this.ParentForm).RefreshWizardPages();
          }
       }
      #endregion

      #endregion

   }
}
