using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using SampleApp.ModuleOmega.Domain;
using SampleApp.ModuleOmega.Domain.Questions;

namespace SampleApp.ModuleOmega.Persistence
{
    internal sealed class TestCreationUoW : ITestCreationUoW, IDisposable
    {
        private readonly TestCreationDbContext context;
        private readonly Lazy<IQuestionRepository> questions;
       

        public IQuestionRepository Questions { get => questions.Value; }


        public Task Save()
        {          
            return context.SaveChangesAsync();
        }

       



        public void Dispose()
        {
            context.Dispose();
        }
    }
}
