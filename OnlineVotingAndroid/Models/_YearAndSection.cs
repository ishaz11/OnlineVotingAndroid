using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class _YearAndSection
    {
        [Key]
        public int YearAndSectionID { get; set; }
        public string Grade { get; set; }
    }
}