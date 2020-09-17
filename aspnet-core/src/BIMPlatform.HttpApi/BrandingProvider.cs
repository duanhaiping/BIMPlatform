using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace BIMPlatform
{
    [Dependency(ReplaceServices = true)]
    public class BrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BIMPlatform";
    }
}
