using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models.APIModels
{
    public class _StudentChangePass
    {
        public string StudentSchoolID { get; set; }
        public string Password { get; set; }

        public string NewPassword { get; set; }

    }
}