using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using System.Reflection;
using System.Web.UI.WebControls;

namespace TRECommon
{
    public class WebControlBind
    {
        #region DropDownList

        public static void DrpBind(Type enumType, DropDownList ddl, string defaultValue, string defaultName)
        {
            ddl.Items.Clear();
            int i = 0;
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    if (!field.IsSpecialName)
                    {
                        ddl.Items.Add(new ListItem(field.Name, field.GetRawConstantValue().ToString()));
                    }
                    else
                    {
                        ddl.Items.Add(new ListItem(field.Name, i.ToString()));
                    }

                    i++;
                }
            }

        }

        public static void DrpBind(Type enumType, DropDownList ddl)
        {
            DrpBind(enumType, ddl, "", "");
        }



        #endregion

        #region RadioList

        public static void RadioBind(Type enumType, RadioButtonList ra)
        {
            ra.Items.Clear();
            int i = 0;
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {
                if (field.FieldType.IsEnum)
                {
                    if (!field.IsSpecialName)
                    {
                        ra.Items.Add(new ListItem(field.Name, field.GetRawConstantValue().ToString()));
                    }
                    else
                    {
                        ra.Items.Add(new ListItem(field.Name, i.ToString()));
                    }

                    i++;
                }
            }

        }

        #endregion

        #region ChkBoxList

        /// <summary>
        /// 获取CheckBoxList 获中值[string a,b,c]
        /// </summary>
        /// <param name="chk">CheckBoxList</param>
        /// <returns>string a,b,c</returns>
        public static string CheckBoxListSelected(CheckBoxList chk)
        {
            string chkValue = "";
            foreach (ListItem item in chk.Items)
            {
                chkValue += item.Selected ? item.Value + "," : "";
            }

            return string.IsNullOrEmpty(chkValue) ? "" : chkValue.Substring(0, chkValue.Length - 1);
        }

        /// <summary>
        /// 判断checkboxlist 是否有选中项
        /// </summary>
        /// <param name="chk">CheckBoxList</param>
        /// <returns>Boolen</returns>
        public static bool IsCheckBoxListSelected(CheckBoxList chk)
        {
            return string.IsNullOrEmpty(CheckBoxListSelected(chk)) ? false : true;
        }

        /// <summary>
        /// CheckBoxList 设置选中项 
        /// </summary>
        /// <param name="chk">CheckBoxList</param>
        /// <param name="values">string[] values</param>
        public static void CheckBoxListSetSelected(CheckBoxList chk, string[] values)
        {
            if (values.Length > 0)
            {
                foreach (ListItem item in chk.Items)
                {
                    if (StringOperation.InArray(item.Value, values, true))
                    {
                        item.Selected = true;
                    }
                }

            }
        }

        /// <summary>
        /// CheckBoxList 设置选中项 
        /// </summary>
        /// <param name="chk">CheckBoxList</param>
        /// <param name="values">string[] values</param>
        public static void CheckBoxListSetSelected(CheckBoxList chk, string values)
        {
            if (values != null && values.Length > 0)
            {
                string[] v = values.Split(',');
                foreach (ListItem item in chk.Items)
                {
                    if (StringOperation.InArray(item.Value, v, true))
                    {
                        item.Selected = true;
                    }

                }

            }
        }

        /// <summary>
        /// CheckBoxList 绑定 DataView
        /// </summary>
        /// <param name="chk">CheckBoxList</param>
        /// <param name="dt">DataView</param>
        public static void CheckBoxListBind(CheckBoxList chk, DataView dv)
        {
            chk.DataSource = dv;
            chk.DataBind();
        }

        public static void CheckBoxListBind(Type enumType, CheckBoxList chk)
        {
            chk.Items.Clear();
            int i = 0;
            System.Reflection.FieldInfo[] fields = enumType.GetFields();
            string strText = string.Empty;
            string strValue = string.Empty;
            foreach (FieldInfo field in fields)
            {


                if (field.FieldType.IsEnum)
                {
                    if (!field.IsSpecialName)
                    {
                        chk.Items.Add(new ListItem(field.Name, field.GetRawConstantValue().ToString()));
                    }
                    else
                    {
                        chk.Items.Add(new ListItem(field.Name, i.ToString()));
                    }
                    i++;
                }
            }
        }


        #endregion

        #region List

        public static string GetListBoxSelectValues(ListBox l)
        {
            string v = "";
            foreach (ListItem item in l.Items)
            {
                if (item.Selected == true)
                {
                    v += item.Value + ",";
                }
            }
            if (v != "" && v.Length > 0)
            {
                return v.Substring(0, v.Length - 1);
            }

            return v;
        }

        public static string GetListBoxSelectValuesAll(ListBox l)
        {
            foreach (ListItem item in l.Items)
            {
                if (item.Value == "0" && item.Selected == true)
                {
                    return "0";
                }
            }
            return GetListBoxSelectValues(l);
        }

        public static string GetListBoxSelectValuesAllIdList(ListBox l)
        {
            string v = "";
            foreach (ListItem item in l.Items)
            {
                if (item.Value == "0" && item.Selected == true)
                {
                    foreach (ListItem i in l.Items)
                    {
                        if (i.Value != "0")
                        {
                            v += i.Value + ",";
                        }
                    }
                    if (v != "" && v.Length > 0)
                    {
                        return v.Substring(0, v.Length - 1);
                    }
                }
            }
            return GetListBoxSelectValues(l);
        }

        public static void SetListBoxSelect(ListBox l, string values)
        {
            if (values != null && values.Length > 0)
            {
                string[] v = values.Split(',');
                foreach (ListItem item in l.Items)
                {
                    item.Selected = false;
                    if (StringOperation.InArray(item.Value, v))
                    {
                        item.Selected = true;
                    }
                }
            }
        }


        #endregion
    }
}
