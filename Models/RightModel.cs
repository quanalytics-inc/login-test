using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class RightModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Parent { get; set; }
        public bool Blocked { get; set; }

        #region Constructor
        public RightModel()
        {

        }
        public RightModel(int id, string name, int parent, bool blocked)
        {
            this.Blocked = blocked;
            Id = id;
            Name = name;
            Parent = parent;
        }
        #endregion

        #region Methods
        public static async Task<List<RightModel>> AllAsync()
        {
            List<RightModel>? rights = new List<RightModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Base.Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Base.token);
                    HttpResponseMessage Res = await client.GetAsync(Base.Baseurl2 + "/right");
                    if (Res.IsSuccessStatusCode)
                    {
                        var LResponse = Res.Content.ReadAsStringAsync().Result;
                        rights = JsonConvert.DeserializeObject<List<RightModel>>(LResponse);
                    }
                    else
                    {
                        return new List<RightModel>();
                    }
                }
            }
            catch
            {
                return new List<RightModel>();
            }

            return rights;
        }

        #endregion
    }
}
