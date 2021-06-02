using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test1.Models;
using System.Data.Entity;
using System.Web.Security;
using System.IO;
using System.Configuration;

namespace Test1.Controllers
{
    public class HomeController : Controller
    {
        Database1Context db = new Database1Context();

        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                var students = db.Students.Include(p => p.Group);
                return View(students.ToList());
            }
            
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult Contact() //___________ЭТО ВРЕМЕННАЯ ПЕСОЧНИЦА____________-
        {
            if (User.Identity.IsAuthenticated)
            {
                int studentid = 0;
                int semester = 0;
                if (Session["studentid"] != null)
                {
                    studentid = Convert.ToInt32(Session["studentid"]);
                    semester = Convert.ToInt32(Session["course"]);
                }
                var attestations = db.Attestations.Where(w => w.StudentId == studentid);
                if (semester > 0)
                {
                    attestations = db.Attestations.Where(w => w.Semester == semester && w.StudentId == studentid);
                }
                return View(attestations.ToList());
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult Progress() // УСПЕВАЕМОСТЬ
        {
            if (User.Identity.IsAuthenticated)
            {
                int studentid = 0;
                int semester = 0;
                if (Session["studentid"] != null)
                {
                    studentid = Convert.ToInt32(Session["studentid"]);
                    semester = Convert.ToInt32(Session["course"]);
                }
                var attestations = db.Attestations.Where(w => w.StudentId == studentid);
                if (semester > 0)
                {
                    attestations = db.Attestations.Where(w => w.Semester == semester && w.StudentId == studentid);
                }
                return View(attestations.ToList());
            }

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult Progress(string course)
        {
            Session["course"] = course;
            return RedirectToAction("Progress", "Home");
        }

        [HttpGet]
        public ActionResult Portfolio() // ПОРТФОЛИО
        {
            if (User.Identity.IsAuthenticated)
            {
                int studentid = 0;
                if (Session["studentid"] != null)
                {
                    studentid = Convert.ToInt32(Session["studentid"]);
                }
                var portfolios = db.Portfolios.Where(w => w.StudentId == studentid);
                return View(portfolios.ToList());
            }
            
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult Notifications() // УВЕДОМЛЕНИЯ
        {
            if (User.Identity.IsAuthenticated)
            {
                int groupid = 0;
                if (Session["groupid"] != null)
                {
                    groupid = Convert.ToInt32(Session["groupid"]);
                }
                var notifications = db.Notifications.Where(w => w.GroupId == groupid);
                return View(notifications.ToList());
            }
            
            return RedirectToAction("Login", "Home");
        }
        [HttpGet]
        public ActionResult Methodical() // МЕТОДИЧЕСКОЕ ОБЕСПЕЧЕНИЕ
        {
            if (User.Identity.IsAuthenticated)
            {
                int studyingplanid = 0;
                if (Session["studyingplanid"] != null)
                {
                    studyingplanid = Convert.ToInt32(Session["studyingplanid"]);
                }
                var studyingplans = db.StudyingPlans.Where(w => w.StudyingPlanId == studyingplanid);
                return View(studyingplans.ToList());
            }
            
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session["studentid"] = null;
                Session["studyingplanid"] = null;
                Session["groupid"] = null;
                Session["course"] = null;
                return View();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                Student student = null;
                using (Database1Context db = new Database1Context())
                {
                    student = db.Students.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);

                }
                if (student != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    Session["studentid"] = student.StudentId;
                    Session["studyingplanid"] = student.StudyingPlanId;
                    Session["groupid"] = student.GroupId;
                    Session["course"] = "0";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult Upload(UploadModel uploadModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                int studentid = 0;
                if (Session["studentid"] != null)
                {
                    studentid = Convert.ToInt32(Session["studentid"]);
                }
                string filename = "";

                    filename = Path.GetFileName(uploadModel.UploadedFile.FileName);

                    //Get Upload path from Web.Config file AppSettings.  
                    //string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                    //Its Create complete path to store in server.  
                    //string UploadPath = "~/files/portfolio_files/"+ filename;

                    //To copy and save file into server.  
                    //uploadModel.UploadedFile.SaveAs(UploadPath);
                    uploadModel.UploadedFile.SaveAs(Server.MapPath("~/files/portfolio_files/" + filename));
                

                Random rnd = new Random();
                int portfolioid = rnd.Next(5000006, 5000999);

                //To save Club Member Contact Form Detail to database table.  
                Portfolio portfolio = new Portfolio();
                portfolio.Category = uploadModel.Category;
                portfolio.DateOfUpload = DateTime.Now;
                portfolio.FileLink = filename;
                portfolio.FileName = uploadModel.Name;
                portfolio.StudentId = studentid;
                portfolio.PortfolioId = portfolioid;

                db.Portfolios.Add(portfolio);
                db.SaveChanges();

                return RedirectToAction("Portfolio", "Home");
            }
            return RedirectToAction("Login", "Home");      
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Portfolio b = db.Portfolios.Find(id);
                Portfolio portfolios = db.Portfolios.FirstOrDefault(p => p.PortfolioId == id);
                if (b == null)
                {
                    return HttpNotFound();
                }
                return View(b);
            }
            return RedirectToAction("Login", "Home");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio b = db.Portfolios.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Portfolios.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Portfolio", "Home");
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session["studentid"] = null;
            Session["studyingplanid"] = null;
            Session["groupid"] = null;
            return RedirectToAction("Login", "Home");
        }

    }
}