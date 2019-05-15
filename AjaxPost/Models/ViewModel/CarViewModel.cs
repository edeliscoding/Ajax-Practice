using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxPost.Models.ViewModel
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public IList<Car> Cars{ get; set; }
    }
}