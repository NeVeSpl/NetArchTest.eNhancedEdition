using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ModuleOmega.Domain.Questions
{
    internal sealed class Question
    {
        private readonly List<Answer> _answers = new List<Answer>();
    }
}
