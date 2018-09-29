using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Models
{
    public class UploadAdViewModel : UploadPostViewModel
    {
        public string Language { get; set; }

        public string Age { get; set; }

        public string Sex { get; set; }

        public string Countries { get; set; }
    }
}