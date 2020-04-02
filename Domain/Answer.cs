using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskSprint1_1
{
    public class Answer
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public Answer(int id, string message)
        {
            ID = id;
            Message = message;
        }
    }
}
