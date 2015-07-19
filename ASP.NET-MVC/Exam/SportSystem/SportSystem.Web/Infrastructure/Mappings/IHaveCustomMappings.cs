namespace SportSystem.Web.Infrastructure.Mappings
{
    #region

    using AutoMapper;

    #endregion

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}