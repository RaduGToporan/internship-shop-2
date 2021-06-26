using Newtonsoft.Json;
using WebApplication2.Domain;

namespace WebApplication2.Models
{
    public class CategoryRepresentation : BaseRepresentation
    {
        public CategoryRepresentation()
        {
           
        }
        public CategoryRepresentation(Category category)
        {
            CategoryID = category.CategoryID;
            Name = category.Name;
        }

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
