using System;
using System.IO;
using System.Text;

class Lab2
{
    static void Main()
    {
        var bytes = Encoding.UTF8.GetBytes("Mit21");
        string path = @"C:\Users\Vovam\OneDrive\Рабочий стол\encfile.dat";

        var message = File.ReadAllBytes(path);
        var key = new byte[5];

        for (int i = 0; i <= message.Length - 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                key[j] = (byte)(message[i + j] ^ bytes[j]);
            }

            var decryptedText = DecryptedText(key, message, i);

            if (ContainsMit21(decryptedText))
            {
                Console.WriteLine($"Password found at index {i}: {Encoding.UTF8.GetString(key)}");
                Console.WriteLine($"Decrypted Text: {Encoding.UTF8.GetString(decryptedText)}");
            }
        }
    }

    public static byte[] DecryptedText(byte[] key, byte[] message, int startIndex)
    {
        var decryptedText = new byte[message.Length];

        for (int i = startIndex; i < message.Length; i+=key.Length) 
        {
            for(int j = 0; j < key.Length; j++)
            {
                if(i+j > decryptedText.Length-1)
                {
                    break;
                }
                decryptedText[i + j] = (byte)(message[i + j] ^ key[j]);
            }
        }
        startIndex -= 1;
        for(int a = startIndex; a >= 0;)
        {
            for(int i = key.Length-1; i >= 0; i--)
            {
                if(a < 0)
                {
                    break;
                }
                decryptedText[a] = (byte)(message[a] ^ key[i]);
                a--;
            }
        }

        return decryptedText;
    }

    public static bool ContainsMit21(byte[] text)
    {
        var str = Encoding.UTF8.GetString(text);
        return str.Contains("Mit21");
    }
}
