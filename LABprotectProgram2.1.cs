using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the text-->");
        string text = Console.ReadLine();
        Console.WriteLine("Enter the key-->");
        string key = Console.ReadLine();

        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        byte[] keyBytes = Encoding.UTF8.GetBytes(key);

        byte[] encryptedText = new byte[textBytes.Length];

        for (int i = 0; i < textBytes.Length; i++)
        {
            encryptedText[i] = (byte)(textBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        using (FileStream stream = new FileStream("data.dat", FileMode.OpenOrCreate))
        {
            stream.Write(encryptedText, 0, encryptedText.Length);
        }

        Console.WriteLine("Text encrypted and written to data.dat.");
    }
}
