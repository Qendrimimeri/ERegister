using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Application.Models.Services;

namespace Application.Repository;

public class EncryptionService
{
    private readonly Encrypt _encrypy;

    public EncryptionService(Encrypt encrypy)
    {
        _encrypy = encrypy;
    }

    public string Encrypt(string encryptstring)
    {
        string encryptionkey = _encrypy.EncryptKey;
        byte[] clearbytes = Encoding.Unicode.GetBytes(encryptstring);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionkey, new byte[] {
            0x71, 0x65, 0x6e, 0x64, 0x72, 0x69, 0x6d
        });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearbytes, 0, clearbytes.Length);
                    cs.Close();
                }
                encryptstring = Convert.ToBase64String(ms.ToArray());
            }
        }
        return encryptstring;
    }

    public string Decrypt(string ciphertext)
    {
        string encryptionkey = _encrypy.EncryptKey;
        ciphertext = ciphertext.Replace(" ", "+");
        byte[] cipherbytes = Convert.FromBase64String(ciphertext);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionkey, new byte[] {
            0x71, 0x65, 0x6e, 0x64, 0x72, 0x69, 0x6d
        });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherbytes, 0, cipherbytes.Length);
                    cs.Close();
                }
                ciphertext = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return ciphertext;
    }
}