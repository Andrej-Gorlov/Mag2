#pragma checksum "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
using Mag2_Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27037070e997785fe18886cdccd2e34d4beae154", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Mag2_Models.ViewModels.OrderListVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("field", "Id", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("headerText", "ID", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", "100", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("field", "FullName", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("headerText", "Name", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("field", "Email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("headerText", "Email", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("field", "PhoneNumber", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("headerText", "Phone", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("field", "OrderStatus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("headerText", "Status", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("field", "OrderDate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("headerText", "Order Date", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("headerText", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", "70", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_16 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("template", "<a rel=\'nofollow\' href=\'Order/Details/${Id}\' class=\'btn btn-primary\'> <i class=\'fas fa-list\'></i><a>", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_17 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", "Grid", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Syncfusion.EJ2.Grids.Grid __Syncfusion_EJ2_Grids_Grid;
        private global::Syncfusion.EJ2.Grids.GridFilterSettings __Syncfusion_EJ2_Grids_GridFilterSettings;
        private global::Syncfusion.EJ2.Grids.GridPageSettings __Syncfusion_EJ2_Grids_GridPageSettings;
        private global::Syncfusion.EJ2.Grids.GridColumns __Syncfusion_EJ2_Grids_GridColumns;
        private global::Syncfusion.EJ2.Grids.GridColumn __Syncfusion_EJ2_Grids_GridColumn;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d9123", async() => {
                WriteLiteral(@"
    <div class=""container p-4 my-3"">
        <h2 class=""text-info"">Order Management</h2>
        <div class=""border bg-white p-3"" style=""border-radius:15px;"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""row"" style=""padding-top:10px"">

                        <div class=""col-4"">
                            ");
#nullable restore
#line 12 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
                       Write(Html.Editor("searchName", new { htmlAttributes = new { @class = "form-control", @placeholder = "Name..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n\r\n                        <div class=\"col-4\">\r\n                            ");
#nullable restore
#line 16 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
                       Write(Html.Editor("searchEmail", new { htmlAttributes = new { @class = "form-control", @placeholder = "Email..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n\r\n                        <div class=\"col-4\">\r\n                            ");
#nullable restore
#line 20 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
                       Write(Html.Editor("searchPhone", new { htmlAttributes = new { @class = "form-control", @placeholder = "Phone..." } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n                    <div class=\"row pt-1\">\r\n\r\n                        <div class=\"col-4\">\r\n                            ");
#nullable restore
#line 28 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
                       Write(Html.DropDownListFor(u => u.Status, Model.StatuaList, "--Order Status--", new { @class = "form-select" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        </div>

                        <div class=""offset-4 col-4"">
                            <button type=""submit"" class=""h-100 btn btn-info form-control"">
                                <i class=""fas fa-search""></i>Search
                            </button>
                        </div>

                    </div>

                </div>
            </div>
        </div> 
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<hr/>\r\n\r\n<div class=\"bg-white p-3\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ejs-grid", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d13153", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-filtersettings", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d13424", async() => {
                }
                );
                __Syncfusion_EJ2_Grids_GridFilterSettings = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridFilterSettings>();
                __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridFilterSettings);
#nullable restore
#line 48 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridFilterSettings.Type = global::Syncfusion.EJ2.Grids.FilterType.Menu;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("type", __Syncfusion_EJ2_Grids_GridFilterSettings.Type, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-pagesettings", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d14829", async() => {
                }
                );
                __Syncfusion_EJ2_Grids_GridPageSettings = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridPageSettings>();
                __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridPageSettings);
#nullable restore
#line 49 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridPageSettings.PageSize = 5;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("pageSize", __Syncfusion_EJ2_Grids_GridPageSettings.PageSize, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-columns", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d16191", async() => {
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d16480", async() => {
                    }
                    );
                    __Syncfusion_EJ2_Grids_GridColumn = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridColumn>();
                    __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridColumn);
                    __Syncfusion_EJ2_Grids_GridColumn.Field = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    __Syncfusion_EJ2_Grids_GridColumn.HeaderText = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 51 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridColumn.IsPrimaryKey = true;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("isPrimaryKey", __Syncfusion_EJ2_Grids_GridColumn.IsPrimaryKey, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 51 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridColumn.TextAlign = global::Syncfusion.EJ2.Grids.TextAlign.Right;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("textAlign", __Syncfusion_EJ2_Grids_GridColumn.TextAlign, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __Syncfusion_EJ2_Grids_GridColumn.Width = (string)__tagHelperAttribute_3.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d18928", async() => {
                    }
                    );
                    __Syncfusion_EJ2_Grids_GridColumn = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridColumn>();
                    __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridColumn);
                    __Syncfusion_EJ2_Grids_GridColumn.Field = (string)__tagHelperAttribute_4.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                    __Syncfusion_EJ2_Grids_GridColumn.HeaderText = (string)__tagHelperAttribute_5.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#nullable restore
#line 52 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridColumn.TextAlign = global::Syncfusion.EJ2.Grids.TextAlign.Right;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("textAlign", __Syncfusion_EJ2_Grids_GridColumn.TextAlign, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d20763", async() => {
                    }
                    );
                    __Syncfusion_EJ2_Grids_GridColumn = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridColumn>();
                    __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridColumn);
                    __Syncfusion_EJ2_Grids_GridColumn.Field = (string)__tagHelperAttribute_6.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                    __Syncfusion_EJ2_Grids_GridColumn.HeaderText = (string)__tagHelperAttribute_7.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 54 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridColumn.TextAlign = global::Syncfusion.EJ2.Grids.TextAlign.Right;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("textAlign", __Syncfusion_EJ2_Grids_GridColumn.TextAlign, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d22594", async() => {
                    }
                    );
                    __Syncfusion_EJ2_Grids_GridColumn = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridColumn>();
                    __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridColumn);
                    __Syncfusion_EJ2_Grids_GridColumn.Field = (string)__tagHelperAttribute_8.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
                    __Syncfusion_EJ2_Grids_GridColumn.HeaderText = (string)__tagHelperAttribute_9.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
#nullable restore
#line 55 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridColumn.TextAlign = global::Syncfusion.EJ2.Grids.TextAlign.Right;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("textAlign", __Syncfusion_EJ2_Grids_GridColumn.TextAlign, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d24425", async() => {
                    }
                    );
                    __Syncfusion_EJ2_Grids_GridColumn = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridColumn>();
                    __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridColumn);
                    __Syncfusion_EJ2_Grids_GridColumn.Field = (string)__tagHelperAttribute_10.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
                    __Syncfusion_EJ2_Grids_GridColumn.HeaderText = (string)__tagHelperAttribute_11.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
