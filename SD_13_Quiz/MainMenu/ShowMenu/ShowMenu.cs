using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_13_Quiz_ConsoleUI
{
    class ShowMenu : Menu.Menu
    {
        public ShowMenu()
        {
            Add(new Menu.MenuItem() { Name = "Show Quizes", Function = ShowQuizes });
            Add(new Menu.MenuItem() { Name = "Show Questions", Function = ShowQuestions });
            Add(new Menu.MenuItem() { Name = "Show Answers", Function = ShowAnswers });
        }

        private void ShowAnswers(object obj)
        {
            var answers = SQLiteDataAccess.LoadAnswers();
            ShowElementsIfListNotEmpty(answers);
        }

        private void ShowQuestions(object obj)
        {
            var questions = SQLiteDataAccess.LoadQuestions();
            ShowElementsIfListNotEmpty(questions);
        }


        private void ShowQuizes(object obj)
        {
            var quizes = SQLiteDataAccess.LoadQuizes();
            ShowElementsIfListNotEmpty(quizes);
        }


        private static void ShowElementsIfListNotEmpty<T>(List<T> elements)
        {
            if (elements.Count != 0)
            {
                elements.ForEach(x => Console.WriteLine(x + Environment.NewLine));
            }
            else
            {
                Console.WriteLine("P U S T O");
            }
            Console.ReadKey(true);
        }


    }
}
