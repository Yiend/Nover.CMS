using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nover.CMS.EntityFrameworkCore;
using Nover.CMS.Localization;
using Nover.CMS.MultiTenancy;
using Nover.CMS.Web.Menus;
using Microsoft.OpenApi.Models;
using OpenIddict.Validation.AspNetCore;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Theming;
using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;

namespace Nover.CMS.Web;

[DependsOn(
	typeof(NoverCmsHttpApiModule),
	typeof(NoverCmsApplicationModule),
	typeof(NoverCmsEntityFrameworkCoreModule),
	typeof(AbpAutofacModule),
	typeof(AbpIdentityWebModule),
	typeof(AbpAspNetCoreMvcUiBasicThemeModule),
	typeof(AbpSettingManagementWebModule),
	typeof(AbpAccountWebOpenIddictModule),
	typeof(AbpTenantManagementWebModule),
	typeof(AbpAspNetCoreSerilogModule),
	typeof(AbpSwashbuckleModule)
	)]
[DependsOn(typeof(CmsKitWebModule))]
public class NoverCmsWebModule : AbpModule
{
	public override void PreConfigureServices(ServiceConfigurationContext context)
	{
		context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
		{
			options.AddAssemblyResource(
				typeof(CMSResource),
				typeof(NoverCmsDomainModule).Assembly,
				typeof(NoverCmsDomainSharedModule).Assembly,
				typeof(NoverCmsApplicationModule).Assembly,
				typeof(NoverCmsApplicationContractsModule).Assembly,
				typeof(NoverCmsWebModule).Assembly
			);
		});



		PreConfigure<OpenIddictServerBuilder>(builder =>
		{
			builder.UseAspNetCore().DisableTransportSecurityRequirement();
		});

		PreConfigure<OpenIddictBuilder>(builder =>
		  {
			  builder.AddValidation(options =>
			  {
				  options.AddAudiences("CMS");
				  options.UseLocalServer();
				  options.UseAspNetCore();
			  });
		  });
	}

	public override void ConfigureServices(ServiceConfigurationContext context)
	{
		var hostingEnvironment = context.Services.GetHostingEnvironment();
		var configuration = context.Services.GetConfiguration();

		//Configure<AbpThemingOptions>(options =>
		//{
		//    options.DefaultThemeName = "";
		//});

		ConfigureRazorPageRoute();
		ConfigureAuthentication(context);
		ConfigureUrls(configuration);
		ConfigureBundles();
		ConfigureAutoMapper();
		ConfigureVirtualFileSystem(hostingEnvironment);
		ConfigureNavigationServices();
		ConfigureAutoApiControllers();
		ConfigureCors(context, configuration);
		ConfigureSwaggerServices(context.Services);
	}

	private void ConfigureRazorPageRoute()
	{
		Configure<RazorPagesOptions>(options =>
		{
			options.Conventions.AddPageRoute("/Home/Index", "/");
			options.Conventions.AddPageRoute("/Live/Index", "live");
			options.Conventions.AddPageRoute("/Resume/Index", "Resume");
		});

	}

	private void ConfigureAuthentication(ServiceConfigurationContext context)
	{
		context.Services.ForwardIdentityAuthenticationForBearer(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
	}

	private void ConfigureUrls(IConfiguration configuration)
	{
		Configure<AppUrlOptions>(options =>
		{
			options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
			options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"].Split(','));
		});
	}

	private void ConfigureBundles()
	{
		Configure<AbpBundlingOptions>(options =>
		{

		});
	}

	private void ConfigureAutoMapper()
	{
		Configure<AbpAutoMapperOptions>(options =>
		{
			options.AddMaps<NoverCmsWebModule>();
		});
	}

	private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
	{
		if (hostingEnvironment.IsDevelopment())
		{
			Configure<AbpVirtualFileSystemOptions>(options =>
			{
				options.FileSets.ReplaceEmbeddedByPhysical<NoverCmsDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Nover.CMS.Domain.Shared"));
				options.FileSets.ReplaceEmbeddedByPhysical<NoverCmsDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Nover.CMS.Domain"));
				options.FileSets.ReplaceEmbeddedByPhysical<NoverCmsApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Nover.CMS.Application.Contracts"));
				options.FileSets.ReplaceEmbeddedByPhysical<NoverCmsApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Nover.CMS.Application"));
				options.FileSets.ReplaceEmbeddedByPhysical<NoverCmsWebModule>(hostingEnvironment.ContentRootPath);
			});
		}
	}

	private void ConfigureNavigationServices()
	{
		Configure<AbpNavigationOptions>(options =>
		{
			options.MenuContributors.Add(new NoverCmsMenuContributor());
		});
	}

	private void ConfigureAutoApiControllers()
	{
		Configure<AbpAspNetCoreMvcOptions>(options =>
		{
			options.ConventionalControllers.Create(typeof(NoverCmsApplicationModule).Assembly);
		});
	}

	private void ConfigureSwaggerServices(IServiceCollection services)
	{
		services.AddAbpSwaggerGen(
			options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "CMS API", Version = "v1" });
				options.DocInclusionPredicate((docName, description) => true);
				options.CustomSchemaIds(type => type.FullName);
			}
		);
	}

	private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
	{
		context.Services.AddCors(options =>
		{
			options.AddPolicy("Default", builder =>
			{
				builder
					.WithOrigins(
						configuration["App:CorsOrigins"]
							.Split(",", StringSplitOptions.RemoveEmptyEntries)
							.Select(o => o.RemovePostFix("/"))
							.ToArray()
					)
					.WithAbpExposedHeaders()
					.SetIsOriginAllowedToAllowWildcardSubdomains()
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials();
			});
		});
	}


	public override void OnApplicationInitialization(ApplicationInitializationContext context)
	{
		var app = context.GetApplicationBuilder();
		var env = context.GetEnvironment();

		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseAbpRequestLocalization();

		if (!env.IsDevelopment())
		{
			app.UseErrorPage();
		}

		app.UseCorrelationId();
		app.UseStaticFiles();
		app.UseRouting();
		app.UseAuthentication();
		app.UseAbpOpenIddictValidation();

		if (MultiTenancyConsts.IsEnabled)
		{
			app.UseMultiTenancy();
		}

		app.UseUnitOfWork();
		app.UseAuthorization();
		app.UseSwagger();
		app.UseAbpSwaggerUI(options =>
		{
			options.SwaggerEndpoint("/swagger/v1/swagger.json", "CMS API");
		});
		app.UseAuditing();
		app.UseAbpSerilogEnrichers();
		app.UseConfiguredEndpoints(endpoints =>
		{
			endpoints.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		});
	}
}
