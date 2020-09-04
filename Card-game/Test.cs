using System;

namespace Test_for_game
{
    class Test
    {
        //static void Main(string[] args)
        //{
        //    //Console.WriteLine("Hello World!");
        //    //Console.WriteLine("GO");
        //    //Another.ShowAnother();
        //    //External ex = new External();
        //    //ex.ShowMe();
        //    Ariphmetcis.Num n = new Ariphmetcis.Num(3);
        //    n.SetValue(50);
        //    Console.WriteLine(n.GetValue());
        //}
    }

    class Another
    {
        public static void ShowAnother()
        {
            Console.WriteLine("Another go");
        }
    }

    class External
    {
        public void ShowMe()
        {
            Console.WriteLine("Show external");
        }
    }
}


namespace Ariphmetcis
{
    class Num
    {
        int val;

        public Num(int a)
        {
            val = a;
        }

        public void SetValue(int a)
        {
            val = a;
        }

        public int GetValue()
        {
            return val;
        }
    }
}
