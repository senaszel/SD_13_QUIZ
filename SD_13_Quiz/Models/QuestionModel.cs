namespace SD_13_Quiz_ConsoleUI
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public int IdQuiz { get; set; }
        public string QuestionText { get; set; }

        public QuestionModel()
        {

        }

        public QuestionModel(int idQuiz, string questionText)
        {
            IdQuiz = idQuiz;
            QuestionText = questionText;
        }

        public override string ToString()
        {
            string question = $"(Id:{Id}) Question for Quiz [{IdQuiz}] {SQLiteDataAccess.SelectQuizById(IdQuiz).Name} : {QuestionText}";


            return $"{question}";
        }
    }
}