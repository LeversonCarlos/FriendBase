using System;
using System.Collections.Generic;
using System.Text;

namespace FS.Data.Common
{
   public class ConnKey
   {

      #region Key
      private string tmp_Key; 
      public string Key
      {
         get { return tmp_Key; }
         set { tmp_Key = value; }
       }
      #endregion

      #region Type
      private System.Type tmp_Type;
      public System.Type Type
      {
         get { return tmp_Type; }
         set { tmp_Type = value; }
       }
      #endregion

      #region Default
      private object tmp_Default;
      public object Default
      {
          get { return tmp_Default; }
          set { tmp_Default = value; }
       }
      #endregion

      #region Step
      private string tmp_Step;
      public string Step
      {
         get { return tmp_Step; }
         set { tmp_Step = value; }
      }
      #endregion

      #region Required
      private bool tmp_Required = true;
      public bool Required
      {
         get { return tmp_Required; }
         set { tmp_Required = value; }
      }
      #endregion

      #region Value
      private object tmp_Value;
      public object Value
       {
          get { return tmp_Value; }
          set { tmp_Value = value; }
       }
       #endregion


      #region isEmpty
      private bool isEmpty(object oValue)
      {
         bool bRET = true;
         if (oValue != null)
         {
            if (this.Type.Equals(System.Type.GetType("System.String")))
            {
               if (!string.IsNullOrEmpty(oValue.ToString()))
               {
                  bRET = false;
                }
             }
            else if (this.Type.Equals(System.Type.GetType("System.DateTime")))
            {
                if (System.DateTime.MinValue != ((DateTime)oValue))
                {
                   bRET = false;
                }
             }
            else
            {
                bRET = false;
              }
         }
         return bRET;
       }
      #endregion

      #region GetValue
      public object GetValue()
      {
         try
         {
            //if (this.Value != null) 
            if (!this.isEmpty(this.Value))
            {
               return Convert.ChangeType(this.Value, this.Type);
            }
            //else if (this.Default != null) 
            else if (!this.isEmpty(this.Default))
            {
               return Convert.ChangeType(this.Default, this.Type);
            }
            else
            {
               //return null;
               return Convert.ChangeType(null, this.Type);
            }
         }
         catch 
         {
            return null;
          }
       }
      #endregion

      #region ToValueString
      public string ToValueString()
      {
         object oRET = this.GetValue();
         if (oRET == null)
         {
            oRET = string.Empty;
          }
          return oRET.ToString();
       }
      #endregion

    }
 }
