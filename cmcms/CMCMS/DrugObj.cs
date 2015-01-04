using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class DrugObj : PermissibleValueObj
    {
        private String minDoseVal {get; set;}
        private String minDoseUnit { get; set; }
        private String maxDoseVal { get; set; }
        private String maxDoseUnit { get; set; }
        private String priType { get; set; }
        private String secType { get; set; }
        private bool deleted { get; set; }
        private bool q1 { get; set; }
        private bool q2 { get; set; }
        private bool q3 { get; set; }
        private bool q4 { get; set; }
        private bool w1 { get; set; }
        private bool w2 { get; set; }
        private bool w3 { get; set; }
        private bool w4 { get; set; }
        private bool w5 { get; set; }
        private bool w6 { get; set; }
        private String pregContra { get; set; }
        private String g6pdContra { get; set; }

        public DrugObj(String name, String value, String minDoseVal, String minDoseUnit, String maxDoseVal, String maxDoseUnit, String priType, String secType, bool deleted, bool q1, bool q2, bool q3, bool q4, bool w1, bool w2, bool w3, bool w4, bool w5, bool w6, String pregContra, String g6pdContra) : base(name, value)
        {
            this.minDoseVal=minDoseVal;
            this.minDoseUnit=minDoseUnit;
            this.maxDoseVal=maxDoseVal;
            this.maxDoseUnit=maxDoseUnit;
            this.priType=priType;
            this.secType=secType;
            this.deleted=deleted;
            this.q1=q1;
            this.q2=q2;
            this.q3=q3;
            this.q4=q4;
            this.w1=w1;
            this.w2=w2;
            this.w3=w3;
            this.w4=w4;
            this.w5=w5;
            this.w6=w6;
            this.pregContra=pregContra;
            this.g6pdContra = g6pdContra;

        }

    }
}
