using Newtonsoft.Json;
using System.Text;

namespace WebApplication1.Models
{
    public class UserModel
    {
        #region Properties
        public int id { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool isBlock { get; set; }
        public int roleId { get; set; }
        public string role { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        #endregion

        #region Constructor
        public UserModel()
        {

        }
        public UserModel(int id, string email, string firstname, string middlename, string lastname, string phone, DateTime createdAt, bool is_locked, int roleId, string password)
        {
            this.id = id;
            this.email = email;
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.phone = phone;
            this.createdAt = this.createdAt;
            this.isBlock = is_locked;
            this.roleId = roleId;
            this.password = password;
        }
        #endregion
      
    }
}
