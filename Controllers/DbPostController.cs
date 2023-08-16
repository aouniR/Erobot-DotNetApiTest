using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Erobot_TestApi.ModelsScaffolded;
namespace Erobot_TestApi.Controllers;

[Route("api/v_0.1/[controller]")]
[ApiController]
public class DbPostController : ControllerBase
{
    private readonly ErobotTestContext _dbContext;
    public DbPostController(ErobotTestContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("projects")]
    public IActionResult CreateProject(Project projectInput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newProject = new Project
        {
            IdProject = Guid.NewGuid(),
            Title = projectInput.Title ?? null,
            Version = projectInput.Version?? null,
            Date = projectInput.Date ?? DateTime.Now.Date,
            Time = projectInput.Time ?? DateTime.Now.TimeOfDay,
            ShortId = projectInput.ShortId ?? null
        };

        _dbContext.Projects.Add(newProject);
        _dbContext.SaveChanges();
        var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{Url.Action("GetProjectById", "DbExplorer", new { id = newProject.IdProject })}";
        return Created(url, newProject);
    }

    [HttpPost("Projects__Files")]
    public IActionResult CreateProjectsFiles(ProjectsFile projectInput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newProjectFile = new ProjectsFile
        {
            IdProjectFile = Guid.NewGuid(),
            IdProjectVersion = projectInput.IdProjectVersion ?? null,
            IdProjectFolder = projectInput.IdProjectFolder?? null,
            Title = projectInput.Title?? null,
            Extension = projectInput.Extension?? null,
            FileCreationDate = projectInput.FileCreationDate ?? DateTime.Now.Date,
            FileCreationTime = projectInput.FileCreationTime ?? DateTime.Now.TimeOfDay,
            FileLastUpdateDate = projectInput.FileLastUpdateDate ?? DateTime.Now.Date,
            FileLastUpdateTime = projectInput.FileLastUpdateTime ?? DateTime.Now.TimeOfDay,
            FileSize = projectInput.FileSize??null
        };

        _dbContext.ProjectsFiles.Add(newProjectFile);
        _dbContext.SaveChanges();
        var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{Url.Action("GetProjectsFilesById", "DbExplorer", new { id = newProjectFile.IdProjectFile })}";
        return Created(url, newProjectFile);
    }

    [HttpPost("Projects__Files__Lines")]
    public IActionResult CreateProjectsFilesLines(ProjectsFilesLine projectInput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newProjectsFilesLine = new ProjectsFilesLine
        {
            IdProjectFileLine = Guid.NewGuid(),
            IdProjectFile = projectInput.IdProjectFile ?? null,
            LineNumber = projectInput.LineNumber?? null,
            Code = projectInput.Code?? null
        };

        _dbContext.ProjectsFilesLines.Add(newProjectsFilesLine);
        _dbContext.SaveChanges();
        var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{Url.Action("GetProjectFilesLinesById", "DbExplorer", new { id = newProjectsFilesLine.IdProjectFileLine })}";
        return Created(url, newProjectsFilesLine);
    }

    [HttpPost("Projects__Folders")]
    public IActionResult CreateProjectsFolderss(ProjectsFolder projectInput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newProjectsFolder= new ProjectsFolder
        {
            IdProjectFolder = Guid.NewGuid(),
            IdProjectVersion = projectInput.IdProjectVersion ?? null,
            IdParent = projectInput.IdParent?? null,
            Path = projectInput.Path?? null,
            Title = projectInput.Title?? null
        };

        _dbContext.ProjectsFolders.Add(newProjectsFolder);
        _dbContext.SaveChanges();
        var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{Url.Action("GetProjectFoldersById", "DbExplorer", new { id = newProjectsFolder.IdProjectFolder })}";
        return Created(url, newProjectsFolder);
    }

    [HttpPost("Projects__Versions")]
    public IActionResult CreateProjectsVersion(ProjectsVersion projectInput)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newProjectsVersion= new ProjectsVersion
        {
            IdProjectVersion = Guid.NewGuid(),
            IdProject = projectInput.IdProject ?? null,
            PrototypeEditorPrototypesVersionsIdPrototypeVersion = projectInput.PrototypeEditorPrototypesVersionsIdPrototypeVersion?? null,
            Title = projectInput.Title?? null,
            Version = projectInput.Version?? null,
            Description=projectInput.Description?? null,
            Date = projectInput.Date??DateTime.Now.Date,
            IsFrontend=projectInput.IsFrontend?? null,
            IsBackend=projectInput.IsBackend?? null,
            IsLastVersion=projectInput.IsLastVersion?? null,
            Time = projectInput.Time?? null,
            ShortId = projectInput.ShortId?? null,
            Path = projectInput.Path?? null,
        };

        _dbContext.ProjectsVersions.Add(newProjectsVersion);
        _dbContext.SaveChanges();
        var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{Url.Action("GetProjectVersionsById", "DbExplorer", new { id = newProjectsVersion.IdProjectVersion })}";
        return Created(url, newProjectsVersion);
    }
    
}
