﻿using eVideoPrime.Core;
using eVideoPrime.Core.Entities;
using eVideoPrime.Core.Implementations;
using eVideoPrime.Core.Interfaces;
using eVideoPrime.Services.Implementations;
using eVideoPrime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eVideoPrime.Services.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            //database
            services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });
            services.AddScoped<DbContext, AppDbContext>();

            //repositories
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Subscription>, Repository<Subscription>>();
            services.AddScoped<IRepository<Movie>, Repository<Movie>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Plan>, Repository<Plan>>();
            services.AddScoped<IRepository <PaymentDetail>, Repository<PaymentDetail>>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            //services
            services.AddScoped<IService<Movie>, Service<Movie>>();
            services.AddScoped<IService<Category>, Service<Category>>();
            services.AddScoped<IService<Plan>, Service<Plan>>();
            services.AddScoped<IService<User>, Service<User>>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
