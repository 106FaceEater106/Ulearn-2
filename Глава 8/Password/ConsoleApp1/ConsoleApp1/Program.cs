using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ChangePassword
{
    public List<string> CharValue(string word)
    {//можно и var использовать.
        List<string> value = new List<string>();
        foreach (var i in value)
            Console.WriteLine(i);
        CharValue(word.ToCharArray(), 0, value);
        return value;
    }

    public void CharValue(char[] word, int startIndex, List<string> value)
    {
        if (startIndex == word.Length)
        {
            value.Add(new string(word));
            return;
        }
        if (char.IsLetter(word[startIndex]) && word[startIndex] != char.ToUpper(word[startIndex])){
            CharValue(word, startIndex+ 1, value);
            word[startIndex] = char.ToUpper(word[startIndex]);
        }
        CharValue(word, startIndex+ 1, value);
        word[startIndex] = char.ToLower(word[startIndex]);
    }
}



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ChangePassword cp1 = new ChangePassword();
            string value = "ab42";
            var val = cp1.CharValue(value);
            foreach(var resultValue in val)
            {
                Console.WriteLine(resultValue);
            }
            
            Console.ReadLine();
        }
    }
}

