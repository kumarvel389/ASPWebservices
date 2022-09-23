using System.ComponentModel.DataAnnotations;

namespace ASPWeb.API.Models.Domain
{
    public class Case
    {

        [Key]
        public Guid GlobalID { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

    }
}
