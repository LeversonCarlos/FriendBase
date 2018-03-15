using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Base.UI.Controls
{
   internal class TextPanel_old : System.Windows.Forms.TextBox
   {

      #region NEW
      internal TextPanel_old()
      {
         this.InitializeComponent();
      }
      #endregion

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // TextPanel
         // 
         this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Multiline = true;
         this.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.ResumeLayout(false);

      }
   }
}
