#pragma checksum "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9e0d157f5897f267f537055aff0109c2488c967"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminOrder_Details), @"mvc.1.0.view", @"/Views/AdminOrder/Details.cshtml")]
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
#nullable restore
#line 10 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
using Shoe.Models.DBModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9e0d157f5897f267f537055aff0109c2488c967", @"/Views/AdminOrder/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30e66222d0b7d0ae75b48f05edee326a5b8e373b", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminOrder_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Shoe.Models.DBModels.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
  
    Layout = "_LayoutAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral("<link rel=\"stylesheet\" href=\"https://www.w3schools.com/w3css/4/w3.css\">\n<style>\n    .mySlides {\n        display: none;\n    }\n</style>\n");
#nullable restore
#line 12 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
  int? totalPrice = 0; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n    <button style=\"color:darkblue\">");
#nullable restore
#line 15 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                              Write(Html.ActionLink("Back", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button>
    <div style=""text-align:center"">
        <h2>Order details</h2>
    </div>

    <hr />
    <table class=""table"">
        <tr>
            <th style=""text-align:center"">
                Information
            </th>
            <th style=""text-align:center"">
                Products
            </th>
        </tr>
        <tr>
            <td>
                <table class=""table"">
                    <tr>
                        <td>
                            ID
                        </td>
                        <td>
                            ");
#nullable restore
#line 38 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            User name\n                        </td>\n                        <td>\n");
#nullable restore
#line 46 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                              User user = (User)ViewData["User"];

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 47 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(model => user.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            Receive name\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 55 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(model => model.ReceiveName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            Address delivery\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 63 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(model => model.AddressDelivery));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            Phone\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 71 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            Payment\n                        </td>\n                        <td>\n");
#nullable restore
#line 79 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
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
            WriteLiteral("                            ");
#nullable restore
#line 90 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => payment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            Message\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 98 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Message));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            Paid\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 106 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(model => model.Paid));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            Date created\n                        </td>\n                        <td>\n                            ");
#nullable restore
#line 114 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(model => model.DateCreated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                        </td>\n                    </tr>\n                    <tr>\n                        <td>\n                            Status\n                        </td>\n                        <td>\n");
#nullable restore
#line 122 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                              string status = "";
                                if (Model.Status == 1)
                                {
                                    status = "Waiting for confirmation";
                                }
                                if (Model.Status == 2)
                                {
                                    status = "Being shipped";
                                }
                                if (Model.Status == 3)
                                {
                                    status = "Delivered";
                                }
                                if (Model.Status == 4)
                                {
                                    status = "Cancelled";
                                }
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
#nullable restore
#line 140 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => status));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table class=""table"">
                    <tr>
                        <th>
                            Product name
                        </th>
                        <th>
                            Price
                        </th>
                        <th>
                            Quality
                        </th>
                    </tr>
");
#nullable restore
#line 158 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                     foreach (var item in (List<Product>) ViewData["Products"])
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\n                            <td>\n                                ");
#nullable restore
#line 162 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                           Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </td>\n\n                            <td>\n                                ");
#nullable restore
#line 166 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                           Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </td>\n\n");
#nullable restore
#line 169 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                              
                                List<ShoeSizeDetail> ssds = (List<ShoeSizeDetail>)ViewData["ShoeSizeDetails"];
                                ShoeSizeDetail ssd = ssds.Find(s => s.ProductId == item.ProductId);
                                OrderDetail odd = new shoeContext().OrderDetails.Where(o => o.OrderId == Model.Id & o.ShoeSizeId == ssd.Id).FirstOrDefault();
                                totalPrice += item.Price * odd.Quantity;
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\n                                ");
#nullable restore
#line 176 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                           Write(odd.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                            </td>\n                        </tr>\n");
#nullable restore
#line 179 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <tr>
                    <td>
                        <table class=""table"">
                            <tr>
                                <td>
                                    Total price:
                                </td>
                                <td>
                                    ");
#nullable restore
#line 188 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                               Write(Html.DisplayFor(model => totalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </td>
                            </tr>                     
                        </table>
                    </td>
                </tr>
                </table>
            </td>
        </tr>
    </table>
    
</div>
<div style=""text-align:center"">
    <p>
        <button style=""color:darkblue"">");
#nullable restore
#line 202 "D:\NETProject\Shoe\Shoe\Views\AdminOrder\Details.cshtml"
                                  Write(Html.ActionLink("Update Status", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</button>

    </p>
    </div>
    <script>
        var slideIndex = 1;
        showDivs(slideIndex);

        function plusDivs(n) {
            showDivs(slideIndex += n);
        }

        function showDivs(n) {
            var i;
            var x = document.getElementsByClassName(""mySlides"");
            if (n > x.length) { slideIndex = 1 }
            if (n < 1) { slideIndex = x.length }
            for (i = 0; i < x.length; i++) {
                x[i].style.display = ""none"";
            }
            x[slideIndex - 1].style.display = ""block"";
        }
    </script>
");
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