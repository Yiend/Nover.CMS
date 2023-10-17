using System.Threading.Tasks;

namespace Nover.CMS.Data;

public interface INoverCmsDbSchemaMigrator
{
    Task MigrateAsync();
}
