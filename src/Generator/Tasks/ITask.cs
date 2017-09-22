﻿using System.IO;
using System.Linq;
using ChilliCream.Tracing.Generator.ProjectSystem;

namespace ChilliCream.Tracing.Generator.Tasks
{
    public interface ITask
    {
        void Execute();
    }

    public class CreateSolutionEventSources
        : ITask
    {
        public string FileOrDirectoryName { get; set; }
        public bool Recursive { get; set; }

        public void Execute()
        {
            if (Directory.Exists(FileOrDirectoryName))
            {
                string[] solutionFileNames = Directory.GetFiles(FileOrDirectoryName, "*.sln",
                    Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                foreach (string solutionFileName in solutionFileNames)
                {
                    ProcessSolution(Solution.Create(solutionFileName));
                }
            }
            else if (File.Exists(FileOrDirectoryName))
            {
                ProcessSolution(Solution.Create(FileOrDirectoryName));
            }
        }

        private void ProcessSolution(Solution solution)
        {
            foreach (Project project in solution.Projects)
            {
                EventSourceBuilder eventSourceBuilder = new EventSourceBuilder(project, project);
                eventSourceBuilder.Build();
            }

            if (solution.Projects.Any(t => t.UpdatedDocumets.Any()))
            {
                solution.CommitChanges();
            }
        }
    }

    public class CreateProjectEventSources
        : ITask
    {

        public string SourceProject { get; set; }
        public string TargetProject { get; set; }

        public void Execute()
        {
            if (string.IsNullOrEmpty(TargetProject))
            {
                TargetProject = SourceProject;
            }

            if (Project.TryParse(SourceProject, out Project source)
                && Project.TryParse(TargetProject, out Project target))
            {
                EventSourceBuilder eventSourceBuilder = new EventSourceBuilder(source, target);
                eventSourceBuilder.Build();

                target.CommitChanges();
            }
        }
    }
}
