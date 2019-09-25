using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronSoft.UI
{
    public interface IHandler
    {
        event Action<string> SetTextBoxHandler;
    }
}
