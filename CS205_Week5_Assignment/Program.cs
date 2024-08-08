using System;

public class CaptainCrunchDecoder
{
    public static string Encode(string input)
    {
        return Transform(input, 13);
    }

    public static string Transform(string input, int shift)
    {
        char[] result = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result[i] = (char)(((c + shift - offset + 26) % 26) + offset);
            }
            else
            {
                result[i] = c; // Preserve spaces
            }
        }

        return new string(result);
    }

    public static void Main(string[] args)
    {
        string input = "Hello World";
        int shift = 13;

        string encoded = Encode(input);
        Console.WriteLine($"Encoded with shift 13: {encoded}");

        string customEncoded = Transform(input, shift);
        Console.WriteLine($"Encoded with custom shift {shift}: {customEncoded}");

        string decoded = Transform(customEncoded, -shift);
        Console.WriteLine($"Decoded with custom shift {-shift}: {decoded}");
    }
}
