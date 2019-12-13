using System;
using UnityAddons.WorkView;

namespace UnityAddons.Tests.TestObjects
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
