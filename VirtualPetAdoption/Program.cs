using Microsoft.EntityFrameworkCore;
using VirtualPetAdoption.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container atfer the method call to AddRazorPages.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PetAdoptionContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PetAdoptionContext")));

var app = builder.Build();

//Apply migrations at startup
using (var scope = app.Services.CreateScope())
{ var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PetAdoptionContext>();
    context.Database.Migrate();
}
    

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
