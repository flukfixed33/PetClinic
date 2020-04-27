using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using PetClinic.Models;


namespace PetClinic.Reports
{
    public partial class WebFormPets : System.Web.UI.Page
    {
        private PetClinicEntities db = new PetClinicEntities();
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack) {
                List<View_1> view = null;
                using(PetClinicEntities dc = new PetClinicEntities())
                {
                    view = dc.View_1.OrderBy(a => a.Pet_ID).ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc") ;
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("DataSet1", view);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                    ReportViewer1.LocalReport.Refresh();


                }

                





            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tt = TextBox1.Text;
            List<PetClinic.Models.View_1> view = null;
            using (PetClinic.Models.PetClinicEntities dc = new PetClinic.Models.PetClinicEntities())
            {
                view = dc.View_1.Where(a => a.Pet_Name == tt).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("DataSet1", view);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();


            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<View_1> view = null;
            using (PetClinicEntities dc = new PetClinicEntities())
            {
                view = dc.View_1.OrderBy(a => a.Pet_ID).ToList();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("DataSet1", view);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();


            }
        }
    }
}