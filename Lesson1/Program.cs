using System.Numerics;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (args.Length > 2)
            {
                string[] result = Step1(args);
                foreach (string item in result)
                {
                    if (item == "") break;
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                result = Step2(result);

                Console.Write($"result = {result[0]} ");

            }
            else
            {
                Console.WriteLine("Need args");
            }

        }
        static string[] Step2(string[] items)
        {
            string[] result = new string[items.Length];
            string OldOperation = "";
            int step = 0;
            bool CheckStep = false;

            foreach (string item in items)
            {
                if (item == "+" || item == "-")
                {
                    OldOperation = item;
                    CheckStep = true;
                }
                else
                {
                    if (CheckStep)
                    {
                        if (OldOperation == "+")
                        {
                            result[step - 1] = (double.Parse(result[step - 1]) + double.Parse(item)).ToString();
                        }
                        else
                        {
                            result[step - 1] = (double.Parse(result[step - 1]) - double.Parse(item)).ToString();
                        }
                        CheckStep = false;
                    }
                    else
                    {
                        result[step] = item;
                        step++;
                    }
                }
            }

            return result;
        }
        static string[] Step1(string[] items)
        {
            string[] result = new string[items.Length];
            string OldOperation = "";
            int step = 0;
            bool CheckStep = false;
            
            foreach (string item in items)
            {
                if (item == "/" || item == "*")
                {
                    OldOperation = item;
                    CheckStep = true;
                }
                else if (item == "+" || item == "-")
                {
                    result[step] = item;
                    step++;
                    CheckStep = false;
                }
                else
                {
                    if (CheckStep)
                    {
                        if (OldOperation == "*")
                        {
                            result[step - 1] = (double.Parse(result[step - 1]) * double.Parse(item)).ToString();
                        }
                        else
                        {
                            result[step - 1] = (double.Parse(result[step - 1]) / double.Parse(item)).ToString();
                        }
                        CheckStep = false;
                    }
                    else
                    {
                        result[step] = item;
                        step++;
                    }
                }
            }

            return result;
        }
    }
}