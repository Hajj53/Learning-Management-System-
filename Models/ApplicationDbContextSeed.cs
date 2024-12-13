using Microsoft.AspNetCore.Identity;
using LMS.Models;  // Update based on your actual namespace
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

public class ApplicationDbContextSeed
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Create the Admin role if it does not exist
        var roleExist = await roleManager.RoleExistsAsync("Admin");
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Create the default Admin user if it does not exist
        var user = await userManager.FindByEmailAsync("admin@yourdomain.com");
        if (user == null)
        {
            user = new ApplicationUser
            {
                UserName = "admin@yourdomain.com",
                Email = "admin@yourdomain.com",
            };
            // Create the user with a default password
            await userManager.CreateAsync(user, "Admin@123");  // Use a secure password here
        }

        // Add the user to the Admin role if not already added
        if (!await userManager.IsInRoleAsync(user, "Admin"))
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
