using Microsoft.AspNetCore.Authorization;

namespace PropertyRenting.Membership.BusinessObject
{
    public class CommonPermissionRequirement : IAuthorizationRequirement
    {
        public CommonPermissionRequirement()
        {
        }
    }
}