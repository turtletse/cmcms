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

        ReportDocument cryRpt = new ReportDocument();
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
            cryRpt.Load(rptName);

            crParameterDiscreteValue.Value = consId;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["in_cons_id"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;

            crParameterValues.Clear();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);
        }

        private void ReportViewer_Shown(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cryRpt;
            crystalReportViewer1.Refresh();
        }
    }
}
