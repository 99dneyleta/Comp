using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Comp
{
    class _3NewAlg
    {
        enum ResultClasses : int
        {
            Identifier = -1,
            IsAlpha = -2,
            IsDigit = -3,
        }

        class Result
        {
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
            public ResultClasses Class { get; set; }
        }

        static LinkedList<Result> Results;
        static Result current;

        static void Func0(string text, int index = 0)
        {
            if (index >= text.Length) return;
            current = new Result { StartIndex = index };

            if (text[index] >= '1' && text[index] <= '9')
                Func1(text, index + 1);
            else if (text[index] == 'i')
                Func2(text, index + 1);
            else
                Func0(text, index+1);

        }

        private static void Finish(int index, ResultClasses result)
        {
            current.EndIndex = index + 1;
            current.Class = result;
            Results.AddLast(current);
        }

        static void Func1(string text, int index)
        {
            if (index >= text.Length)
            {
                current.StartIndex = index - 1;
                Finish(index - 1, ResultClasses.Identifier);
                return;
            }
            if (text[index] >= '0' && text[index] <= '9')
                Finish(index - 1, ResultClasses.Identifier);
            Func0(text, index + 1);



        }

        static void Func2(string text, int index)
          {
            if (text[index] == 's')
                Func3(text, index + 1);
            else
                Func0(text, index);
        }

        static void Func3(string text, int index)
        {
            switch (text[index])
            {
                case 'a':
                    Func4(text, index + 1);
                    break;
                case 'd':
                    Func5(text, index + 1);
                    break;
                default:
                    Func0(text, index);
                    break;
            }
        }

        static void Func5(string text, int index)
        {
            switch (text[index])
            {
                case 'i':
                    Func9(text, index + 1);
                    break;
                default:
                    Func0(text, index);
                    break;
            }
        }

        static void Func9(string text, int index)
        {

            if (text[index] == 'i')

                Func2(text, index);

            else if (text[index] == 'g')

                Func10(text, index + 1);
            else
                Func0(text, index);


        }



        static void Func10(string text, int index)
        {
            switch (text[index])
            {
                case 'i':
                    Func11(text, index + 1);
                    break;
                default:
                    Func0(text, index);
                    break;
            }
        }

        static void Func11(string text, int index)
        {
            if (index >= text.Length)
            {
                current.StartIndex = index - 1;
                Finish(index - 1, ResultClasses.IsDigit);
                return;
            }
            else if (text[index] == 'i')
            {
                current = new Result { StartIndex = index};
                Func2(text, index + 1);
            }
            else if (text[index] == 't')
            {
                Finish(index - 1, ResultClasses.IsDigit);
                Func0(text, index + 1);
            }
            else if (text[index] == 's')
            {
                current = new Result { StartIndex = index};
                Func3(text, index);
            }

                
            else
                Func0(text, index + 1);
        }


        static void Func4(string text, int index)
        {
            switch (text[index])
            {
                case 'l':
                    Func6(text, index + 1);
                    break;
                default:
                    Func0(text, index);
                    break;
            }
        }

        static void Func6(string text, int index)
        {
            switch (text[index])
            {
                case 'p':
                    Func7(text, index + 1);
                    break;
                default:
                    Func0(text, index);
                    break;
            }
        }

        static void Func7(string text, int index)
        {
            switch (text[index])
            {
                case 'h':
                    Func8(text, index + 1);
                    break;
                default:
                    Func0(text, index);
                    break;
            }
        }

        static void Func8(string text, int index)
        {
            if (index >= text.Length)
            {
                current.StartIndex = index - 1;
                Finish(index - 1, ResultClasses.IsAlpha);
                return;
            }
            switch (text[index])
            {
                case 'a':
                    Finish(index - 1, ResultClasses.IsAlpha);
                    Func0(text, index + 1);
                    break;
                default:
                    Func0(text, index );
                    break;
            }
        }

        static void Main(string[] args)
        {
            Results = new LinkedList<Result>();

            string text = "";
            using (var fileStream = new FileStream(@"C:\Users\progr\source\repos\Comp\Comp\3Input.txt", FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fileStream);
                text += sr.ReadToEnd();
                sr.Close();
            }

            Func0(text);


            using (var fileStream = new FileStream(@"C:\Users\progr\source\repos\Comp\Comp\Out3.txt", FileMode.Open, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fileStream);

                foreach (var item in Results)
                {
                    string tmp = text.Substring(item.StartIndex, item.EndIndex - item.StartIndex + 1);
                    sw.WriteLine($"word: {tmp}, class: {item.Class}");
                }
                sw.Close();
            }
        }
    }
}
