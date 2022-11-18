using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessLayer.DataAccess;

namespace BusinessLogicLayer
{
    public class RoleBussiness
    {
        RoleDataAccess rda = new RoleDataAccess();
        public List<RoleModel> GetAllRoles()
        {
            return rda.GetAllRoles();
        }
        public void AddRole(RoleModel roleModel)
        {
            rda.AddRole(roleModel);
        }
        public RoleModel GetRoleModelById(int roleId)
        {
            return rda.GetRoleModelById(roleId);
        }
        public void UpdateRole(RoleModel roleModel)
        {
            rda.UpdateRole(roleModel);
        }
        public void DeleteRole(int RolrId)
        {
            rda.DeleteaRole(RolrId);
        }
    }
}
