using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Singleton class for Table. Only one table will be in the whole game.
namespace Monopoly2019
{
    public sealed class Table
    {
        private static Table table = null;
        private static readonly object padlock = new object();

        Table()
        { }

        public static Table Instance
        {
            get
            {
                lock (padlock)
                {
                    if (table == null)
                    {
                        table = new Table();
                    }
                    return table;
                }
            }
        }
    }
}
