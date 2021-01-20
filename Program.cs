using System;
using System.Collections;

namespace _2
{
    class Program
    {
        static string Check(string Palindrom, int RightIndex,int LeftIndex)
        {
            try // Extends the length of the palindrome if the edges have the same characters
            {
                while(Palindrom[LeftIndex - 1]== Palindrom[RightIndex + 1])
                {
                    RightIndex++;
                    LeftIndex--;
                }
            }
            catch { }
            return (Palindrom.Substring(LeftIndex, RightIndex - LeftIndex + 1));
        }
        static void Main(string[] args)
        {
            string SourceString = Console.ReadLine();
            ArrayList Palindroms = new ArrayList(); // Place of recording of the found palindromes
            int MinimalPalindrom = SourceString.Length;
            for (int NumberInString = 0; NumberInString <= SourceString.Length - 1; NumberInString++)
            {
                try //Search for the middle of a palindrome if there is one character in the middle ( *a* )
                {
                    if (SourceString[NumberInString - 1] == SourceString[NumberInString + 1])
                    {
                        string Palindrom = Check(SourceString, NumberInString, NumberInString);
                        if (Palindrom.Length <= MinimalPalindrom)
                        {
                            MinimalPalindrom = Palindrom.Length;
                            Palindroms.Add(Palindrom);
                        }
                    }
                }
                catch { }
                try // Find the middle of the palindrome if there are two characters in the middle ( *aa* )
                {
                    if (SourceString[NumberInString] == SourceString[NumberInString + 1])
                    {
                        string Palindrom = Check(SourceString, NumberInString, NumberInString + 1);
                        if (Palindrom.Length <= MinimalPalindrom)
                        {
                            MinimalPalindrom = Palindrom.Length;
                            Palindroms.Add(Palindrom);
                        }
                    }
                }
                catch { }
            }
            if (Palindroms.Count != 0) //The definition of the smallest palindrome
            {
                string palindrom = "";
                for (int NumberInList = 0; NumberInList < Palindroms.Count; NumberInList++)
                {
                    if (palindrom == "")
                    {
                        if (Palindroms[NumberInList].ToString().Length == MinimalPalindrom)
                            palindrom = Palindroms[NumberInList].ToString();
                    }
                    else
                    if (Palindroms[NumberInList].ToString().Length == MinimalPalindrom)
                        if (String.Compare(Palindroms[NumberInList].ToString(), palindrom) == -1)
                            palindrom = Palindroms[NumberInList].ToString();
                }
                Console.WriteLine(palindrom);
            }
            else
                Console.WriteLine(-1);
            Console.ReadKey();
        }
    }
}
