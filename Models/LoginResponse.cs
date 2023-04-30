namespace WebApplication1.Models
{
    public class LoginResponse
    {
        #region Properties
        public bool Success { get; set; }
        public string Message { get; set; }
        public int status { get; set; }
        public LoginUser data { get; set; }
        #endregion

        public LoginResponse()
        {

        }
    }
}
