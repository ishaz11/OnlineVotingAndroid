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

        [Display(Name = "Party List")]
        [Required(ErrorMessage = "Required")]
        public string PartyListName { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public bool isEnable { get; set; }


    }
}