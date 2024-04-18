using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    internal class VicePresident : IManager
    {
        private IManager _manager;
        public void ApproveRequest(ExpenseReport expenseReport)
        {
            if (expenseReport.Amount < 1000)    Console.WriteLine("Approved by Vice President.");
            else                                _manager?.ApproveRequest(expenseReport);
        }

        public void SetSupervisor(IManager manager)
        {
            this._manager = manager;
        }
    }
}
