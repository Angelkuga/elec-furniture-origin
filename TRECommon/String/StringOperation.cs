//======================================================================
// 组织名: Troopsen
// 命名空间名称: Utils
// 文件名: StringOperation
// 创建人: Troopsen
// 创建时间: 2011/3/10 8:39:00
//======================================================================
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Data;

namespace TRECommon
{
    public class StringOperation
    {

        //正则表达式

        //回车 换行 正则
        private static Regex RegexBr = new Regex("@(\r\n)",RegexOptions.IgnoreCase);


        #region 长度

        /// <summary>
        /// 返回字符串真实长度 1英文=1  1中文=2
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns>返回长度（int）</returns>
        public static int GetStringLength(string str)
        {
            if (str == string.Empty || str == null || str=="")
                return 0;
            else
                return System.Text.Encoding.Default.GetBytes(str).Length;
        }

        /// <summary>
        /// 获取 不包括 回车 空格 换行 字符串长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetNoBRTrimStringLength(string str)
        {
            return GetStringLength(HTMLUtils.RTrim(str));
        }

        /// <summary>
        /// 获取 不包括 回车 换行 字符串长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetNoBRStringLength(string str)
        {
            return GetStringLength(HTMLUtils.ClearBR(str));
        }

        /// <summary>
        /// 获取 不包括 空格的字符串长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetNoTrimStringLength(string str)
        {
            return GetStringLength(str.Trim());
        }


        #endregion

        #region 是否存在

        //==================字符串======================================
        public static bool InString(string strSearch,string strSource)
        {
            return strSource.Contains(strSearch);
        }

        //==================数组======================================
        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0;
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">字符串数组</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        /// <summary>
        /// 判断指定字符串是否属于指定字符串数组中的一个元素
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="stringarray">内部以逗号分割单词的字符串</param>
        /// <param name="strsplit">分割字符串</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>判断结果</returns>
        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }

        #endregion

        #region 判断位置


