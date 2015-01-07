using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class DrugObj : PermissibleValueObj
    {
        private String minDoseVal;
        private String minDoseUnit;
        private String maxDoseVal;
        private String maxDoseUnit;
        private String priType;
        private String secType;
        private bool deleted;
        private bool q1;
        private bool q2;
        private bool q3;
        private bool q4;
        private bool w1;
        private bool w2;
        private bool w3;
        private bool w4;
        private bool w5;
        private bool w6;
        private String pregContra;
        private String g6pdContra;

        public String MinDoseVal
        {
            get { return minDoseVal; }
            private set { minDoseVal = value; }
        }
        
        public String MinDoseUnit
        {
            get { return minDoseUnit; }
            private set { minDoseUnit = value; }
        }

        public String MaxDoseVal
        {
            get { return maxDoseVal; }
            private set { maxDoseVal = value; }
        }

        public String MaxDoseUnit
        {
            get { return maxDoseUnit; }
            private set { maxDoseUnit = value; }
        }

        public String PriType
        {
            get { return priType; }
            private set { priType = value; }
        }

        public String SecType
        {
            get { return secType; }
            private set { secType = value; }
        }

        public bool Deleted
        {
            get { return deleted; }
            private set { deleted = value; }
        }

        public bool Q1
        {
            get { return q1; }
            private set { q1 = value; }
        }

        public bool Q2
        {
            get { return q2; }
            private set { q2 = value; }
        }

        public bool Q3
        {
            get { return q3; }
            private set { q3 = value; }
        }
        
        public bool Q4
        {
            get { return q4; }
            private set { q4 = value; }
        }

        public bool W1
        {
            get { return w1; }
            private set { w1 = value; }
        }
        
        public bool W2
        {
            get { return w2; }
            private set { w2 = value; }
        }

        public bool W3
        {
            get { return w3; }
            private set { w3 = value; }
        }

        public bool W4
        {
            get { return w4; }
            private set { w4 = value; }
        }

        public bool W5
        {
            get { return w5; }
            private set { w5 = value; }
        }

        public bool W6
        {
            get { return w6; }
            private set { w6 = value; }
        }

        public String PregContra
        {
            get { return pregContra; }
            private set { pregContra = value; }
        }

        public String G6pdContra
        {
            get { return g6pdContra; }
            private set { g6pdContra = value; }
        }

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
