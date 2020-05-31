using System;

namespace SD_13_Quiz_ConsoleUI
{
    class MainMenu : Menu.Menu
    {

        public MainMenu()
        {
            Add(new Menu.MenuItem() { Name = "Take Quiz", Function = ChooseQuiz, Distance = 1 });
            Add(new Menu.MenuItem() { Name = "Insert", Function = InsertMenu });
            Add(new Menu.MenuItem() { Name = "Show", Function = ShowMenu });
            Add(new Menu.MenuItem() { Name = "Delete", Function = DeleteMenu });
        }

        private void ChooseQuiz(object obj)
        {
            int exit;
            do
            {
                Menu.Menu insertMenu = new TakeQuizMenu();
                exit = insertMenu.Start();

            } while (exit != 1);
        }

        private void InsertMenu(object obj)
        {
            int exit;
            do
            {
                Menu.Menu insertMenu = new InsertMenu();
                exit = insertMenu.Start();

            } while (exit != 1);
        }

        private void DeleteMenu(object obj)
        {
            int exit;
            do
            {
                DeleteMenu deleteMenu = new DeleteMenu();
                exit = deleteMenu.Start();

            } while (exit != 1);
        }

        private void ShowMenu(object obj)
        {
            int exit;
            do
            {
                ShowMenu showMenu = new ShowMenu();
                exit = showMenu.Start();

            } while (exit != 1);
        }


    }
}
