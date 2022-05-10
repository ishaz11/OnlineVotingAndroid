using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models.APIModels
{
    public class CandidatesAPI
    {
        public int CandidateID { get; set; }

        public string PartyListName { get; set; }

        public int? StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}