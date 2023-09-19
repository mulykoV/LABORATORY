using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the key-->");
        string key = Console.ReadLine();

        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] decryptedText;

        using (FileStream stream = new FileStream("data.dat", FileMode.Open))
        {
            decryptedText = new byte[stream.Length];
            stream.Read(decryptedText, 0, (int)stream.Length);
        }

        byte[] originalText = new byte[decryptedText.Length];

        for (int i = 0; i < decryptedText.Length; i++)
        {
            originalText[i] = (byte)(decryptedText[i] ^ keyBytes[i % keyBytes.Length]);
        }

        string text = Encoding.UTF8.GetString(originalText);

        Console.WriteLine("Decrypted Text: " + text);
    }
}
