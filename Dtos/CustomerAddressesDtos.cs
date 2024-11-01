using RealIndianGuyOneToMany.Models;

namespace RealIndianGuyOneToMany.Dtos
{
    public class CustomerAddressesDtos
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int CustomerId { get; set; }
    }
}
