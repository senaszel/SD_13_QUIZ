using System;

namespace SD_13_Quiz_ConsoleUI
{
    class DeleteQuestionMenu : Menu.Menu
    {
        public DeleteQuestionMenu()
        {
            var questions = SQLiteDataAccess.LoadQuestions();
            if (questions.Count != 0)
            {

            foreach (var item in questions)
            {
                Add(new Menu.MenuItem()
                {
                    Name = item.ToString(),
                    Function = DeleteQuestionById,
                    Parameter = item.Id
                });
            }
            } else
            {
                Add(new Menu.MenuItem() { Name = "P U S T O" });
            }
        }

        private void DeleteQuestionById(object obj)
        {
            QuestionModel deletedQuestion = SQLiteDataAccess.SelectQuestionById((int)obj);

            try
            {
                SQLiteDataAccess.DeleteQuestionById((int)obj);

                Console.WriteLine("Poprawnie usunieto z bazy pytan pytanie: \n");
                Console.WriteLine(deletedQuestion);
            }
            catch (Exception)
            {
                Console.WriteLine("Nie udalo sie usunac pytania");
            }

            Console.ReadKey(true);
        }


    }
}