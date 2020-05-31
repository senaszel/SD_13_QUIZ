using System;

namespace SD_13_Quiz_ConsoleUI
{
    internal class TakeQuizMenu : Menu.Menu
    {
        public TakeQuizMenu()
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
                        Function = TakeQuiz,
                        Parameter = item.Id
                    });
                }
            }
            else
            {
                Add(new Menu.MenuItem() { Name = "P U S T O" });
            }
        }

        private void TakeQuiz(object quizId)
        {
            double results = 0;
            var questions = SQLiteDataAccess.SelectQuestionsByQuizesId((int)quizId);


            foreach (var question in questions)
            {

                bool usersAnswer = AskEachQuestionOneAtTheTime(question);

                if (usersAnswer)
                {
                    results += 1;
                    Console.WriteLine("\n\tIt is a correct answer!\n");
                }else
                {
                    Console.WriteLine("\n\tYyyyy!!\tWrong!\n");
                }

                Console.ReadKey();
            }

            Console.Clear();

            Console.WriteLine("\n\n\tYour Quiz ended");
            Console.WriteLine($"\n\t\tU scored : {Math.Round((results*100)/questions.Count)} % !");

            Console.ReadKey();
        }

        private bool AskEachQuestionOneAtTheTime(QuestionModel question)
        {
            Menu.Menu possibleAnswers = new PossibleAnswersMenu(question);
            int result = possibleAnswers.Start();


            return result == 1 ? true : false;
        }


    }
}