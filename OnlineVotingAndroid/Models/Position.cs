using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class Position
    {
        [Key]
        [Display(Name = "Position ID")]
        public int PositionId { get; set; }

        public int? ElectionID { get; set; }
        [ForeignKey("ElectionID")]
        public virtual Election Election { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Position")]
        public string PositionName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Count")]
        public int Count { get; set; }

    }
}