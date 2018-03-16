namespace FS.Connector.Wizard
{
   partial class WizardName
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.NameTextbox = new System.Windows.Forms.TextBox();
         this.NameLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // NameTextbox
         // 
         this.NameTextbox.Location = new System.Drawing.Point(200, 60);
         this.NameTextbox.Name = "NameTextbox";
         this.NameTextbox.Size = new System.Drawing.Size(200, 21);
         this.NameTextbox.TabIndex = 0;
         // 
         // NameLabel
         // 
         this.NameLabel.AutoSize = true;
         this.NameLabel.Location = new System.Drawing.Point(80, 60);
         this.NameLabel.Name = "NameLabel";
         this.NameLabel.Size = new System.Drawing.Size(40, 13);
         this.NameLabel.TabIndex = 2;
         this.NameLabel.Text = "Name";
         // 
         // WizardName
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.Controls.Add(this.NameLabel);
         this.Controls.Add(this.NameTextbox);
         this.Name = "WizardName";
         this.Title = "Confirm the name for this connection";
         this.Controls.SetChildIndex(this.NameTextbox, 0);
         this.Controls.SetChildIndex(this.NameLabel, 0);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox NameTextbox;
      private System.Windows.Forms.Label NameLabel;
   }
}
