using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxPost.Models
{
    public class Car
    {
        public ApplicationUser Employee { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public List<Car> Cars { get; set; }
        //public ICollection<string> CarKeys { get; set; }
        //public string ListString
        //{
        //    get { return string.Join(",", Cars); }
        //    set { Cars = value.Split(',').ToList(); }
        //}
    }
}