using System;
using System.ServiceModel.Web;


namespace WcfServiceLibrary1 {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1 {
        public string GetData(int value) {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "data/{id}")]
        public Person GetDataPerson(string id) {
            // lookup person with the requested id 
            return new Person() {
                Id = Convert.ToInt32(id),
                Name = "Leo Messi"
            };
        }


    }

    public class Person {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
