#pragma checksum "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a1ca9bf77f2ea72e6578d9c541e43bafe08e7f6a"
// <auto-generated/>
#pragma warning disable 1591
namespace MeterAfrica.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
#line 3 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
using MeterAfrica.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
using Syncfusion.Blazor.Notifications;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MeterAfrica.Shared.TokenLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/urbanshelter")]
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
            __builder.OpenElement(13, "span");
            __builder.AddAttribute(14, "class", "pull-left");
            __builder.AddMarkupContent(15, " <text style=\"color:orangered\"></text>");
            __builder.AddContent(16, 
#nullable restore
#line 19 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                                               errorMsg

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n                ");
            __builder.OpenElement(18, "span");
            __builder.AddAttribute(19, "class", "pull-right");
            __builder.AddContent(20, " ");
            __builder.OpenElement(21, "strong");
            __builder.AddMarkupContent(22, "₦");
            __builder.AddContent(23, 
#nullable restore
#line 20 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                    meter.amount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddContent(24, " ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n            ");
            __builder.AddMarkupContent(27, "<div class=\"text-center payment-details text-white py-3 my-3\">\r\n                PAYMENT DETAILS\r\n            </div>\r\n            ");
            __builder.OpenElement(28, "div");
            __builder.AddMarkupContent(29, "\r\n                ");
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "form-group px-2 py-2");
            __builder.AddMarkupContent(32, "\r\n                    ");
            __builder.AddMarkupContent(33, "<label class=\"pl-2 mb-0\"><strong>Merchant</strong> </label>\r\n                    ");
            __builder.OpenElement(34, "select");
            __builder.AddAttribute(35, "class", "form-control border-0");
            __builder.AddAttribute(36, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 28 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                   meter.discoRef

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(37, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.discoRef = __value, meter.discoRef));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddMarkupContent(38, "\r\n                        ");
            __builder.OpenElement(39, "option");
            __builder.AddAttribute(40, "selected", "selected");
            __builder.AddAttribute(41, "value", "5");
            __builder.AddContent(42, "Select Merchant");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n");
#nullable restore
#line 30 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                         foreach (var item in GetIDiscoObjects)
                        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(44, "                            ");
            __builder.OpenElement(45, "option");
            __builder.AddAttribute(46, "value", 
#nullable restore
#line 32 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                            item.Ref

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(47, 
#nullable restore
#line 32 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                       item.Name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n");
#nullable restore
#line 33 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(49, "                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n                ");
            __builder.OpenElement(52, "div");
            __builder.AddAttribute(53, "class", "form-group px-2 py-2");
            __builder.AddMarkupContent(54, "\r\n                    ");
            __builder.AddMarkupContent(55, "<label class=\"pl-2 mb-0\"><strong>Meter Number</strong> </label>\r\n                    ");
            __builder.OpenElement(56, "input");
            __builder.AddAttribute(57, "type", "text");
            __builder.AddAttribute(58, "class", "form-control border-0");
            __builder.AddAttribute(59, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 38 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                    meter.meterRef

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(60, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.meterRef = __value, meter.meterRef));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(61, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n\r\n                ");
            __builder.OpenElement(63, "div");
            __builder.AddAttribute(64, "class", "form-group pl-2 py-2");
            __builder.AddMarkupContent(65, "\r\n                    ");
            __builder.AddMarkupContent(66, "<label class=\"pl-2\"><strong>Phone Number</strong> </label>\r\n\r\n                    ");
            __builder.OpenElement(67, "input");
            __builder.AddAttribute(68, "type", "text");
            __builder.AddAttribute(69, "class", "form-control border-0");
            __builder.AddAttribute(70, "placeholder", "Enter your phone number");
            __builder.AddAttribute(71, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 44 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                                                  meter.customerPhone

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(72, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.customerPhone = __value, meter.customerPhone));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(73, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n                ");
            __builder.OpenElement(75, "div");
            __builder.AddAttribute(76, "class", "form-group pl-2 py-2");
            __builder.AddMarkupContent(77, "\r\n                    ");
            __builder.AddMarkupContent(78, "<label class=\"pl-2\"><strong>Email Address</strong> </label>\r\n\r\n                    ");
            __builder.OpenElement(79, "input");
            __builder.AddAttribute(80, "type", "email");
            __builder.AddAttribute(81, "class", "form-control border-0");
            __builder.AddAttribute(82, "placeholder", "Enter Mail");
            __builder.AddAttribute(83, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 49 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                     meter.customerEmail

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(84, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.customerEmail = __value, meter.customerEmail));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(85, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                ");
            __builder.OpenElement(87, "div");
            __builder.AddAttribute(88, "class", "form-group pl-2 py-2");
            __builder.AddMarkupContent(89, "\r\n                    ");
            __builder.AddMarkupContent(90, "<label class=\"pl-2\"><strong>Amount</strong> </label>\r\n\r\n                    ");
            __builder.OpenElement(91, "input");
            __builder.AddAttribute(92, "type", "number");
            __builder.AddAttribute(93, "class", "form-control border-0");
            __builder.AddAttribute(94, "placeholder", "Amount Of power in naira");
            __builder.AddAttribute(95, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 54 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                      meter.amount

#line default
#line hidden
#nullable disable
            , culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.AddAttribute(96, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.amount = __value, meter.amount, culture: global::System.Globalization.CultureInfo.InvariantCulture));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(98, "\r\n                ");
            __builder.OpenElement(99, "div");
            __builder.AddAttribute(100, "class", "form-group pl-2 py-2");
            __builder.AddMarkupContent(101, "\r\n                    ");
            __builder.OpenElement(102, "button");
            __builder.AddAttribute(103, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 57 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                      ValidateMeter

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(104, "class", "btn btn-yellow btn-block btn-rounded");
            __builder.AddMarkupContent(105, "<text style=\"font-size:70%\">Proceed to Start Payment</text>");
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(107, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(108, "\r\n\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(109, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(110, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 68 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
      
    SfToast ToastObj;
    private string ToastPosition = "center";

    private MeterValidateReq meter = new MeterValidateReq();
    private string errorMsg { get; set; }
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
        try
        {
            store.Amount = meter.amount;
            store.Email = meter.customerEmail;

            var response = await _meterService.ValidateMeter(meter);


            if (response.Status)
            {
                store.TransToken = response.Data.data.transactionRef;
                store.MeterName = response.Data.data.fullName;
                NavManager.NavigateTo("/charge");
            }
            else
            {
                errorMsg = response.Message;
                meter = new MeterValidateReq();
                var toast = new ToastModel { Title = "Error!", Content = "Invalid Meter", CssClass = "e-toast-danger", Icon = "e-error toast-icons" };
                await this.ToastObj.Show(toast);
            }
        }
        catch (Exception ex)
        {

            throw;
        }

    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Blazored.SessionStorage.ISessionStorageService sessionStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MeterAfrica.Data.MeterAfricaServices.ProcessMeterService _meterService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Data.UIStoreEntity store { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
