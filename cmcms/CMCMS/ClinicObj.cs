using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class ClinicObj:PermissibleValueObj
    {
        private String clinicId;
        private String chineseName;
        private String englishName;
        private String addr;
        private String phoneNo;
        private bool isSuspended;

        public ClinicObj(String clinicId, String chineseName, String englishName, String addr, String phoneNo, bool isSuspended)
            : base(clinicId, clinicId)
        {
            this.clinicId = clinicId;
            this.chineseName = chineseName;
            this.englishName = englishName;
            this.addr = addr;
            this.phoneNo = phoneNo;
            this.isSuspended = isSuspended;
        }

        public ClinicObj()
        {
            // TODO: Complete member initialization
        }
        
        public bool IsSuspended
        {
            get { return isSuspended; }
            set { isSuspended = value; }
        }

        public String PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        public String Addr
        {
            get { return addr; }
            set { addr = value; }
        }

        public String EnglishName
        {
            get { return englishName; }
            set { englishName = value; }
        }

        public String ChineseName
        {
            get { return chineseName; }
            set { chineseName = value; }
        }

        public String ClinicId
        {
            get { return clinicId; }
            set { clinicId = value; }
        }
    }
}
