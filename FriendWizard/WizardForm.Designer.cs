namespace FS.Wizard
{
   public partial class WizardForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardForm));
         this.tmp_TabControl = new System.Windows.Forms.TabControl();
         this.NavPanel = new System.Windows.Forms.Panel();
         this.PreviousButton = new System.Windows.Forms.Button();
         this.NextButton = new System.Windows.Forms.Button();
         this.CancelingButton = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.NavPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // tmp_TabControl
         // 
         this.tmp_TabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
         this.tmp_TabControl.Location = new System.Drawing.Point(-3, 42);
         this.tmp_TabControl.Name = "tmp_TabControl";
         this.tmp_TabControl.SelectedIndex = 0;
         this.tmp_TabControl.Size = new System.Drawing.Size(500, 273);
         this.tmp_TabControl.TabIndex = 1;
         this.tmp_TabControl.TabStop = false;
         // 
         // NavPanel
         // 
         this.NavPanel.Controls.Add(this.PreviousButton);
         this.NavPanel.Controls.Add(this.NextButton);
         this.NavPanel.Controls.Add(this.CancelingButton);
         this.NavPanel.Location = new System.Drawing.Point(-1, 312);
         this.NavPanel.Name = "NavPanel";
         this.NavPanel.Size = new System.Drawing.Size(496, 46);
         this.NavPanel.TabIndex = 1;
         this.NavPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.NavPanel_Paint);
         // 
         // PreviousButton
         // 
         this.PreviousButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.PreviousButton.Location = new System.Drawing.Point(203, 12);
         this.PreviousButton.Name = "PreviousButton";
         this.PreviousButton.Size = new System.Drawing.Size(90, 23);
         this.PreviousButton.TabIndex = 2;
         this.PreviousButton.Text = "< Previous";
         this.PreviousButton.UseVisualStyleBackColor = true;
         this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
         // 
         // NextButton
         // 
         this.NextButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.NextButton.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.NextButton.Location = new System.Drawing.Point(299, 12);
         this.NextButton.Name = "NextButton";
         this.NextButton.Size = new System.Drawing.Size(90, 23);
         this.NextButton.TabIndex = 2;
         this.NextButton.Text = "Next >";
         this.NextButton.UseVisualStyleBackColor = true;
         this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
         // 
         // CancelingButton
         // 
         this.CancelingButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.CancelingButton.Location = new System.Drawing.Point(395, 12);
         this.CancelingButton.Name = "CancelingButton";
         this.CancelingButton.Size = new System.Drawing.Size(90, 23);
         this.CancelingButton.TabIndex = 2;
         this.CancelingButton.Text = "Cancel";
         this.CancelingButton.UseVisualStyleBackColor = true;
         this.CancelingButton.Click += new System.EventHandler(this.CancelingButton_Click);
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.Color.White;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(496, 66);
         this.panel1.TabIndex = 2;
         // 
         // WizardForm
         // 
         this.AcceptButton = this.NextButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.CancelingButton;
         this.ClientSize = new System.Drawing.Size(494, 357);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.NavPanel);
         this.Controls.Add(this.tmp_TabControl);
         this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "WizardForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Wizard Form";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Base_FormClosing);
         this.NavPanel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tmp_TabControl;
      private System.Windows.Forms.Panel NavPanel;
      private System.Windows.Forms.Button CancelingButton;
      private System.Windows.Forms.Button PreviousButton;
      private System.Windows.Forms.Button NextButton;
      private System.Windows.Forms.Panel panel1;
   }
}