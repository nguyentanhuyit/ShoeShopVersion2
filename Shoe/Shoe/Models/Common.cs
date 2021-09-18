﻿using System;
namespace Shoe.Models
{
    public class Common
    {
        //Mã hóa chuỗi thành chuỗi MD5
        //Input: sToEncrypt (Chuỗi cần mã hóa)
        // Output: Chuỗi sau khi mã hóa
        public static string EncryptMD5(string sToEncrypt)
        {
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(sToEncrypt);
            //encrypt bytes
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);
            //Convert the encrypted bytes back to a string(base 16)
            string hashString = "";
            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }
            return hashString.PadLeft(32, '0');
        }
    }
}
