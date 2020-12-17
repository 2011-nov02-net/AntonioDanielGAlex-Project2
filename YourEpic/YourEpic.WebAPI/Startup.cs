using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using YourEpic.DB;
using YourEpic.DB.Repositories;
using YourEpic.Domain;
using YourEpic.Domain.Interfaces;

namespace YourEpic.WebAPI
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "YourEpic.WebAPI", Version = "v1" });
            });
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IEpicRepository, EpicRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IReaderRepository, ReaderRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            services.AddControllers(options =>
            {
                // make asp.net core forget about text/plain so swagger ui uses json as the default
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
                // teach asp.net core to be able to serialize & deserialize XML
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                options.ReturnHttpNotAcceptable = true;
            });
            services.AddDbContext<YourEpicProjectTwoDatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("YourEpic")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/YourEpic.WebApp-{Date}.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YourEpic.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
