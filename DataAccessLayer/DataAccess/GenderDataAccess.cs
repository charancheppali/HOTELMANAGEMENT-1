using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess.DataAccessLayer;
using DataAccessLayer;

namespace DataAccess.DataAccessLayer
{
    public class GenderDataAccess
    {
        HOTELMANAGEMENT1_Context _Context = new HOTELMANAGEMENT1_Context();

        public List<GenderModel> GetAllGenders()
        {
            List<tblGender> genderList = _Context.tblGenders.ToList();
            List<GenderModel> genderListBo = new List<GenderModel>();

            foreach (tblGender gen in genderList)
            {
                GenderModel genModel = new GenderModel
                {
                    Id = gen.Id,
                    Name = gen.Name,
                    ISACTIVE = gen.ISACTIVE
                };
                genderListBo.Add(genModel);
            }

            return genderListBo;
        }

        public void AddGender(GenderModel tblGender)
        {
            //tblGender gender = new tblGender();
            //gender.Name = tblGender.Name;
            //gender.CREATEDDATE = tblGender.CREATEDDATE;
            //gender.CREATEDBY = tblGender.CREATEDBY;
            //gender.ISACTIVE = tblGender.ISACTIVE;

            tblGender gender = new tblGender()
            {
                Name = tblGender.Name,
                CREATEDDATE = tblGender.CREATEDDATE,
                CREATEDBY = tblGender.CREATEDBY,
                ISACTIVE = tblGender.ISACTIVE
            };
            _Context.tblGenders.Add(gender);
            _Context.SaveChanges();
        }
        public GenderModel GetGenderById(int genderId)
        {
            tblGender gender = _Context.tblGenders.Where(x => x.Id == genderId).FirstOrDefault();

            GenderModel genderModel = new GenderModel()
            {
                Name = gender.Name,
                CREATEDDATE = gender.CREATEDDATE,
                CREATEDBY = gender.CREATEDBY,
                ISACTIVE = gender.ISACTIVE
            };
            return genderModel;
        }

        public void UpdateGender(GenderModel genderModel)
        {
            var gender = _Context.tblGenders.Where(x => x.Id == genderModel.Id).FirstOrDefault();
            if (gender != null)
            {
                gender.Name = genderModel.Name;
                gender.MODIFIEDDATE = DateTime.Now;
                gender.MODIFIEDBY = 1;
                gender.ISACTIVE = true;
                _Context.SaveChanges();
            }
        }

        public void DeleteGender(int genderId)
        {
            var gender = _Context.tblGenders.Where(x => x.Id == genderId).FirstOrDefault();
            if (gender != null)
            {
                gender.MODIFIEDDATE = DateTime.Now;
                gender.MODIFIEDBY = 1;
                gender.ISACTIVE = false;
                _Context.SaveChanges();
            }
            //_Context.tblGenders.Remove(gender);
            _Context.SaveChanges();
        }
    }
}
