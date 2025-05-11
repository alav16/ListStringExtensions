/*
Length                          1. Length (Property)
Substring                       6. Substring()
IndexOf                         9. IndexOf() / LastIndexOf()
Contains                        2. Contains()
Replace                         7. Replace()
ToLower / ToUpper               4. ToUpper() / ToLower()
Trim                            5. Trim() / TrimStart() / TrimEnd()   
Split / Join                    8. Split() / String.Join()
Equals / StartsWith / EndsWith  3. StartsWith() / EndsWith() / String.Equals() (with StringComparison)
 */

using System;
using System.Collections.Generic;

namespace stringExt
{
    public static class StringEx
    {
        public static int MyLength(this string text)//Length
        {
            int count = 0;
            foreach (char c in text)
            {
                count++;
            }
            return count;
        }


        public static string MySubstring(this string text, int index, int count)
        {
            if (index  < 0 || index >= text.MyLength())
            {
                throw new ArgumentException("please enter the true index");
            }

            string sub = null;

            for (int i = index; i < index + count; i++)
            {
                sub += text[i];
            }
            return sub;
        }

        public static int MyIndexOf(this string text, string sub)
        {
            for (int i = 0; i < text.MyLength() - sub.MyLength(); i++)
            {
                bool found = true;

                for (int j = 0; j  < sub.MyLength(); j++)
                {
                    if (text[i + j] != sub[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int MyIndexOf1(this string text, char c)
        {
            for (int i = 0; i < text.MyLength(); ++i)
            {
                if (text[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int MyLastIndexOf(this string text, char c)
        {
            for (int i = text.MyLength() - 1;  i >= 0; --i)
            {
                if (text[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool MyContains(this string text, string sub)
        {
            for (int i = 0; i < text.MyLength() - sub.MyLength(); ++i)
            {
                bool found = true;

                for (int j = 0; j < sub.MyLength(); ++j)
                {
                    if (text[i + j] != sub[j])
                    {
                        found = false;
                        break;
                    }

                }
                if (found)
                {
                    return true;
                }
            }
            return false;
        }

        public static string MyReplaceChar(this string text, char old, char changed)
        {
            char[] result = new char[text.MyLength()];
            for (int i = 0; i < text.MyLength(); ++i)
            {
                result[i] = (text[i] == old) ? changed : text[i];
            }
            return new string(result);
        }

        public static string MyReplaceString(this string text, string old, string changed)
        {
            string result = "";

            for (int i = 0; i < text.MyLength(); i++)
            {
                bool comp = true;

                for (int j = 0; j < old.MyLength(); ++j)
                {
                    if (i + j >= text.MyLength() || text[i + j] != old[j])
                    {
                        comp = false;
                        break;
                    }
                }
                if (comp)
                {
                    for (int k = 0; k < changed.MyLength(); ++k)
                    {
                        result += changed[k];
                    }
                    i += old.MyLength() - 1;
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }

        public static string MyToLower(this string text)
        {
            string result = "";
            for (int i = 0; i < text.MyLength(); ++i)
            {
                char c = text[i];
                if (c >= 'A' && c <= 'Z')
                {
                    c = (char)(c + 32);
                }
                result += c;
            }
            return result;
        }

        public static string MyToUpper(this string text)
        {
            string result = "";
            for (int i = 0; i < text.MyLength(); ++i)
            {
                char c = text[i];
                if (c >= 'a' && c <= 'z')
                {
                    c = (char)(c - 32);
                }
                result += c;
            }
            return result;
        }

        public static string MyTrim(this string text)
        {
            int start = 0;
            int end = text.MyLength() - 1;

            while (start <= end && text[start] == ' ')
            {
                start++;
            }

            while (end >= start && text[end] == ' ')
            {
                end--;
            }

            string result = "";

            for (int i = 0; i <=end; ++i)
            {
                result += text[i];
            }
            return result;
        }
        public static string[] MySplit(this string text, char separator)
        {
            List<string> parts = new List<string>();
            string cur = "";

            for (int i = 0; i < text.MyLength(); i++)
            {
                if (text[i] == separator)
                {
                    parts.Add(cur);
                    cur = "";
                }
                else
                {
                    cur += text[i];
                }
            }
            parts.Add(cur);
            string[] result = new string[parts.Count];
            for (int i = 0; i < parts.Count; i++)
            {
                result[i] = parts[i];
            }
            return result;
        }

        public static string MyJoin(this string[] text, char separator)
        {
            string res = "";
            for (int i = 0; i < text.Length; i++)
            {
                res += text[i]; ;
                if (i <  text.Length - 1)
                {
                    res += separator;
                }
            }
            return res;
        }

        public static bool MyEquals(this string text, string other)
        {
            if (text.MyLength() != other.MyLength())
            {
                return false;
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != other[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool MyStartsWithChar(this string text, char c)
        {
            for (int i = 0; i < text.MyLength(); ++i)
            {
                if (text[0] != c)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool MyStartWithString(this string text, string sub)
        {
            if (sub.MyLength() > text.MyLength())
            {
                return false;
            }

            for (int i = 0; i < sub.MyLength(); ++i)
            {
                if (text[i] != sub[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool MyEndWithChar(this string text, char c)
        {
            for (int i = 0; i < text.MyLength() - 1; ++i)
            {
                if (text[text.MyLength() - 1] != c)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool MyEndWithString(this string text, string sub)
        {
            if (sub.MyLength() > text.MyLength())
            {
                return false;
            }

            int start = text.MyLength() - sub.MyLength();
            for (int i = 0; i < sub.MyLength(); ++i)
            {
                if (text[start + i] != sub[i])
                {
                    return false;
                }
            }
            return true;
        }
    }  
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Mane, Arian, Lena";
            Console.WriteLine($"{name.MyLength()}");

            Console.WriteLine($"{name.MySubstring(5, 5)}");

            Console.WriteLine($"{name.MyIndexOf("Ari")}");

            Console.WriteLine($"{name.MyIndexOf1('a')}");

            Console.WriteLine($"{name.MyLastIndexOf('n')}");

            Console.WriteLine($"{name.MyContains("Lena")}");

            Console.WriteLine($"{name.MyReplaceChar('a', 'o')}");

            Console.WriteLine($"{name.MyReplaceString("Aria", "Lulu")}");

            Console.WriteLine( $"{name.MyToLower()}");

            Console.WriteLine($"{name.MyToUpper()}");

            Console.WriteLine($"{name.MyTrim()}");

            string[] parts = name.MySplit(',');
            for (int i= 0; i < parts.Length; i++)
            {
                Console.WriteLine(parts[i]);
            }

            string[] names = { "Mane", "Arian", "Lena" };
            string res = names.MyJoin('-');
            Console.WriteLine(res);

            string name1 = "Aren";
            Console.WriteLine($"{name1.MyEquals("Arenj")}");
            
            Console.WriteLine($"{name.MyStartsWithChar('k')}");

            Console.WriteLine($"{name.MyStartWithString("Man")}");
            Console.WriteLine("1");
            Console.WriteLine($"{name.MyEndWithChar('j')}");

            Console.WriteLine($"{name.MyEndWithString("lna")}");


        }
    }
}
