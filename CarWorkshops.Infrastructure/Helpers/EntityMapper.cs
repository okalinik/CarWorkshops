using AutoMapper;

namespace CarWorkshops.Infrastructure.Helpers
{
    public static class EntityMapper
    {
        public static T Map<T>(this object source) where T : class
        {
            var destinationType = typeof(T);
            var sourceType = source.GetType();

            var mappingResult = Mapper.Map(source, sourceType, destinationType);

            return mappingResult as T;
        }

    }
}
