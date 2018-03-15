using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Base.UI
{
   public class Tabs: System.Windows.Forms.UserControl
   {

      #region Initialize
      private FS.Base.UI.Controls.TabsControl oTabsControl;

      private void InitializeComponent()
      {
         this.SuspendLayout();
         oTabsControl = new FS.Base.UI.Controls.TabsControl();

         // 
         // oTabsControl
         // 
         this.oTabsControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
         this.oTabsControl.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
         this.oTabsControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.oTabsControl.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
         this.oTabsControl.IDEPixelBorder = false;
         this.oTabsControl.Location = new System.Drawing.Point(0, 0);
         this.oTabsControl.Name = "oTabsControl";
         this.oTabsControl.Size = new System.Drawing.Size(350, 275);
         this.oTabsControl.TabIndex = 0;
         this.oTabsControl.SelectionChanged += new System.EventHandler(this.oTabsControl_SelectionChanged);
         this.oTabsControl.ClosePressed += new System.EventHandler(this.Tabs_ClosePressed);
         // 
         // Tabs
         // 
         this.Controls.Add(this.oTabsControl);
         this.Name = "Tabs";
         this.Size = new System.Drawing.Size(350, 275);
         this.ResumeLayout(false);

      }
      #endregion

      #region NEW
      public Tabs()
      {
         this.InitializeComponent();
       }
      #endregion

      #region AddNewPage
      public void AddNewPage(string sTitle, string sConnectionName)
      {
         this.AddNewPage(sTitle, sConnectionName, string.Empty);
       }
      public void AddNewPage(string sTitle, string sConnectionName, string sQueryText)
      {
         Crownwood.Magic.Controls.TabPage oNewPage = null;
         Editor oEditor = null;
         try
         {
            oEditor = new Editor();
            oEditor.ConnectionName = sConnectionName;
            oEditor.QueryText = sQueryText;

            oNewPage = new Crownwood.Magic.Controls.TabPage(sTitle, oEditor);
            oNewPage.Selected = true;
            this.oTabsControl.TabPages.Add(oNewPage);
            oEditor.TabPage = oNewPage;

            this.oTabsControl.BackColor = System.Drawing.SystemColors.Control;
            this.oTabsControl.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
          }
         catch (Exception ex)
         {
            throw ex;
          }
       }
      #endregion

      #region RemovePage
      private void RemovePage()
      {
         this.SelectedEditor.Dispose();
         this.oTabsControl.TabPages.Remove(this.oTabsControl.SelectedTab);
         if (this.oTabsControl.TabPages.Count == 0)
         {
            this.oTabsControl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.oTabsControl.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
          }
      }
      #endregion

      #region SelectNextTab
      public void SelectNextTab()
      {
         if (this.oTabsControl.SelectedIndex < (this.oTabsControl.TabPages.Count - 1))
         {
            this.oTabsControl.SelectedIndex += 1;
          }
         else
         {
            this.oTabsControl.SelectedIndex = 0;
          } 
       }
      #endregion

      #region SelectPreviousTab
      public void SelectPreviousTab()
      {
         if (this.oTabsControl.SelectedIndex > 0)
         {
            this.oTabsControl.SelectedIndex -= 1;
          }
         else
         {
            this.oTabsControl.SelectedIndex = (this.oTabsControl.TabPages.Count - 1);
          } 
       }
      #endregion

      #region PROPERTIES

      #region SelectedEditor
      public Editor SelectedEditor
      {
         get
         {
            if (this.oTabsControl.SelectedIndex == -1)
            {
               return null;
             }
            {
               return ((Editor)this.oTabsControl.SelectedTab.Control);
             }
          }
       }
      #endregion

      #endregion

      #region EVENTS

      #region oTabsControl_SelectionChanged
      public delegate void TabChangedEventHandler(Editor oTabEditor);
      public event TabChangedEventHandler TabChanged;
      private void oTabsControl_SelectionChanged(object sender, EventArgs e)
      {
         if (this.TabChanged != null)
         {
            this.TabChanged(this.SelectedEditor);
          }
       }
      #endregion

      #region Tabs_ClosePressed
      private void Tabs_ClosePressed(object sender, EventArgs e)
      {
         this.RemovePage();
       }
      #endregion

      #endregion


   }
}
