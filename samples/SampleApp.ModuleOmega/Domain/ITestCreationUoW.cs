using SampleApp.ModuleOmega.Domain.Questions;

namespace SampleApp.ModuleOmega.Domain
{
    internal interface ITestCreationUoW
    {
        IQuestionRepository Questions { get; }       

        Task Save();
    }
}
