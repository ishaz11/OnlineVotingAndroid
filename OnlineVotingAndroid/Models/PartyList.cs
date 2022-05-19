using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class PartyList
    {
        [Key]
        public int PartyListID { get; set; }

        [Display(Name = "Partylist Name")]
        [Required(ErrorMessage = "Required")]
        public string PartyListName { get; set; }

        [Display(Name = "Is Active")]

        public string Platform1 { get; set; }
        public string Platform2 { get; set; }
        public string Platform3 { get; set; }
        public string Platform4 { get; set; }
        public string Platform { get; set; }
        public string Platform6 { get; set; }

        public bool IsActive { get; set; }

        public bool isEnable { get; set; }


    }
}