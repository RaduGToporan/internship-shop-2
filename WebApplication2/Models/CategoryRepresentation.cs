using Newtonsoft.Json;

namespace WebApplication2.Models
{
    public class CategoryRepresentation
    {
        public CategoryRepresentation(int categoryID, string name)
        {
            this.CategoryID = categoryID;
            this.Name = name;
        }

        [JsonProperty(PropertyName = "categoryId")]
        public int CategoryID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
