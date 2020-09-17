using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Net.Http;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Authentication.OAuth;
using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Autofac;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;

namespace BIMPlatform.InstantMessage
{
    [DependsOn(
        typeof(AbpAspNetCoreAuthenticationOAuthModule),
        typeof(BIMPlatformHttpApiModule),
        typeof(AbpAccountHttpApiClientModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule),
        typeof(AbpFeatureManagementHttpApiClientModule),
        typeof(AbpAutofacModule),
        typeof(BIMPlatformApplicationContractsModule),
        typeof(AbpAspNetCoreSignalRModule),
        typeof(AbpEventBusRabbitMqModule)
    )]
    public class BIMPlatformRealTimeMessageModule : AbpModule
    {
        public const string RemoteServiceName = "Default";
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            IConfiguration configuration = context.Services.GetConfiguration();

            ConfigureAuthentication(context, configuration);
            context.Services.AddHttpClientProxies(
               typeof(BIMPlatformApplicationContractsModule).Assembly,
               RemoteServiceName
           );
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            //context.Services.AddAuthentication(options =>
            //{
            //    options.DefaultScheme = "Cookies";
            //    options.DefaultChallengeScheme = "oidc";
            //})
            //.AddCookie("Cookies", options =>
            //{
            //    options.ExpireTimeSpan = TimeSpan.FromDays(365);
            //})
            //.AddOpenIdConnect("oidc", options =>
            //{
            //    options.Authority = "https://localhost:44312";
            //    options.RequireHttpsMetadata = true;
            //    options.ResponseType = OpenIdConnectResponseType.CodeIdToken;

            //    options.ClientId = "BIMPlatform_Web";
            //    options.ClientSecret = "1q2w3e*";

            //    options.SaveTokens = true;
            //    options.GetClaimsFromUserInfoEndpoint = true;

            //    options.Scope.Add("role");
            //    options.Scope.Add("email");
            //    options.Scope.Add("phone");
            //    options.Scope.Add("BIMPlatform");
               
            //    options.ClaimActions.MapAbpClaimTypes();
            //});
        }

        //private void ConfigureAutoMapper()
        //{
        //    Configure<AbpAutoMapperOptions>(options =>
        //    {
        //        options.AddMaps<BIMPlatformRealTimeMessageModule>();
        //    });
        //}
    }
}
