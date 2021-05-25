using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class ProductRepresentation
    {
        public ProductRepresentation(int productID, string name)
        {
            this.ProductID = productID;
            this.Name = name;
        }
        [JsonProperty(PropertyName = "productId")]
        public int ProductID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
