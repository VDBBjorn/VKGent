using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using p2g33_web.Models.DAL.Mapper;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.DAL
{
    public class P2G33Context : DbContext
    {
        static P2G33Context()
        {
            Database.SetInitializer<P2G33Context>(null);
        }

        public P2G33Context()
            : base("p2g33Context")
        {
        }

        //public DbSet<BoxQuestion> BoxQuestions { get; set; }
        //public DbSet<CaseAnswer> CaseAnswers { get; set; }
        //public DbSet<CaseQuestion> CaseQuestions { get; set; }
        //public DbSet<Element> Elements { get; set; }
        //public DbSet<LearningProcess> LearningProcesses { get; set; }
        //public DbSet<StatementGameQuestion> StatementGameQuestions { get; set; }
        //public DbSet<StatementGameQuestionAnswer> StatementGameQuestionAnswers { get; set; }
        //public DbSet<TrajectElement> TrajectElements { get; set; }
        public DbSet<VKUser> VKUsers { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CaseAnswerMap());
            modelBuilder.Configurations.Add(new CaseQuestionMap());
            modelBuilder.Configurations.Add(new ElementMap());
            modelBuilder.Configurations.Add(new UserAnswerMap());
            modelBuilder.Configurations.Add(new BoxUserAnswerMap());
            modelBuilder.Configurations.Add(new StatementGameUserAnswerMap());
            modelBuilder.Configurations.Add(new CaseUserAnswerMap());
            modelBuilder.Configurations.Add(new CaseMap());
            modelBuilder.Configurations.Add(new BoxMap());
            modelBuilder.Configurations.Add(new BoxQuestionMap());
            modelBuilder.Configurations.Add(new LearningProcessMap());
            modelBuilder.Configurations.Add(new StatementGameMap());
            modelBuilder.Configurations.Add(new StatementGameQuestionMap());
            modelBuilder.Configurations.Add(new StatementGameQuestionAnswerMap());
            modelBuilder.Configurations.Add(new VKUserMap());
            modelBuilder.Configurations.Add(new EvaluationMap());
        }

        public void UpdateBoxUserAnswer(string email, string learningprocessCode, int elementId, int boxQuestionId, string newAnswer, string newMotivation)
        {
            SqlConnection connection = null;
            string connectionString = System.Configuration.ConfigurationManager
                                            .ConnectionStrings[1].ConnectionString;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText =
                    "update UserAnswer " +
                    "set BoxMotivation = @motivation , " +
                    "BoxAnswer = @answer " +
                    "where ElementId = @elementID and " +
                    "Email = @email and " +
                    "LearningProcessCode = @lpc and " +
                    "BoxQuestionId = @bqID";

                command.Parameters.AddWithValue("@motivation", newMotivation);
                command.Parameters.AddWithValue("@answer", newAnswer);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@lpc", learningprocessCode);
                command.Parameters.AddWithValue("@bqID", boxQuestionId);
                command.Parameters.AddWithValue("@elementID", elementId);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}