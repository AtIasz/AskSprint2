using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Npgsql;

namespace AskSprint1_1.Services
{
    public class InMemoryQuestionsService : IQuestionsService
    {
        [Required]
        
        private List<Question> _questions = new List<Question>();
        string posgresUsername = Environment.GetEnvironmentVariable("postgresUsername");
        string posgresPW = Environment.GetEnvironmentVariable("postgresPassword");
        private int ID = 0;
        public InMemoryQuestionsService()
        { 

        }
        public int GetId()
        {
            return this.ID;
        }
        public List<Question> GetAll()
        {
            using (var conn = new NpgsqlConnection($"Host=localhost;Username={posgresUsername};Password={posgresPW};Database=askmate"))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("select * from question", conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var questionId = this.ID;
                        var questionTitle = reader["question_title"].ToString();
                        var questionMessage = reader["question_message"].ToString();
                        
                        Question q = new Question(questionId, questionTitle, questionMessage);
                        bool thereIs = false;
                        for (int i = 0; i < _questions.Count; i++)
                        {

                            if (_questions[i].Title==q.Title)
                            {
                                thereIs = true;
                            }
                        }
                        if (thereIs==false)
                        {
                            this.ID += 1;
                            _questions.Add(q);
                        }
                    }
                }
            }

            return _questions;
        }
        public Question GetOne(int id)
        {
            return _questions.Where(q => q.ID == id).First();
        }
        public List<Question> AddOne(string title,string message)                                               //EZT MEGCSINÁLNI
        {
            this.ID += 1;
            using (var conn = new NpgsqlConnection($"Host=localhost;Username={posgresUsername};Password={posgresPW};Database=askmate"))
            {
                //INSERT INTO celebs (id, name, age) 
                conn.Open();
                using (var cmd = new NpgsqlCommand("insert into question(question_id,question_title,question_message) values (@qId,@qT,@qM)", conn))
                {
                    
                    cmd.Parameters.AddWithValue("qId", GetId());
                    cmd.Parameters.AddWithValue("qT", title);
                    cmd.Parameters.AddWithValue("qM", message);
                    cmd.ExecuteNonQuery();
                }
            }
            Question q = new Question(GetId(), title, message);
            _questions.Add(q);
            return _questions;
        }
        public List<Question> Add1Answer(int id, string message)
        {
            foreach (var q in _questions)
            {
                if (q.ID==id)
                {
                    q.Answers.Add(message);
                }
            }
            return _questions;
        }
       
    }
}
