using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Connector
{

   public class cItems : System.Collections.IEnumerable, IDisposable
   {
      
      #region New
      internal cItems()
      {
       }
      #endregion

      #region Item
      public cItem this[string Name]
      {
         get
         {
            if (this.Items.Contains(Name))
            {
               return (cItem)this.Items[Name];
            }
            else
            {
               return null;
            }
          }
      }
      #endregion

      #region Items
      private System.Collections.SortedList tmp_Items;
      private System.Collections.SortedList Items
      {
         get
         {
            if (tmp_Items == null)
            {
               tmp_Items = new System.Collections.SortedList();
             }
            return tmp_Items;
          }
       }
      #endregion

      #region Contains
      public bool Contains(string Key)
      {
         return this.Items.Contains(Key);
      }
      #endregion

      #region Clear
      public void Clear()
      {
         this.Items.Clear();
       }
      #endregion

      #region Remove
      public void Remove(cItem oConnItem)
      {
         this.ItemRemoved(oConnItem);
         this.Items.Remove(oConnItem.Name);
       }
      public void Remove(string Name)
      {
         this.ItemRemoved(((cItem) this.Items[Name]));
         this.Items.Remove(Name);
       }
      #endregion

      #region Add
      public void Add(string Type, string Name)
      {
         if (! this.Items.Contains(Name))
         {
            cItem oItem = new cItem(Type, Name);
            this.Items.Add(Name, oItem);
            oItem.ItemChanged += Base_ItemChanged;
            oItem.ItemRenamed += Base_ItemRenamed;
            oItem.GetWizardProperties += Base_GetWizardProperties;
            this.ItemChanged(oItem);
         }
       }

      internal void Add(string Content, bool Loading)
      {
         cItem oItem = new cItem();
         oItem.Load(Content);
         this.Add(oItem);
      }

      public void Add(cItem oItem)
      {
         if (!string.IsNullOrEmpty(oItem.Name))
         {
            this.Items.Add(oItem.Name, oItem);
            oItem.ItemChanged += Base_ItemChanged;
            oItem.ItemRenamed += Base_ItemRenamed;
            oItem.GetWizardProperties += Base_GetWizardProperties;
            this.ItemChanged(oItem);
         }
      }
      #endregion

      #region Count
      public Int32 Count
      {
         get { return this.Items.Count; }
       }
      #endregion

      #region GetEnumerator
      System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
         return this.Items.Values.GetEnumerator();
      }
      #endregion

      #region Dispose
      private bool disposed = false;
      public void Dispose()
      {
         this.Dispose(true);
         GC.SuppressFinalize(this);
      }
      private void Dispose(bool disposing)
      {
         if (!this.disposed)
         {
            if (tmp_Items != null)
            {
               tmp_Items.Clear();
               tmp_Items = null;
            }
         }
         disposed = true;
      }
      #endregion


      #region ItemChanged
      internal event cItem.ItemEventHandler ItemChanged;
      private void Base_ItemChanged(cItem sender)
      {
         this.ItemChanged(sender);
       }
      #endregion

      #region ItemRenamed
      internal event cItem.ItemRenamedEventHandler ItemRenamed;
      private void Base_ItemRenamed(cItem sender, string NewName)
      {
         string OldName = sender.Name;
         this.ItemRenamed(sender, NewName);
         if (sender.Name == NewName)
         {
            this.Add(sender);
            //this.Remove(OldName);
          }
       }
      #endregion

      #region Base_ItemRenamed
      #endregion

      #region ItemRemoved
      //internal delegate void ItemRemovedEventHandler(cItem sender);
      internal event cItem.ItemEventHandler ItemRemoved;
      //private void Base_ItemRemoved(cItem sender)
      //{
      //   this.ItemRemoved(sender);
      //}
      #endregion

      #region Base_GetWizardProperties
      internal event Wizard.WizardForm.GetWizardPropertiesEventHandler GetWizardProperties;
      private void Base_GetWizardProperties(FS.Wizard.WizardForm sender)
      {
         if (this.GetWizardProperties != null)
         {
            this.GetWizardProperties(sender);
          }
       }
      #endregion

   }

}
