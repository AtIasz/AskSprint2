﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AskSprint1_1.Services
{
    public interface IAnswersService
    {
        List<Question> AddOneAnswer(int id,string message); 
    }
}
