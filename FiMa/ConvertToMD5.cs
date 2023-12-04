using System;
using System.Security.Cryptography;
using System.Text;

public static class ConvertToMD5 {

    public static string ConvertStringToMD5(string input) {

        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] data = md5.ComputeHash(utf8.GetBytes(input));
            return Convert.ToBase64String(data);
        }

    }

}


