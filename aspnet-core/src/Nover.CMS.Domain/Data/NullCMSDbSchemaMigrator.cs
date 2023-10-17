using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Nover.CMS.Data;

/* This is used if database provider does't define
 * ICMSDbSchemaMigrator implementation.
 */
public class NullCMSDbSchemaMigrator : INoverCmsDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
