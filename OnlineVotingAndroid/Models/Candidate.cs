using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class Candidate
    {
        [Key]
        [Display(Name = "Candidate ID")]
        public int CandidateID { get; set; }

        public int? PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

        public int? StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Students Students { get; set; }


    }
}