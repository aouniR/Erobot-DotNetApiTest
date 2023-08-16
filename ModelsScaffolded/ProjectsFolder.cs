using System;
using System.Collections.Generic;

namespace Erobot_TestApi.ModelsScaffolded;

public partial class ProjectsFolder
{
    public Guid IdProjectFolder { get; set; }

    public Guid? IdProjectVersion { get; set; }

    public Guid? IdParent { get; set; }

    public string? Path { get; set; }

    public string? Title { get; set; }

    public virtual ProjectsFolder? IdParentNavigation { get; set; }

    public virtual ProjectsVersion? IdProjectVersionNavigation { get; set; }

    public virtual ICollection<ProjectsFolder> InverseIdParentNavigation { get; set; } = new List<ProjectsFolder>();

    public virtual ICollection<ProjectsFile> ProjectsFiles { get; set; } = new List<ProjectsFile>();
}
