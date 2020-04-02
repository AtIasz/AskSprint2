﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AskSprint1_1.Models;
using AskSprint1_1.Services;
using System.Web;
using System.Net;

namespace AskSprint1_1.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionsService _questionsService;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionsService questionService)
        {
            _questionsService = questionService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult All()
        {
            var questions = _questionsService.GetAll();
            return View(questions);
        }
        public IActionResult Get(int id)
        {
            var question = _questionsService.GetOne(id);
            return View(question);
        }
        
        public IActionResult AddQuestion(string Title, string Message)
        {
            var question = _questionsService.AddOne(Title, Message);
            return RedirectToAction("Get", new { id = _questionsService.GetId() });
            
        }
        public IActionResult Add()
        {
            return View("Add");
        }
        public IActionResult Delete(int id)
        {
            List<Question> questions = _questionsService.GetAll();
            foreach (var question in questions)
            {
                if (question.ID == id)
                {
                    questions.Remove(question);
                    break;
                }
            }
            return Redirect("/Questions/All");
        }
        public IActionResult Answer(int id)
        {
            var q = _questionsService.GetOne(id);
            return View("new-answer",q);
        }




        public IActionResult Add1Answer(int id,string answer)
        {
            List<Question> questions = _questionsService.GetAll();
            foreach (var question in questions)
            {
                if(question.ID == id)
                {
                    question.Answers.Add(answer);
                    break;
                }
            }
            return Redirect($"/Questions/All");
        }
        
        public IActionResult DeleteThisAnswer(string answer, int id)
        {
            List<Question> questions = _questionsService.GetAll();
            foreach (var question in questions)
            {
                if (question.ID == id)
                {
                    question.Answers.Remove(answer);
                    break;
                }
            }
            return Redirect($"/Questions/All");
        }
    }
}
