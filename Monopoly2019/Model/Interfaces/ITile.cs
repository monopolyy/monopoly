using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly2019.Model;


namespace Monopoly2019.Model.Interfaces
{
    interface ITile
    {
        int Index { get; }
        string name { get; }
        string ActOnPlayer ( Player player );
    }
}
