#pragma checksum "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2db4ad0616449c75903608cc5a8901f74bc1476"
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
#nullable restore
#line 6 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
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
#line 18 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
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
#line 19 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
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
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(28);
            __builder.AddAttribute(29, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 24 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                              meter

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(30, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 24 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                    ValidateMeter

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(31, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(32, "\r\n                ");
                __builder2.OpenElement(33, "div");
                __builder2.AddAttribute(34, "class", "form-group px-2 py-2");
                __builder2.AddMarkupContent(35, "\r\n                    ");
                __builder2.AddMarkupContent(36, "<label class=\"pl-2 mb-0\"><strong>Merchant</strong> </label>\r\n                    ");
                __builder2.OpenElement(37, "select");
                __builder2.AddAttribute(38, "class", "form-control border-0");
                __builder2.AddAttribute(39, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 27 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                   meter.discoRef

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.discoRef = __value, meter.discoRef));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.AddMarkupContent(41, "\r\n                        ");
                __builder2.OpenElement(42, "option");
                __builder2.AddAttribute(43, "selected", "selected");
                __builder2.AddAttribute(44, "value", "5");
                __builder2.AddContent(45, "Select Merchant");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(46, "\r\n");
#nullable restore
#line 29 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                         foreach (var item in GetIDiscoObjects)
                        {

#line default
#line hidden
#nullable disable
                __builder2.AddContent(47, "                            ");
                __builder2.OpenElement(48, "option");
                __builder2.AddAttribute(49, "value", 
#nullable restore
#line 31 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                            item.Ref

#line default
#line hidden
#nullable disable
                );
                __builder2.AddContent(50, 
#nullable restore
#line 31 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                       item.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(51, "\r\n");
#nullable restore
#line 32 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                        }

#line default
#line hidden
#nullable disable
                __builder2.AddContent(52, "                    ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(53, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(54, "\r\n                ");
                __builder2.OpenElement(55, "div");
                __builder2.AddAttribute(56, "class", "form-group px-2 py-2");
                __builder2.AddMarkupContent(57, "\r\n                    ");
                __builder2.AddMarkupContent(58, "<label class=\"pl-2 mb-0\"><strong>Meter Number</strong> </label>\r\n                    ");
                __builder2.OpenElement(59, "input");
                __builder2.AddAttribute(60, "type", "text");
                __builder2.AddAttribute(61, "class", "form-control border-0");
                __builder2.AddAttribute(62, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 37 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                    meter.meterRef

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(63, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.meterRef = __value, meter.meterRef));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(64, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(65, "\r\n\r\n                ");
                __builder2.OpenElement(66, "div");
                __builder2.AddAttribute(67, "class", "form-group pl-2 py-2");
                __builder2.AddMarkupContent(68, "\r\n                    ");
                __builder2.AddMarkupContent(69, "<label class=\"pl-2\"><strong>Phone Number</strong> </label>\r\n\r\n                    ");
                __builder2.OpenElement(70, "input");
                __builder2.AddAttribute(71, "type", "text");
                __builder2.AddAttribute(72, "class", "form-control border-0");
                __builder2.AddAttribute(73, "placeholder", "Enter your phone number");
                __builder2.AddAttribute(74, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 43 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                                                  meter.customerPhone

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(75, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.customerPhone = __value, meter.customerPhone));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(76, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(77, "\r\n                ");
                __builder2.OpenElement(78, "div");
                __builder2.AddAttribute(79, "class", "form-group pl-2 py-2");
                __builder2.AddMarkupContent(80, "\r\n                    ");
                __builder2.AddMarkupContent(81, "<label class=\"pl-2\"><strong>Email Address</strong> </label>\r\n\r\n                    ");
                __builder2.OpenElement(82, "input");
                __builder2.AddAttribute(83, "type", "email");
                __builder2.AddAttribute(84, "class", "form-control border-0");
                __builder2.AddAttribute(85, "placeholder", "Enter Mail");
                __builder2.AddAttribute(86, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 48 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                     meter.customerEmail

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(87, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.customerEmail = __value, meter.customerEmail));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(88, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(89, "\r\n                ");
                __builder2.OpenElement(90, "div");
                __builder2.AddAttribute(91, "class", "form-group pl-2 py-2");
                __builder2.AddMarkupContent(92, "\r\n                    ");
                __builder2.AddMarkupContent(93, "<label class=\"pl-2\"><strong>Amount</strong> </label>\r\n\r\n                    ");
                __builder2.OpenElement(94, "input");
                __builder2.AddAttribute(95, "type", "number");
                __builder2.AddAttribute(96, "class", "form-control border-0");
                __builder2.AddAttribute(97, "placeholder", "Amount Of power in naira");
                __builder2.AddAttribute(98, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 53 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                                      meter.amount

#line default
#line hidden
#nullable disable
                , culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.AddAttribute(99, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => meter.amount = __value, meter.amount, culture: global::System.Globalization.CultureInfo.InvariantCulture));
                __builder2.SetUpdatesAttributeName("value");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(100, "\r\n                ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(101, "\r\n                ");
                __builder2.AddMarkupContent(102, "<div class=\"form-group pl-2 py-2\">\r\n                    <button type=\"submit\" class=\"btn btn-yellow btn-block btn-rounded\"><text style=\"font-size:70%\">Proceed to Start Payment</text></button>\r\n                </div>\r\n            ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(103, "\r\n\r\n            ");
            __builder.OpenComponent<Syncfusion.Blazor.Notifications.SfToast>(104);
            __builder.AddAttribute(105, "ID", "toast_type");
            __builder.AddAttribute(106, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(107, "\r\n                ");
                __builder2.OpenComponent<Syncfusion.Blazor.Notifications.ToastPosition>(108);
                __builder2.AddAttribute(109, "X", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 61 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                                   ToastPosition

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(110, "\r\n            ");
            }
            ));
            __builder.AddComponentReferenceCapture(111, (__value) => {
#nullable restore
#line 60 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
                           ToastObj = (Syncfusion.Blazor.Notifications.SfToast)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(112, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(113, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 67 "C:\Dev\WebDev\MeterAfrica\MeterAfrica\Pages\ProcessMeter.razor"
      
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
