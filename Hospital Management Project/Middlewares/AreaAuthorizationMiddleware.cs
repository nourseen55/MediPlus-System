namespace Hospital_Management_Project.Middlewares
{
    public class AreaAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AreaAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Get the area from route data
            var area = context.GetRouteData()?.Values["area"]?.ToString();

            // If area is null or empty, skip authorization checks
            if (string.IsNullOrEmpty(area) || area.Equals("Identity", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }

            if (!context.User.Identity?.IsAuthenticated ?? false)
            {
                context.Response.Redirect("/Identity/Account/Login");
                return;
            }

            // Get user roles from claims
            var userRoles = context.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            // Validate user roles based on the area
            if (!IsUserAuthorizedForArea(userRoles, area.ToLower()))
            {
                context.Response.Redirect("/Identity/Account/AccessDenied");
                return;
            }

            await _next(context);
        }

        private bool IsUserAuthorizedForArea(IEnumerable<string> userRoles, string area)
        {
            return area switch
            {
                "admin" => userRoles.Contains(UserRoles.Admin.ToString()),
                "doctor" => userRoles.Contains(UserRoles.Doctor.ToString()),
                "patient" => userRoles.Contains(UserRoles.Patient.ToString()),
                "nurse" => userRoles.Contains(UserRoles.Nurse.ToString()),
                _ => true 
            };
        }
    }
}
