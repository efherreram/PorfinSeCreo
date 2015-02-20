using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Antlr.Runtime.Misc;
using StackOverflow.Web.Models;

namespace StackOverflow.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        
        
        // GET: /Question/
        [AllowAnonymous]
        public ActionResult Index()
        {
            List<QuestionListModel> models = new ListStack<QuestionListModel>();
            QuestionListModel model1 = new QuestionListModel();
            model1.Title = "Title Test";
            model1.OwnerName = "Juan";
            model1.Votes = 1;
            model1.CreationTime = DateTime.Now;
            model1.QuestionId = Guid.NewGuid();
            model1.OwnerId = Guid.NewGuid();
    
            models.Add(model1);
            QuestionListModel model2 = new QuestionListModel();

            model2.Title = "Title Test";
            model2.OwnerName = "Juan";
            model2.Votes = 1;
            model2.CreationTime = DateTime.Now;
            model2.OwnerId = Guid.NewGuid();
            model2.QuestionId = Guid.NewGuid();

            models.Add(model2);
            return View(models);
          
        }


        public ActionResult IndexAddQuestion()
        {
            return View(new AddNewQuestionModel());
        }

        [AllowAnonymous]
        public ActionResult QuestionDetails()
        {
            return View(new QuestionDetailsModel());
        
        }

        [HttpPost]
        public ActionResult QuestionDetails(QuestionDetailsModel model)
        {
            return View(model);
        }        
	}
}