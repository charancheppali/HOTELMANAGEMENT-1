using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer.DataAccess;

namespace BusinessLogicLayer
{
    public class AddressTypeBusiness
    {
        AddressTypeDataAccess atd = new AddressTypeDataAccess();
        public List<AddressTypeModel> GetAllAddressTypes()
        {
            return atd.GetAllAddressTypes();
        }
        public void AddAddressType(AddressTypeModel tblAddressType)
        {
            atd.AddAddressType(tblAddressType);
        }
        public AddressTypeModel GetAddressTypeById(int addressTypeId)
        {
            return atd.GetAddressTypeById(addressTypeId);
        }
        public void UpdateAddressType(AddressTypeModel addressTypeModel)
        {
            atd.UpdateAddressType(addressTypeModel);
        }
        public void DeleteAddressType(int AddressTypeId)
        {
            atd.DeleteAddressType(AddressTypeId);
        }
    }
}
