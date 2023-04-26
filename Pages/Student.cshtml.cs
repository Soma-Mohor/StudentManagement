using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagement.Modal;
namespace StudentManagement.Pages
{
    public class StudentModel : PageModel
    {
        Student s = new Student();

        public IActionResult OnPost()
        {
            s.name = Request.Form["txtNm"];
            s.rollNumber = Int32.Parse(Request.Form["txtRoll"]);
            s.age = Int32.Parse(Request.Form["txtage"]);
            s.st_class = Int32.Parse(Request.Form["txtClass"]);
            s.eng = Int32.Parse(Request.Form["txtEng"]);
            s.maths = Int32.Parse(Request.Form["txtMath"]);
            s.sc = Int32.Parse(Request.Form["txtSc"]);

            s.total = s.eng + s.maths + s.sc;
            //s.avg = ((double)s.total) / 3.0;

            if (s.avg >= 90)
                s.grade = "A+";
            else if (s.avg >= 80)
                s.grade = "A";
            else if (s.avg >= 70)
                s.grade = "B";
            else if (s.avg >= 60)
                s.grade = "C";
            else if (s.avg >= 50)
                s.grade = "D";
            else
                s.grade = "FAIL";


            TextWriter tw = System.IO.File.AppendText("Student.txt");
            tw.Write(s.name + ",");
            tw.Write(s.rollNumber + ",");
            tw.Write(s.age + ",");
            tw.Write(s.st_class + ",");
            tw.Write(s.maths + ",");
            tw.Write(s.eng + ",");
            tw.Write(s.sc + ",");
            tw.Write(s.total + ",");
            tw.Write(s.avg + ",");
            tw.Write(s.grade + "\n");

            tw.Close();

            ViewData["success"] = "Data Added Successfully";
            ViewData["student"] = s;

            return new ViewResult()
            {
                ViewName = "ViewResult",
                ViewData = this.ViewData
            };

        }
    }
}
