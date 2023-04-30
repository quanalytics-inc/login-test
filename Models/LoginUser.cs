using Newtonsoft.Json;
using System.Text;

namespace WebApplication1.Models
{
    public class LoginUser
    {
        #region Properties
        public int id { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string token { get; set; }
        public bool isBlock { get; set; }
        public List<RightModel> rights { get; set; }
        public int passwordChanged { get; set; }
        public DateTime passwordChangedAt { get; set; }
        #endregion

        #region Constructor
        public LoginUser()
        {

        }

        public static async Task<LoginResponse> getLoginAsync(Login model)
        {
            LoginResponse? loginResponse = new LoginResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();
                    var json = JsonConvert.SerializeObject(model);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var url = Base.Baseurl2 + "/ddr/Auth/login";
                    HttpResponseMessage Res = await client.PostAsync(url, data);
                    if (Res.IsSuccessStatusCode)
                    {
                        var LResponse = Res.Content.ReadAsStringAsync().Result;
                        loginResponse = JsonConvert.DeserializeObject<LoginResponse>(LResponse);

                    }
                    else
                    {
                        var LResponse = Res.Content.ReadAsStringAsync().Result;
                        loginResponse = JsonConvert.DeserializeObject<LoginResponse>(LResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            return loginResponse;
        }

        public LoginUser(int id, string email, string name, string phone, string token, bool isBlock)
        {
            this.id = id;
            this.email = email;
            this.name = name;
            this.phone = phone;
            this.isBlock = isBlock;
            this.token = token;
        }
        #endregion
    }



    public class Login
    {
        public string email { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
    }

}
