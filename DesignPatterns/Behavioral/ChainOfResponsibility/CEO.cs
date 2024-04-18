using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    internal class CEO : IManager
    {
        private IManager _manager;
        public void ApproveRequest(ExpenseReport expenseReport)
        {
            if (expenseReport.Amount < 5000)    Console.WriteLine("Approved by CEO.");
            else                                Console.WriteLine("Not approved.");
        }

        public void SetSupervisor(IManager manager)
        {
            this._manager = manager;
        }
    }
}
