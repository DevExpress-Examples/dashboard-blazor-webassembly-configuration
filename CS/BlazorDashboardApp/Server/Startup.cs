using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.Json;
using Microsoft.Extensions.FileProviders;
using System;

namespace BlazorDashboardApp.Server {
    public class Startup {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment) {
            Configuration = configuration;
            FileProvider = hostingEnvironment.ContentRootFileProvider;
        }

        public IConfiguration Configuration { get; }
        public IFileProvider FileProvider { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDevExpressControls();
            services.AddMvc();

            services.AddScoped<DashboardConfigurator>((IServiceProvider serviceProvider) => {
                DashboardConfigurator configurator = new DashboardConfigurator();
                
                configurator.SetDashboardStorage(new DashboardFileStorage(FileProvider.GetFileInfo("App_Data/Dashboards").PhysicalPath));
                configurator.SetDataSourceStorage(new DataSourceInMemoryStorage());
                configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(Configuration));
                configurator.ConfigureDataConnection += Configurator_ConfigureDataConnection;

                return configurator;
            });    
        }

        private void Configurator_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "jsonSupport") {
                Uri fileUri = new Uri(FileProvider.GetFileInfo("App_data/Support.json").PhysicalPath, UriKind.RelativeOrAbsolute);
                JsonSourceConnectionParameters jsonParams = new JsonSourceConnectionParameters();
                jsonParams.JsonSource = new UriJsonSource(fileUri);
                e.ConnectionParameters = jsonParams;
            }
            if (e.ConnectionName == "jsonCategories") {
                Uri fileUri = new Uri(FileProvider.GetFileInfo("App_data/Categories.json").PhysicalPath, UriKind.RelativeOrAbsolute);
                JsonSourceConnectionParameters jsonParams = new JsonSourceConnectionParameters();
                jsonParams.JsonSource = new UriJsonSource(fileUri);
                e.ConnectionParameters = jsonParams;
            }
            if (e.ConnectionName == "jsonCustomers") {
                JsonSourceConnectionParameters jsonParams = new JsonSourceConnectionParameters();
                jsonParams.JsonSource = new UriJsonSource(
                    new Uri("https://raw.githubusercontent.com/DevExpress-Examples/DataSources/master/JSON/customers.json"));
                e.ConnectionParameters = jsonParams;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            } else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseDevExpressControls();
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "api/dashboard", "DefaultDashboard");
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
