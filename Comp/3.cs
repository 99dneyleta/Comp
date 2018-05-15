using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Comp
{
    class _3
    {
        public static string correct;
        public string currentword;
        public static int currentPos;

        public static string A(string line)
        {
            Match match = Regex.Match(line[currentPos].ToString(), "[1-9]");
            if (match.Success)
            {
                currentPos++;
                return B(line);
            }
            else
            {
                return ReplaceFirst(line, line[0].ToString(), "");
            }
        }

        public static string B(string line)
        {
            Match match = Regex.Match(line[currentPos].ToString(), "[0-9]");
            currentPos = 0;
            if (match.Success)
            {
                correct += " AB: " + line.Substring(0, 2);
                return line.Substring(2,line.Length-2);
            }
            else
            {
                return line.Substring(2,line.Length-2);
            }
        }
        public static string C(string line)
        {
            if(line[currentPos] == 's')
            {
                currentPos++;
                return D(line);
            }
            else
            {
                return line.Substring(1, line.Length-1);
            }
        }
        public static string D(string line)
        {
            if(line[currentPos] == 'a')
            {
                currentPos++;
                return E(line);
            }
            else if (line[currentPos] == 'd')
            {
                currentPos++;
                return F(line);
            }
            else
            {
                return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string E(string line)
        {
            if (line[currentPos] == 'l')
            {
                currentPos++;
                return K(line);
            }
            else
            {
                return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string F(string line)
        {
            if(line[currentPos] == 'i')
            {
                currentPos++;
                return G(line);
            }
            else
            {
                return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string G(string line)
        {
            if(line[currentPos] == 'g')
            {
                currentPos++;
                return H(line);
            }
            else
            {
                return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string H(string line)
        {
            if (line[currentPos] == 'i')
            {
                currentPos++;
                return I(line);
            }
            else
            {
                return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string I(string line)
        {
            if (line[currentPos] == 't')
            {
                currentPos++;
                return J(line);
            }
            else
            {
                return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string J(string line)
        {
            correct += " SCDFGHIJ: " + line.Substring(0,currentPos);
            return line.Substring(currentPos, line.Length-currentPos);
        }
        public static string K(string line)
        {
            if (line[currentPos] == 'p')
            {
                currentPos++;
                return L(line);
            }
            else
            {
               return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string L(string line)
        {
            if (line[currentPos] == 'h')
            {
                currentPos++;
                return M(line);
            }
            else
            {
                return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string M(string line)
        {
            if (line[currentPos] == 'a')
            {
                currentPos++;
                return N(line);
            }
            else
            { 
                return line.Substring(currentPos, line.Length-currentPos);
            }
        }
        public static string N(string line)
        {
            correct += " CDEKLMN: " + line.Substring(0, currentPos);
            return line.Substring(currentPos, line.Length-currentPos);
        }
        
        public static void S(string line)
        {
            
            while (line.Length > 2)
            {
                currentPos = 0;
                if (line[0] == 'i' && line.Length > 6)
                {
                        currentPos++;
                        line = C(line);
                }
                else
                {
                   line = A(line);
                }
            }      
        }

        public static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }


        public static void Main(string[] args)
        {
            string line = System.IO.File.ReadAllText(@"c:\users\progr\source\repos\Comp\Comp\3Input.txt");
            S(line);


            string[] arr1 = new string[] { correct };
            System.IO.File.WriteAllLines(@"c:\users\progr\source\repos\Comp\Comp\Out3.txt", arr1);
            Console.WriteLine(correct);
        }
    }
}
