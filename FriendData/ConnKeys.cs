using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Data.Common
{
   public class ConnKeys : System.Collections.IEnumerable, IDisposable
   {

      #region Add
      public ConnKey Add(string Key, System.Type Type)
      {
         return this.Add(Key, Type, "General", null);
       }
      public ConnKey Add(string Key, System.Type Type, string Step)
      {
         return this.Add(Key, Type, Step, null);
      }
      public ConnKey Add(string Key, System.Type Type, string Step, object Default)
      {
         ConnKey oItem = new ConnKey();
         oItem.Key = Key;
         oItem.Type = Type;
         oItem.Default = Default;
         oItem.Step = Step;

         int iItem = (this.Items.Count);
         this.ItemsKeys.Add(Key, iItem);
         this.Items.Add(oItem);

         return oItem;
       }
      #endregion

      #region Item
      public ConnKey this[string Key]
      {
         get
         {
            if (this.ItemsKeys.Contains(Key))
            {
               return (ConnKey)this.Items[((int)this.ItemsKeys[Key])];
             }
            else
            {
               return null;
             }
          }
       }
      #endregion

      #region ItemsKeys
      private System.Collections.SortedList tmp_ItemsKeys;
      private System.Collections.SortedList ItemsKeys
      {
          get
          {
             if (tmp_ItemsKeys == null)
             {
                tmp_ItemsKeys = new System.Collections.SortedList();
             }
             return tmp_ItemsKeys;
          }
       }
       #endregion

      #region Items
      private System.Collections.ArrayList tmp_Items;
      private System.Collections.ArrayList Items 
       {
         get
         {
            if (tmp_Items == null)
            {
               tmp_Items = new System.Collections.ArrayList();
               tmp_ItemsKeys = new System.Collections.SortedList();
             }
            return tmp_Items;
          }
       }
      #endregion

      #region Clear
      public void Clear()
      {
         this.Items.Clear();
         this.ItemsKeys.Clear();
      }
      #endregion

      #region ClearValues
      public void ClearValues()
      {
         foreach (ConnKey oItem in this.Items)
         {
            oItem.Value = null;
          }
      }
      #endregion

      #region Count
      public Int32 Count
      {
         get { return this.Items.Count; }
       }
      #endregion

      #region Load
      public void Load(string sKeys)
      {
         string[] aKeys = sKeys.Split(';');
         foreach (string sKey in aKeys)
         {
            if (!string.IsNullOrEmpty(sKey))
            {
               string[] aKeyValue = sKey.Split('=');
               string sItemKey = aKeyValue.GetValue(0).ToString();
               string sItemValue = aKeyValue.GetValue(1).ToString();

               ((ConnKey)this[sItemKey]).Value = sItemValue;
            }
         }

       }
      #endregion


      #region GetEnumerator
       System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
      {
         return this.Items.GetEnumerator();
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
               tmp_Items = null;
            }
            if (tmp_ItemsKeys != null)
            {
               tmp_ItemsKeys = null;
            }
         }
         disposed = true;
       }
      #endregion


      #region ToTypeArray 
      public System.Type[] ToTypeArray()
      {
         System.Collections.ArrayList aTypes = null;

         try
         {
            aTypes = new System.Collections.ArrayList();
            foreach (ConnKey oItem in this.Items)
            {
               aTypes.Add(oItem.Type); 
             }
          }
         catch { }
         return (System.Type[])aTypes.ToArray(System.Type.GetType("System.Type"));
       }
      #endregion

      #region ToValueArray
      public object[] ToValueArray()
      {
         System.Collections.ArrayList aValues = null;
         try
         {
            aValues = new System.Collections.ArrayList();
            foreach (ConnKey oItem in this.Items)
            {
               aValues.Add(oItem.GetValue());
             }
          }
         catch { }
         return aValues.ToArray();
      }
      #endregion

      #region ToValueList
      public string ToValueList()
      {
         string sRET = string.Empty;
         foreach (ConnKey oItem in this.Items)
         {
            sRET += oItem.Key + "=";
            sRET += oItem.ToValueString() + ";";
         }
         return sRET;
       }
      #endregion

    }
}
