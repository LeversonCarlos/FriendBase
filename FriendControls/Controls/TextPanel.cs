using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Base.UI.Controls
{
   internal class TextPanel : ICSharpCode.TextEditor.TextEditorControl
   {

      #region InitializeComponent
      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // TextPanel
         // 
         this.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingStrategyFactory.CreateHighlightingStrategy("SQL");
         this.ShowEOLMarkers = false;
         this.ShowInvalidLines = false;
         this.ShowMatchingBracket = false;
         this.ShowSpaces = false;
         this.ShowTabs = false;
         this.TabIndent = 3;
         this.ConvertTabsToSpaces=true;
         this.IndentStyle= ICSharpCode.TextEditor.Document.IndentStyle.Smart;
         this.TextEditorProperties.ShowVerticalRuler=false;
         this.TextEditorProperties.UseAntiAliasedFont=true;
         this.Font = new System.Drawing.Font("Courier New", 10, System.Drawing.FontStyle.Regular);
         this.ActiveTextAreaControl.Caret.PositionChanged += new EventHandler(TextEditor_CaretPositionChanged);
         this.ActiveTextAreaControl.TextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(TextEditor_KeyDown);
         this.ResumeLayout(false);
      }
      #endregion

      #region NEW
      internal TextPanel()
      {
         this.InitializeComponent();
       }
      #endregion


      #region QueryText
      public string QueryText
      {
         get { return this.Text; }
         set { this.Text = value; this.ActiveTextAreaControl.TextArea.Invalidate(); }
       }
      #endregion

      #region QueryTextSelected
      public string QueryTextSelected
      {
         get 
         {
            if (string.IsNullOrEmpty(this.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText))
            {
               return this.Text;
             }
            else
            {
               return this.ActiveTextAreaControl.TextArea.SelectionManager.SelectedText;
             }
         }
      }
      #endregion

      #region CurrentLine 
      public Int32 CurrentLine
      {
         get{ return this.ActiveTextAreaControl.Caret.Line + 1;}
       }
      #endregion

      #region CurrentColumn 
      public Int32 CurrentColumn
      {
         get { return this.ActiveTextAreaControl.Caret.Column + 1;}
       }
      #endregion


      #region CurrentPositionChanged 
      public delegate void CurrentPositionChangedHandler(Int32 CurrentLine, Int32 CurrentColumn);
      public event CurrentPositionChangedHandler CurrentPositionChanged;
      private void TextEditor_CaretPositionChanged(object sender, EventArgs e)
      {
         if (this.CurrentPositionChanged != null)
         {
            this.CurrentPositionChanged(this.CurrentLine, this.CurrentColumn);
          }
       }
      #endregion

      #region TextEditor_KeyDown 
      //public delegate void KeyDownHandler(Int16 CurrentLine, sys CurrentColumn);
      public new event System.Windows.Forms.KeyEventHandler KeyDown;
      private void TextEditor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         if (e.KeyCode == System.Windows.Forms.Keys.F && e.Control == true) 
         {

            //string sSearchText = this.QueryTextSelected;
            //int iOffset = this.ActiveTextAreaControl.TextArea.Caret.Offset;

            //int iNext = this.QueryText.ToUpper().IndexOf(sSearchText, iOffset);
            //if (iNext != -1)
            //{
            //   this.ActiveTextAreaControl.TextArea.Caret.Column=2; 

            // }


            //ICSharpCode.TextEditor.Util.LookupTable
            
            //Dim obj As New ICSharpCode.SharpDevelop.Gui..Gui.CompletionWindow(Me.objCodeEditorControl.Document)
          }
         else
         {
            if (this.KeyDown != null)
            {
               this.KeyDown(sender, e);
             }
          }
       }
      #endregion

    }
}
