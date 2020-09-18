#pragma checksum "C:\OHSU19S\kouluilm\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "425863ddd3e59bbc2e60aa4c7467f4593bf378da"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 8 "C:\OHSU19S\kouluilm\Pages\Index.razor"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 235 "C:\OHSU19S\kouluilm\Pages\Index.razor"
       
    private Koulutus koulutus = new Koulutus();
    private List<Koulutus> koulutukset;
    private Resurssi resurssi = new Resurssi();
    private List<Resurssi> resurssit;
    private List<Varaus> varaukset;
    private List<Ilmoittautuminen> ilmoittautumiset;
    private Ilmoittautuminen ilmo = new Ilmoittautuminen();
    private string selite = "", ilmoMessu = "", user = "";
    private bool naytaOsallistujat = false, naytaOsallistujatModal = false, ilmoittauduDisabled = false, naytaKaavake = false, naytaMenneet = false;

    private async void naytaOsallistujatFunc(int varaus_id, int osallistujaLkm)
    {   
        // Haetaan ilmoittautujat   
        ilmoittautumiset = await IlmoittautuminenService.GetOsallistujatAsync(varaus_id);

        // Haetaan varaukselle paikkalkm
        int resurssi_id = await VarausService.GetResurssiFromVarausAsync(varaus_id);
        Resurssi r = await ResurssiService.GetResurssiByIDAsync(resurssi_id);
        ilmo.PaikkaLkm = r.Paikkalkm;
        ilmo.OsallistujaLkm = osallistujaLkm;

        // DEBUG
        //Console.WriteLine("naytaOsallistujatFunc ilmo.paikkalkm: {0}", ilmo.PaikkaLkm);

        // Mahtuuko mukaan?
        if (ilmo.OsallistujaLkm < ilmo.PaikkaLkm)
        {
            ilmoittauduDisabled = false;
        }
        else
        {
            ilmoittauduDisabled = true;
        }

        // Taulukko osallistujista
        //naytaOsallistujat = !naytaOsallistujat;

        // Modal osallistujista
        naytaOsallistujatModal = true;
        
        ilmo.Linkki_Varaus_ID = varaus_id;
    }

    void OsallistujatPeruuta() => naytaOsallistujatModal = false;
    void Ilmoittaudu() => naytaKaavake = true;

    void KaavakePeruuta()
    {
        naytaKaavake = false;
        ilmoMessu = "";
        ilmo.Nimi = string.Empty;
        ilmo.Yksikko = string.Empty;
        ilmo.Puh = string.Empty;
    }
    async Task KaavakeOK()
    {
        // Tarkastetaan syötetyt kentät
        if (string.IsNullOrWhiteSpace(ilmo.Nimi))
        {            
            ilmoMessu = "Anna ilmoittautujan nimi!";
            return;
        }
        else if (string.IsNullOrWhiteSpace(ilmo.Yksikko))
        {            
            ilmoMessu = "Anna ilmoittautujan yksikkö!";
            return;
        }
        else if (string.IsNullOrWhiteSpace(ilmo.Puh))
        {            
            ilmoMessu = "Anna ilmoittautujan puhnro!";
            return;
        }        

        ilmo.Varaaja = httpContextAccessor.HttpContext.User.Identity.Name;
        if (IlmoittautuminenService.InsertOsallistujaAsync(ilmo))
        {
            //Console.WriteLine("Varaus onnistui!");

            // Piilotetaan dialogi ja haetaan ilmoittautumiset        
            ilmoittautumiset = await IlmoittautuminenService.GetOsallistujatAsync(ilmo.Linkki_Varaus_ID);
            ilmoMessu = "";
            ilmo.Nimi = string.Empty;
            ilmo.Yksikko = string.Empty;
            ilmo.Puh = string.Empty;
            naytaKaavake = false;
            ilmo.OsallistujaLkm++;

            // Päivitä alla oleva osallistujamäärä
            await koulutusMuutos(ilmo.Koulutus_ID.ToString());

            // Mahtuuko mukaan?
            if (ilmo.OsallistujaLkm < ilmo.PaikkaLkm)
            {
                ilmoittauduDisabled = false;
            }
            else
            {
                ilmoittauduDisabled = true;
            }
        }
        else
        {
            //Console.WriteLine("Varaus ei onnistunut!");
            ilmoMessu = "Varaus ei onnistunut!";
        }
    }

    protected override async Task OnInitializedAsync()
    {
        // Haetaan koulutukset ja resurssit
        koulutukset = await KoulutusService.GetKoulutusAsync("=0");
        resurssit = await ResurssiService.GetResurssiAsync();
        
        // Käyttäjän tiedot
        user = httpContextAccessor.HttpContext.User.Identity.Name;
        //var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        //user = authState.User.Identity.Name;
    }

    private async Task koulutusMuutos(string value)
    {
        // Valitaan kyseinen koulutus-olio listalta
        koulutus = koulutukset.Single(k => k.Koulutus_ID == value);
        selite = koulutus.Selite;
        ilmo.Koulutus_ID = int.Parse(value);  // Koulutus ID talteen ilmoittautumis-oliolle

        // Haetaan tilavaraukset asiasanojen mukaisesti valitulle koulutukselle
        // Pilkotaan ensin asia- ja kieltosanat
        string sql = "";
        string[] sanat = koulutus.Asiasanat.Split(' ');

        foreach (string sana in sanat)
        {
            sql += " AND aihe LIKE '%" + sana + "%'";
        }

        if (koulutus.Kieltosanat != null)
        {
            sanat = koulutus.Kieltosanat.Split(' ');
            foreach (string sana in sanat)
            {
                sql += " AND aihe NOT LIKE '%" + sana + "%'";
            }
        }

        // Haetaanko vain tulevat koulutukset        
        if (!naytaMenneet)
        {
            sql += " AND varauspvm >= '" + DateTime.Today.ToString("yyyy-MM-dd") + "'";
        }

        // Koulutuksiin käytettävät resurssit
        string sql2 = "";

        foreach (Resurssi r in resurssit)
        {
            sql2 += r.Resurssi_ID.ToString() + ", ";
        }

        // Haetaan tilavaraukset
        //varaukset = await VarausService.GetVarausAsync(sql, sql2, int.Parse(koulutus.Koulutus_ID));
        varaukset = await VarausService.GetVarausAsync(sql, sql2);

        foreach (Varaus v in varaukset)
        {
            // Lasketaan ilmoittautuneet ja talletetaan olioon
            v.Osallistujat = await IlmoittautuminenService.GetOsallistujatCountAsync(v.Varaus_ID);
        }

        //return Task.CompletedTask;
    }

    private async void PiilotaMenneet()
    {
        naytaMenneet = false;
        await koulutusMuutos(ilmo.Koulutus_ID.ToString());
    }

    private async void NaytaMenneet()
    {
        naytaMenneet = true;
        await koulutusMuutos(ilmo.Koulutus_ID.ToString());
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpContextAccessor httpContextAccessor { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IlmoittautuminenService IlmoittautuminenService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private VarausService VarausService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ResurssiService ResurssiService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private KoulutusService KoulutusService { get; set; }
    }
}
#pragma warning restore 1591
