namespace FS.Package.Wizard
{
   partial class ObjectSelector
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
         this.btnRemoveAll = new System.Windows.Forms.Button();
         this.btnRemove = new System.Windows.Forms.Button();
         this.btnSelect = new System.Windows.Forms.Button();
         this.btnSelectAll = new System.Windows.Forms.Button();
         this.oListSelected = new System.Windows.Forms.ListBox();
         this.optSelectionAll = new System.Windows.Forms.RadioButton();
         this.optSelectionCustom = new System.Windows.Forms.RadioButton();
         this.oListAvailable = new System.Windows.Forms.ListBox();
         this.optSelectionNone = new System.Windows.Forms.RadioButton();
         this.SuspendLayout();
         // 
         // btnRemoveAll
         // 
         this.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.btnRemoveAll.Location = new System.Drawing.Point(186, 154);
         this.btnRemoveAll.Name = "btnRemoveAll";
         this.btnRemoveAll.Size = new System.Drawing.Size(42, 23);
         this.btnRemoveAll.TabIndex = 7;
         this.btnRemoveAll.Text = "<<";
         this.btnRemoveAll.UseVisualStyleBackColor = true;
         this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
         // 
         // btnRemove
         // 
         this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.btnRemove.Location = new System.Drawing.Point(186, 125);
         this.btnRemove.Name = "btnRemove";
         this.btnRemove.Size = new System.Drawing.Size(42, 23);
         this.btnRemove.TabIndex = 6;
         this.btnRemove.Text = "<";
         this.btnRemove.UseVisualStyleBackColor = true;
         this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
         // 
         // btnSelect
         // 
         this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.btnSelect.Location = new System.Drawing.Point(186, 96);
         this.btnSelect.Name = "btnSelect";
         this.btnSelect.Size = new System.Drawing.Size(42, 23);
         this.btnSelect.TabIndex = 5;
         this.btnSelect.Text = ">";
         this.btnSelect.UseVisualStyleBackColor = true;
         this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
         // 
         // btnSelectAll
         // 
         this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
         this.btnSelectAll.Location = new System.Drawing.Point(186, 67);
         this.btnSelectAll.Name = "btnSelectAll";
         this.btnSelectAll.Size = new System.Drawing.Size(42, 23);
         this.btnSelectAll.TabIndex = 4;
         this.btnSelectAll.Text = ">>";
         this.btnSelectAll.UseVisualStyleBackColor = true;
         this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
         // 
         // oListSelected
         // 
         this.oListSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.oListSelected.FormattingEnabled = true;
         this.oListSelected.Location = new System.Drawing.Point(234, 49);
         this.oListSelected.Name = "oListSelected";
         this.oListSelected.Size = new System.Drawing.Size(159, 147);
         this.oListSelected.TabIndex = 8;
         // 
         // optSelectionAll
         // 
         this.optSelectionAll.AutoSize = true;
         this.optSelectionAll.Checked = true;
         this.optSelectionAll.Location = new System.Drawing.Point(3, -3);
         this.optSelectionAll.Name = "optSelectionAll";
         this.optSelectionAll.Size = new System.Drawing.Size(103, 17);
         this.optSelectionAll.TabIndex = 0;
         this.optSelectionAll.Text = "Use ALL objects";
         this.optSelectionAll.UseVisualStyleBackColor = true;
         this.optSelectionAll.CheckedChanged += new System.EventHandler(this.TypeSelection_All);
         // 
         // optSelectionCustom
         // 
         this.optSelectionCustom.AutoSize = true;
         this.optSelectionCustom.Location = new System.Drawing.Point(3, 31);
         this.optSelectionCustom.Name = "optSelectionCustom";
         this.optSelectionCustom.Size = new System.Drawing.Size(175, 17);
         this.optSelectionCustom.TabIndex = 2;
         this.optSelectionCustom.Text = "Use ONLY the following objects";
         this.optSelectionCustom.UseVisualStyleBackColor = true;
         this.optSelectionCustom.CheckedChanged += new System.EventHandler(this.TypeSelection_Custom);
         // 
         // oListAvailable
         // 
         this.oListAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.oListAvailable.FormattingEnabled = true;
         this.oListAvailable.Location = new System.Drawing.Point(22, 49);
         this.oListAvailable.Name = "oListAvailable";
         this.oListAvailable.Size = new System.Drawing.Size(158, 147);
         this.oListAvailable.TabIndex = 3;
         // 
         // optSelectionNone
         // 
         this.optSelectionNone.AutoSize = true;
         this.optSelectionNone.ForeColor = System.Drawing.Color.DarkRed;
         this.optSelectionNone.Location = new System.Drawing.Point(3, 14);
         this.optSelectionNone.Name = "optSelectionNone";
         this.optSelectionNone.Size = new System.Drawing.Size(164, 17);
         this.optSelectionNone.TabIndex = 1;
         this.optSelectionNone.Text = "Don´t use ANY of this objects";
         this.optSelectionNone.UseVisualStyleBackColor = true;
         this.optSelectionNone.CheckedChanged += new System.EventHandler(this.TypeSelection_None);
         // 
         // ObjectSelector
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.oListAvailable);
         this.Controls.Add(this.optSelectionNone);
         this.Controls.Add(this.btnRemoveAll);
         this.Controls.Add(this.btnRemove);
         this.Controls.Add(this.btnSelect);
         this.Controls.Add(this.btnSelectAll);
         this.Controls.Add(this.oListSelected);
         this.Controls.Add(this.optSelectionAll);
         this.Controls.Add(this.optSelectionCustom);
         this.Name = "ObjectSelector";
         this.Size = new System.Drawing.Size(420, 204);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnRemoveAll;
      private System.Windows.Forms.Button btnRemove;
      private System.Windows.Forms.Button btnSelect;
      private System.Windows.Forms.Button btnSelectAll;
      internal System.Windows.Forms.ListBox oListSelected;
      internal System.Windows.Forms.ListBox oListAvailable;
      internal System.Windows.Forms.RadioButton optSelectionAll;
      internal System.Windows.Forms.RadioButton optSelectionCustom;
      internal System.Windows.Forms.RadioButton optSelectionNone;
   }
}
