using RealIndianGuyOneToMany.Models;

namespace RealIndianGuyOneToMany.Dtos
{
    public class CustomerDtos
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public List<CustomerAddressesDtos> customerAddresses { get; set; }
    }
}
