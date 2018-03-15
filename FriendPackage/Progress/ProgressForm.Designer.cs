namespace FS.Package.Progress
{
   partial class ProgressForm
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
         this.TasksGroup = new System.Windows.Forms.GroupBox();
         this.ProgressGroup = new System.Windows.Forms.GroupBox();
         this.oProgressBar = new System.Windows.Forms.ProgressBar();
         this.CheckTables = new System.Windows.Forms.CheckBox();
         this.CheckViews = new System.Windows.Forms.CheckBox();
         this.CheckProcedures = new System.Windows.Forms.CheckBox();
         this.CheckFunctions = new System.Windows.Forms.CheckBox();
         this.CheckData = new System.Windows.Forms.CheckBox();
         this.CheckClose = new System.Windows.Forms.CheckBox();
         this.CheckOpen = new System.Windows.Forms.CheckBox();
         this.TasksGroup.SuspendLayout();
         this.ProgressGroup.SuspendLayout();
         this.SuspendLayout();
         // 
         // TasksGroup
         // 
         this.TasksGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.TasksGroup.Controls.Add(this.CheckOpen);
         this.TasksGroup.Controls.Add(this.CheckClose);
         this.TasksGroup.Controls.Add(this.CheckData);
         this.TasksGroup.Controls.Add(this.CheckFunctions);
         this.TasksGroup.Controls.Add(this.CheckProcedures);
         this.TasksGroup.Controls.Add(this.CheckViews);
         this.TasksGroup.Controls.Add(this.CheckTables);
         this.TasksGroup.Location = new System.Drawing.Point(12, 12);
         this.TasksGroup.Name = "TasksGroup";
         this.TasksGroup.Size = new System.Drawing.Size(140, 191);
         this.TasksGroup.TabIndex = 0;
         this.TasksGroup.TabStop = false;
         // 
         // ProgressGroup
         // 
         this.ProgressGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.ProgressGroup.Controls.Add(this.oProgressBar);
         this.ProgressGroup.Location = new System.Drawing.Point(12, 209);
         this.ProgressGroup.Name = "ProgressGroup";
         this.ProgressGroup.Size = new System.Drawing.Size(140, 44);
         this.ProgressGroup.TabIndex = 1;
         this.ProgressGroup.TabStop = false;
         // 
         // oProgressBar
         // 
         this.oProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.oProgressBar.Location = new System.Drawing.Point(6, 14);
         this.oProgressBar.Name = "oProgressBar";
         this.oProgressBar.Size = new System.Drawing.Size(127, 23);
         this.oProgressBar.TabIndex = 0;
         // 
         // CheckTables
         // 
         this.CheckTables.AutoSize = true;
         this.CheckTables.Enabled = false;
         this.CheckTables.Location = new System.Drawing.Point(14, 45);
         this.CheckTables.Name = "CheckTables";
         this.CheckTables.Size = new System.Drawing.Size(63, 17);
         this.CheckTables.TabIndex = 1;
         this.CheckTables.TabStop = false;
         this.CheckTables.Text = "Tables";
         this.CheckTables.UseVisualStyleBackColor = true;
         // 
         // CheckViews
         // 
         this.CheckViews.AutoSize = true;
         this.CheckViews.Enabled = false;
         this.CheckViews.Location = new System.Drawing.Point(14, 68);
         this.CheckViews.Name = "CheckViews";
         this.CheckViews.Size = new System.Drawing.Size(59, 17);
         this.CheckViews.TabIndex = 2;
         this.CheckViews.TabStop = false;
         this.CheckViews.Text = "Views";
         this.CheckViews.UseVisualStyleBackColor = true;
         // 
         // CheckProcedures
         // 
         this.CheckProcedures.AutoSize = true;
         this.CheckProcedures.Enabled = false;
         this.CheckProcedures.Location = new System.Drawing.Point(14, 91);
         this.CheckProcedures.Name = "CheckProcedures";
         this.CheckProcedures.Size = new System.Drawing.Size(90, 17);
         this.CheckProcedures.TabIndex = 3;
         this.CheckProcedures.TabStop = false;
         this.CheckProcedures.Text = "Procedures";
         this.CheckProcedures.UseVisualStyleBackColor = true;
         // 
         // CheckFunctions
         // 
         this.CheckFunctions.AutoSize = true;
         this.CheckFunctions.Enabled = false;
         this.CheckFunctions.Location = new System.Drawing.Point(14, 114);
         this.CheckFunctions.Name = "CheckFunctions";
         this.CheckFunctions.Size = new System.Drawing.Size(79, 17);
         this.CheckFunctions.TabIndex = 4;
         this.CheckFunctions.TabStop = false;
         this.CheckFunctions.Text = "Functions";
         this.CheckFunctions.UseVisualStyleBackColor = true;
         // 
         // CheckData
         // 
         this.CheckData.AutoSize = true;
         this.CheckData.Enabled = false;
         this.CheckData.Location = new System.Drawing.Point(14, 137);
         this.CheckData.Name = "CheckData";
         this.CheckData.Size = new System.Drawing.Size(53, 17);
         this.CheckData.TabIndex = 5;
         this.CheckData.TabStop = false;
         this.CheckData.Text = "Data";
         this.CheckData.UseVisualStyleBackColor = true;
         // 
         // CheckClose
         // 
         this.CheckClose.AutoSize = true;
         this.CheckClose.Enabled = false;
         this.CheckClose.Location = new System.Drawing.Point(14, 160);
         this.CheckClose.Name = "CheckClose";
         this.CheckClose.Size = new System.Drawing.Size(58, 17);
         this.CheckClose.TabIndex = 6;
         this.CheckClose.TabStop = false;
         this.CheckClose.Text = "Close";
         this.CheckClose.UseVisualStyleBackColor = true;
         // 
         // CheckOpen
         // 
         this.CheckOpen.AutoSize = true;
         this.CheckOpen.Enabled = false;
         this.CheckOpen.Location = new System.Drawing.Point(14, 22);
         this.CheckOpen.Name = "CheckOpen";
         this.CheckOpen.Size = new System.Drawing.Size(56, 17);
         this.CheckOpen.TabIndex = 0;
         this.CheckOpen.TabStop = false;
         this.CheckOpen.Text = "Open";
         this.CheckOpen.UseVisualStyleBackColor = true;
         // 
         // ProgressForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(164, 265);
         this.Controls.Add(this.ProgressGroup);
         this.Controls.Add(this.TasksGroup);
         this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "ProgressForm";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Progress";
         this.TasksGroup.ResumeLayout(false);
         this.TasksGroup.PerformLayout();
         this.ProgressGroup.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox TasksGroup;
      private System.Windows.Forms.GroupBox ProgressGroup;
      internal System.Windows.Forms.ProgressBar oProgressBar;
      internal System.Windows.Forms.CheckBox CheckTables;
      internal System.Windows.Forms.CheckBox CheckViews;
      internal System.Windows.Forms.CheckBox CheckProcedures;
      internal System.Windows.Forms.CheckBox CheckFunctions;
      internal System.Windows.Forms.CheckBox CheckData;
      internal System.Windows.Forms.CheckBox CheckOpen;
      internal System.Windows.Forms.CheckBox CheckClose;
   }
}