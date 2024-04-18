using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    public class SeniorManager : IManager
    {
        private IManager _manager;
        public void ApproveRequest(ExpenseReport expenseReport)
        {
            if (expenseReport.Amount < 500)     Console.WriteLine("Approved by manager.");
            else                                _manager?.ApproveRequest(expenseReport);
        }

        public void SetSupervisor(IManager manager)
        {
            this._manager = manager;
        }
    }
}
