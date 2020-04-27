using PetClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data.Entity;

namespace PetClinic.Reports
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private PetClinicEntities db = new PetClinicEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                var Sales = new List<View_visit>();
                Sales = db.View_visit.ToList();

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report3.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource reportDataSource = new ReportDataSource("DataSet2", Sales);
                ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var Sales = new List<View_visit>();
            var time = Convert.ToDateTime(TextBox1.Text);
            Sales = db.View_visit.Where(a => DbFunctions.TruncateTime(a.VisitDate) == DbFunctions.TruncateTime(time)).ToList();

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report3.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet2", Sales);
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var Sales = new List<View_visit>();
            Sales = db.View_visit.ToList();

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report3.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource = new ReportDataSource("DataSet2", Sales);
            ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}