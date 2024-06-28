using System.Text;
using EcommerceAPI.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var _configuration = Configuration;
        var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
        services.AddDbContext<EcommerceContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 3, 0))));
        services.AddControllers();
        // Add authentications JWT
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        // Add Swagger to the project.
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "EcommerceAPI - DigitalesWeb",
                Version = "v1",
                Description = "API RESTful para Ecommerce con ASP.NET Core 8 y MySQL 8.0.26 - DigitalesWeb",
                TermsOfService = new Uri("https://digitalesweb.com/")
            });
            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            };

            c.AddSecurityDefinition("Bearer", securitySchema);
            var securitySchemaRequirement = new OpenApiSecurityRequirement
            {{
                securitySchema, new[]{"Bearer"}
            }};
            c.AddSecurityRequirement(securitySchemaRequirement);

        });




    }



    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        //app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        // Enable Swagger and Swagger UI
        app.UseSwagger();
        app.UseSwaggerUI(c => 
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcommerceAPI - DigitalesWeb v1");
            c.RoutePrefix = string.Empty;
            c.DocumentTitle = "EcommerceAPI - DigitalesWeb";
            
        });
        app.UseEndpoints(enpoints =>
        {
            enpoints.MapControllers();
        });
    }
}