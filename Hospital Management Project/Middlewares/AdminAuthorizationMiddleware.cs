using HospitalSystem.Core.Enums; // Ensure this has UserRoles enum
using System.Security.Claims;

namespace Hospital_Management_Project.Middlewares
{
    public class AdminAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Check if the request is in the "Admin" area
            var area = context.GetRouteData()?.Values["area"]?.ToString();
            if (area != null && area.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                // Ensure the user is authenticated
                if (!context.User.Identity.IsAuthenticated)
                {
                    context.Response.Redirect("/Identity/Account/Login");
                    return;
                }

                // Check if the user has the Admin role based on the claims
                var userRoles = context.User.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value)
                    .ToList();

                var isAdmin = userRoles.Contains(UserRoles.Admin.ToString());

                // Return a 403 Forbidden response if the user is not an admin
                if (!isAdmin)
                {
                    context.Response.Redirect("/Identity/Account/AccessDenied");
                    return;
                }
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}
