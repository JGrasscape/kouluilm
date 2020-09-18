#pragma checksum "C:\OHSU19S\kouluilm\Pages\Hae.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f0c19525e3378d25cb08424ac5a9b5759cc93771"
// <auto-generated/>
#pragma warning disable 1591
namespace kouluilm.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\OHSU19S\kouluilm\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\OHSU19S\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\OHSU19S\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\OHSU19S\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\OHSU19S\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\OHSU19S\kouluilm\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\OHSU19S\kouluilm\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\OHSU19S\kouluilm\_Imports.razor"
using kouluilm;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\OHSU19S\kouluilm\_Imports.razor"
using kouluilm.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\OHSU19S\kouluilm\_Imports.razor"
using kouluilm.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/hae")]
    public partial class Hae : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<head>\r\n    <h1>Omat ilmoittautumisesi</h1>\r\n</head>\r\n\r\n");
            __builder.OpenElement(1, "table");
            __builder.AddAttribute(2, "class", "table table-hover");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.AddMarkupContent(4, "<thead>\r\n        <tr>\r\n            <th>Pvm</th>\r\n            <th>Kello</th>\r\n            <th>Koulutus</th>\r\n            <th>Sijainti</th>\r\n            <th>Osallistuja</th>            \r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    ");
            __builder.OpenElement(5, "tbody");
            __builder.AddMarkupContent(6, "\r\n");
