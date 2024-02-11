using General.Domain.Enums.KsStad;

namespace General.Domain.DTO.Tengella.v2.Customer
{
    public class AddressDTO
    {
        public AddressDTO(KsAddressDTO ksAddress)
        {
            Street = ksAddress.Street;
            Street2 = ksAddress.Street2;
            ZipCode = ksAddress.ZipCode;
            City = ksAddress.City;
            if (ksAddress.AddressType == CustomerAddressTypeEnums.InvoiceAddress)
            {
                AddressType = 1;
                IsDefaultAddressforType = ksAddress.IsDefaultAddress;
            } else if (ksAddress.AddressType == CustomerAddressTypeEnums.WorkAddress)
            {
                AddressType = 4;
                IsDefaultAddressforType = ksAddress.IsDefaultAddress;
            } else if (ksAddress.AddressType == CustomerAddressTypeEnums.DeliveryAddress)
            {
                AddressType = 2;
                IsDefaultAddressforType = ksAddress.IsDefaultAddress;
            }
        }
        public int AddressType { get; set; }
        public bool IsDefaultAddressforType { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
