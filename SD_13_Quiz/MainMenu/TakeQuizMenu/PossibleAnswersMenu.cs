using SD_13_Quiz.MainMenu;
using System.Collections.Generic;

namespace SD_13_Quiz_ConsoleUI
{
    internal class PossibleAnswersMenu : Menu.Menu
    {


        public PossibleAnswersMenu(QuestionModel question)
        {
            List<AnswerModel> possibleAnswers = SQLiteDataAccess.SelectAnswersByQuestionId(question.Id);

            Add(new Menu.MenuItem() { Name = question.QuestionText, Distance = 2, Unselectable = true });
            possibleAnswers.Shuffle().ForEach(x =>
            {
                Add(new Menu.MenuItem() { Name = x.AnswerText, Distance = 1, BoolFunction = IsCorrect, Parameter = x.IsCorrect });
            });
        }

        private bool IsCorrect(object arg)
        {
            bool isCorrect = (bool)arg;


            return isCorrect;
        }





    }
}