using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Connector
{
   public class cItem: IDisposable
      {

      internal delegate void ItemEventHandler(cItem sender);
      internal event ItemEventHandler ItemChanged;

         #region NEW
         internal cItem() { }

         internal cItem(string sType)
         {
            tmp_Type = sType;
          }

         internal cItem(string sType, string sName)
         {
            tmp_Name = sName;
            tmp_Type = sType;
          }

         #endregion

         #region PROPERTIES

         #region ID
         /*
         private Guid tmp_ID = Guid.Empty;
         public string ID
         {
            get
            {
               if (tmp_ID = Guid.Empty)
               {
                  tmp_ID = new Guid();
                }
               return tmp_ID.ToString();
             }
          }
         */ 
         #endregion

         #region Name
         private string tmp_Name;
         public string Name
         {
            get { return tmp_Name; }
          }
         internal void NameSet(string value)
         {
            tmp_Name = value;
          }
         #endregion

         #region Type
         private string tmp_Type;
         public string Type
         {
            get { return tmp_Type; }
          }
         internal void TypeSet(string value)
         {
            tmp_Type = value;
         }
         #endregion

         #region ConnKeys
         private FS.Data.Common.ConnKeys tmp_ConnKeys;
         internal FS.Data.Common.ConnKeys ConnKeys
         {
            get 
            {
               if (tmp_ConnKeys == null)
               {
                  tmp_ConnKeys = FS.Data.Common.Abstracter.GetConnKeys(this.Type);
                  /*
                  Abstracter oAbstracter = null;
                  oAbstracter = new Abstracter(this.Type);
                  tmp_ConnKeys = oAbstracter.GetConnKeys();
                  oAbstracter.Dispose();
                  oAbstracter = null;
                   * */
                }
               return tmp_ConnKeys; 
             }
          }
         #endregion

         #region EditForm
         internal event Wizard.WizardForm.GetWizardPropertiesEventHandler GetWizardProperties;
         private Wizard.WizardForm tmp_EditForm;
         private Wizard.WizardForm EditForm
         {
            get
            {
               if (tmp_EditForm == null)
               {
                  tmp_EditForm = new FS.Connector.Wizard.WizardForm();
                  //tmp_EditForm.WizardChanged += EditForm_WizardChanged;
                  tmp_EditForm.GetConnItem += EditForm_GetConnItem;
                  if (this.GetWizardProperties != null)
                  {
                     this.GetWizardProperties(tmp_EditForm);
                   }
                }
               return tmp_EditForm;
             }
          }
         private void EditForm_GetConnItem(ref cItem Value)
         {
            Value = this;
          }
         /*
         private void EditForm_WizardChanged()
         {
            this.ItemChanged(this);
            if (tmp_EditForm != null)
            {
               tmp_EditForm.Dispose();
               tmp_EditForm = null;
             }
          }
         */
         #endregion

         #endregion

         #region METHODS

         #region Load
         internal void Load(string sContent)
         {
            sContent = FS.Common.Type.Decrypt(sContent);
            if (sContent.StartsWith("|") && sContent.EndsWith("|"))
            {
               foreach (string sContentItem in sContent.Split('|'))
               {
                  if (!string.IsNullOrEmpty(sContentItem))
                  {
                     string[] sContentSubItem = sContentItem.Split('>');
                     string sKey = sContentSubItem.GetValue(0).ToString();
                     string sValue = sContentSubItem.GetValue(1).ToString();

                     if (sKey.ToUpper() == "NAME") { tmp_Name = sValue; }
                     else if (sKey.ToUpper() == "TYPE") { tmp_Type = sValue; }
                     else if (sKey.ToUpper() == "KEYS") 
                     {
                        if (this.ConnKeys != null)
                        {
                           this.ConnKeys.Load(sValue);
                           //{ tmp_Keys = new cItemKeys(sValue); }
                         }
                      } 
                  }
               }
            }

          }
         #endregion

         #region ClearKeys
         public void ClearKeys()
         {
            this.ConnKeys.ClearValues();
            this.ItemChanged(this);
          }
         #endregion

         #region AddKey
         public void AddKey(string Key, object Value)
         {
            try
            {
               this.ConnKeys[Key].Value = Value;
               this.ItemChanged(this);
            }
            catch { }
          }
         #endregion

         #region GetKey
         public object GetKey(string Key)
         {
            try
            {
               return this.ConnKeys[Key].Value;
             }
            catch 
            {
               return null;
             }
          }
         #endregion

         #region Rename
         internal delegate void ItemRenamedEventHandler(cItem sender, string NewName);
         internal event ItemRenamedEventHandler ItemRenamed;
         public void Rename(string sName)
         {
            try
            {
               this.ItemRenamed(this, sName);
             }
            catch(Exception ex)
            {
               System.Windows.Forms.MessageBox.Show(ex.Message, "ALERT", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
             }
          }
         #endregion

         #region ShowEditForm
         public System.Windows.Forms.DialogResult ShowEditForm()
         {
            System.Windows.Forms.DialogResult oRET = System.Windows.Forms.DialogResult.Cancel;
            try
            {
               this.EditForm.Initialize();
               oRET = this.EditForm.ShowDialog();
               if (oRET == System.Windows.Forms.DialogResult.OK)
               {
                  this.ItemChanged(this);
                }
             }
            catch (Exception ex) { }
            finally
            {
               this.EditForm.Dispose();
               tmp_EditForm = null;
             }
            return oRET; 
          }
         #endregion

         #region ToContent
         public string ToContent()
         {
             string sRET = string.Empty;

             sRET += "|";
             sRET += "Name>" + this.Name + "|";
             sRET += "Type>" + this.Type + "|";
             sRET += "Keys>";
             if (this.ConnKeys != null)
             {
                sRET += this.ConnKeys.ToValueList();
             }
             sRET += "|";

             sRET = FS.Common.Type.Encrypt(sRET);

             return sRET;
          }
         #endregion


         #region GetData
         public FS.Data.Common.Data GetData()
         {
            return FS.Data.Common.Abstracter.GetDataByTypeName(this.Type, this.ConnKeys);
            /*
            FS.Data.Common.Data oRET = null;
            Abstracter objAbstracter = null;
            try
            {
               objAbstracter = new Abstracter(this.Type);
               oRET = objAbstracter.GetData(this.ConnKeys);
            }
            catch (System.Exception ex) { throw ex; }
            finally
            {
               objAbstracter.Dispose();
               objAbstracter = null;
            }
            return oRET;
            */ 
         }
         #endregion

         #region GetConnSteps
         internal System.Collections.ArrayList GetConnSteps()
         {
            System.Collections.ArrayList oConnSteps = null;
            FS.Data.Common.Data oData = null;
            try
            {
               oData = this.GetData();
               oConnSteps = oData.ConnectionStringSteps;
             }
            catch { }
            finally
            {
               if (oData != null)
               {
                  oData.Dispose();
                  oData = null;
                }
             }
            return oConnSteps;
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
                if (tmp_EditForm != null)
                {
                   tmp_EditForm.Dispose();
                   tmp_EditForm = null;
                 }
                if (tmp_ConnKeys != null)
                {
                   tmp_ConnKeys.Dispose();
                   tmp_ConnKeys = null;
                }
             }
             disposed = true;
          }
          #endregion

         #endregion

        }
}
