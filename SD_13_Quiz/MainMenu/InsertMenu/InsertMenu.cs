using System;
using System.Collections.Generic;

namespace SD_13_Quiz_ConsoleUI
{
    class InsertMenu : Menu.Menu
    {

        public InsertMenu()
        {
            Add(new Menu.MenuItem() { Name = "Full Quiz", Function = FullQuiz });
        }

        private void FullQuiz(object obj)
        {
            AddNewQuiz(null);
            int exitCode;
            do
            {
                AskOneQuestionAndItsAnswersAtTheTime();
                Menu.Menu yesNoMenu = new YesNoMenu();
                exitCode = yesNoMenu.Start();

            } while (exitCode != 0);

            QuizModel latestQuiz = SQLiteDataAccess.SelectLatestQuiz();
            List<QuestionModel> questionsCount = SQLiteDataAccess.SelectQuestionsByQuizesId(latestQuiz.Id);

            Console.WriteLine($"{questionsCount.Count} x Questions Have Been Added To Quiz: {latestQuiz.Name}");
            Console.ReadKey();
        }

        private void AskOneQuestionAndItsAnswersAtTheTime()
        {
            string questionText;
            do
            {
                Console.Clear();
                Console.WriteLine("\nInput new Question:");
                Console.ForegroundColor = ConsoleColor.Blue;
                questionText = Console.ReadLine();
                Console.ResetColor();

            } while (MyValidation.ValidateStringsWithRegex.ForQuestions(questionText));

            int idquiz = SQLiteDataAccess.SelectLatestQuiz().Id;
            QuestionModel questionModel = new QuestionModel(idquiz, questionText);
            SQLiteDataAccess.InsertQuestion(questionModel);

            Console.WriteLine("\nInput 4 consequtive answers. Of which only first one should be correct.");

            string correctAnswer = AddNextAnswer("Input correct answer:", ConsoleColor.Green);
            Console.WriteLine($"Saved : {correctAnswer}\n");

            string[] incorrectAnswers = new string[3];
            incorrectAnswers = Get3IncorrectAnswersFromUser(incorrectAnswers);

            var latestQuestion = SQLiteDataAccess.SelectLatestQuestion();
            AnswerModel answerModel = new AnswerModel(latestQuestion.Id, correctAnswer, true);
            SQLiteDataAccess.InsertAnswer(answerModel);

            for (int i = 0; i < incorrectAnswers.Length; i++)
            {
                AnswerModel _answerModel = new AnswerModel(latestQuestion.Id, incorrectAnswers[i], false);
                SQLiteDataAccess.InsertAnswer(_answerModel);
            };

        }

        private string[] Get3IncorrectAnswersFromUser(string[] incorrectAnswers)
        {
            for (int i = 0; i < incorrectAnswers.Length; i++)
            {
                incorrectAnswers[i] = AddNextAnswer("Input incorrect answer: ", ConsoleColor.Red);
                Console.WriteLine($"Saved : {incorrectAnswers[i]}\n");
            }

            return incorrectAnswers;
        }

        private string AddNextAnswer(string PromptMessage, ConsoleColor consoleColor)
        {
            string answer;
            do
            {
                Console.Clear();
                Console.WriteLine($"\n{PromptMessage}");
                Console.ForegroundColor = consoleColor;
                answer = Console.ReadLine();
                Console.ResetColor();
            } while (MyValidation.ValidateStringsWithRegex.ForStatements(answer));


            return answer;
        }

        private void AddNewQuiz(object obj)
        {
            int addedQuizId;
            do
            {

                string newQuizsName;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Add new Quiz");
                    Console.WriteLine();
                    Console.WriteLine("What will be its name?");
                    Console.WriteLine("( Input only letter characters; Separators are also available )\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    newQuizsName = Console.ReadLine();
                    Console.ResetColor();

                } while (MyValidation.ValidateStringsWithRegex.ForStatements(newQuizsName.Trim()));

                Console.Clear();
                Console.Write("New Quiz ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{newQuizsName}");
                Console.ResetColor();
                Console.WriteLine(" will be created for You.");

                QuizModel newQuiz = new QuizModel
                {
                    Name = newQuizsName.Trim()
                };
                addedQuizId = SQLiteDataAccess.InsertQuiz(newQuiz);

            } while (addedQuizId == -1);

        }




    }
}