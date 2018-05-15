using System;
using System.Text.RegularExpressions;

namespace Comp
{
    class Program
    {
        private const string EREG = "^[x|x1|y|y1]+";
        public static string E(string line)
        {
            Match match = Regex.Match(line, "^<b>");
            if (match.Success)
            {
                line = ReplaceFirst(line, match.Value, "");

                line = B(line);
                match = Regex.Match(line, "^</b>");
                if (match.Success)
                {
                    line = ReplaceFirst(line, match.Value, "");
                    return line;
                }
            }
            throw new Exception("Error in E");
        }

        public static string D(string line)
        {
            var count = 0;

            while (true)
            {
                if (string.IsNullOrWhiteSpace(line))
                    return line;

                try
                {
                    line = B(line);
                    count++;
                }
                catch
                {
                    try
                    {
                        line = E(line);
                        count++;
                    }
                    catch
                    {
                        return line;
                    }
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

        public static string T(string line)
        {
            do
            {
                if (string.IsNullOrEmpty(line))
                    return line;

                Match match = Regex.Match(line, "^<p>");
                if (match.Success)
                {
                    try
                    {
                        line = ReplaceFirst(line, match.Value, "");

                        line = D(line);

                        match = Regex.Match(line, "^</p>");
                        if (!match.Success)
                            throw new Exception("Error in T");
                        else
                            line = ReplaceFirst(line, match.Value, "");
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                return line;
            } while (true);

        }

        public static string C(string line)
        {
            Match match = Regex.Match(line, EREG);
            if (!match.Success)
                throw new Exception("Error in C");
            return ReplaceFirst(line, match.Value, "");
        }

        public static string B(string line)
        {
            int count = 0;
            bool haveError = false;
            while (!haveError)
            {
                try
                {
                    line = C(line);
                }
                catch
                {
                    line = (count > 0) ? line : throw new Exception("Error in D");
                    haveError = !haveError;
                }

                count++;
            }
            return line;
        }

        public static string A(string line)
        {
            Match match = Regex.Match(line, "^<h1>");
            if (match.Success)
            {
                line = ReplaceFirst(line, match.Value, "");
                line = B(line);
                match = Regex.Match(line, "^</h1>");
                if (match.Success)
                {
                    line = ReplaceFirst(line, match.Value, "");
                    return line;
                }
            }
            throw
                new Exception("Error in A");
        }

        public static string S(string line)
        {
            try
            {
                line = A(line);
                line = T(line);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return line;
        }
        /*public static void Main(string[] args)
        {
            var res = "";
            string[] lines = System.IO.File.ReadAllLines(@"c:\users\progr\source\repos\Comp\Comp\Input.txt");
            foreach(var line in lines)
            {
                try
                {
                    res = S(line);
                    Console.WriteLine("Line is Ok");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }*/
    }
}
