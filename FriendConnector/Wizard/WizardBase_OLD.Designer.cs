namespace FS.Connector.Wizard
{
   internal partial class WizardBase_OLD
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.objTimer = new System.Windows.Forms.Timer(this.components);
         this.TitleLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // objTimer
         // 
         this.objTimer.Tick += new System.EventHandler(this.objTimer_Tick);
         // 
         // TitleLabel
         // 
         this.TitleLabel.AutoSize = true;
         this.TitleLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.TitleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
         this.TitleLabel.Location = new System.Drawing.Point(4, 4);
         this.TitleLabel.Name = "TitleLabel";
         this.TitleLabel.Size = new System.Drawing.Size(36, 13);
         this.TitleLabel.TabIndex = 0;
         this.TitleLabel.Text = "Title";
         // 
         // WizardBase
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.TitleLabel);
         this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "WizardBase";
         this.Size = new System.Drawing.Size(494, 245);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Timer objTimer;
      private System.Windows.Forms.Label TitleLabel;
   }
}
