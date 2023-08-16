using System;
using System.Collections.Generic;

namespace Erobot_TestApi.ModelsScaffolded;

public partial class ProjectsFilesLine
{
    public Guid IdProjectFileLine { get; set; }

    public Guid? IdProjectFile { get; set; }

    public int? LineNumber { get; set; }

    public string? Code { get; set; }

    public virtual ProjectsFile? IdProjectFileNavigation { get; set; }
}
