using System.Reflection;
using LocadoraDeAutomoveis.Aplicacao;
using LocadoraDeAutomoveis.Aplicacao.Serviços;
using LocadoraDeAutomoveis.Dominio.ModuloAutomovel;
using LocadoraDeAutomoveis.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeAutomoveis.Infra.Orm.Compartilhado;
using LocadoraDeAutomoveis.Infra.Orm.GrupoAutomoveis;
using LocadoraDeAutomoveis.Infra.Orm.ModuloAutomovel;

namespace LocadoraDeAutomoveis.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<LocadoraDeAutomoveisDbContext>();

            builder.Services.AddScoped<GrupoAutomoveisService>();
            builder.Services.AddScoped<AutomovelService>();

            builder.Services.AddScoped<IRepositorioGrupoAutomoveis, RepositorioGrupoAutomoveisEmOrm>();
            builder.Services.AddScoped<IRepositorioAutomovel, RepositorioAutomovelEmOrm>();

			builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews(); 

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
