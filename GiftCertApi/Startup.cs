﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GiftCertApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GiftCertApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DevConnection");
            if (Environment.IsProduction())
            {
                connection = Configuration.GetConnectionString("ProductionConnection");
            }
            else if (Environment.IsStaging())
            {
                connection = Configuration.GetConnectionString("StagingConnection");
            }


            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connection));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            // Add application services.
            //services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            services.AddDbContext<GiftCertificateDBContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
