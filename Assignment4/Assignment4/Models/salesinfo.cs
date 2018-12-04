using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Assignment4.Models
{
    public class salesinfo
    {

        public int _id { get; set; }
        [DisplayName("Name")]
        public string _name { get; set; }
        [DisplayName("Contact No")]
        public string _contact_no { get; set; }
        [DisplayName("Contact Email")]
        public string _contact_email { get; set; }
        [DisplayName("Address")]
        public string _address { get; set; }
        [DisplayName("City")]
        public string _city { get; set; }
        [DisplayName("Car Model")]
        public string _car_model { get; set; }
        [DisplayName("Car Make")]
        public string _car_make { get; set; }
        [DisplayName("Car Year")]
        public string _car_year { get; set; }
    }
}