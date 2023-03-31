using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TextMemento_
{
    class Memento
    {
        string text;
        private DateTime _date;

        public Memento(string text)
        {
            this.text = text;
            this._date = DateTime.Now;
        }
        public string GetText()
        {
            return text;
        }
        public void SetText(string text)
        {
            this.text = text;
        }
        public DateTime GetDate()
        {
            return this._date;
        }

    };
    class Redactor
    {
        string text;

        public Redactor(string text)
        {
            this.text = text;
        }
        public void AddText(string str)
        {
            this.text += str;
        }
        public Memento SaveMemento()
        {
            Console.WriteLine("Saving memento...");
            return new Memento(text);
        }
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("Restoring memento...");
            this.text = memento.GetText();
        }
        public void Print()
        {
            Console.Write("Redactor: " + text);
        }
    }

    class CareTaker
    {
        private List<Memento> _mementos = new List<Memento>();

        public void Add(Memento memento)
        {
            if(_mementos.Count == 256)
            {
                _mementos.RemoveAt(0);
            }
            _mementos.Add(memento);
        }
        public List<Memento> GetList() {
            return _mementos;
        }
        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.GetDate() + " - " + memento.GetText());
            }
        }
    }
}

