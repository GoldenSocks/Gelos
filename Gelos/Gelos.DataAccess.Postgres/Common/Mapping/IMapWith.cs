

namespace Gelos.DataAccess.Postgres.Common.Mapping
{
    public interface IMapWith<in T>
    {
        void Mapping(AssemblyMappingProfile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
