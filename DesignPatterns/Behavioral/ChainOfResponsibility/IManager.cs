using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility
{
    public interface IManager
    {
        void SetSupervisor(IManager manager);
        void ApproveRequest(ExpenseReport expenseReport);
    }
}
