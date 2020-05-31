using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SD_13_Quiz_ConsoleUI
{
    class SQLiteDataAccess
    {
        public static List<QuizModel> LoadQuizes()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string quizes = "SELECT * FROM Quizes";
                var output = conn.Query<QuizModel>(quizes, new DynamicParameters());


                return output.ToList();
            }
        }


        public static List<QuestionModel> LoadQuestions()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string questions = "SELECT * FROM Questions";
                var output = conn.Query<QuestionModel>(questions, new DynamicParameters());


                return output.ToList();
            }
        }

        internal static QuizModel SelectLatestQuiz()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string SQLite = "SELECT * FROM Quizes WHERE Id=(SELECT MAX(Id) FROM Quizes)";
                QuizModel output = conn.Query<QuizModel>(SQLite, new DynamicParameters()).First();


                return output;
            }
        }

        internal static List<QuestionModel> SelectQuestionsByQuizesId(int IdQuiz)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string SQLite = $"SELECT * FROM Questions WHERE IdQuiz={IdQuiz}";
                IEnumerable<QuestionModel> output = conn.Query<QuestionModel>(SQLite);


                return output.ToList();
            }
        }

        internal static QuestionModel SelectLatestQuestion()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string SQLite = "SELECT * FROM Questions WHERE Id=(SELECT MAX(Id) FROM Questions)";
                QuestionModel output = conn.Query<QuestionModel>(SQLite, new DynamicParameters()).First();


                return output;
            }
        }

        internal static AnswerModel SelectAnswerById(int answerId)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = $"SELECT * FROM ANSWERS WHERE ID={answerId}";
                return conn.QueryFirst<AnswerModel>(sql);
            }
        }

        internal static void DeleteAnswerById(int answerId)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = $"DELETE FROM ANSWERS WHERE ID={answerId}";
                conn.Execute(sql);
            }
        }

        public static List<AnswerModel> LoadAnswers()
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string answers = $"SELECT * FROM ANSWERS";
                IEnumerable<AnswerModel> output = conn.Query<AnswerModel>(answers, new DynamicParameters());


                return output.ToList();
            }
        }
        internal static List<AnswerModel> SelectAnswersByQuestionId(int QuestionId)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sqlite = $"SELECT * FROM Answers WHERE IdQuestion={QuestionId}";
                List<AnswerModel> output = conn.Query<AnswerModel>(sqlite).ToList();

                return output;
            }
        }

        internal static QuestionModel SelectQuestionById(int questionId)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = $"SELECT * FROM QUESTIONS WHERE ID={questionId}";
                return conn.QueryFirst<QuestionModel>(sql);
            }
        }

        internal static void DeleteQuestionById(int questionId)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = $"DELETE FROM QUESTIONS WHERE ID={questionId}";
                conn.Execute(sql);
            }
        }

        public static int InsertQuiz(QuizModel quiz)
        {
            try
            {
                using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
                {
                    conn.Execute("INSERT INTO QUIZES(Name) VALUES (@Name)", quiz);
                }
            }
            catch (Exception)
            {


                return -1;
            }


            return quiz.Id;
        }

        internal static QuizModel SelectQuizById(int quizId)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    // todo wywala sie jak w bazie sa pytania przypisane do usunietego quizu. Dopisac usuwanie pytan skladowych quizu kiedy sie go usuwa.
                    string sql = $"SELECT * FROM Quizes WHERE ID={quizId}";
                    return conn.QueryFirst<QuizModel>(sql);

                }
                catch (Exception)
                {
                    return new QuizModel("ERROR");
                }
            }
        }

        internal static void DeleteQuizById(int quizId)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = $"DELETE FROM QUIZES WHERE ID={quizId}";
                conn.Execute(sql);
            }
        }

        public static void InsertQuestion(QuestionModel question)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                conn.Execute("INSERT INTO QUESTIONS(IdQuiz, QuestionText) VALUES (@IdQuiz, @QuestionText)", question);
            }
        }

        public static void InsertAnswer(AnswerModel answer)
        {
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = "INSERT INTO ANSWERS(IdQuestion,AnswerText,IsCorrect) VALUES (@IdQuestion ,@AnswerText ,@IsCorrect)";
                conn.Execute(sql, answer);
            }
        }


        public static string IdQuizToString(int idQuiz)
        {
            // bubu
            string nameOfQuiz;
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = $"Select Name from Quizes where Id={idQuiz}";
                nameOfQuiz = conn.Query<string>(sql).First().ToString();
            }


            return nameOfQuiz;
        }



        internal static int GetQuestionId(QuestionModel questionModel)
        {
            int ret;
            using (IDbConnection conn = new SQLiteConnection(LoadConnectionString()))
            {
                string sql = $"SELECT Id from Questions where QuestionText=\"{questionModel.QuestionText}\"";
                ret = conn.QueryFirst<int>(sql);
            }


            return ret;
        }



        private static string LoadConnectionString(string id = "QuizesDB")
        {


            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
