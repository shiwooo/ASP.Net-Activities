using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Application_Activities.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult StudentAccountingSystem()
        {
            ViewBag.Message = "Student Accoungting System page.";

            return View();
        }
        public ActionResult StudentEntry()
        {
            var data = new List<object>();

            var course_code = Request["crsCode"];
            var subject = Request["subjCount"];
            int subj_count = Convert.ToInt32(subject);
            int unit_sum = subj_count * 3;
            
            double tuition_per_unit = 0;
            double reg_fee = 0;
            double misc_fee = 0;
            double lab_fee = 0;
            var course = "";
            switch (course_code)
            {
                case "0001":
                    course = "C1";
                    tuition_per_unit = 356.75;
                    reg_fee = 545.00;
                    misc_fee = 1000.45;
                    lab_fee = 1900.75;
                    break;

                case "0002":
                    course = "C2";
                    tuition_per_unit = 387.75;
                    reg_fee = 550.00;
                    misc_fee = 1050.35;
                    lab_fee = 1920.20;
                    break;

                case "0003":
                    course = "C3";
                    tuition_per_unit = 345.94;
                    reg_fee = 555.00;
                    misc_fee = 1100.25;
                    lab_fee = 1939.65;
                    break;

                case "0004":
                    course = "C4";
                    tuition_per_unit = 351.26;
                    reg_fee = 560.00;
                    misc_fee = 1150.15;
                    lab_fee = 1959.10;
                    break;

                case "0005":
                    course = "C5";
                    tuition_per_unit = 378.44;
                    reg_fee = 565.00;
                    misc_fee = 1200.05;
                    lab_fee = 1978.55;
                    break;

                case "0006":
                    course = "C6";
                    tuition_per_unit = 326.11;
                    reg_fee = 570.00;
                    misc_fee = 1249.05;
                    lab_fee = 1998.00;
                    break;

                case "0007":
                    course = "C7";
                    tuition_per_unit = 310.45;
                    reg_fee = 610.00;
                    misc_fee = 1299.85;
                    lab_fee = 2017.45;
                    break;

                case "0008":
                    course = "C8";
                    tuition_per_unit = 399.79;
                    reg_fee = 624.00;
                    misc_fee = 1349.75;
                    lab_fee = 2036.9;
                    break;
            }

            double total_tuition = unit_sum * tuition_per_unit;
            double overall_fee = total_tuition + reg_fee + misc_fee + lab_fee;
            double prelim = overall_fee * .53;
            double midterm = overall_fee * .64 - prelim;
            double semi_final = (overall_fee * .75) - (midterm + prelim);
            double final = overall_fee - (prelim + midterm + semi_final);
            var mop = (overall_fee >= 8000) ? "Cash" : (overall_fee >= 5000) ? "Check" : "Credit";

            data.Add(new
            {
                course_name = course,
                tuition_fee = tuition_per_unit,
                registration_fee = reg_fee,
                miscellaneous_fee = misc_fee,
                laboratory_fee = lab_fee,
                total_tuition_fee = total_tuition,
                total_fee = overall_fee,
                prelim_payment = prelim,
                midterm_payment = midterm,
                semi_final_payment = semi_final,
                final_payment = final,
                mode_of_payment = mop,
                total_unit = unit_sum
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}