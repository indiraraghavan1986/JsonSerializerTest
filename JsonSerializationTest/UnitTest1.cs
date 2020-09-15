using Newtonsoft.Json;
using System;
using Xunit;

namespace JsonSerializationTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var myObject = new TestModel()
            {
                Id = 1, FirstName = "Indira", LastName = "Raghavan", PhoneNumber = "111-111-1111"
            };

            var json = JsonConvert.SerializeObject(myObject);

            Assert.Equal(json.ToString(), allValuesPresentJson);

            myObject.FirstName = null;

            json = JsonConvert.SerializeObject(myObject);

            Assert.Equal(json.ToString(), nullValuesPresentJson);            
        }        

        [Fact()]
        public void AttributesSerializationTest()
        {
            var attributesObject = new TestModelWithJsonAttributes()
            {
                Id = 1,
                FirstName = null,
                LastName = "Raghavan",
                PhoneNumber = "111-111-1111"
            };

            var json = JsonConvert.SerializeObject(attributesObject);

            Assert.Equal(json.ToString(), ignoredPropertiesJson);


            json = JsonConvert.SerializeObject(attributesObject, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            
            Assert.Equal(json.ToString(), nullValuesIgnoredJson);
        }

        public string allValuesPresentJson = "{\"Id\":1,\"FirstName\":\"Indira\",\"LastName\":\"Raghavan\",\"PhoneNumber\":\"111-111-1111\"}";

        public string nullValuesPresentJson = "{\"Id\":1,\"FirstName\":null,\"LastName\":\"Raghavan\",\"PhoneNumber\":\"111-111-1111\"}";

        public string nullValuesIgnoredJson = "{\"Id\":1,\"LastName\":\"Raghavan\"}";

        public string ignoredPropertiesJson = "{\"Id\":1,\"FirstName\":null,\"LastName\":\"Raghavan\"}";
    }
}
