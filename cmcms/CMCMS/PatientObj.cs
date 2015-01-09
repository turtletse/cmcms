using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class PatientObj : PermissibleValueObj
    {
        private int patientId; 
        private String chineseName;
        private String englishName;
        private String hashedPW;
        private String idDocType;
        private String idDocNo;
        private String phoneNo;
        private String dob;
        private String sex;
        private bool isG6PD;
        private String addr;
        private String allergicDrugIds;
        private bool isDeceased;
        private String deceasedRecordDtm;

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public String ChineseName
        {
            get { return chineseName; }
            set { chineseName = value; }
        }

        public String EnglishName
        {
            get { return englishName; }
            set { englishName = value; }
        }

        public String HashedPW
        {
            get { return hashedPW; }
            set { hashedPW = value; }
        }

        public String IdDocType
        {
            get { return idDocType; }
            set { idDocType = value; }
        }

        public String IdDocNo
        {
            get { return idDocNo; }
            set { idDocNo = value; }
        }

        public String PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        public String Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        public String Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public bool IsG6PD
        {
            get { return isG6PD; }
            set { isG6PD = value; }
        }

        public String Addr
        {
            get { return addr; }
            set { addr = value; }
        }

        public String AllergicDrugIds
        {
            get { return allergicDrugIds; }
            set { allergicDrugIds = value; }
        }

        public bool IsDeceased
        {
            get { return isDeceased; }
            set { isDeceased = value; }
        }

        public String DeceasedRecordDtm
        {
            get { return deceasedRecordDtm; }
            set { deceasedRecordDtm = value; }
        }

        public PatientObj(int patientId, String chineseName, String englishName, String hashedPW, String idDocType, String idDocNo, String phoneNo, String dob, String sex, bool isG6PD, String addr, String allergicDrugIds, bool isDeceased, String deceasedRecordDtm)
        {
            this.patientId = patientId;
            this.chineseName = chineseName;
            this.englishName = englishName;
            this.hashedPW = hashedPW;
            this.idDocType = idDocType;
            this.idDocNo = idDocNo;
            this.phoneNo = phoneNo;
            this.dob = dob;
            this.sex = sex;
            this.isG6PD = isG6PD;
            this.addr = addr;
            this.allergicDrugIds = allergicDrugIds;
            this.isDeceased = isDeceased;
            this.deceasedRecordDtm = deceasedRecordDtm;
        }
    }
}
