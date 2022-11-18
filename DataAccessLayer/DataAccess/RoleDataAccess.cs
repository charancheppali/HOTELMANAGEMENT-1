using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer;

namespace DataAccessLayer.DataAccess
{
    public class RoleDataAccess
    {
        HOTELMANAGEMENT1_Context _Context = new HOTELMANAGEMENT1_Context();
        public List<RoleModel> GetAllRoles()
        {
            List<tblRole> roleList = _Context.tblRoles.ToList();
            List<RoleModel> roleListBo = new List<RoleModel>();

            foreach(tblRole role in roleList)
            {
                RoleModel roleModel = new RoleModel()
                {
                    Id = role.Id,
                    //CODE = role.CODE,
                    Name = role.Name,
                    CREATEDDATE = role.CREATEDDATE,
                    CREATEDBY = role.CREATEDBY,
                    MODIFIEDDATE = role.MODIFIEDDATE,
                    MODIFIEDBY = role.MODIFIEDBY,
                    ISACTIVE = role.ISACTIVE
                };
                roleListBo.Add(roleModel);
            }
            return roleListBo;
        }
        public void AddRole(RoleModel tblRole)
        {
            tblRole role = new tblRole()
            {
                Name = tblRole.Name,
                CODE = tblRole.CODE,
                CREATEDDATE = tblRole.CREATEDDATE,
                CREATEDBY = tblRole.CREATEDBY,
                ISACTIVE = tblRole.ISACTIVE
            };
            _Context.tblRoles.Add(role);
            _Context.SaveChanges();
        }
        public RoleModel GetRoleModelById(int roleId)
        {
            tblRole tat = _Context.tblRoles.Where(x => x.Id == roleId).FirstOrDefault();

            RoleModel rm = new RoleModel()
            {
                Name = tat.Name,
                CREATEDDATE = tat.CREATEDDATE,
                CREATEDBY = tat.CREATEDBY,
                ISACTIVE = tat.ISACTIVE
            };
            return rm;
        }

        public void UpdateRole(RoleModel roleModel)
        {
            var role = _Context.tblRoles.Where(x => x.Id == roleModel.Id).FirstOrDefault();
            if (role != null)
            {
                role.Name = role.Name;
                role.MODIFIEDDATE = DateTime.Now;
                role.MODIFIEDBY = 1;
                role.ISACTIVE = true;
                _Context.SaveChanges();
            }
        }
        public void DeleteaRole(int RolrId)
        {
            var role = _Context.tblRoles.Where(x => x.Id == RolrId).FirstOrDefault();
            if (role != null)
            {
                role.MODIFIEDDATE = DateTime.Now;
                role.MODIFIEDBY = 1;
                role.ISACTIVE = false;
                _Context.SaveChanges();
            }
            //_Context.tblGenders.Remove(gender);
            _Context.SaveChanges();
        }
    }
}