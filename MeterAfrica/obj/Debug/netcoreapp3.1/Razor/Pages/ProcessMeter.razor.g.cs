#pragma checksum "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b253ff211d308fe0fd828a114ff1d1aa75992de3"
// <auto-generated/>
#pragma warning disable 1591
namespace MeterAfrica.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using MeterAfrica;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\_Imports.razor"
using MeterAfrica.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
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
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "paye");
            __builder.AddAttribute(5, "style", "margin-bottom:30px");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "pay-info p-5");
            __builder.AddMarkupContent(9, "\r\n            ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "clearfix");
            __builder.AddMarkupContent(12, "\r\n                ");
            __builder.AddMarkupContent(13, "<span class=\"pull-left\"> <text style=\"color:orangered\"></text></span>\r\n                ");
            __builder.OpenElement(14, "span");
            __builder.AddAttribute(15, "class", "pull-right");
            __builder.AddContent(16, " ");
            __builder.OpenElement(17, "strong");
            __builder.AddMarkupContent(18, "₦");
            __builder.AddContent(19, 
#nullable restore
#line 17 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                    meter.amount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddContent(20, " ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n            ");
            __builder.AddMarkupContent(23, "<div class=\"text-center payment-details text-white py-3 my-3\">\r\n                PAYMENT DETAILS\r\n            </div>\r\n            ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(24);
            __builder.AddAttribute(25, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 22 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                              meter

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(26, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 22 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                    ValidateMeter

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(27, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(28, "\r\n                ");
                __builder2.OpenElement(29, "div");
                __builder2.AddAttribute(30, "class", "form-group px-2 py-2");
                __builder2.AddMarkupContent(31, "\r\n                    ");
                __builder2.AddMarkupContent(32, "<label class=\"pl-2 mb-0\"><strong>Merchant</strong> </label>\r\n                    ");
                __builder2.OpenElement(33, "select");
                __builder2.AddAttribute(34, "class", "form-control border-0");
                __builder2.AddAttribute(35, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 25 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                   meter.discoRef

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(36, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.discoRef = __value, meter.discoRef));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.AddMarkupContent(37, "\r\n                        ");
                __builder2.OpenElement(38, "option");
                __builder2.AddAttribute(39, "selected", "selected");
                __builder2.AddAttribute(40, "value", "5");
                __builder2.AddContent(41, "Select Merchant");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n");
#nullable restore
#line 27 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                         foreach (var item in GetIDiscoObjects)
                        {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(43, "                            ");
                __builder2.OpenElement(44, "option");
                __builder2.AddAttribute(45, "value", 
#nullable restore
#line 29 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                            item.Ref

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(46, 
#nullable restore
#line 29 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                       item.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(47, "\r\n");
#nullable restore
#line 30 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                        }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(48, "                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(49, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(50, "\r\n                ");
                __builder2.OpenElement(51, "div");
                __builder2.AddAttribute(52, "class", "form-group px-2 py-2");
                __builder2.AddMarkupContent(53, "\r\n                    ");
                __builder2.AddMarkupContent(54, "<label class=\"pl-2 mb-0\"><strong>Meter Number</strong> </label>\r\n                    ");
                __builder2.OpenElement(55, "input");
                __builder2.AddAttribute(56, "type", "text");
                __builder2.AddAttribute(57, "class", "form-control border-0");
                __builder2.AddAttribute(58, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 35 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                    meter.meterRef

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(59, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.meterRef = __value, meter.meterRef));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(60, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(61, "\r\n\r\n                ");
                __builder2.OpenElement(62, "div");
                __builder2.AddAttribute(63, "class", "form-group pl-2 py-2");
                __builder2.AddMarkupContent(64, "\r\n                    ");
                __builder2.AddMarkupContent(65, "<label class=\"pl-2\"><strong>Phone Number</strong> </label>\r\n\r\n                    ");
                __builder2.OpenElement(66, "input");
                __builder2.AddAttribute(67, "type", "text");
                __builder2.AddAttribute(68, "class", "form-control border-0");
                __builder2.AddAttribute(69, "placeholder", "Enter your phone number");
                __builder2.AddAttribute(70, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 41 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                                                  meter.customerPhone

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(71, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.customerPhone = __value, meter.customerPhone));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(72, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(73, "\r\n                ");
                __builder2.OpenElement(74, "div");
                __builder2.AddAttribute(75, "class", "form-group pl-2 py-2");
                __builder2.AddMarkupContent(76, "\r\n                    ");
                __builder2.AddMarkupContent(77, "<label class=\"pl-2\"><strong>Email Address</strong> </label>\r\n\r\n                    ");
                __builder2.OpenElement(78, "input");
                __builder2.AddAttribute(79, "type", "email");
                __builder2.AddAttribute(80, "class", "form-control border-0");
                __builder2.AddAttribute(81, "placeholder", "Enter Mail");
                __builder2.AddAttribute(82, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 46 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                     meter.customerEmail

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(83, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.customerEmail = __value, meter.customerEmail));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(84, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(85, "\r\n                ");
                __builder2.OpenElement(86, "div");
                __builder2.AddAttribute(87, "class", "form-group pl-2 py-2");
                __builder2.AddMarkupContent(88, "\r\n                    ");
                __builder2.AddMarkupContent(89, "<label class=\"pl-2\"><strong>Amount</strong> </label>\r\n\r\n                    ");
                __builder2.OpenElement(90, "input");
                __builder2.AddAttribute(91, "type", "number");
                __builder2.AddAttribute(92, "class", "form-control border-0");
                __builder2.AddAttribute(93, "placeholder", "Amount Of power in naira");
                __builder2.AddAttribute(94, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 51 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                      meter.amount

#line default
#line hidden
#nullable disable
                , culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.AddAttribute(95, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.amount = __value, meter.amount, culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(96, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(97, "\r\n                ");
                __builder2.AddMarkupContent(98, "<div class=\"form-group pl-2 py-2\">\r\n                    <button type=\"submit\" class=\"btn btn-yellow btn-block btn-rounded\"><text style=\"font-size:70%\">Proceed to Start Payment</text></button>\r\n                </div>\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(99, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(100, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(101, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 61 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
      

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
        await sessionStorage.SetItemAsync("Amount", Convert.ToString(meter.amount));
        await sessionStorage.SetItemAsync("Email", Convert.ToString(meter.customerEmail));

        var response = await _meterService.ValidateMeter(meter);
        if (response.Status)
        {
            NavManager.NavigateTo("/charge");
        }
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MeterAfrica.Data.MeterAfricaServices.ProcessMeterService _meterService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
