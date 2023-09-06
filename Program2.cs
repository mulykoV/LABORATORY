using System;
using System.Security.Cryptography;

class RNGCryptoServiceProviderDemo
{
    static void Main()
    {
        Console.WriteLine("Генерація  криптографічно стійкої послідоності випадкових чисел!!!");
        var rndNumberGenerator = new RNGCryptoServiceProvider();
        var randomNumber = new byte[64];
        rndNumberGenerator.GetBytes(randomNumber);
        Console.WriteLine(Convert.ToBase64String(randomNumber));
    }
}
