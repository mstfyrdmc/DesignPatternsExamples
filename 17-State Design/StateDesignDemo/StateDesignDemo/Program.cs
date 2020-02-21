using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesignDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //3
            Context context = new Context();
            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);

            DeleteddState deleted = new DeleteddState();
            deleted.DoAction(context);

            AddedState added = new AddedState();
            added.DoAction(context);

            Console.WriteLine(context.GetState().ToString()); //son durum
            Console.ReadLine();
            //
        }
    }

    //1
    interface IState
    {
        void DoAction(Context context);

    }

    class Context
    {
       private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
    //

    //2
    class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified";
        }
    }
    class DeleteddState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");

            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }
    //
}