#nullable restore
#line 25 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
         foreach (var ilmo in ilmoSearches)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "            ");
            __builder.OpenElement(8, "tr");
            __builder.AddMarkupContent(9, "\r\n                ");
            __builder.OpenElement(10, "td");
            __builder.AddContent(11, 
#nullable restore
#line 28 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                     ilmo.Pvm.ToShortDateString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.OpenElement(13, "td");
            __builder.AddContent(14, 
#nullable restore
#line 29 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                     ilmo.KloAlku

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(15, " - ");
            __builder.AddContent(16, 
#nullable restore
#line 29 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                                     ilmo.KloLoppu

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                ");
            __builder.OpenElement(18, "td");
            __builder.AddContent(19, 
#nullable restore
#line 30 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                     ilmo.Koulutus

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n                ");
            __builder.OpenElement(21, "td");
            __builder.AddContent(22, 
#nullable restore
#line 31 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                     ilmo.Sijainti

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n                ");
            __builder.OpenElement(24, "td");
            __builder.AddContent(25, 
#nullable restore
#line 32 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                     ilmo.Osallistuja

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n                ");
            __builder.OpenElement(27, "td");
            __builder.AddMarkupContent(28, "\r\n                    ");
            __builder.OpenElement(29, "button");
            __builder.AddAttribute(30, "type", "button");
            __builder.AddAttribute(31, "class", "btn btn-labeled btn-danger");
            __builder.AddAttribute(32, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 34 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                                                                                         () => Poista(ilmo.Varaus_ID)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(33, "\r\n                        ");
            __builder.AddMarkupContent(34, "<span class=\"btn-label\">\r\n                            <i class=\"oi oi-trash\"></i>\r\n                        </span>\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(35, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n");
#nullable restore
#line 41 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(38, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n\r\n");
#nullable restore
#line 45 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
 if (naytaPoistaModal)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(41, "    ");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "class", "modal fade show");
            __builder.AddAttribute(44, "id", "poistaModal");
            __builder.AddAttribute(45, "style", "display:block");
            __builder.AddAttribute(46, "aria-modal", "true");
            __builder.AddAttribute(47, "role", "dialog");
            __builder.AddMarkupContent(48, "\r\n        ");
            __builder.OpenElement(49, "div");
            __builder.AddAttribute(50, "class", "modal-dialog modal-dialog-centered");
            __builder.AddMarkupContent(51, "\r\n            ");
            __builder.OpenElement(52, "div");
            __builder.AddAttribute(53, "class", "modal-content");
            __builder.AddMarkupContent(54, "\r\n                ");
            __builder.OpenElement(55, "div");
            __builder.AddAttribute(56, "class", "modal-header");
            __builder.AddMarkupContent(57, "\r\n                    ");
            __builder.AddMarkupContent(58, "<h4 class=\"modal-title\">Poisto</h4>\r\n                    ");
            __builder.OpenElement(59, "button");
            __builder.AddAttribute(60, "type", "button");
            __builder.AddAttribute(61, "class", "close");
            __builder.AddAttribute(62, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                                                                   PoistaPeruuta

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(63, "×");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n\r\n                ");
            __builder.OpenElement(66, "div");
            __builder.AddAttribute(67, "class", "modal-body");
            __builder.AddMarkupContent(68, "\r\n                    ");
            __builder.AddMarkupContent(69, "<p>Haluatko varmasti poistaa ilmoittautumisesi tähän koulutukseen?</p>\r\n                    ");
            __builder.OpenElement(70, "p");
            __builder.AddContent(71, 
#nullable restore
#line 57 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                        ilmoDetails.Koulutus

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(72, " ");
            __builder.AddContent(73, 
#nullable restore
#line 57 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                                              ilmoDetails.Pvm.ToShortDateString()

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(74, " klo ");
            __builder.AddContent(75, 
#nullable restore
#line 57 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                                                                                       ilmoDetails.KloAlku

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(76, " - ");
            __builder.AddContent(77, 
#nullable restore
#line 57 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                                                                                                              ilmoDetails.KloLoppu

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(78, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(79, "\r\n\r\n                ");
            __builder.OpenElement(80, "div");
            __builder.AddAttribute(81, "class", "modal-footer");
            __builder.AddMarkupContent(82, "\r\n                    ");
            __builder.OpenElement(83, "button");
            __builder.AddAttribute(84, "type", "button");
            __builder.AddAttribute(85, "class", "btn btn-secondary");
            __builder.AddAttribute(86, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 61 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                                                                               PoistaPeruuta

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(87, "Peruuta");
            __builder.CloseElement();
            __builder.AddMarkupContent(88, "\r\n                    ");
            __builder.OpenElement(89, "button");
            __builder.AddAttribute(90, "type", "button");
            __builder.AddAttribute(91, "class", "btn btn-success");
            __builder.AddAttribute(92, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 62 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
                                                                             PoistaOK

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(93, "Poista");
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(96, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(98, "\r\n");
#nullable restore
#line 67 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(99, "\r\n");
            __builder.AddMarkupContent(100, "<footer style=\"position: fixed; bottom: 0; width: 80%; text-align: center;\">\r\n    <p>&copy; EPSHP</p>\r\n</footer>");
        }
        #pragma warning restore 1998
#nullable restore
#line 73 "C:\OHSU19S\kouluilm\Pages\Hae.razor"
       
    private List<IlmoSearch> ilmoSearches = new List<IlmoSearch>();
    private IlmoSearch ilmoSearch = new IlmoSearch();
    private IlmoSearch ilmoDetails;
    private string user;
    private bool naytaPoistaModal = false;
    private int _varaus_id;

    protected override async Task OnInitializedAsync()
    {
        // Käyttäjän tiedot
        user = httpContextAccessor.HttpContext.User.Identity.Name;

        // Haetaan ilmoittautumiset
        ilmoSearches = await IlmoSearchService.GetIlmoSearchByVaraajaAsync(user);
    }

    void Poista(int varaus_id)
    {
        _varaus_id = varaus_id;
        ilmoDetails = ilmoSearches.Single(i => i.Varaus_ID == varaus_id);
        naytaPoistaModal = true;
    }
    void PoistaPeruuta() => naytaPoistaModal = false;
    async void PoistaOK()
    {
        IlmoittautuminenService.DeleteOsallistujaAsync(_varaus_id);

        // Haetaan ilmoittautumiset
        ilmoSearches = await IlmoSearchService.GetIlmoSearchByVaraajaAsync(user);

        naytaPoistaModal = false;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpContextAccessor httpContextAccessor { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IlmoittautuminenService IlmoittautuminenService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IlmoSearchService IlmoSearchService { get; set; }
    }
}
#pragma warning restore 1591
