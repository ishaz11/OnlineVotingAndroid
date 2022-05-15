using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class _CandidatesVoteCount
    {
        public Candidate candidate { get; set; }
        public string partyLists { get; set; }

        public int voteCount { get; set; }
    }
}