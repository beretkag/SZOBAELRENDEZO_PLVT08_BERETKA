var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});





app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseCors(x => x
.AllowCredentials()
.AllowAnyHeader()
.AllowAnyHeader()
.WithOrigins("http://localhost:5500")
);

app.Run(); 
