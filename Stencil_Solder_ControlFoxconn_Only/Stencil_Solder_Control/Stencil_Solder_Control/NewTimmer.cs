using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stencil_Solder_Control
{
    class NewTimmer:System.Windows.Forms.Timer
    {
        public delegate void EventHandlerNew(object sender, EventArgs e, int row);
        public event EventHandlerNew TickNew;
    }
}
