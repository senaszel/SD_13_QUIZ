using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_13_Quiz_ConsoleUI
{
    class YesNoMenu : Menu.Menu
    {

        public YesNoMenu()
        {
            Add(new Menu.MenuItem() { Name = "Add another question to this Quiz?", Distance = 1, Unselectable = true });
            Add(new Menu.MenuItem() { Name = "Yes", BoolFunction = Yes });
            Add(new Menu.MenuItem() { Name = "No", BoolFunction = No, Distance = 1 });
            Add(new Menu.MenuItem() { Name = "Please choose Y/N from menu above.", Unselectable = true });
        }

        private bool No(object arg)
        {
            return false;
        }

        private bool Yes(object arg)
        {
            return true;
        }

    }
}
