#pragma checksum "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "666d05c9d6f93327321e991a27a41595fcdf9e89"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__IndividualProductCard), @"mvc.1.0.view", @"/Views/Shared/_IndividualProductCard.cshtml")]
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
#line 1 "C:\Users\admin\source\repos\Mag2\Mag2\Views\_ViewImports.cshtml"
using Mag2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\admin\source\repos\Mag2\Mag2\Views\_ViewImports.cshtml"
using Mag2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"666d05c9d6f93327321e991a27a41595fcdf9e89", @"/Views/Shared/_IndividualProductCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e8d74ad21a59df852c40e5cb68dd359f4535ba0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__IndividualProductCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Mag2.Models.Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark form-control btn-sm p-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:40px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 40, "\"", 115, 5);
            WriteAttributeValue("", 48, "col-lg-4", 48, 8, true);
            WriteAttributeValue(" ", 56, "col-md-6", 57, 9, true);
            WriteAttributeValue(" ", 65, "pb-4", 66, 5, true);
            WriteAttributeValue(" ", 70, "filter", 71, 7, true);
#nullable restore
#line 4 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
WriteAttributeValue(" ", 77, Model.Category.Name.Replace(' ','_'), 78, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <!-- Card-->\r\n        <div class=\"card bg-white rounded shadow-sm\" style=\"border: 1px solid #222;width:300px\" >\r\n            \r\n            <div class=\"card-body px-3 pt-3 pb-1 row\">\r\n                <div class=\"col-7\"><label class=\"float-left\">");
#nullable restore
#line 9 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
                                                        Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label></div>\r\n                <div class=\"col-5\"><label class=\"float-right\"><span class=\"text-info h5\">");
#nullable restore
#line 10 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
                                                                                    Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> /&#8381 </label> </div>\r\n            </div>\r\n\r\n            <img class=\"card-img-top img-thumbnail d-block mx-auto mb-3 \" style=\"border-radius: 15px 15px\"");
            BeginWriteAttribute("src", " src=\"", 660, "\"", 697, 2);
#nullable restore
#line 13 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
WriteAttributeValue("", 666, WebConst.ImagePath, 666, 19, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
WriteAttributeValue("", 685, Model.Image, 685, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n            \r\n            <div class=\"card-body p-1 px-3 row \">\r\n\r\n                <div class=\"col-6\">\r\n                    <span class=\"badge p-2 border w-100\" style=\"border-radius: 0px 15px; background-color: lavenderblush\">");
#nullable restore
#line 18 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
                                                                                                                     Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                \r\n                <div class=\"col-6 border-0\">\r\n                    <span class=\"badge p-2 border w-100\" style=\"border-radius: 15px 0px; background-color: aliceblue\">");
#nullable restore
#line 22 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
                                                                                                                 Write(Model.ApplicationType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n\r\n                <div class=\"col-12 pt-2\" style=\"font-size:13px; text-align:justify\">\r\n                    <p> ");
#nullable restore
#line 26 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
                   Write(Model.ShortDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n\r\n\r\n\r\n                <div class=\"col-12 p-1\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "666d05c9d6f93327321e991a27a41595fcdf9e898227", async() => {
                WriteLiteral("View Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 32 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Shared\_IndividualProductCard.cshtml"
                                              WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Mag2.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
