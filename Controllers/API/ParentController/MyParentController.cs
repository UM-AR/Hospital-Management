using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace V1.Login.Controllers.API
{
    public class MyParentController : ControllerBase
    {
        public int TokenUserID
        {
            get
            {

                var userData = GetDataFromClaim("UserId");
                if (!string.IsNullOrEmpty(userData))
                {
                    return Convert.ToInt32(userData);
                }
                return 0;

            }
        }
        public string TokenUserName
        {
            get
            {

                var userData = GetDataFromClaim("Email");
                if (!string.IsNullOrEmpty(userData))
                {
                    return (userData);
                }
                return string.Empty;

            }
        }
        private string GetDataFromClaim(string ClaimProperty)
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var claim = identity.FindFirst(ClaimProperty);
                return claim?.Value ?? "";
            }
            return string.Empty;
        }

    }
}
