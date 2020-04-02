using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AskSprint1_1.Services
{
    public class InMemoryAnswersService : IAnswersService
    {
        List<Question> questions = new List<Question>();
        InMemoryQuestionsService inMemory = new InMemoryQuestionsService();
        public InMemoryAnswersService()
        {
            questions=inMemory.GetAll();
        }
        public List<Question> AddOneAnswer(int id, string message)
        {
            var answer = new Answer(inMemory.GetId(), message);
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].ID==id)
                {
                    questions[i].Answers.Add(message);
                }
            }
            return questions;
        }
    } 
}
