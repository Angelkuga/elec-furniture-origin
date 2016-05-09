using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace TRECommon
{
    public class MyMD5
    {
        //���������ַ���������32
        //����������ݿ���Salt�ֶγ���32
        private static string GetSalt()
        {
            Random rnd = new Random();
            Byte[] b = new Byte[32];
            rnd.NextBytes(b);
            return MD5ToHexString(b);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="strPassword">�û����������,���ܿ�</param>
        /// <param name="salt">saltֵ</param>
        /// <returns>����MD5���ܺ������</returns>
        /// <remarks>
        /// ������Ҫ�����˴�saltֵ��ʲô��ʽʲô�����������
        /// </remarks>
        public static string Encrypt(string strPassword, string salt)
        {
            if (strPassword == null) strPassword = "";
            if (salt == null) salt = "";

            return GetMD5(strPassword + salt);
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static string Encrypt(string strPassword)
        {
            return Encrypt(strPassword, null);
        }
        /// <summary>
        /// MD5 ���ܣ�byte[]��
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static byte[] MD5_Byte(byte[] data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            return md5.ComputeHash(data);
        }
        /// <summary>
        /// MD5 ���ܣ�byte[]�ͼ���Ϊstring
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string MD5ToHexString(byte[] data)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string t = "";
            string tTemp = "";
            for (int i = 0; i < result.Length; i++)
            {
                tTemp = Convert.ToString(result[i], 16);
                if (tTemp.Length != 2)
                {
                    switch (tTemp.Length)
                    {
                        case 0: tTemp = "00"; break;
                        case 1: tTemp = "0" + tTemp; break;
                        default: tTemp = tTemp.Substring(0, 2); break;
                    }
                }
                t += tTemp;
            }
            return t;
        }
        /// <summary>
        /// ����ʵ��
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string GetMD5(string strText)
        {
            //byte[] result = Encoding.Default.GetBytes(strText);    //tbPassΪ����������ı���
            //MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] output = md5.ComputeHash(result);
            //return BitConverter.ToString(output).Replace("-", "");

            //�ɵĴ���
            byte[] data = System.Text.ASCIIEncoding.Unicode.GetBytes(strText);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            string t = "";
            for (int i = 0; i < result.Length; i++)
            {
                t += Convert.ToString(result[i], 16);
            }
            return t;

  

 


        }
        /// <summary>
        /// ����32λMD5
        /// 2015-01-30 shen
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD532(string str)
        {
            return MyMD5.GetMD5(str);
        }
    }
}
