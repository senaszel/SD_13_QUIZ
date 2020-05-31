using System;

namespace SD_13_Quiz_ConsoleUI
{
    class DeleteQuizMenu : Menu.Menu
    {
        public DeleteQuizMenu()
        {
            var quizes = SQLiteDataAccess.LoadQuizes();
            if (quizes.Count != 0)
            {
                foreach (var item in quizes)
                {
                    var quizToStringLength = item.ToString().Length < 100 ? item.ToString() : item.ToString().Substring(0, 100);
                    Add(new Menu.MenuItem()
                    {
                        Name = item.ToString().Substring(0, quizToStringLength.Length),
                        Function = DeleteQuizesById,
                        Parameter = item.Id
                    });
                }
            }
            else
            {
                Add(new Menu.MenuItem() { Name = "P U S T O" });
            }
        }

        private void DeleteQuizesById(object obj)
        {
            QuizModel deletedQuiz = SQLiteDataAccess.SelectQuizById((int)obj);

            try
            {
                SQLiteDataAccess.DeleteQuizById((int)obj);

                Console.WriteLine("Poprawnie usunieto z bazy pytan pytanie: \n");
                Console.WriteLine(deletedQuiz);
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie udalo sie usunac pytania.");
                Console.ResetColor();
            }

            Console.ReadKey(true);
        }


    }
}