#nullable restore
#line 56 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridColumn.TextAlign = global::Syncfusion.EJ2.Grids.TextAlign.Right;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("textAlign", __Syncfusion_EJ2_Grids_GridColumn.TextAlign, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d26260", async() => {
                    }
                    );
                    __Syncfusion_EJ2_Grids_GridColumn = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridColumn>();
                    __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridColumn);
                    __Syncfusion_EJ2_Grids_GridColumn.Field = (string)__tagHelperAttribute_12.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
                    __Syncfusion_EJ2_Grids_GridColumn.HeaderText = (string)__tagHelperAttribute_13.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_13);
#nullable restore
#line 57 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridColumn.CustomFormat = (new { type="date", format="MM/dd/yyyy" });

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("customFormat", __Syncfusion_EJ2_Grids_GridColumn.CustomFormat, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 57 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_GridColumn.TextAlign = global::Syncfusion.EJ2.Grids.TextAlign.Right;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("textAlign", __Syncfusion_EJ2_Grids_GridColumn.TextAlign, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n            ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-grid-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38f43ca548deb5a91c9c38ea69bf8a6ed3ca194d28553", async() => {
                        WriteLiteral("\r\n\r\n            ");
                    }
                    );
                    __Syncfusion_EJ2_Grids_GridColumn = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridColumn>();
                    __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridColumn);
                    __Syncfusion_EJ2_Grids_GridColumn.Field = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    __Syncfusion_EJ2_Grids_GridColumn.HeaderText = (string)__tagHelperAttribute_14.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
                    __Syncfusion_EJ2_Grids_GridColumn.Width = (string)__tagHelperAttribute_15.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_15);
                    __Syncfusion_EJ2_Grids_GridColumn.Template = (string)__tagHelperAttribute_16.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_16);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n        ");
                }
                );
                __Syncfusion_EJ2_Grids_GridColumns = CreateTagHelper<global::Syncfusion.EJ2.Grids.GridColumns>();
                __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_GridColumns);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Syncfusion_EJ2_Grids_Grid = CreateTagHelper<global::Syncfusion.EJ2.Grids.Grid>();
            __tagHelperExecutionContext.Add(__Syncfusion_EJ2_Grids_Grid);
            __Syncfusion_EJ2_Grids_Grid.Id = (string)__tagHelperAttribute_17.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_17);
#nullable restore
#line 47 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_Grid.DataSource = Model.OrderHeaderList;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("dataSource", __Syncfusion_EJ2_Grids_Grid.DataSource, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 47 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_Grid.AllowFiltering = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("allowFiltering", __Syncfusion_EJ2_Grids_Grid.AllowFiltering, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 47 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_Grid.AllowSorting = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("allowSorting", __Syncfusion_EJ2_Grids_Grid.AllowSorting, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 47 "C:\Users\admin\source\repos\Mag2\Mag2\Views\Order\Index.cshtml"
__Syncfusion_EJ2_Grids_Grid.AllowPaging = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("allowPaging", __Syncfusion_EJ2_Grids_Grid.AllowPaging, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Mag2_Models.ViewModels.OrderListVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
