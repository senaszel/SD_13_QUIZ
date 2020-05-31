namespace SD_13_Quiz_ConsoleUI
{
    internal class QuizModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public QuizModel()
        {

        }

        public QuizModel(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            string quiz = $"(Id:{Id}) Quiz: {Name}";


            return $"{quiz,-30}";
        }


    }
}