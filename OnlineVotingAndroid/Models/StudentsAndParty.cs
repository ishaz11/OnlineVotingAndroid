using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class StudentsAndParty
    {
        public Students students { get; set; }
        public string party { get; set; }
        public int partyMemberID { get; set; }
    }
}