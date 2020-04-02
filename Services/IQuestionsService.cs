using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskSprint1_1.Services
{
    public interface IQuestionsService
    {
        List<Question> GetAll();

        Question GetOne(int id);
        List<Question> AddOne(string title,string message);
        int GetId(); 
    }
}
