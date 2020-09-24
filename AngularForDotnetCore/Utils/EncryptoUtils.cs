using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AngularForDotnetCore.Utils
{
    public class EncryptoUtils
    {
        /// <summary>
        /// calculate file or content md5 value.
        /// </summary>
        /// <param name="content"> fileFullPath or character.</param>
        /// <param name="isFile"></param>
        /// <returns></returns>
        public static string Md5(string content, bool isFile = false)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] byteHash;
            StringBuilder sb = new StringBuilder();
            if(isFile)
            {
                using(FileStream fs = new FileStream(content, FileMode.Open, FileAccess.Read))
                {
                    byteHash = md5.ComputeHash(fs);
                }
            }else
            {
                byteHash = md5.ComputeHash(Encoding.UTF8.GetBytes(content));
            }

            for(int i=0;i<byteHash.Length;i++)
            {
                sb.Append(byteHash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}