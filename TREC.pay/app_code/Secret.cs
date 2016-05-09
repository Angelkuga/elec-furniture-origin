using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;

/// <summary>
///Secret 的摘要说明
/// </summary>
public class Secret
{
    //Encryption 加密
    //Decryption 解密

    /// <summary>
    /// 将普通文本转换成Base64编码的文本
    /// </summary>
    /// <param name="value">普通文本</param>
    /// <returns></returns>
    private string StringToBase64String(String value)
    {
        byte[] binBuffer = (new UnicodeEncoding()).GetBytes(value);
        int base64ArraySize = (int)Math.Ceiling(binBuffer.Length / 3d) * 4;
        char[] charBuffer = new char[base64ArraySize];

        Convert.ToBase64CharArray(binBuffer, 0, binBuffer.Length, charBuffer, 0);
        string s = new string(charBuffer);
        return s;
    }

    /// <summary>
    /// 将Base64编码的文本转换成普通文本
    /// </summary>
    /// <param name="base64">Base64编码的文本</param>
    /// <returns></returns>
    private string Base64StringToString(string base64)
    {
        char[] charBuffer = base64.ToCharArray();
        byte[] bytes = Convert.FromBase64CharArray(charBuffer, 0, charBuffer.Length);
        return (new UnicodeEncoding()).GetString(bytes);
    }

    /// <summary>
    /// 字符转为Ascii码十进制
    /// </summary>
    /// <param name="charvalue"></param>
    /// <returns></returns>
    private int CharToAscii(char charvalue)
    {
        return (short)charvalue;
    }

    /// <summary>
    /// 将Ascii码转为字符
    /// </summary>
    /// <param name="ii">Ascii（十进制的）</param>
    /// <returns></returns>
    private char AsciiToChar(int ii)
    {
        return (char)ii;
    }
    /// <summary>
    /// 十进制转为十六进制字符串
    /// </summary>
    /// <param name="n">十进制数字</param>
    /// <returns></returns>
    private string Change10To16(int n)
    {
        String h16 = Convert.ToString(n, 16);
        return h16.ToUpper();
    }
    /// <summary>
    /// 将16进制字符串转为10进制数字
    /// </summary>
    /// <param name="h16">16进制字符串</param>
    /// <returns></returns>
    private int Change16To10(string h16)
    {
        return Convert.ToInt32(h16, 16);
    }
    /// <summary>
    /// 无中文字符串加密
    /// </summary>
    /// <param name="value">加密数据值</param>
    /// <param name="movelen">移动位数</param> 
    /// <returns></returns>
    public string Encryption(string value, int movelen)
    {
        try
        {
            if (!string.IsNullOrEmpty(value))
            {
                StringBuilder changestrs = new StringBuilder(string.Empty);
                foreach (char c in value.ToCharArray())
                {
                    int II = this.CharToAscii(c) + movelen;

                    if (II > 127)
                    {
                        II = II - 127;
                    }
                    string h16 = this.Change10To16(II);//转为16进制
                    if (h16.Length == 1)
                    {
                        h16 = "0" + h16;
                    }
                    changestrs.Append(h16);
                }

                return changestrs.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        catch
        {
            return string.Empty;
        }
    }
    /// <summary>
    /// 含中文字符串加密，加密后转为Base64流格试输出
    /// </summary>
    /// <param name="value">加密数据值</param>
    /// <returns></returns>
    public string EncryptionFormat(string value)
    {
        try
        {
            StringBuilder changestrs = new StringBuilder(string.Empty);
            foreach (char c in value.ToCharArray())
            {
                int II = this.CharToAscii(c);
                if (II > 127)//如果是中文
                {
                    changestrs.Append(c.ToString());
                }
                else
                {
                    II = this.CharToAscii(c) + 4;
                    if (II > 127)
                    {
                        II = II - 127;
                    }
                    string h16 = this.Change10To16(II);//转为16进制
                    changestrs.Append(h16);
                }
            }

            return this.StringToBase64String(changestrs.ToString());
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// 无中文字符串解密
    /// </summary>
    /// <param name="value">解密字符串</param>
    /// <param name="movelen">移动字符串</param> 
    /// <returns></returns>
    public string Decryption(string value, int movelen)
    {
        try
        {
            if (!string.IsNullOrEmpty(value))
            {
                int len = value.Length;
                StringBuilder changestrs = new StringBuilder(string.Empty);
                for (int i = 0; i < len; i = i + 2)
                {
                    string h16 = value.Substring(i, 2);
                    int h10 = this.Change16To10(h16) - movelen;
                    if (h10 < 0)
                    {
                        h10 = h10 + 127;
                    }
                    changestrs.Append(AsciiToChar(h10).ToString());
                }

                return changestrs.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
        catch
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// 含中文字符串解密
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string DecryptionFormat(string value)
    {
        try
        {
            StringBuilder changestrs = new StringBuilder(string.Empty);
            string decr = this.Base64StringToString(value);
            int i = 0;
            while (i < decr.Length)
            {
                if (CharToAscii(char.Parse(decr.Substring(i, 1))) <= 127)
                {
                    string h16 = decr.Substring(i, 2);
                    int h10 = this.Change16To10(h16) - 4;
                    if (h10 < 0)
                    {
                        h10 = h10 + 127;
                    }
                    changestrs.Append(AsciiToChar(h10).ToString());
                    i = i + 2;
                }
                else
                {
                    changestrs.Append(decr.Substring(i, 1));
                    i++;
                }
            }
            return changestrs.ToString();
        }
        catch
        {
            return string.Empty;
        }
    }
}