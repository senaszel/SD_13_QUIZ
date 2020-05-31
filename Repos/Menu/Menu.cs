using System;
using System.Collections.Generic;
using System.Linq;

namespace Menu
{
    public abstract class Menu
    {
        private readonly List<MenuItem> Items;
        private MenuItem SelectedItem
        {
            get
            {


                return Items.FirstOrDefault(x => x.IsSelected == true);
            }

        }

        public Menu()
        {
            Items = new List<MenuItem>();
        }

        public void MoveNext()
        {
            if (SelectedItem != Items.Last(x => x.Unselectable == false))
            {
                MenuItem newIndex = Items.SkipWhile(x => x.IsSelected == false).Skip(1).First(x => x.Unselectable == false);

                SelectedItem.IsSelected = false;
                newIndex.IsSelected = true;
            }
        }

        public void MoveBack()
        {
            if (SelectedItem != Items.First(x => x.Unselectable == false))
            {
                MenuItem newIndex = Items.AsEnumerable().Reverse().SkipWhile(x => x.IsSelected == false).Skip(1).First(x => x.Unselectable == false);

                SelectedItem.IsSelected = false;
                newIndex.IsSelected = true;
            }
        }

        public void Invoke()
        {
            SelectedItem.Invoke();
        }

        public void Add(MenuItem menuItem)
        {
            Items.Add(menuItem);
            if (menuItem.Unselectable == false && SelectedItem is null)
            {
                menuItem.IsSelected = true;
            }
        }

        public void Print(bool doNotClear = false)
        {
            if (!doNotClear)
            {
                Console.Clear();
            }
            Console.WriteLine("\n\n");
            foreach (var item in Items)
            {
                if (item.IsSelected)
                {
                    Console.Write("{0}", "".PadLeft(100 - item.Name.Length));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", item.Name);
                    Console.ResetColor();
                }
                else Console.WriteLine("{0,100}", item.Name);
                if (item.Distance > 0)
                {
                    string space = new string('\n', item.Distance);
                    Console.Write("{0}", space);
                }
            }
        }

        public virtual int Start(int code = -1, bool doNotClear = false)
        {
            ConsoleKey choice;
            do
            {

                Print(doNotClear);

                choice = Console.ReadKey(true).Key;


                switch (choice)
                {
                    case ConsoleKey.DownArrow:
                        MoveNext();
                        break;
                    case ConsoleKey.UpArrow:
                        MoveBack();
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("\n\n");
                        if (SelectedItem.BoolFunction is null)
                        {
                            if (SelectedItem.Function is null)
                            {
                                code = 1;
                                break;
                            }
                            else
                            {
                                Invoke();
                                code = 0;
                                break;
                            }
                        }
                        else
                        {
                            if (Process())
                            {
                                code = 1;
                                break;
                            }
                            else
                            {
                                code = 0;
                                break;
                            }
                        }
                    case ConsoleKey.Escape:
                        code = 1;
                        break;
                }

            } while (choice != ConsoleKey.Enter &&
                    choice != ConsoleKey.Escape
            );

            return code;

        }

        private bool Process()
        {
            if (SelectedItem.Parameter is null)
            {
                return SelectedItem.BoolFunction(null);
            }
            else
            {
                return SelectedItem.BoolFunction(SelectedItem.Parameter);
            }
        }


    } //end of Class
} //end of Namespace
