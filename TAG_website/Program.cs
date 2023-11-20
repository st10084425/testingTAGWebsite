using Microsoft.EntityFrameworkCore;
using TAG_website.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using TAG_website.Services;
using TAG_website;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//the db service
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));


builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("AuthMessageSenderOptions"));


// Configure Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(config =>
{
    // config.SignIn.RequireConfirmedEmail = false;
    
    config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
        new TokenProviderDescriptor(
            typeof(CustomEmailConfirmationTokenProvider<ApplicationUser>)));
    config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

// Add EmailSender
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<CustomEmailConfirmationTokenProvider<ApplicationUser>>();



builder.Services.AddSession();

builder.Services.AddRazorPages();


builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
       o.TokenLifespan = TimeSpan.FromHours(3));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


using(var scope = app.Services.CreateScope())
{

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "User" };


    foreach (var role in roles)
    {

        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }


}


using (var scope = app.Services.CreateScope())
{

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string email = "admin@tag.co.za";
    string password = "Test123!";


  if(await userManager.FindByEmailAsync(email) == null)
    {

        var user = new ApplicationUser();
        user.UserName = email;
        user.Email = email;

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }




}

app.MapRazorPages();

app.Run();
