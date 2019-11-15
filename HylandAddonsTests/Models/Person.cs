using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HylandAddons.WorkView;

namespace HylandAddonsTests
{
    public class Person
    {
        [WorkViewAttribute]
        public string Name { get; set; }

        [WorkViewAttribute(Address = "Parent.Age")]
        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        [WorkViewAttribute(optional: true)]
        public string BestfriendName { get; set; }
    }
}