        //=================数组========================


        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <param name="caseInsensetive">是否不区分大小写, true为不区分, false为区分</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                        return i;
                }
                else if (strSearch == stringArray[i])
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// 判断指定字符串在指定字符串数组中的位置
        /// </summary>
        /// <param name="strSearch">字符串</param>
        /// <param name="stringArray">字符串数组</param>
        /// <returns>字符串在指定字符串数组中的位置, 如不存在则返回-1</returns>		
        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }


        /// <summary>
        /// 去除数组中重复的记录并排序
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="orderByType">排序方式</param>
        /// <returns>处理后的数组</returns>
        public static string[] SortAndDdistinct(string[] array, OrderByType orderByType)
        {
            List<String> result = new List<string>();
            string[] newArray = array;
            bool isChange = false;      //本次循环是否排序过
            int j = 0;                  //排序循环叠加变量
            if (OrderByType.ASC == orderByType)  //升序
            {
                for (int i = 0; i < newArray.Length; i++)
                {
                    isChange = false;
                    for (; j < newArray.Length - 1 - i; j++)
                    {
                        if (newArray[j].CompareTo(newArray[j + 1]) > 0)  //每次将相对较小大的值放在后面
                        {
                            string swap = newArray[j];
                            newArray[j] = newArray[j + 1];
                            newArray[j + 1] = swap;
                            //排序过
                            isChange = true;
                        }
                    }

                    string value = newArray[newArray.Length - 1 - i];
                    if (!result.Contains(value))   //如果集合中未包含该元素,则添加
                        result.Add(value);

                    //判断是否继续排直接序操作
                    //如果上次操作未排,则下次不再排序,直接去重复
                    j = isChange ? 0 : newArray.Length;
                }
            }
            else   //降序
            {
                for (int i = 0; i < newArray.Length; i++)
                {
                    isChange = false;
                    for (; j < newArray.Length - 1 - i; j++)
                    {
                        if (newArray[j].CompareTo(newArray[j + 1]) < 0)  //每次将相对较的值放在后面
                        {
                            string swap = newArray[j];
                            newArray[j] = newArray[j + 1];
                            newArray[j + 1] = swap;
                            //排序过
                            isChange = true;
                        }
                    }

                    string value = newArray[newArray.Length - 1 - i];
                    if (!result.Contains(value))   //如果集合中未包含该元素,则添加
                        result.Add(value);

                    //判断是否继续排直接序操作
                    //如果上次操作未排,则下次不再排序,直接去重复
                    j = isChange ? 0 : newArray.Length;
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// 排序方式
        /// </summary>
        public  enum OrderByType
        {
            ASC, DESC
        }


        #endregion

        #region 载取

        /// <summary>
        /// 从字符串的指定位置截取指定长度的子字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex">开始位置</param>
        /// <param name="length">载取长度</param>
        /// <returns></returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                // 如果载取长度为负数 则从开始位置往左计算载取长度   否则 从指定位置往右计算长度 
                if (length < 0)  
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                       
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }

                if (startIndex > str.Length)
                    return "";
            }
            else
            {
                if (length < 0)
                    return "";
                else
                {
                    if (length + startIndex > 0)
                    {
                        length = startIndex + length;
                        startIndex = 0;
                    }
                    else
                        return "";
                }
            }

            if(str.Length-startIndex<length)
                length = str.Length - startIndex;

            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// 载取字符串 从指定开始位置载取到结尾
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }


        /// <summary>
        /// 从指定位置载取字符串
        /// </summary>
        /// <param name="p_SrcString"></param>
        /// <param name="p_StartIndex"></param>
        /// <param name="p_Length"></param>
        /// <param name="p_TailString"></param>
        /// <returns></returns>
        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string myResult = p_SrcString;

            Byte[] bComments = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char c in Encoding.UTF8.GetChars(bComments))
            {    //当是日文或韩文时(注:中文的范围:\u4e00 - \u9fa5, 日文在\u0800 - \u4e00, 韩文为\xAC00-\xD7A3)
                if ((c > '\u0800' && c < '\u4e00') || (c > '\xAC00' && c < '\xD7A3'))
                {
                    //if (System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\u0800-\u4e00]+") || System.Text.RegularExpressions.Regex.IsMatch(p_SrcString, "[\xAC00-\xD7A3]+"))
                    //当截取的起始位置超出字段串长度时
                    if (p_StartIndex >= p_SrcString.Length)
                        return "";
                    else
                        return p_SrcString.Substring(p_StartIndex,
                                                       ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }

            if (p_Length >= 0)
            {
                byte[] bsSrcString = Encoding.Default.GetBytes(p_SrcString);

                //当字符串长度大于起始位置
                if (bsSrcString.Length > p_StartIndex)
                {
                    int p_EndIndex = bsSrcString.Length;

                    //当要截取的长度在字符串的有效长度范围内
                    if (bsSrcString.Length > (p_StartIndex + p_Length))
                    {
                        p_EndIndex = p_Length + p_StartIndex;
                    }
                    else
                    {   //当不在有效范围内时,只取到字符串的结尾

                        p_Length = bsSrcString.Length - p_StartIndex;
                        p_TailString = "";
                    }

                    int nRealLength = p_Length;
                    int[] anResultFlag = new int[p_Length];
                    byte[] bsResult = null;

                    int nFlag = 0;
                    for (int i = p_StartIndex; i < p_EndIndex; i++)
                    {
                        if (bsSrcString[i] > 127)
                        {
                            nFlag++;
                            if (nFlag == 3)
                                nFlag = 1;
                        }
                        else
                            nFlag = 0;

                        anResultFlag[i] = nFlag;
                    }

                    if ((bsSrcString[p_EndIndex - 1] > 127) && (anResultFlag[p_Length - 1] == 1))
                        nRealLength = p_Length + 1;

                    bsResult = new byte[nRealLength];

                    Array.Copy(bsSrcString, p_StartIndex, bsResult, 0, nRealLength);

                    myResult = Encoding.Default.GetString(bsResult);
                    myResult = myResult + p_TailString;
                }
            }

            return myResult;

        }


        /// <summary>
        /// 字符串如果操过指定长度则将超出的部分用指定字符串代替
        /// </summary>
        /// <param name="p_SrcString">要检查的字符串</param>
        /// <param name="p_Length">指定长度</param>
        /// <param name="p_TailString">用于替换的字符串</param>
        /// <returns>截取后的字符串</returns>
        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetUnicodeSubString(string str, int len, string p_TailString)
        {
            string result = string.Empty;// 最终返回的结果
            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度
            int byteCount = 0;// 记录读取进度
            int pos = 0;// 记录截取位置
            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                        byteCount += 2;
                    else// 按英文字符计算加1
                        byteCount += 1;
                    if (byteCount > len)// 超出时只记下上一个有效位置
                    {
                        pos = i;
                        break;
                    }
                    else if (byteCount == len)// 记下当前位置
                    {
                        pos = i + 1;
                        break;
                    }
                }

                if (pos >= 0)
                    result = str.Substring(0, pos) + p_TailString;
            }
            else
                result = str;

            return result;
        }

        #endregion

        #region 替换

        /// <summary>
        /// 自定义的替换字符串函数
        /// </summary>
        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        #endregion

        #region 分割
        
        /// <summary>
        /// 分割自符串
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="strSplit"></param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (!Validator.StrIsNullOrEmpty(strContent))
            {
                if (strContent.IndexOf(strSplit) < 0)
                    return new string[] { strContent };


                return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
            }
            else
            {
                return new string[0] { };

            }
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] result = new string[count];
            string[] splited = SplitString(strContent, strSplit);

            for (int i = 0; i < count; i++)
            {
                if (i < splited.Length)
                    result[i] = splited[i];
                else
                    result[i] = string.Empty;
            }

            return result;
        }

        /// <summary>
        /// 过滤字符串数组中每个元素为合适的大小
        /// 当长度小于minLength时，忽略掉,-1为不限制最小长度
        /// 当长度大于maxLength时，取其前maxLength位
        /// 如果数组中有null元素，会被忽略掉
        /// </summary>
        /// <param name="minLength">单个元素最小长度</param>
        /// <param name="maxLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                int t = maxLength;
                maxLength = minLength;
                minLength = t;
            }

            int iMiniStringCount = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if (minLength > -1 && strArray[i].Length < minLength)
                {
                    strArray[i] = null;
                    continue;
                }
                if (strArray[i].Length > maxLength)
                    strArray[i] = strArray[i].Substring(0, maxLength);

                iMiniStringCount++;
            }

            string[] result = new string[iMiniStringCount];
            for (int i = 0, j = 0; i < strArray.Length && j < result.Length; i++)
            {
                if (strArray[i] != null && strArray[i] != string.Empty)
                {
                    result[j] = strArray[i];
                    j++;
                }
            }
            return result;
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <param name="maxElementLength">单个元素最大长度</param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            return ignoreRepeatItem ? DistinctStringArray(result, maxElementLength) : result;
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int minElementLength, int maxElementLength)
        {
            string[] result = SplitString(strContent, strSplit);

            if (ignoreRepeatItem)
            {
                result = DistinctStringArray(result);
            }
            return PadStringArray(result, minElementLength, maxElementLength);
        }

        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="strContent">被分割的字符串</param>
        /// <param name="strSplit">分割符</param>
        /// <param name="ignoreRepeatItem">忽略重复项</param>
        /// <returns></returns>
        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }



        #endregion

        #region 生成
        /// <summary>
        /// 生成指定数量的html空格符号
        /// </summary>
        public static string GetStrString(int spacesCount,string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                sb.Append(str);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成指定长度的字符串,即生成strLong个str字符串
        /// </summary>
        /// <param name="strLong">生成的长度</param>
        /// <param name="str">以str生成字符串</param>
        /// <returns></returns>
        public static string StringOfChar(int strLong, string str)
        {
            string ReturnStr = "";
            for (int i = 0; i < strLong; i++)
            {
                ReturnStr += str;
            }

            return ReturnStr;
        }

        #endregion

        #region 清空/移除

       

        #endregion

        #region 删除重复项

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <param name="maxElementLength">字符串数组中单个元素的最大长度</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            Hashtable h = new Hashtable();

            foreach (string s in strArray)
            {
                string k = s;
                if (maxElementLength > 0 && k.Length > maxElementLength)
                {
                    k = k.Substring(0, maxElementLength);
                }
                h[k.Trim()] = s;
            }

            string[] result = new string[h.Count];

            h.Keys.CopyTo(result, 0);

            return result;
        }

        /// <summary>
        /// 清除字符串数组中的重复项
        /// </summary>
        /// <param name="strArray">字符串数组</param>
        /// <returns></returns>
        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }


        #endregion



        #region 过滤字符
        private static string StrKeyWord =
       @",|(|)|[|]|}|{|%|@|*|!|'|exec|cast|declare|count(|drop table|update|truncate|asc(|mid(|char(|xp_cmdshell|exec master|netlocalgroup administrators|:|net user";

        /// <summary>
        /// 过滤非法字符
        /// shen 2015-02-04
        /// </summary>
        /// <returns></returns>
        public static string newstr(string str)
        {
            //过滤or,and ',&,+,,,'',
            if (!string.IsNullOrEmpty(str))
            {
                str = str.ToLower();
                string[] keys = StrKeyWord.Split(new string[] { "|" },
                                                  StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < keys.Length; i++)
                    str = str.Replace(keys[i], "");
                return str;
            }
            else
                return "";
        }
        #endregion


        #region datatable to json
        public static string DataTableToJSON(DataTable dt, string dtName)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            //Newtonsoft.Json.JsonWriter jw = new Newtonsoft.Json.JsonWriter();
            //JsonExSerializer.Framework.JsonWriter jww = new JsonExSerializer.Framework.JsonWriter();
            //JsonTextWriter

            using (Newtonsoft.Json.JsonWriter jw = new Newtonsoft.Json.JsonWriter(sw))
            {
                Newtonsoft.Json.JsonSerializer ser = new Newtonsoft.Json.JsonSerializer();
                jw.WriteStartObject();
                jw.WritePropertyName(dtName);
                jw.WriteStartArray();
                foreach (DataRow dr in dt.Rows)
                {
                    jw.WriteStartObject();

                    foreach (DataColumn dc in dt.Columns)
                    {
                        jw.WritePropertyName(dc.ColumnName);
                        ser.Serialize(jw, dr[dc].ToString());
                    }

                    jw.WriteEndObject();
                }
                jw.WriteEndArray();
                jw.WriteEndObject();

                sw.Close();
                jw.Close();

            }

            return sb.ToString();
        }
        #endregion


   
        public static string RemoveSame(string str, string split)
        {
            String[] s = str.Split(new string[] { split }, StringSplitOptions.RemoveEmptyEntries);
            List<string> addressArray = new List<string>(s);
            List<string> newstring = new List<string>();
            if (s.Length > 0)
            {
                int num = 0;
                int lab = 0;
                for (int i = 0; i < addressArray.Count; i++)
                {
                    lab = 0;
                    for (int j = 0; j < num; j++)
                    {
                        if (newstring[j] == addressArray[i])
                            lab = 1;
                    }
                    if (lab == 0)
                    {
                        newstring.Add(addressArray[i]);
                        //newstring.Add("、");
                        num++;
                    }
                }
                return String.Join(split, newstring.ToArray());
            }
            return str;
        }
        public static  int[] differSamenessRandomNum(int num, int minValue, int maxValue)
        {
            if (num == 1)
            {
                int[] arrNum2 = new int[1];
                arrNum2[0] = 0;
                return arrNum2;
            }
                 

            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));

            int[] arrNum = new int[num];
            int tmp = 0;
            for (int i = 0; i <= num - 1; i++)
            {
                tmp = ra.Next(minValue, maxValue);
                arrNum[i] = getRandomNum(arrNum, tmp, minValue, maxValue, ra);
            }






            return arrNum;

        }

        public static int getRandomNum(int[] arrNum, int tmp, int minValue, int maxValue, Random ra)
        {
            int n = 0;
            while (n <= arrNum.Length - 1)
            {
                if (arrNum[n] == tmp)
                {
                    tmp = ra.Next(minValue, maxValue);
                    getRandomNum(arrNum, tmp, minValue, maxValue, ra);
                }
                n++;
            }
            return tmp;
        }

        /// <summary>
        /// 取出html标签
        /// </summary>
        /// <param name="html">字符中</param>
        /// <param name="length">长度</param>
        /// <returns></returns>
        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="param">需要截取的字符串</param>
        /// <param name="length">截取的长度(字节)</param>
        /// <param name="end">后置值</param>
        /// <returns></returns>
        public static string GetString(string param, int length, string end)
        {
            if (string.IsNullOrEmpty(param))
                return param;
            int byteLen = Encoding.Default.GetByteCount(param);

            if (byteLen <= length)
                return param;

            string Pattern = null;
            MatchCollection m = null;
            StringBuilder result = new StringBuilder();
            int n = 0;
            char temp;
            bool isCode = false; //是不是HTML代码
            bool isHTML = false; //是不是HTML特殊字符,如&nbsp;
            char[] pchar = param.ToCharArray();
            for (int i = 0; i < pchar.Length; i++)
            {
                temp = pchar[i];
                if (temp == '<')
                    isCode = true;
                else if (temp == '&')
                    isHTML = true;
                else if (temp == '>' && isCode)
                {
                    n = n - 1;
                    isCode = false;
                }
                else if (temp == ';' && isHTML)
                    isHTML = false;

                if (!isCode && !isHTML)
                {
                    n = n + 1;
                    //UNICODE码字符占两个字节
                    if (Encoding.Default.GetBytes(temp + "").Length > 1)
                        n = n + 1;
                }

                result.Append(temp);
                if (n >= length)
                    break;
            }
            result.Append(end);

            string temp_result = Regex.Replace(result.ToString(),
                                                "(>)[^<>]*(<?)",
                                                "$1$2",
                                                RegexOptions.IgnoreCase);
            //去掉不需要结素标记的HTML标记 
            temp_result = Regex.Replace(temp_result,
                                         @"</?(area|base|basefont|body|br|col|colgroup|dd|dt|frame|head|hr|html|img|input|isindex|li|link|meta|option|p|param|tbody|td|tfoot|th|thead|tr)[^<>]*/?>"
                                         ,
                                         "",
                                         RegexOptions.IgnoreCase);
            //去掉成对的HTML标记 
            temp_result = Regex.Replace(temp_result,
                                         @"<([a-zA-Z]+)[^<>]*>(.*?)</\1>",
                                         "",
                                         RegexOptions.IgnoreCase);
            //用正则表达式取出标记 
            Pattern = ("<([a-zA-Z]+)[^<>]*>");
            m = Regex.Matches(temp_result, Pattern);
            ArrayList endHTML = new ArrayList();
            foreach (Match mt in m)
                endHTML.Add(mt.Result("$1"));
            //补全不成对的HTML标记 
            for (int i = endHTML.Count - 1; i >= 0; i--)
            {
                result.Append("</");
                result.Append(endHTML[i]);
                result.Append(">");
            }
            return result.ToString();


        }

    }
}
