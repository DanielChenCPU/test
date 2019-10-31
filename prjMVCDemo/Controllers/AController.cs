using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjMVCDemo.Controllers
{
    public class AController : Controller
    {
        // GET: A
        public string Randm496()
        {
            int[] OpenNum1 = new int[6];
            Random OpenNumOne = new Random();
            string str = "";

            for (int i = 0; i < 6; i++)
            {
                int ON1 = OpenNumOne.Next(1, 50);

                while (OpenNum1.Contains(ON1))
                {
                    ON1 = OpenNumOne.Next(1, 50);
                }

                OpenNum1[i] = ON1;                

            }

            Array.Sort(OpenNum1);

            foreach (int t in OpenNum1)
            {
                str += " "+ t.ToString();
            }


            return str;

        }


        public string getCustomerInfo(int? fId)
        {
            ftest c = (new dbDemoDataContext()).ftest.FirstOrDefault(t => t.fid == fId);
            if (c == null)
                return "沒有任何資料";
            return c.fName + "<br/>" + c.fPhone + " / " + c.fEmail;




        }
        public ActionResult getCustomerInfoWithPic(int? fId)
        {
            ftest c = (new dbDemoDataContext()).ftest.FirstOrDefault(t => t.fid == fId);
            ViewBag.NameInfo = "沒有任何資料";
            if (c != null)
                ViewBag.NameInfo = c.fName;

            return View();
        }
    }
}