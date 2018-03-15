namespace FS.Base.UI.Controls
{
   partial class ResultsPanel
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
         this.panBack = new System.Windows.Forms.Panel();
         this.tabControl = new Crownwood.Magic.Controls.TabControl();
         this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
         this.panBack.SuspendLayout();
         this.SuspendLayout();
         // 
         // panBack
         // 
         this.panBack.Controls.Add(this.tabControl);
         this.panBack.Controls.Add(this.tabPage1);
         this.panBack.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panBack.Location = new System.Drawing.Point(0, 0);
         this.panBack.Name = "panBack";
         this.panBack.Size = new System.Drawing.Size(402, 176);
         this.panBack.TabIndex = 2;
         // 
         // tabControl
         // 
         this.tabControl.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiBox;
         this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.tabControl.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideUsingLogic;
         this.tabControl.Location = new System.Drawing.Point(0, 0);
         this.tabControl.Name = "tabControl";
         this.tabControl.SelectedIndex = 0;
         this.tabControl.SelectedTab = this.tabPage1;
         this.tabControl.Size = new System.Drawing.Size(402, 176);
         this.tabControl.TabIndex = 3;
         this.tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1});
         // 
         // tabPage1
         // 
         this.tabPage1.Location = new System.Drawing.Point(16, 18);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Size = new System.Drawing.Size(262, 97);
         this.tabPage1.TabIndex = 2;
         this.tabPage1.Title = "01";
         // 
         // ResultsPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.Controls.Add(this.panBack);
         this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.Name = "ResultsPanel";
         this.Size = new System.Drawing.Size(402, 176);
         this.panBack.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Panel panBack;
      private Crownwood.Magic.Controls.TabControl tabControl;
      private Crownwood.Magic.Controls.TabPage tabPage1;

   }
}
