using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SampleApp.ModuleOmega.App.RequestHandlers.Questions
{
    internal class ReadQuestionsQuery : IRequest<List<QuestionOnListDTO>>
    {
    }
}
