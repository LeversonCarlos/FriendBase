namespace FS.Connector.Wizard
{
   partial class TypeSelector
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
         this.components = new System.ComponentModel.Container();
         this.oListView = new System.Windows.Forms.ListView();
         this.colDescription = new System.Windows.Forms.ColumnHeader();
         this.oImageList = new System.Windows.Forms.ImageList(this.components);
         this.SuspendLayout();
         // 
         // oListView
         // 
         this.oListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.oListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescription});
         this.oListView.FullRowSelect = true;
         this.oListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
         this.oListView.Location = new System.Drawing.Point(96, 63);
         this.oListView.MultiSelect = false;
         this.oListView.Name = "oListView";
         this.oListView.ShowGroups = false;
         this.oListView.ShowItemToolTips = true;
         this.oListView.Size = new System.Drawing.Size(302, 121);
         this.oListView.SmallImageList = this.oImageList;
         this.oListView.TabIndex = 1;
         this.oListView.UseCompatibleStateImageBehavior = false;
         this.oListView.View = System.Windows.Forms.View.Details;
         // 
         // colDescription
         // 
         this.colDescription.Width = 280;
         // 
         // oImageList
         // 
         this.oImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
         this.oImageList.ImageSize = new System.Drawing.Size(16, 16);
         this.oImageList.TransparentColor = System.Drawing.Color.Transparent;
         // 
         // TypeSelector
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
         this.Controls.Add(this.oListView);
         this.Name = "TypeSelector";
         this.Title = "Select a data engine to use";
         this.Controls.SetChildIndex(this.oListView, 0);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ListView oListView;
      private System.Windows.Forms.ColumnHeader colDescription;
      private System.Windows.Forms.ImageList oImageList;

   }
}
