using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Base.UI.Controls
{
   internal class TabsControl: Crownwood.Magic.Controls.TabControl
   {

      #region NEW
      internal TabsControl()
      {
         this.InitializeComponent();
       }
      #endregion

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // _hostPanel
         // 
         this._hostPanel.Location = new System.Drawing.Point(0, 25);
         // 
         // _closeButton
         // 
         this._closeButton.Location = new System.Drawing.Point(133, 7);
         // 
         // _leftArrow
         // 
         this._leftArrow.Location = new System.Drawing.Point(105, 7);
         // 
         // _rightArrow
         // 
         this._rightArrow.Location = new System.Drawing.Point(119, 7);
         // 
         // TabsControl
         // 
         this.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
         this.IDEPixelBorder = false;
         this.Name = "TabsControl";
         this.ResumeLayout(false);

      }

   }
}
