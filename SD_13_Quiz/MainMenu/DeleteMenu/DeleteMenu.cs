using System;

namespace SD_13_Quiz_ConsoleUI
{
    class DeleteMenu : Menu.Menu
    {

        public DeleteMenu()
        {
            Add(new Menu.MenuItem() { Name = "Delete Quiz", Function = DeleteQuiz });
            Add(new Menu.MenuItem() { Name = "Delete Question", Function = DeleteQuestion });
            Add(new Menu.MenuItem() { Name = "Delete Answer", Function = DeleteAnswer });
        }


        private void DeleteAnswer(object obj)
        {
            int exit;
            do
            {
                Menu.Menu deleteAnswerMenu = new DeleteAnswerMenu();
                exit = deleteAnswerMenu.Start();

            } while (exit != 1);
        }


        private void DeleteQuestion(object obj)
        {
            int exit;
            do
            {
                Menu.Menu deleteQuestionMenu = new DeleteQuestionMenu();
                exit = deleteQuestionMenu.Start();

            } while (exit != 1);
        }



        private void DeleteQuiz(object obj)
        {
            int exit;
            do
            {
                Menu.Menu deleteQuizMenu = new DeleteQuizMenu();
                exit = deleteQuizMenu.Start();

            } while (exit != 1);
        }


    }
}