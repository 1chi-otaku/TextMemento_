using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TextMemento_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Redactor redactor = new Redactor("Hello ");
            CareTaker taker = new CareTaker();

            taker.Add(redactor.SaveMemento());

            redactor.AddText("World! ");
            taker.Add(redactor.SaveMemento());

            redactor.AddText("I love blueberries! ");
            taker.Add(redactor.SaveMemento());

            redactor.AddText("Blueberries are great.");
            taker.Add(redactor.SaveMemento());

            taker.ShowHistory();

            Console.WriteLine();
            for (int i = taker.GetList().Count; i > 0;i--)
            {
                redactor.RestoreMemento(taker.GetList()[i-1]);
                redactor.Print();
                Console.WriteLine();
            }
           

            

        }
    }
}
