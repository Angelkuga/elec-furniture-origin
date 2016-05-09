//======================================================================
// 组织名: Troopsen
// 命名空间名称: Utils
// 文件名: TypeConverts
// 创建人: Troopsen
// 创建时间: 2011/3/10 9:39:00
//======================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Text;
using System.Drawing;

namespace TRECommon
{
    public class TypeConverter
    {
        #region ToString

        /// <summary>
        /// 将对象转换为 String
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjToStr(object obj)
        {
            return obj.ToString();
        }
        
        /// <summary>
        /// 将Int 转换为 string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string IntToStr(int value)
        {
            return ObjToStr(value);
        }

        /// <summary>
        /// 将Bool 转换为  string 英文 'true','false'
        /// </summary>
        /// <param name="bol"></param>
        /// <returns></returns>
        public static string BoolToStrEn(bool bol)
        {
            if (bol == true)
                return "true";
            else
                return "false";
        }

        /// <summary>
        /// 将Bool 转换为  string  中文 是,否
        /// </summary>
        /// <param name="bol"></param>
        /// <returns></returns>
        public static string BoolToStrCn(bool bol)
        {
            if (bol == true)
                return "是";
            else
                return "否";
        }

        #endregion

        #region ToInt
        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        /// <summary>
        /// 将对象转换为Int32类型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int ObjectToInt(object expression, int defValue)
        {
            if (expression != null)
                return StrToInt(expression.ToString(), defValue);

            return defValue;
        }

        /// <summary>
        /// 将字符串转换为Int32类型,转换失败返回0
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }

        /// <summary>
        /// 将字符串转换为Int32类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(string str, int defValue)
        {
            if (string.IsNullOrEmpty(str) || str.Trim().Length >= 11 || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
                return defValue;

            int rv;
            if (Int32.TryParse(str, out rv))
                return rv;

            return Convert.ToInt32(StrToFloat(str, defValue));
        }


        #endregion

        #region ToFloat

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float ObjectToFloat(object strValue, float defValue)
        {
            if ((strValue == null))
                return defValue;

            return StrToFloat(strValue.ToString(), defValue);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float ObjectToFloat(object strValue)
        {
            return ObjectToFloat(strValue.ToString(), 0);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string strValue)
        {
            if ((strValue == null))
                return 0;

            return StrToFloat(strValue.ToString(), 0);
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(string strValue, float defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
                return defValue;

            float intValue = defValue;
            if (strValue != null)
            {
                bool IsFloat = Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$");
                if (IsFloat)
                    float.TryParse(strValue, out intValue);
            }
            return intValue;
        }
        #endregion

        #region ToBool

        /// <summary>
        /// 将String 转换为 Bool
        /// </summary>
        /// <param name="strValue">需要转输字符串 true 是 or false否</param>
        /// <param name="defValue">缺省值</param>
        /// <returns></returns>
        public static bool StrToBool(string strValue,bool defValue)
        {
            if (strValue != null)
            {
                if (string.Compare(strValue, "true", true) == 0 || strValue=="是")
                {
                    
                    return true;
                }
                else if (string.Compare(strValue, "false", true) == 0 || strValue=="否")
                {
                    return false;
                }
            }
            return defValue;
        }

        /// <summary>
        /// 将String 转换为 Bool 缺省值 false
        /// </summary>
        /// <param name="strValue">需要转输字符串 true 是 or false否</param>
        /// <returns></returns>
        public static bool StrToBool(string strValue)
        {
            return StrToBool(strValue, false);
        }

        /// <summary>
        /// 将 Int 转为 BOOL (intValue < 1 or intValue>0)
        /// </summary>
        /// <param name="intValue">转要转转换的数字</param>
        /// <param name="defValue">缺省值</param>
        /// <returns></returns>
        public static bool IntToBool(int intValue, bool defValue)
        {
            if (intValue > 0)
                return true;
            else if(intValue<1)
                return false;

            return defValue;
        }

        /// <summary>
        /// 将 Int 转为 BOOL (intValue < 1 or intValue>0) 缺省为 false
        /// </summary>
        /// <param name="intValue">转要转转换的数字</param>
        /// <returns></returns>
        public static bool IntToBool(int intValue)
        {
            return IntToBool(intValue, false);
        }

        public static bool ObjectToBool(object obectValue)
        {
            if (obectValue.ToString().ToLower() == "false")
            {
                return false;
            }
            return true;
        }
        
        #endregion

        #region ToData

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime StrToDateTime(string str, DateTime defValue)
        {
            if (!string.IsNullOrEmpty(str))
            {
                DateTime dateTime;
                if (DateTime.TryParse(str, out dateTime))
                    return dateTime;
            }
            return defValue;
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime StrToDateTime(string str)
        {
            return StrToDateTime(str, DateTime.Now);
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime ObjectToDateTime(object obj)
        {
            return StrToDateTime(obj.ToString());
        }

        /// <summary>
        /// 将对象转换为日期时间类型
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static DateTime ObjectToDateTime(object obj, DateTime defValue)
        {
            return StrToDateTime(obj.ToString(), defValue);
        }

        #endregion

        #region ToColor

        /// <summary>
        /// 将字符串转换为Color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ToColor(string color)
        {
            int red, green, blue = 0;
            char[] rgb;
            color = color.TrimStart('#');
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            switch (color.Length)
            {
                case 3:
                    rgb = color.ToCharArray();
                    red = Convert.ToInt32(rgb[0].ToString() + rgb[0].ToString(), 16);
                    green = Convert.ToInt32(rgb[1].ToString() + rgb[1].ToString(), 16);
                    blue = Convert.ToInt32(rgb[2].ToString() + rgb[2].ToString(), 16);
                    return Color.FromArgb(red, green, blue);
                case 6:
                    rgb = color.ToCharArray();
                    red = Convert.ToInt32(rgb[0].ToString() + rgb[1].ToString(), 16);
                    green = Convert.ToInt32(rgb[2].ToString() + rgb[3].ToString(), 16);
                    blue = Convert.ToInt32(rgb[4].ToString() + rgb[5].ToString(), 16);
                    return Color.FromArgb(red, green, blue);
                default:
                    return Color.FromName(color);

            }
        }

        #endregion

        #region ToDecamal
        public static decimal ObjToDeimal(object obj)
        {
            return obj == null ? 0 : decimal.Parse(obj.ToString());
        }

        public static decimal StrToDeimal(string str)
        {
            return string.IsNullOrEmpty(str) ? 0 : decimal.Parse(str);
        }


        #endregion




    }
}
