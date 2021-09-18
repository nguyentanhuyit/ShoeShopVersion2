#pragma checksum "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00abba9fc6bdd1b8cb5cf3c4bc0af191b80b2532"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminOrder_Edit), @"mvc.1.0.view", @"/Views/AdminOrder/Edit.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\NETProject\Shoe\Shoe\Views\_ViewImports.cshtml"
using Shoe;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\NETProject\Shoe\Shoe\Views\_ViewImports.cshtml"
using Shoe.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00abba9fc6bdd1b8cb5cf3c4bc0af191b80b2532", @"/Views/AdminOrder/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30e66222d0b7d0ae75b48f05edee326a5b8e373b", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminOrder_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Shoe.Models.DBModels.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
  
    Layout = "_LayoutAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<button style=\"color:darkblue\">");
#nullable restore
#line 6 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
                          Write(Html.ActionLink("Back", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\n<div style=\"text-align:center\">\n    <h2>Edit status order</h2>\n</div>\n\n");
#nullable restore
#line 11 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
                            
    List<SelectListItem> listSelect = new List<SelectListItem>();
    listSelect.Add(new SelectListItem { Value = "1", Text = "Waiting for confirmation" });
    listSelect.Add(new SelectListItem { Value = "2", Text = "Being shipped" });
    listSelect.Add(new SelectListItem { Value = "3", Text = "Delivered" });
    listSelect.Add(new SelectListItem { Value = "4", Text = "Cancelled" });

#line default
#line hidden
#nullable disable
            WriteLiteral("    <hr />\n");
#nullable restore
#line 20 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\n        <tr>\n            <td>Status</td>\n\n            <td>\n                ");
#nullable restore
#line 28 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.DropDownListFor(model => model.Status, listSelect, "Choose a status"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 29 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.ValidationMessageFor(model => model.Status, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                User name\n            </td>\n            <td>\n                ");
#nullable restore
#line 37 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.DisplayFor(modelItem => Model.User.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Receiver name\n            </td>\n            <td>\n                ");
#nullable restore
#line 45 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.DisplayFor(modelItem => Model.ReceiveName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Address delivery\n            </td>\n            <td>\n                ");
#nullable restore
#line 53 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.DisplayFor(modelItem => Model.AddressDelivery));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Phone\n            </td>\n            <td>\n                ");
#nullable restore
#line 61 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.DisplayFor(modelItem => Model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Payment\n            </td>\n            <td>\n");
#nullable restore
#line 69 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
                  string payment = "";
                    if (Model.Payment == 0)
                    {
                        payment = "COD";
                    }
                    if (Model.Payment == 1)
                    {
                        payment = "Online";
                    }

                

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 80 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.DisplayFor(modelItem => payment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Message\n            </td>\n            <td>\n                ");
#nullable restore
#line 88 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.DisplayFor(modelItem => Model.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Total price\n            </td>\n            <td>\n                ");
#nullable restore
#line 96 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"
           Write(Html.DisplayFor(modelItem => Model.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </td>
        </tr>
    </table>
    <div style=""text-align:center"">
        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10"">
                <input type=""submit"" value=""Save"" class=""btn btn-default"" style=""color:darkblue"" />
            </div>
        </div>
    </div>
");
#nullable restore
#line 107 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Edit.cshtml"

}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shoe.Models.DBModels.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
