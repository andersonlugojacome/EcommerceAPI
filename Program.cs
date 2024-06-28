using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Manually add the services form Startup.cs
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI(c =>
    // {
    //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceAPI v1");
    //     c.RoutePrefix = string.Empty; // Para que Swagger UI esté en la raíz
    // });
    
    
}

//app.UseHttpsRedirection();


startup.Configure(app, app.Environment);

// Open API Documentation browser
var urlSwagger = "http://localhost:5070/index.html";
try{
    var psi = new ProcessStartInfo
    {
        FileName = urlSwagger,
        UseShellExecute = true
    };
    Process.Start(psi);

}catch(Exception ex){
    Console.WriteLine(String.Format("Error al abrir el navegador: {0}, but you can open manually: {1}", ex.Message, urlSwagger));
}

app.Run();
