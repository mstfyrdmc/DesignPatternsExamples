using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrideDesignDemo
    // amacımız bir nesnenin içinde soyutlanabilir,değiştirilebilir kısımlar varsa onları soyutlama teknikleriyle gerçekleştirmektir.
{
    class Program
    {
        static void Main(string[] args)
        {
            //4
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new EMailSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
            //
        }
    }

    //1
   abstract  class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message Saved");
        }

        public abstract void Send(Body body);
       
    }
     class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    //

    //2
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} and {1} was sent via SmsSender",body.Title,body.Text);
        }
    }

    class EMailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} and {1} was sent via EmailSender", body.Title,body.Text);
        }
    }
    //

    //3
    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }
        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body {Title="Mesaj Başlığı",Text="Mesajın Kendisi" });
            Console.WriteLine("Customer Updated");
        }
    }
    //
}
