using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Nover.CMS.Domain;

namespace Nover.CMS.EntityFrameworkCore
{
    public static class NoverCmsDbContextModelCreatingExtensions
    {
        public static void ConfigureNoverCms(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            if (builder.IsTenantOnlyDatabase())
            {
                return;
            }

            builder.Entity<MenuItem>(b =>
            {
                b.ToTable(NoverCmsDbProperties.DbTablePrefix + "MenuItems");
                b.ConfigureByConvention();

                /* Configure more properties here */

                b.HasKey(e => new
                {
                    e.Name,
                });

                b.HasMany(x => x.MenuItems).WithOne().HasForeignKey(x => x.ParentName);
            });
        }
    }
}
