#pragma checksum "C:\temp\Ohjelmistoprojekti\kouluilm\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4cf021f46d658217df6a35b15fafef704a47a3ce"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace kouluilm.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using kouluilm;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using kouluilm.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\temp\Ohjelmistoprojekti\kouluilm\_Imports.razor"
using kouluilm.Data;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 23 "C:\temp\Ohjelmistoprojekti\kouluilm\Shared\NavMenu.razor"
       
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
