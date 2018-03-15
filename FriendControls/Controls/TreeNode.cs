using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Base.UI.Controls
{
   public enum NodeTypeEnum
   {
      None = 0,
      Engine = 1,
      Database = 2,
      Editor = 3,
      Tables = 4,
      Table = 5,
      Views = 6,
      View = 7,
      Procedures = 8,
      Procedure = 9,
      Functions = 10,
      Function = 11, 
      TableColumns = 12,
      TableColumn = 13,
      TableIndexes = 14,
      TableIndex = 15,
      TableTriggers = 16 
   }

   public class TreeNode : System.Windows.Forms.TreeNode
   {

      #region NEW
      public TreeNode(string sText)
      {
         base.Text = sText;
       }
      #endregion

      #region Type
      private NodeTypeEnum tmp_Type = NodeTypeEnum.None;
      public NodeTypeEnum Type
      {
         get { return tmp_Type; }
         set { tmp_Type = value; }
       }
      #endregion

      #region OnOff
      private bool tmp_OnOff = false;
      public bool OnOff
      {
         get { return tmp_OnOff; }
         set 
         { 
            tmp_OnOff = value;
            string sImageKey = this.GetImageKey();
            this.ImageKey = sImageKey;
            this.SelectedImageKey = sImageKey;
         }
       }
      #endregion

      #region Connector
      private object tmp_Connector = null;
      public object Connector
      {
         get { return tmp_Connector; }
         set { tmp_Connector = value; }
      }
      #endregion


      #region GetImageKey
      private string GetImageKey()
      {
         switch (this.Type)
         {
            case NodeTypeEnum.Database:
               return (this.OnOff ? "DatabaseOn" : "DatabaseOff");

            case NodeTypeEnum.Editor:
               return "Editor";

            case NodeTypeEnum.Tables:
               return "Tables";
            case NodeTypeEnum.Table:
               return "Table";
               
            case NodeTypeEnum.Views:
               return "Views";
            case NodeTypeEnum.View:
               return "View";

            case NodeTypeEnum.Procedures:
               return "Procedures";
            case NodeTypeEnum.Procedure:
               return "Procedure";

            case NodeTypeEnum.Functions:
               return "Functions";
            case NodeTypeEnum.Function:
               return "Function";

            case NodeTypeEnum.TableColumns:
            case NodeTypeEnum.TableIndexes:
            case NodeTypeEnum.TableTriggers:
               return "Directory";

            default:
               return this.ImageKey;
         }
       }
      #endregion

      #region GetParentNodeByType 
      public TreeNode GetParentNodeByType(NodeTypeEnum eType)
      {
         return this.GetParentNodeByType(this, eType);
       }
      private TreeNode GetParentNodeByType(TreeNode oNode, NodeTypeEnum eType)
      {
         if (oNode.Type == eType)
         {
            return oNode;
          }
         else
         {
            return this.GetParentNodeByType(((TreeNode)oNode.Parent), eType);
          }
       }
      #endregion


   }
}
