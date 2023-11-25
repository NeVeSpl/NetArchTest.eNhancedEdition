using SampleApp.BuildingBlocks.Persistence;
using SampleApp.ModuleOmega.Domain.Questions;

namespace SampleApp.ModuleOmega.Persistence.Questions
{
    internal sealed class QuestionRepository : GenericRepository<Question, TestCreationDbContext>, IQuestionRepository
    {
        public QuestionRepository(TestCreationDbContext context) : base(context)
        {

        }


        public Question GetByIdWithAnswers(long id)
        {
            return null;
        }
    }
}
