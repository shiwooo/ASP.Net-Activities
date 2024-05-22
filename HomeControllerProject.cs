using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\source\repos\CRUD\CRUD\App_Data\Database1.mdf;Integrated Security=True";

        public ActionResult CreateStudentAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudentAccount(FormCollection collection, HttpPostedFileBase img)
        {
            string imag = null;
            if (img != null)
            {
                imag = Path.GetFileName(img.FileName);
                string extension = Path.GetExtension(img.FileName).ToLower();
                int filesize = img.ContentLength;

                string logpath = @"C:\Users\User\Desktop\Uploads";
                string filepath = Path.Combine(logpath, imag);
                img.SaveAs(filepath);
            }

            var lname = collection["lastname"];
            var fname = collection["firstname"];
            var address = collection["address"];

            using (var db = new SqlConnection(connStr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO STUDENT(LASTNAME, FIRSTNAME, ADDRESS, PROFILEPIC)"
                                    + "VALUES (@lastname, @firstname, @address, @file)";
                    cmd.Parameters.AddWithValue("@lastname", lname);
                    cmd.Parameters.AddWithValue("@firstname", fname);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@file", (object)imag ?? DBNull.Value);

                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        Response.Write("<script>alert('Student account is created')</script>");
                    }
                }
            }

            return View();
        }


        public ActionResult viewStudent()
        {
            if (Request["display"] != null)
            {
                var id = Request["studId"];
                using (var db = new SqlConnection(connStr))
                {
                    db.Open();
                    using (var cmd = db.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT * FROM STUDENT WHERE ID='" + id + "'";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var name = reader["PROFILEPIC"];
                                ViewData["studPic"] = name;
                                ViewData["studLastname"] = reader["LASTNAME"];
                                ViewData["studFirstname"] = reader["FIRSTNAME"];
                                ViewData["studAddress"] = reader["ADDRESS"];

                            }
                            else
                            {
                                Response.Write("<script>alert('No Records Found!')</script>");
                            }
                        }

                    }
                }
            }
            return View();
        }

        public ActionResult ViewList()
        {
            var students = new List<Dictionary<string, object>>();

            using (var db = new SqlConnection(connStr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM STUDENT";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var student = new Dictionary<string, object>
                    {
                        { "ID", reader["ID"] },
                        { "PROFILEPIC", reader["PROFILEPIC"] },
                        { "LASTNAME", reader["LASTNAME"] },
                        { "FIRSTNAME", reader["FIRSTNAME"] },
                        { "ADDRESS", reader["ADDRESS"] }
                    };
                            students.Add(student);
                        }
                    }
                }
            }

            ViewData["students"] = students;
            return View();
        }


        public ActionResult Image(string filename)
        {
            var folder = @"C:\Users\User\Desktop\Uploads";
            var filepath = Path.Combine(folder, filename);

            if (!System.IO.File.Exists(filepath))
            {
                return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "image/jpeg");
        }

/////////////////////search student

 public ActionResult SearchStudent()
        {
            var data = new List<object>();
            var id = Request["idno"];
            using (var db = new SqlConnection(connStr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = " SELECT * FROM STUDENT "
                                    + " WHERE ID ='" + id + "'";
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        data.Add(new
                        {
                            mess = 0,
                            lastname = reader["LASTNAME"].ToString(),
                            firstname = reader["FIRSTNAME"].ToString(),
                            address = reader["ADDRESS"].ToString()
                        });
                    }
                    else
                    {
                        data.Add(new
                        {
                            mess = 1
                        });
                    }

                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        //////////////////update
        public ActionResult StudentUpdate()
        {
            var data = new List<object>();
            var idno = Request["idno"];
            var lname = Request["lname"];
            var fname = Request["fname"];
            var address = Request["address"];

            using (var db = new SqlConnection(connStr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE STUDENT SET "
                                    + " LASTNAME = @lname, "
                                    + " FIRSTNAME = @fname, "
                                    + " ADDRESS = @address "
                                    + " WHERE ID='" + idno + "'";
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@address", address);
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        data.Add(new
                        {
                            mess = 0

                        });
                    }
                }
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        ///////////////delete
        public ActionResult StudentDelete()
        {
            var data = new List<object>();
            var idno = Request["idno"];
            using (var db = new SqlConnection(connStr))
            {
                db.Open();
                using (var cmd = db.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM STUDENT WHERE ID='" + idno + "'";
                    var ctr = cmd.ExecuteNonQuery();
                    if (ctr > 0)
                    {
                        data.Add(new
                        {
                            mess = 0
                        });
                    }

                }

            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
