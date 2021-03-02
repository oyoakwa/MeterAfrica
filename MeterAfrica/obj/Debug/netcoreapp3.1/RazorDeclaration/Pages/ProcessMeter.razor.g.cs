#pragma checksum "c:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67edabfe251fe177f026811bf08ce606a4dcacd0"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MeterAfrica.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using MeterAfrica;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using MeterAfrica.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
using MeterAfrica.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MeterAfrica.Shared.TokenLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class ProcessMeter : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 61 "c:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
      

    private MeterValidateReq meter = new MeterValidateReq();

    private List<UIDiscoObject> GetIDiscoObjects;

    protected override async Task OnInitializedAsync()
    {
        GetIDiscoObjects = GetDiscos();
    }

    public List<UIDiscoObject> GetDiscos()
    {
        try
        {
            //sessionStorage.SetItemAsync("Amount", Convert.ToString(meter.amount)).Wait();
            var res = _meterService.GetDiscos();
            if (res.status)
            {
                List<UIDiscoObject> objDisco = new List<UIDiscoObject>();
                foreach (var data in res.data)
                {
                    UIDiscoObject s = new UIDiscoObject();
                    s.Ref = data.reference;
                    s.Name = data.name;
                    objDisco.Add(s);
                }
                return objDisco;
            }
            else
            {
                return null;

                // Show Error Notification
            }

        }
        catch (Exception ex)
        {
            return null;
        }
    }


    //45028963390
    public async Task ValidateMeter()
    {
        var response = await _meterService.ValidateMeter(meter);
        if (response.Status)
        {
            NavManager.NavigateTo("/charge");
        }
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MeterAfrica.Data.MeterAfricaServices.ProcessMeterService _meterService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
