using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVotingAndroid.Models
{
    public class StudentPhoto
    {
        public int StudentPhotoID { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
        public Students Students { get; set; }
    }
}