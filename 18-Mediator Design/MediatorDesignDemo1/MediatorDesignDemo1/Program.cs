using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorDesignDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            //6
            Mediator mediator = new Mediator();
            Teacher hoca = new Teacher(mediator);
            hoca.Name = "Engin";
            mediator.Teacher = hoca;

            Student ogrenci = new Student(mediator);
            ogrenci.Name = "Mustafa";
        
          

            Student ogrenci2 = new Student(mediator);
            ogrenci2.Name = "Salih";

            mediator.Students = new List<Student> { ogrenci, ogrenci2 };

            hoca.SendNewImageUrl("slide1.jpg");
            hoca.ReciveQuestion("is it true?", ogrenci2);
            
            Console.ReadLine();

            //
        }
    }

    //1
   abstract class CourseMember //corsememberdan => Mediator (karar verir) => Student ve ya Teacher
    {
        //2
        protected Mediator Mediator;
        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
        //
    }
    class Teacher : CourseMember
    {
        public string Name { get; set; }
        //3
        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        //
        public void ReciveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recived a question from {0},{1}", student.Name,question);
        }
        //5
        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url); //bütün öğrencilere url'i gönderdi.
        }
        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question: {0},{1}", student.Name, answer);
        }
        //
    }
    class Student : CourseMember
    {
        public string Name { get;  set; }
        //4
        public Student (Mediator mediator) : base(mediator)
        {

        }
        //
        public void ReciveImage(string url)
        {
            Console.WriteLine("{1} received image: {0}", url,Name); //bütün öğrenciler aldı
        }

        public void ReciveAnswer(string answer)
        {
            Console.WriteLine("Student received answer : {0}", answer);
        }
    }

    class Mediator
    {
        public Teacher Teacher{ get; set; } //1 öğretmen var
        public List<Student> Students { get; set; } //1'den çok öğrenci var

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReciveImage(url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.ReciveQuestion(question,student);
        }

        public void SendAnswer(string answer,Student student)
        {
            student.ReciveAnswer(answer);
        }
    }
    //
}
