#pragma checksum "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c54924270bbd6f55e1621bd9a0460d81eb9e04ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminUser_Delete), @"mvc.1.0.view", @"/Views/AdminUser/Delete.cshtml")]
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
#line 2 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
using Shoe.Models.DBModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c54924270bbd6f55e1621bd9a0460d81eb9e04ad", @"/Views/AdminUser/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"30e66222d0b7d0ae75b48f05edee326a5b8e373b", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminUser_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Shoe.Models.DBModels.User>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
   Layout = "_LayoutAdmin"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<h3>Are you sure?</h3>\n<div>\n    <table class=\"table\">\n        <tr>\n            <td>\n                User name\n            </td>\n            <td>\n                ");
#nullable restore
#line 14 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Role\n            </td>\n            <td>\n");
#nullable restore
#line 22 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
                  Role role = (Role)ViewData["Role"];

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 23 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
           Write(Html.DisplayFor(model => role.RoleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n\n        <tr>\n            <td>\n                Gender\n            </td>\n            <td>\n                ");
#nullable restore
#line 32 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Birthday\n            </td>\n            <td>\n                ");
#nullable restore
#line 40 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Birthday));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Email\n            </td>\n            <td>\n                ");
#nullable restore
#line 48 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Phone number\n            </td>\n            <td>\n                ");
#nullable restore
#line 56 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
           Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Address\n            </td>\n            <td>\n                ");
#nullable restore
#line 64 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n        <tr>\n            <td>\n                Verified\n            </td>\n            <td>\n                ");
#nullable restore
#line 72 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
           Write(Html.DisplayFor(model => model.Verified));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n    </table>\n\n");
#nullable restore
#line 77 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
     using (Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-actions no-color\">\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" style=\"color:red\" />\n            <button class=\"btn btn-default\">");
#nullable restore
#line 81 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"
                                       Write(Html.ActionLink("Cancel", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\n        </div>\n");
#nullable restore
#line 83 "D:\NETProject\Shoe\Shoe\Views\AdminUser\Delete.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Shoe.Models.DBModels.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
