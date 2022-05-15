using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models.APIModels
{
    public class APIVotes
    {
        public int VoteID { get; set; }

        public int? StudentID { get; set; }

        public int? CandidateID { get; set; }

        public int? ElectionID { get; set; }


        public DateTime DateVoted { get; set; }
    }
}