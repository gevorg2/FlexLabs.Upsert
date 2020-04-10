#if !EFCORE3
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlexLabs.EntityFrameworkCore.Upsert.Runners
{
    internal static class ProxyExtensions
    {
        public static string GetSchema(this IEntityType entity) => entity.GetDefaultSchema();
        public static string GetTableName(this IEntityType entity) => entity.GetTableName();
        public static PropertySaveBehavior GetAfterSaveBehavior(this IProperty property) => property.GetAfterSaveBehavior();
        public static string GetColumnName(this IProperty property) => property.GetColumnName();
        public static object GetDefaultValue(this IProperty property) => property.GetDefaultValue();
        public static string GetDefaultValueSql(this IProperty property) => property.GetDefaultValueSql();
    }
}
#endif
