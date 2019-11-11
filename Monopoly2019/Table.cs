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
        public Form1 form;
        private static Table table = new Table();
        private static readonly object padlock = new object();

        Table()
        {
             form = new Form1();
        }

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
