using System;
using System.Collections;
using System.Collections.Generic;

namespace Demo1
{

    public interface INumberHandler
    {
        string HandleNUmber(int a);
    }

    public class LowNumberHandler : INumberHandler
    {
        public string HandleNUmber(int a)
        {
            string result = "a <= 10 ";
            result += "-.-";

            Console.WriteLine($"sono nel { nameof(LowNumberHandler) }");
            return result;
        }
    }

    public class MediumNumberHandler : INumberHandler
    {
        public string HandleNUmber(int a)
        {
            string result = "a tra 10 e 50 ";
            result += "-.-";
            Console.WriteLine($"sono nel { nameof(MediumNumberHandler) }");
            return result;
        }
    }

    public class HighNumberHandler : INumberHandler
    {
        public string HandleNUmber(int a)
        {
            string result = "a tra 50 e 100 ";
            result += "-.-";
            Console.WriteLine($"sono nel { nameof(HighNumberHandler) }");
            return result;
        }
    }


    public class VeryHighNumberHandler : INumberHandler
    {
        public string HandleNUmber(int a)
        {
            string result = "a > 100";
            result += "-.-";
            Console.WriteLine($"sono nel { nameof(VeryHighNumberHandler) }");
            return result;
        }
    }

    public class Composer
    {
        public bool Condition { get; set; }
        public INumberHandler Handler { get; set; }

        public Composer(bool condition, INumberHandler numberHandler)
        {
            Condition = condition;
            Handler = numberHandler;
        }
    }
    
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(baa(5));
        }

        public static string baa(int a)
        {
            List<Composer> handlers = new List<Composer>();
            handlers.Add(new Composer(a <= 10, new LowNumberHandler()));
            handlers.Add(new Composer(a > 10 && a <= 50, new MediumNumberHandler()));
            handlers.Add(new Composer(a > 50 && a <= 100, new HighNumberHandler()));
            handlers.Add(new Composer(a > 100, new VeryHighNumberHandler()));
            foreach (var h in handlers)
            {
                if (h.Condition)
                    return h.Handler.HandleNUmber(a);
            }

            return "No condition found";
        }

        public static string foo(int a)
        {
            string result = "-";
            if (a <= 10)
            {
                result = "a <= 10 ";
                result += "-.-";
            }
            else if (a > 10 && a <= 50)
            {
                result = "a tra 10 e 50 ";
                result += "-.-";
            }
            else if (a > 50 && a <= 100)
            {
                result = "a tra 50 e 100 ";
                result += "-.-";
            }
            else
            {
                result = "a > 100";
                result += "-.-";
            }
            return result;
        }

    }


}
