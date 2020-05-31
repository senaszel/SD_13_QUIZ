using System;

namespace SD_13_Quiz_ConsoleUI
{
    class DeleteAnswerMenu : Menu.Menu
    {
        public DeleteAnswerMenu()
        {
            var answers = SQLiteDataAccess.LoadAnswers();
            if (answers.Count != 0)
            {
                foreach (var item in answers)
                {
                    Add(new Menu.MenuItem()
                    {
                        Name = item.ToString().Substring(0, 98) + Environment.NewLine,
                        Function = DeleteAnswerById,
                        Parameter = item.Id
                    });
                }
            }
            else
            {
                Add(new Menu.MenuItem() { Name = "P U S T O"});
            }
        }


        private void DeleteAnswerById(object obj)
        {
            AnswerModel deletedAnswer = SQLiteDataAccess.SelectAnswerById((int)obj);

            try
            {
                SQLiteDataAccess.DeleteAnswerById((int)obj);


                Console.WriteLine("Poprawnie usunieto z bazy odpowiedzi odpowiedz: \n");
                Console.WriteLine(deletedAnswer);
            }
            catch (Exception)
            {
                Console.WriteLine("Nie udalo sie usunac odpowiedzi");
            }

            Console.ReadKey(true);
        }


    }
}