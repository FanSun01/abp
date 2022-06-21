﻿using System.Collections.Generic;
using Volo.Abp.Cli.ProjectBuilding.Building;
using Volo.Abp.Cli.ProjectBuilding.Building.Steps;

namespace Volo.Abp.Cli.ProjectBuilding.Templates.App;

public class AppProTemplate : AppTemplateBase
{
    /// <summary>
    /// "app-pro".
    /// </summary>
    public const string TemplateName = "app-pro";

    public const Theme DefaultTheme = Theme.LeptonX;

    public AppProTemplate()
        : base(TemplateName)
    {
        DocumentUrl = CliConsts.DocsLink + "/en/commercial/latest";
    }

    protected override void ConfigureTheme(ProjectBuildContext context, List<ProjectBuildPipelineStep> steps)
    {
        if (!context.BuildArgs.Theme.HasValue)
        {
            return;
        }

        if (context.BuildArgs.Theme == Theme.LeptonX)
        {
            context.Symbols.Add("LEPTONX");
        }

        if (context.BuildArgs.Theme == Theme.Lepton)
        {
            context.Symbols.Add("LEPTON");
        }

        if (DefaultTheme != context.BuildArgs.Theme)
        {
            steps.Add(new ChangeThemeStep());
        }
    }
}
