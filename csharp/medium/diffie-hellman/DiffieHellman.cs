using System;
using System.Numerics;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP) 
    {
        byte[] randomBigInt = new byte[primeP.GetByteCount()];
        var rng = new Random();
        BigInteger res = new BigInteger(randomBigInt);
        do
        {
            rng.NextBytes(randomBigInt);    

            res = new BigInteger(randomBigInt);
        }
        while(res < 1 || res >= primeP);
        
        return res;
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) => BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) => BigInteger.ModPow(publicKey, privateKey, primeP);
}