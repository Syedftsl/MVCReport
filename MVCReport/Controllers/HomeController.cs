using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using MVCReport.Models;

namespace MVCReport.Controllers
{
    public class HomeController : Controller
    {
        StudentInfoEntities db=new StudentInfoEntities();
        public ActionResult StudentInfo()
        {
            return View(db.Students.ToList());
        }

        public ActionResult Reports( string ReportType)
        {
            LocalReport localreport=new LocalReport();
            localreport.ReportPath = Server.MapPath("~/Reports/rptStudent.rdlc");
            ReportDataSource reportDataSource=new ReportDataSource();
            reportDataSource.Name = "StudentDataSet";
            reportDataSource.Value = db.Students.ToList();
            localreport.DataSources.Add(reportDataSource);
            string reportType = ReportType;
            string mineType;
            string encoding;
            string fileNameExtention;
            if (reportType=="Excel")
            {
                fileNameExtention = "xlsx";
            }
            else if (reportType == "PDF")
            {
                fileNameExtention = "pdf";
            }
            else if (reportType == "Word")
            {
                fileNameExtention = "docx";
            }
            else 
            {
                fileNameExtention = "jpg";
            }
            string[] streams;
            Warning[] warnings;
            byte[] renderByte;
            renderByte = localreport.Render(reportType, "", out mineType, out encoding, out fileNameExtention,
                out streams, out warnings);
            Response.AddHeader("content-disposition","attachment:filename=student_report."+fileNameExtention);
            return File(renderByte, fileNameExtention);
           
        }
    }
}