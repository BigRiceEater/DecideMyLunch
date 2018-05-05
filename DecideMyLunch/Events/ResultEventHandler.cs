using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecideMyLunch.Events
{
    public delegate void ResultEventHandler(object sender, ResultEventArgs e);

    public class ResultEventArgs : EventArgs
    {

    }
}
