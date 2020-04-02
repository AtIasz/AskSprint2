using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AskSprint1_1
{
    public class Question
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public List<string> Answers { get; set; }
        public Question(int id, string title, string message)
        {
            ID = id;
            Title = title;
            Message = message;
            Answers = new List<string>();
        }
        public Question(int id, string title, string message, List<string> answers)
        {
            ID = id;
            Title = title;
            Message = message;
            Answers = answers;
        }
    }
}
