using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace AskSprint1_1
{
    public class FileHandler
    {
        List<Question> questions;
        List<Answer> answers;
        public FileHandler()
        {
            questions = new List<Question>();
            answers = new List<Answer>();
            //QuestionsReader();
        }
       /* public void QuestionsReader()
        {
            StreamReader sr = new StreamReader("questions.csv");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Question q = new Question();
                questions.Add(q);
            }
        }
        */
        public void AnswerReader()
        {
            StreamReader sr = new StreamReader("answers.csv");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Answer a = new Answer(1,"");
                answers.Add(a);
            }
        }
        
    }
}
