using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCMS
{
    public class UserObj :PermissibleValueObj
    {
        private String userId;
        private String hashedPw;
        private String chineseName;
        private String englishName;
        private String regNo;
        private String lastLogoutDtm;
        private String lastLogoutClinicId;
        private int currentLoginRole;
        private String currentLoginClinicId;

        public UserObj(String userId, String hashedPw, String chineseName, String englishName, String regNo, String lastLogoutDtm, String lastLogoutClinicId, int currentLoginRole, String currentLoginClinicId)
            : base(userId + " " + chineseName, userId)
        {
            this.userId = userId;
            this.hashedPw = hashedPw;
            this.chineseName = chineseName;
            this.englishName = englishName;
            this.regNo = regNo;
            this.lastLogoutDtm = lastLogoutDtm;
            this.lastLogoutClinicId = lastLogoutClinicId;
            this.currentLoginRole = currentLoginRole;
            this.currentLoginClinicId = currentLoginClinicId;
        }

        public String CurrentLoginClinicId
        {
            get { return currentLoginClinicId; }
            set { currentLoginClinicId = value; }
        }

        public int CurrentLoginRole
        {
            get { return currentLoginRole; }
            set { currentLoginRole = value; }
        }

        public String LastLogoutClinicId
        {
            get { return lastLogoutClinicId; }
            set { lastLogoutClinicId = value; }
        }

        public String LastLogoutDtm
        {
            get { return lastLogoutDtm; }
            set { lastLogoutDtm = value; }
        }

        public String RegNo
        {
            get { return regNo; }
            set { regNo = value; }
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

        public String HashedPw
        {
            get { return hashedPw; }
            set { hashedPw = value; }
        }

        public String UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
