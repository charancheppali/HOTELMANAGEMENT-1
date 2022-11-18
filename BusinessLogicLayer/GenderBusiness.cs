using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess.DataAccessLayer;

namespace BusinessLogicLayer
{
    public class GenderBusiness
    {
        GenderDataAccess gda = new GenderDataAccess();
        public List<GenderModel> GetAllGenders()
        {
            return gda.GetAllGenders();
        }
        public void AddGender(GenderModel tblGender)
        {
            gda.AddGender(tblGender);
        }
        public GenderModel GetGenderById(int genderId)
        {
            return gda.GetGenderById(genderId);
        }
        public void UpdateGender(GenderModel tblgender)
        {
            gda.UpdateGender(tblgender);
        }
        public void DeleteGender(int genderId)
        {
            gda.DeleteGender(genderId);
        }
    }
}
