using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Package.Wizard
{
   internal class WizardSave: WizardBase
   {

      #region Initialize

      private System.Windows.Forms.TextBox NameTextBox;
      private System.Windows.Forms.CheckBox SaveCheckBox;

      private void InitializeComponent()
      {
         this.NameTextBox = new System.Windows.Forms.TextBox();
         this.SaveCheckBox = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // NameTextBox
         // 
         this.NameTextBox.Enabled = false;
         this.NameTextBox.Location = new System.Drawing.Point(87, 88);
         this.NameTextBox.Name = "NameTextBox";
         this.NameTextBox.Size = new System.Drawing.Size(305, 21);
         this.NameTextBox.TabIndex = 2;
         // 
         // SaveCheckBox
         // 
         this.SaveCheckBox.AutoSize = true;
         this.SaveCheckBox.Location = new System.Drawing.Point(67, 68);
         this.SaveCheckBox.Name = "SaveCheckBox";
         this.SaveCheckBox.Size = new System.Drawing.Size(262, 17);
         this.SaveCheckBox.TabIndex = 4;
         this.SaveCheckBox.Text = "Save this Config with the Following Name";
         this.SaveCheckBox.UseVisualStyleBackColor = true;
         this.SaveCheckBox.CheckedChanged += new System.EventHandler(this.SaveCheckBox_CheckedChanged);
         // 
         // WizardSave
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.Controls.Add(this.SaveCheckBox);
         this.Controls.Add(this.NameTextBox);
         this.Name = "WizardSave";
         this.Title = "Confirm the Export Execution";
         this.Controls.SetChildIndex(this.NameTextBox, 0);
         this.Controls.SetChildIndex(this.SaveCheckBox, 0);
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      #region NEW
      internal WizardSave():base()
      {
         this.InitializeComponent();
         this.Initializing += Base_Initializing;
         this.BaseValidating += Base_Validating;
       }
      #endregion

      #region EVENTS

      #region Base_Initializing
      private void Base_Initializing()
      {
         if (string.IsNullOrEmpty(this.NameTextBox.Text))
         {
            this.NameTextBox.Text = this.Package.FileName;
            if (string.IsNullOrEmpty(this.NameTextBox.Text))
            {
               this.NameTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
             }
            else
            {
               this.SaveCheckBox.Checked = true;
             }
          }
       }
      #endregion

      #region SaveCheckBox_CheckedChanged
      private void SaveCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         this.NameTextBox.Enabled = this.SaveCheckBox.Checked;
       }
      #endregion

      #region Base_Validating
      //protected event ValidatingEventHandler WizardValidating;
      internal void Base_Validating(ref bool Valid, ref string Msg)
      {
         try
         {
            if (this.SaveCheckBox.Checked)
            {

               if (string.IsNullOrEmpty(this.NameTextBox.Text))
               {
                  Valid = false;
                  Msg = "Type the Package Name";
                  return;
                }

               if ( string.IsNullOrEmpty(this.Package.FileName) )
               {
                  this.Package.FileName = this.NameTextBox.Text;
                }

               this.Package.Save();
             }

          }
         catch (Exception ex) { Valid=false; Msg=ex.ToString(); }
       }
      #endregion

      #endregion

   }
}
