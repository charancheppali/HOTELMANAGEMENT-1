using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessLayer.DataAccess
{
    public class AddressTypeDataAccess
    {
        HOTELMANAGEMENT1_Context _Context = new HOTELMANAGEMENT1_Context();
        public List<AddressTypeModel> GetAllAddressTypes()
        {
            List<tblAddressType> addressTypesList = _Context.tblAddressTypes.ToList();
            List<AddressTypeModel> addressTypesListBo = new List<AddressTypeModel>();

            foreach(tblAddressType addressType in addressTypesList)
            {
                AddressTypeModel addressTypeModel = new AddressTypeModel
                {
                    Id = addressType.Id,
                    Name = addressType.Name,
                    CREATEDDATE = addressType.CREATEDDATE,
                    CREATEDBY = addressType.CREATEDBY,
                    MODIFIEDDATE = addressType.MODIFIEDDATE,
                    MODIFIEDBY = addressType.MODIFIEDBY,
                    ISACTIVE = addressType.ISACTIVE
                };
                addressTypesListBo.Add(addressTypeModel);
            }
            return addressTypesListBo;
        }
        public void AddAddressType(AddressTypeModel tblAddressType)
        {
            tblAddressType addressType = new tblAddressType()
            {
                Name = tblAddressType.Name,
                CREATEDDATE = tblAddressType.CREATEDDATE,
                CREATEDBY = tblAddressType.CREATEDBY,
                ISACTIVE = tblAddressType.ISACTIVE
            };
            _Context.tblAddressTypes.Add(addressType);
            _Context.SaveChanges();
        }
        public AddressTypeModel GetAddressTypeById(int addressTypeId)
        {
            tblAddressType tat = _Context.tblAddressTypes.Where(x => x.Id == addressTypeId).FirstOrDefault();

            AddressTypeModel atm = new AddressTypeModel()
            {
                Name = tat.Name,
                CREATEDDATE = tat.CREATEDDATE,
                CREATEDBY = tat.CREATEDBY,
                ISACTIVE = tat.ISACTIVE
            };
            return atm;
        }

        public void UpdateAddressType(AddressTypeModel addressTypeModel)
        {
            var addressType = _Context.tblAddressTypes.Where(x => x.Id == addressTypeModel.Id).FirstOrDefault();
            if (addressType != null)
            {
                addressType.Name = addressType.Name;
                addressType.MODIFIEDDATE = DateTime.Now;
                addressType.MODIFIEDBY = 1;
                addressType.ISACTIVE = true;
                _Context.SaveChanges();
            }
        }
        public void DeleteAddressType(int AddressTypeId)
        {
            var addressType = _Context.tblAddressTypes.Where(x => x.Id == AddressTypeId).FirstOrDefault();
            if (addressType != null)
            {
                addressType.MODIFIEDDATE = DateTime.Now;
                addressType.MODIFIEDBY = 1;
                addressType.ISACTIVE = false;
                _Context.SaveChanges();
            }
            //_Context.tblGenders.Remove(gender);
            _Context.SaveChanges();
        }
    }
}
