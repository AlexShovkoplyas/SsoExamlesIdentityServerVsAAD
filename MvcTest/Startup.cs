﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MvcTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            
            services.AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme)
                .AddBasic<IBasicAuthenticationService>(o =>
                {
                    o.Realm = "My App";
                });

            services.AddSingleton<IPostConfigureOptions<BasicAuthenticationOptions>, BasicAuthenticationPostConfigureOptions>();


            //services.AddAuthentication(options =>
            //    {
            //        options.DefaultScheme = "cookie1";
            //    })
            //    .AddCookie("cookie1", "cookie1Name", options =>
            //    {
            //        options.Cookie.Name = "cookie1Name";
            //        options.LoginPath = "/loginc1";
            //    })
            //    .AddCookie("cookie2", "cookie2Name", options =>
            //    {
            //        options.Cookie.Name = "cookie2Name";
            //        options.LoginPath = "/loginc2";
            //    });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            //app.Use(next =>
            //{
            //    return async ctx =>
            //    {
            //        switch (ctx.Request.Path)
            //        {
            //            case "/loginc1":
            //                var identity1 = new ClaimsIdentity("cookie1");
            //                identity1.AddClaim(new Claim("name", "Alice-c1"));
            //                await ctx.SignInAsync("cookie1", new ClaimsPrincipal(identity1));
            //                break;
            //            case "/loginc2":
            //                var identity2 = new ClaimsIdentity("cookie2");
            //                identity2.AddClaim(new Claim("name", "Alice-c2"));
            //                await ctx.SignInAsync("cookie2", new ClaimsPrincipal(identity2));
            //                break;
            //            case "/logoutc1":
            //                await ctx.SignOutAsync("cookie1");
            //                break;
            //            case "/logoutc2":
            //                await ctx.SignOutAsync("cookie2");
            //                break;
            //            default:
            //                await next(ctx);
            //                break;
            //        }
            //    };
            //});

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    
}
