using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesignDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //5 Kullanışı
            Book book = new Book
            {
                Title="Sefiller",
                Isbn="123456",
                Author="Victor Hugo"
            };
            book.ShowBook();

            //backup alma
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            //bilgi değiştirme
            book.Isbn = "99999";
            book.Title = "SEFİLLER";
            book.Author = "VICTOR HUGO";
            book.ShowBook();


            //değişiklikleri geri alma

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();

            Console.ReadLine();
            //
        }
    }

    //1
    class Book
    {
        //encapsulation özelliğinden yararlanmamız lazım
        private string _title;
        private string _author;
        private string _isbn;
        DateTime _lastEdited;
        public string Title
        {
            get { return _title; }  //değer okuma kısmı
            set   //değer yazma kısmı
            {
                _title = value;
                SetLastEdited();
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();

            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set
            {
                _isbn = value;
                SetLastEdited();

            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        //4
        public Memento CreateUndo()  //eski halini tutmaya yarıyor
        {
            return new Memento(_isbn, _title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited : {3}", Isbn, Title, Author, _lastEdited);
        }
        //
    }
    //

    //2
    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn,string title, string author, DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }
    //

    //3
    class CareTaker
    {
        public Memento Memento { get; set; }
    }
    //
}
