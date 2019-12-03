using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PiDev.Domain.Entities;

namespace PiDev.web.Models
{
    public class Test
    {
        public int idTest { get; set; }

        public string descriptionTest { get; set; }

        public string titeTest { get; set; }


        public virtual formation formation { get; set; }

    }
}