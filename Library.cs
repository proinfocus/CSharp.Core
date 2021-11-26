using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace CSharp.Core;

public static class Library
{
    public static void Print(this string value)
    {
        Console.WriteLine(value);
    }
    public static void Is(this bool condition, Action action)
    {
        if (condition)
            action();
    }
    public static void IsNot(this bool condition, Action action)
    {
        if (condition == false)
            action();
    }
    public static void Loop(int from, int to, Action<int> action, int step = 1)
    {
        if (from <= to)
        {
            for (int index = from; index <= to; index += step)
                action(index);
        }
        else
        {
            for (int index = from; index >= to; index -= step)
                action(index);
        }
    }
    public static int RandomNumber(int startingWith, int endingWith)
    {
        return new Random().Next(startingWith, endingWith + 1);
    }
    public static void IsNull<T>(this T instance, Action action)
    {
        if (instance == null)
            action();
    }
    public static void IsNotNull<T>(this T instance, Action<object> action)
    {
        if (instance != null)
            action(instance);
    }
    public static long TimeTaken(Action action)
    {
        long output = 0;
        var watch = System.Diagnostics.Stopwatch.StartNew();
        try
        {
            watch.Start();
            action();
        }
        catch (Exception)
        {
            output = -1;
            throw;
        }
        finally
        {
            watch.Stop();
        }
        output = output == 0 ? watch.ElapsedMilliseconds : output;
        return output;
    }
    public static void WithLock(Action action)
    {
        object lo = new();
        lock (lo)
        {
            action();
        }
    }
    public static string ReadFromFile(string path)
    {
        using var sr = new StreamReader(path);
        return sr.ReadToEnd();
    }
    public static void WriteToFile(string path, string data, bool writeToLine = true)
    {
        using var sw = new StreamWriter(path);
        if (writeToLine == false)
            sw.Write(data);
        else
            sw.WriteLine(data);
        sw.Close();
    }
    public static string HashPassword(string password)
    {
        var generateSalt = new byte[128 / 8];
        using (var r = RandomNumberGenerator.Create())
        {
            r.GetBytes(generateSalt);
        }

        var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: generateSalt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return $"{hashedPassword}.{Convert.ToBase64String(generateSalt)}";
    }
    public static bool VerifyHash(string password, string hashedPassword)
    {
        var salt = Convert.FromBase64String(hashedPassword.Split('.')[1]);
        var hash = hashedPassword.Split('.')[0];

        var result = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return (result == hash);
    }
}