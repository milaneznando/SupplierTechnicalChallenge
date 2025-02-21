using System.Data;
using Dapper;

namespace ApiProjects.Infrastructure.Data.Mapping;

/// <summary>
/// Provides a custom type handler for mapping GUIDs to and from
/// the database using Dapper.
/// </summary>
public class GuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override void SetValue(IDbDataParameter parameter, Guid value)
    {
        parameter.Value = value.ToString();
    }

    public override Guid Parse(object value)
    {
        return Guid.Parse(value.ToString() ?? string.Empty);
    }
}