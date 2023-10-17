using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Data;

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

            
        }
    }
}
