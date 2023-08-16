using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Erobot_TestApi.ModelsScaffolded;
namespace Erobot_TestApi.Controllers;

[Route("api/v_0.1/[controller]")]
[ApiController]
public class DbExplorerController : ControllerBase
{
    private readonly ErobotTestContext _dbContext;

    public DbExplorerController(ErobotTestContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("tables")]
    public ActionResult<IEnumerable<string>> GetAllTablesNames()
    {
        var tableNames = _dbContext.Model.GetEntityTypes()
                            .Select(t => t.GetTableName())
                            .ToList();

        return Ok(tableNames);
    }

    [HttpGet("columns")]
    public IActionResult GetColumnNames(string tableName)
    {
        if (string.IsNullOrEmpty(tableName))
        {
            return BadRequest("table names are required.");
        }
        var entityType = _dbContext.Model.GetEntityTypes()
            .SingleOrDefault(e => e.GetTableName() == tableName);

        if (entityType == null)
        {
            return NotFound($"Table '{tableName}' not found.");
        }
        var columnNames = entityType.GetProperties().Select(p => p.GetColumnName());
        return Ok(columnNames);
    }

    [HttpGet("projects")]
    public IActionResult GetAllProjects()
    {
        var projects = _dbContext.Projects.ToList();
        return Ok(projects);
    }
    

    [HttpGet("projects/{id}")]
    public IActionResult GetProjectById(Guid id)
    {
        var project = _dbContext.Projects.Find(id);

        if (project == null)
        {
            return NotFound($"Project with IdProject '{id}' not found.");
        }

        return Ok(project);
    }

    [HttpGet("Projects__Files")]
    public IActionResult GetAllProjects__Files()
    {
        var projectsFiles = _dbContext.ProjectsFiles.ToList();
        return Ok(projectsFiles);
    }
    [HttpGet("Projects__Files/{id}")]
    public IActionResult GetProjectsFilesById(Guid id)
    {
        var ProjectFile = _dbContext.ProjectsFiles.Find(id);

        if (ProjectFile == null)
        {
            return NotFound($"ProjectFile with IdProjectFile '{id}' not found.");
        }

        return Ok(ProjectFile);
    }

    [HttpGet("Projects__Files__Lines")]
    public IActionResult GetAllProjectsFilesLines()
    {
        var projectsFilesLines = _dbContext.ProjectsFilesLines.ToList();
        return Ok(projectsFilesLines);
    }
    [HttpGet("Projects__Files__Lines/{id}")]
    public IActionResult GetProjectFilesLinesById(Guid id)
    {
        var ProjectsFilesLines = _dbContext.ProjectsFilesLines.Find(id);

        if (ProjectsFilesLines == null)
        {
            return NotFound($"ProjectsFilesLines with IdProjectFileLine '{id}' not found.");
        }

        return Ok(ProjectsFilesLines);
    }


    [HttpGet("Projects__Folders")]
    public IActionResult GetAllProjectsFolders()
    {
        var projectsFolders = _dbContext.ProjectsFolders.ToList();
        return Ok(projectsFolders);
    }
    [HttpGet("Projects__Folders/{id}")]
    public IActionResult GetProjectFoldersById(Guid id)
    {
        var ProjectsFolders = _dbContext.ProjectsFolders.Find(id);

        if (ProjectsFolders == null)
        {
            return NotFound($"ProjectsFolders with IdProjectFolder '{id}' not found.");
        }

        return Ok(ProjectsFolders);
    }

    [HttpGet("Projects__Versions")]
    public IActionResult GetAllProjectsVersions()
    {
        var projectsVersions = _dbContext.ProjectsVersions.ToList();
        return Ok(projectsVersions);
    }
    [HttpGet("Projects__Versions/{id}")]
    public IActionResult GetProjectVersionsById(Guid id)
    {
        var ProjectsVersions = _dbContext.ProjectsVersions.Find(id);

        if (ProjectsVersions == null)
        {
            return NotFound($"ProjectsVersions with IdProjectVersion '{id}' not found.");
        }

        return Ok(ProjectsVersions);
    }
}
