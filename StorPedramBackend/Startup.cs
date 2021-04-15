using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using CorService.Services.IService;
using CorService.Services.SliderService;
using CorService.Services.Category;
using CorService.Services.BrandService;
using CorService.Services.Product;
using CorService.Services.CommentService;
using CorService.Services.FAQ;
using CorService.Services.MainService;
using CorService.Services.Banner;
using CorService.Services.ProprtySevice;
using CorService.Services;
using CorService.Services.Gallery;
using CorService.Services.UserService;
using CorService.Sender;
using CorService.Helper;
using CorService.Services.VarintS;
using CorService.Services.Sller;
using CorService.Services.Order;
using CorService.Services.RatingService;
using Quartz.Spi;
using CorService.Jobs;
using Quartz;
using Quartz.Impl;
using StorPedramBackend.Jobs;

namespace StorPedramBackend
{
    public class Startup
    {
        public const string cookieschem = "Storeonline";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson();


            services.AddDbContext<DigikalaContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Digikala"));
            });
            #region Ioc
            services.AddTransient<ISlider,SliderService>();
            services.AddTransient<ICategoryService,CategoryService>();
            services.AddTransient<IBrandService,BrandService>();
            services.AddTransient<IProductService,ProductService>();
            services.AddTransient<ICommentService,CommentService>();
            services.AddTransient<IFAQService,FAQService>();
            services.AddTransient<IMainMenuService,MainMenuService>();
            services.AddTransient<IBannerService,BannerService>();
            services.AddTransient<IProprtyService,ProprtyService>();
            services.AddTransient<IGalleryServeice,GalleryService>();
            services.AddTransient<IUserService,UserService>();
            services.AddTransient<ISellerService,ISellerService>();
            services.AddTransient<IEmailSender,MassageSender>();
            services.AddTransient<ISmsSender,MassageSender>();
            services.AddTransient<IRenderViewToString, RenderViewToString>();
            services.AddTransient<IVarintService, VarintService>();
            services.AddTransient<ICartService, Cartservice>();
            services.AddTransient<IRatingService,RatingService>();
            services.AddTransient<IFavoriteService,FavoriteUserService>();
            #endregion
            #region Quartz
            services.AddSingleton<IJobFactory, SingltownFactorjob>();
            services.AddSingleton<ISchedulerFactory,StdSchedulerFactory> ();
            services.AddSingleton<RemoveCartJobcs>();
            services.AddSingleton(new jobschulde(jobtype: typeof(RemoveCartJobcs), cronExpression:
               
                "0/5 * * * * ?"

                ));
            services.AddHostedService<QuartzHostService>();
            #endregion
            services.AddAuthentication(cookieschem)
                .AddCookie(cookieschem, option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.AccessDeniedPath="/Account/Login";
                    option.ExpireTimeSpan = TimeSpan.FromSeconds(100);
                });
            
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Error/PageNotFound");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("defualt", "{controller=Home}/{action=Index}/{id?}");
                
            });
        }
    }
}
