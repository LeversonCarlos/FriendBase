using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Base.UI
{
   public class Control: System.Windows.Forms.UserControl
   {

      #region NEW
      internal Control()
      {
         this.InitializeComponent();
       }
      #endregion

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // Control
         // 
         this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "Control";
         this.Size = new System.Drawing.Size(250, 250);
         this.ResumeLayout(false);

      }
   }
}
