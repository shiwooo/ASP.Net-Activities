using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Application_Activity.Controllers
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
            var student_data = new List<object>();
            var course_code = Request["crsCode"];
            int subject = Convert.ToInt32(Request["subjCount"]);
            int unit_sum = subject * 3;
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
            double midterm = overall_fee * .64;
            double semi_final = overall_fee * .75;
            double final = overall_fee;

            /*ALTERNATIVE FORMULA IF LAHI ANG PASABOT*/
            /*double midterm = overall_fee * .64 - prelim;
            double semi_final = (overall_fee * .75) - (midterm + prelim);
            double final = overall_fee - (prelim + midterm + semi_final);*/

            student_data.Add(new
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
                total_unit = unit_sum
            });
            return Json(student_data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Assessment()
        {
            var assessment_data = new List<object>();
            double amt_tndrd = Convert.ToDouble(Request["amtTendered"]);
            double amt_tendered = amt_tndrd / 100;
            double pre_assessment = Convert.ToDouble(Request["prelimAssess"]);
            double midterm_assessment = Convert.ToDouble(Request["midtermAssess"]);
            double semifinal_assessment = Convert.ToDouble(Request["semifinalAssess"]);
            double final_assessment = Convert.ToDouble(Request["finalAssess"]);
            int ass_choice = Convert.ToInt32(Request["assessChoice"]);
            double change_amount = 0;
            double number = 0;

            switch (ass_choice)
            {
                case 1:
                {
                    change_amount = amt_tendered - pre_assessment;
                    number = pre_assessment;
                    break;
                }

                case 2:
                {
                    change_amount = amt_tendered - midterm_assessment;
                    number = midterm_assessment;
                    break;
                }
                    
                case 3:
                {
                    change_amount = amt_tendered - semifinal_assessment;
                    number = semifinal_assessment;
                    break;
                }
 
                case 4:
                {
                    change_amount = amt_tendered - final_assessment;
                    number = final_assessment;
                    break;
                }
            }

            string number_to_phrase = "";
            int thousands = (int)number / 1000;
            switch (thousands)
            {
                case 1: number_to_phrase += "One thousand "; break;
                case 2: number_to_phrase += "Two thousand "; break;
                case 3: number_to_phrase += "Three thousand "; break;
                case 4: number_to_phrase += "Four thousand "; break;
                case 5: number_to_phrase += "Five thousand "; break;
                case 6: number_to_phrase += "Six thousand "; break;
                case 7: number_to_phrase += "Seven thousand "; break;
                case 8: number_to_phrase += "Eight thousand "; break;
                case 9: number_to_phrase += "Nine thousand "; break;
                case 10: number_to_phrase += "Ten thousand "; break;
                case 11: number_to_phrase += "Eleven thousand "; break;
                case 12: number_to_phrase += "Twelve thousand "; break;
                case 13: number_to_phrase += "Thirteen thousand "; break;
                case 14: number_to_phrase += "Fourteen thousand "; break;
                case 15: number_to_phrase += "Fifteen thousand "; break;
                case 16: number_to_phrase += "Sixteen thousand "; break; 
            }

            int hundreds = (int)number % 1000 / 100;
            switch (hundreds)
            {
                case 1: number_to_phrase += "one hundred "; break;
                case 2: number_to_phrase += "two hundred "; break;
                case 3: number_to_phrase += "three hundred "; break;
                case 4: number_to_phrase += "four hundred "; break;
                case 5: number_to_phrase += "five hundred "; break;
                case 6: number_to_phrase += "six hundred "; break;
                case 7: number_to_phrase += "seven hundred "; break;
                case 8: number_to_phrase += "eight hundred "; break;
                case 9: number_to_phrase += "nine hundred "; break;
             
            }

            int tens = (int)number % 100 / 10;
            int ones = (int)number % 10;
            switch (tens)
            {
                case 1:
                {
                    switch (ones)
                    {
                        case 0: number_to_phrase += "ten "; break;
                        case 1: number_to_phrase += "eleven "; break;
                        case 2: number_to_phrase += "twelve "; break;
                        case 3: number_to_phrase += "thirteen "; break;
                        case 4: number_to_phrase += "fourteen "; break;
                        case 5: number_to_phrase += "fifteen "; break;
                        case 6: number_to_phrase += "sixteen "; break;
                        case 7: number_to_phrase += "seventeen "; break;
                        case 8: number_to_phrase += "eighteen "; break;
                        case 9: number_to_phrase += "nineteen "; break;
                    }
                    break;
                }
                case 2: number_to_phrase += "twenty "; break;
                case 3: number_to_phrase += "thirty "; break;
                case 4: number_to_phrase += "forty "; break;
                case 5: number_to_phrase += "fifty "; break;
                case 6: number_to_phrase += "sixty "; break;
                case 7: number_to_phrase += "seventy "; break;
                case 8: number_to_phrase += "eighty "; break;
                case 9: number_to_phrase += "ninety "; break;
            }

            if (tens != 1)
            {
                switch (ones)
                {
                    case 1: number_to_phrase += "one "; break;
                    case 2: number_to_phrase += "two "; break;
                    case 3: number_to_phrase += "three "; break;
                    case 4: number_to_phrase += "four "; break;
                    case 5: number_to_phrase += "five "; break;
                    case 6: number_to_phrase += "six "; break;
                    case 7: number_to_phrase += "seven "; break;
                    case 8: number_to_phrase += "eight "; break;
                    case 9: number_to_phrase += "nine "; break;
                }
            }

            double decimal_to_whole = number * 100;
            int tenths = (int)decimal_to_whole % 100 / 10;
            int hundreths = (int)decimal_to_whole % 10;
            switch (tenths)
            {
                case 0:
                {
                    switch (hundreths)
                    {
                        case 1: number_to_phrase += "and one cent."; break;
                        case 2: number_to_phrase += "and two cents."; break;
                        case 3: number_to_phrase += "and three cents."; break;
                        case 4: number_to_phrase += "and four cents."; break;
                        case 5: number_to_phrase += "and five cents."; break;
                        case 6: number_to_phrase += "and six cents."; break;
                        case 7: number_to_phrase += "and seven cents."; break;
                        case 8: number_to_phrase += "and eight cents."; break;
                        case 9: number_to_phrase += "and nine cents."; break;
                    }
                    break;
                }
                case 1:
                {
                    switch (hundreths)
                    {
                        case 0: number_to_phrase += "and ten cents."; break;
                        case 1: number_to_phrase += "and eleven cents."; break;
                        case 2: number_to_phrase += "and twelve cents."; break;
                        case 3: number_to_phrase += "and thirteen cents."; break;
                        case 4: number_to_phrase += "and fourteen cents."; break;
                        case 5: number_to_phrase += "and fifteen cents."; break;
                        case 6: number_to_phrase += "and sixteen cents."; break;
                        case 7: number_to_phrase += "and seventeen cents."; break;
                        case 8: number_to_phrase += "and eighteen cents."; break;
                        case 9: number_to_phrase += "and nineteen cents."; break;
                    }
                    break;
                }
                case 2: number_to_phrase += "and twenty "; break;
                case 3: number_to_phrase += "and thirty "; break;
                case 4: number_to_phrase += "and forty " ; break;
                case 5: number_to_phrase += "and fifty " ; break;
                case 6: number_to_phrase += "and sixty " ; break;
                case 7: number_to_phrase += "and seventy "; break;
                case 8: number_to_phrase += "and eighty "; break;
                case 9: number_to_phrase += "and ninety "; break;
            }

            if (tenths == 0 || tenths == 1)
                number_to_phrase += "";
            else
            {
                switch (hundreths)
                {
                    case 0: number_to_phrase += "cents."; break;
                    case 1: number_to_phrase += "one cents."; break;
                    case 2: number_to_phrase += "two cents."; break;
                    case 3: number_to_phrase += "three cents."; break;
                    case 4: number_to_phrase += "four cents."; break;
                    case 5: number_to_phrase += "five cents."; break;
                    case 6: number_to_phrase += "six cents."; break;
                    case 7: number_to_phrase += "seven cents."; break;
                    case 8: number_to_phrase += "eight cents."; break;
                    case 9: number_to_phrase += "nine cents."; break;
                }
            }

            assessment_data.Add(new
            {
                amount_tendered = amt_tendered,
                change = change_amount,
                phrase = number_to_phrase
            });
            return Json(assessment_data, JsonRequestBehavior.AllowGet);
        }
    }
}
