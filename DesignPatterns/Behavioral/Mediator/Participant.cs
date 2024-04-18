using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Mediator
{
    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    public class Participant
    {
        private Chatroom _chatroom;
        private string _name;

        public Chatroom Chatroom
        {
            get { return _chatroom; }
            set { _chatroom = value; }
        }

        public string Name
        {
            get { return _name; }
        }

        public Participant(string name)
        {
            this._name = name;
        }

        public void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"{from} to {Name}: '{message}'");
        }
    }
}
