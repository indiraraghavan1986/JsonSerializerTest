using System;
using System.Collections.Generic;
using System.Text;

namespace JsonSerializationTest
{
    public class TestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class TestModelWithJsonAttributes
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public string PhoneNumber { get; set; }
    }
}
