#pragma checksum "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4382ea35d59eb3d62f936bcec03c4a000343658"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebSite.Home.Views_Home_Registration), @"mvc.1.0.view", @"/Views/Home/Registration.cshtml")]
namespace WebSite.Home
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
#line 2 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\_ViewImports.cshtml"
using WebSite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\_ViewImports.cshtml"
using WebSite.Models.Comments;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\_ViewImports.cshtml"
using WebSite.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\_ViewImports.cshtml"
using WebSite.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\_ViewImports.cshtml"
using WebSite.Cores;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\_ViewImports.cshtml"
using WebSite.Enums;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4382ea35d59eb3d62f936bcec03c4a000343658", @"/Views/Home/Registration.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bab4879c651ac470e4594aaa22e3a0c9a836e21", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Registration : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ExternalLoginModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ExternalLogin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" form-select"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <div class=""card bg-light"">
        <article class=""card-body mx-auto"" style=""max-width: 400px;"">
            <h4 class=""card-title mt-3 text-center"">Create Account</h4>
            <p class=""text-center"">Get started with your free account</p>


");
#nullable restore
#line 13 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
             if (Model.ExternalLogins.Count != 0)
            {
                foreach (var item in Model.ExternalLogins)
                {

                    if (item.Name == "Google")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4382ea35d59eb3d62f936bcec03c4a0003436586673", async() => {
                WriteLiteral("\r\n                            <div class=\"external-login-div\">\r\n                                <button class=\"btn btn-twitter\" type=\"submit\" name=\"provider\"");
                BeginWriteAttribute("value", " value=\"", 794, "\"", 812, 1);
#nullable restore
#line 22 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
WriteAttributeValue("", 802, item.Name, 802, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <span><i class=\"fab fa-google fa-fw \" aria-hidden=\"true\"></i></span>\r\n                                    ");
#nullable restore
#line 24 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </button>\r\n\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 29 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                         if (TempData["Error"] != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <p>");
#nullable restore
#line 31 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                          Write(TempData["Error"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 32 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                         


                    }
                    if (item.Name == "Facebook")
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4382ea35d59eb3d62f936bcec03c4a00034365810710", async() => {
                WriteLiteral("\r\n                            <div class=\"external-login-div\">\r\n                                <button class=\"btn btn-facebook\" type=\"submit\" name=\"provider\"");
                BeginWriteAttribute("value", " value=\"", 1615, "\"", 1633, 1);
#nullable restore
#line 41 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
WriteAttributeValue("", 1623, item.Name, 1623, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <span><i class=\"fab fa-facebook-f \" aria-hidden=\"true\"></i></span>\r\n                                    ");
#nullable restore
#line 43 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                               Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </button>\r\n\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"


                    }



                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <p class=\"divider-text\">\r\n                <span class=\"bg-light\">OR</span>\r\n            </p>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4382ea35d59eb3d62f936bcec03c4a00034365814014", async() => {
                WriteLiteral(@"
                <div class=""input-group"">
                    <span class=""input-group-text""> <i class=""fa fa-address-book"" aria-hidden=""true""></i></span>
                    <input type=""text"" name=""firstName"" class=""form-control"" placeholder=""First Name"" required>
                    <input type=""text"" name=""lastName"" class=""form-control"" placeholder=""Last Name"" required>
                </div>

                <div class=""input-group"">
                    <span class=""input-group-text""> <i class=""fa fa-user"" aria-hidden=""true""></i> </span>
                    <input name=""Username"" class=""form-control"" placeholder=""Username"" type=""text"" required />
                </div>

                <div class=""input-group"">
                    <span class=""input-group-text""> <i class=""fa fa-envelope"" aria-hidden=""true""></i> </span>
                    <input name=""Email"" class=""form-control"" placeholder=""Email"" type=""email"" required />
                </div>

                <div class=""input-group""");
                WriteLiteral(@">
                    <span class=""input-group-text""> <i class=""fa fa-phone""></i> </span>
                    <span class=""form-control"" style=""max-width: 120px;"">Ge(+995)</span>
                    <input type=""tel"" class=""form-control"" name=""phoneNumber"" placeholder=""555-123-456""
                           pattern=""[9-9]{2}-[5-5]{1}-[0-9]{3}-[0-9]{3}-[0-9]{3}"">
                </div>

                <div class=""input-group"">
                    <span class=""input-group-text""> <i class=""fa fa-birthday-cake"" aria-hidden=""true""></i> </span>
                    <input class=""form-control"" type=""date"" name=""dateOfBirth"">
                    <span class=""input-group-text""> <i class=""fa fa-venus-mars"" aria-hidden=""true""></i> </span>
                    <select name=""Gender"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4382ea35d59eb3d62f936bcec03c4a00034365816246", async() => {
                    WriteLiteral("Gender...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 90 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                         foreach (var item in Enum.GetValues(typeof(GenderEnum)))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4382ea35d59eb3d62f936bcec03c4a00034365818869", async() => {
#nullable restore
#line 92 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                                             Write(item);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                               WriteLiteral(item);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 93 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </select>
                </div>

                <div class=""input-group"">
                    <span class=""input-group-text""> <i class=""fa fa-flag"" aria-hidden=""true""></i> </span>
                    <select name=""Country"" class="" form-select"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4382ea35d59eb3d62f936bcec03c4a00034365821287", async() => {
                    WriteLiteral("Country...");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 101 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                         foreach (var item in Enum.GetValues(typeof(CountryEnum)))
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a4382ea35d59eb3d62f936bcec03c4a00034365823826", async() => {
#nullable restore
#line 103 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                                             Write(item);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 103 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                               WriteLiteral(item);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 104 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Registration.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </select>
                </div>

                <div class=""input-group"">
                    <span class=""input-group-text""> <i class=""fa fa-lock""></i> </span>
                    <input name=""regPassword"" class=""form-control"" placeholder=""Password"" type=""password"" required />
                </div>

                <div class=""input-group"">
                    <span class=""input-group-text""> <i class=""fa fa-lock""></i> </span>
                    <input name=""confirmPassword"" class=""form-control"" placeholder=""Confirm Password"" type=""password"" required />
                </div>
                <div class=""displayRegistrationErrors"" id=""displayErrors"">


                </div>
                <div class=""input-group create-account-btn-div"">
                    <button type=""button"" class=""btn btn-primary btn-block"" id=""register"">Create Account</button>
                </div> <!-- form-group// -->
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </article>\r\n    </div> <!-- card.// -->\r\n\r\n\r\n</main>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ExternalLoginModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591