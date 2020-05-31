using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_13_Quiz_ConsoleUI
{
    class AnswerModel
    {
        public AnswerModel()
        {

        }
        public AnswerModel(int idQuestion, string answerText, bool isCorrect)
        {
            IdQuestion = idQuestion;
            AnswerText = answerText;
            IsCorrect = isCorrect;
        }

        public int Id { get; set; }
        public int IdQuestion { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        public override string ToString()
        {
            string toString = $">>(Id: {Id,2})\nAnswer for Question[{IdQuestion,2}]\nIsCorrect[{IsCorrect,5}]\n{AnswerText,-100}<<";


            return toString;
        }



    }
}
