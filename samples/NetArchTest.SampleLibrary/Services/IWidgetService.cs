namespace NetArchTest.SampleLibrary.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Model;

    public interface IWidgetService 
    {
        Task<IEnumerable<Widget>> GetWidgetsAsync();
    }
}
