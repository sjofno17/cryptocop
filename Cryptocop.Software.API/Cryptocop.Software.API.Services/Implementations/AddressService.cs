using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;

        public AddressService(IAddressRepository addressRepository, IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
        }
        public void AddAddress(string email, AddressInputModel address)
        {
            _addressRepository.AddAddress(email, address);
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            return _addressRepository.GetAllAddresses(email);
        }

        public void DeleteAddress(string email, int addressId)
        {
            _addressRepository.DeleteAddress(email, addressId);
        }
    }
}
