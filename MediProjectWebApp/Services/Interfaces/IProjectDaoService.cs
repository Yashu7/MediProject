using MediProjectWebApp.Helpers;
using MediProjectWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediProjectWebApp.Services.Interfaces
{
    public interface IProjectDaoService
    {
        List<Project> ReadAllProjects();
        Project ReadProject(long idProject);
        QueryStatus UpdateProject(Project project);
        QueryStatus CreateProject(Project project);
        QueryStatus DeleteProject(Project project);
    }
}
