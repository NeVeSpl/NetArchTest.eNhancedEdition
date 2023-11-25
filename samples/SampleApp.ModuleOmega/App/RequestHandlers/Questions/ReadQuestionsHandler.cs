using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SampleApp.ModuleOmega.Persistence;

namespace SampleApp.ModuleOmega.App.RequestHandlers.Questions
{
    internal sealed class ReadQuestionsHandler : IRequestHandler<ReadQuestionsQuery, List<QuestionOnListDTO>>
    {
        private readonly ReadOnlyTestCreationDbContext context;

        public ReadQuestionsHandler(ReadOnlyTestCreationDbContext context)
        {
            this.context = context;
        }


        public async Task<List<QuestionOnListDTO>> Handle(ReadQuestionsQuery query, CancellationToken cancellationToken)
        {
            

            return null;
        }
    }
}
