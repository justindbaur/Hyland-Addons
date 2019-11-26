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

        [WorkViewAttribute("Parent.Age")]
        public int Age { get; set; }

        public DateTime Birthday { get; set; }

        [WorkViewAttribute(Modifiers = WorkViewAttributeModifiers.Optional)]
        public string BestfriendName { get; set; }
    }
}
