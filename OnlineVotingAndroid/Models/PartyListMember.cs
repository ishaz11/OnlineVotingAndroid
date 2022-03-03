using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class PartyListMember
    {
        [Key]
        public int Id { get; set; }

        public int? StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Students Students { get; set; }

        [Display(Name = "Is Officer")]
        public bool isOfficer { get; set; }
    }
}