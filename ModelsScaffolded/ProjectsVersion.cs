using System;
using System.Collections.Generic;

namespace Erobot_TestApi.ModelsScaffolded;

public partial class ProjectsVersion
{
    public Guid IdProjectVersion { get; set; }

    public Guid? IdProject { get; set; }

    public Guid? PrototypeEditorPrototypesVersionsIdPrototypeVersion { get; set; }

    public string? Title { get; set; }

    public int? Version { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public bool? IsFrontend { get; set; }

    public bool? IsBackend { get; set; }

    public bool? IsLastVersion { get; set; }

    public string? Time { get; set; }

    public string? ShortId { get; set; }

    public string? Path { get; set; }

    public virtual Project? IdProjectNavigation { get; set; }

    public virtual ICollection<ProjectsFile> ProjectsFiles { get; set; } = new List<ProjectsFile>();

    public virtual ICollection<ProjectsFolder> ProjectsFolders { get; set; } = new List<ProjectsFolder>();
}
