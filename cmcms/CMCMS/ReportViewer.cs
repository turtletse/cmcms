using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CMCMS
{
    public partial class ReportViewer : Form
    {
        String rptName = "";

        ReportDocument crRpt = new ReportDocument();
        ParameterFieldDefinitions crParameterFieldDefinitions ;
        ParameterFieldDefinition crParameterFieldDefinition ;
        ParameterValues crParameterValues = new ParameterValues();
        ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

        public ReportViewer()
        {
            InitializeComponent();
        }

        private void setRptName(String rptName)
        {
            this.rptName = rptName;
        }

        public void preparePrescription(String consId)
        {
            setRptName("Prescription.rpt");
            crRpt.Load(rptName);
            
            crParameterDiscreteValue.Value = consId;
            crParameterFieldDefinitions = crRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["in_cons_id"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        public void prepareSickLeaveCert(int sickLeaveCertId)
        {
            setRptName("SickLeaveCert.rpt");
            crRpt.Load(rptName);

            crParameterDiscreteValue.Value = sickLeaveCertId;
            crParameterFieldDefinitions = crRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["in_cert_id"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        public void preparePregCert(int pregCertId)
        {
            setRptName("PregCert.rpt");
            crRpt.Load(rptName);

            crParameterDiscreteValue.Value = pregCertId;
            crParameterFieldDefinitions = crRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["in_cert_id"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        public void prepareConsultationCert(int consId)
        {
            setRptName("ConsultationCert.rpt");
            crRpt.Load(rptName);

            crParameterDiscreteValue.Value = consId;
            crParameterFieldDefinitions = crRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["in_cons_id"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        public void prepareConsultationHistory(int patId, int consId)
        {
            setRptName("ConsultationHistory.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_pat_id", patId);
            crRpt.SetParameterValue("in_cons_id", consId);
        }

        public void prepareMedicalReport(String clinicId, int patId, int consId)
        {
            setRptName("FullMedicalRecord.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_clinic_id", clinicId);
            crRpt.SetParameterValue("in_pat_id", patId);
            crRpt.SetParameterValue("in_cons_id", consId);
        }

        public void prepareClinicConsStatByDay30(String clinicId)
        {
            setRptName("ClinicConsCntByDay.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_clinic_id", clinicId);
        }

        public void prepareLast30DaysDxStat(String clinicId)
        {
            setRptName("Last30DaysDxStat.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_clinic_id", clinicId);
        }

        public void prepareSuspiciousPresList(String clinicId)
        {
            setRptName("SuspiciousPresListing.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_clinic_id", clinicId);
        }

        public void prepareUserListing(String clinicId)
        {
            setRptName("UserListing.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_clinic_id", clinicId);
        }

        public void prepareClinicListing(String clinicId)
        {
            setRptName("ClinicListing.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_clinic_id", clinicId);
        }

        public void prepareDrugListing(String clinicId)
        {
            setRptName("DrugListing.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_clinic_id", clinicId);
        }

        public void preparePatientListing(String clinicId, String userId)
        {
            setRptName("patientListing.rpt");
            crRpt.Load(rptName);

            crRpt.SetParameterValue("in_clinic_id", clinicId);
            crRpt.SetParameterValue("in_user_id", userId);
        }

        private void ReportViewer_Shown(object sender, EventArgs e)
        {
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = CMCMS.Properties.Resources.server + " DRIVER={MySQL ODBC 5.3 Unicode Driver}; DSN=CMCMS;";
            crConnectionInfo.DatabaseName = "cmcms";
            crConnectionInfo.UserID = "cmcms";
            crConnectionInfo.Password = "abc3###2015A";
            TableLogOnInfo crTableLogoninfo = new TableLogOnInfo();

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in crRpt.Database.Tables)
            {
                crTableLogoninfo = CrTable.LogOnInfo;
                crTableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crTableLogoninfo);
            }
            foreach (ReportDocument subreport in crRpt.Subreports)
            {
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in subreport.Database.Tables)
                {
                    crTableLogoninfo = CrTable.LogOnInfo;
                    crTableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crTableLogoninfo);
                }
            }

            crystalReportViewer1.ReportSource = crRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
