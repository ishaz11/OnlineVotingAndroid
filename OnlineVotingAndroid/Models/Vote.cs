using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class Vote
    {
        [Key]
        [Display(Name = "Vote ID")]
        public int VoteID { get; set; }

        public int? StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Students Students { get; set; }

        public int? CandidateID { get; set; }
        [ForeignKey("CandidateID")]
        public virtual Candidate Candidates { get; set; }

        
        [Display(Name = "Date Voted")]
        public DateTime DateVoted { get; set; }

    }
}