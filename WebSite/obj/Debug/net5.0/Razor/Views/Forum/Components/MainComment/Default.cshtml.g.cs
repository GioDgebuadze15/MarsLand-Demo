#pragma checksum "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19d176a9c73a7049a39fa3fc5401a2b89aa984fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebSite.Forum.Components.MainComment.Views_Forum_Components_MainComment_Default), @"mvc.1.0.view", @"/Views/Forum/Components/MainComment/Default.cshtml")]
namespace WebSite.Forum.Components.MainComment
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19d176a9c73a7049a39fa3fc5401a2b89aa984fb", @"/Views/Forum/Components/MainComment/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bab4879c651ac470e4594aaa22e3a0c9a836e21", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Forum_Components_MainComment_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserInfoCollectionViewModel>
    #nullable disable
    {
        private global::WebSite.Forum.Components.MainComment.Views_Forum_Components_MainComment_Default.__Generated__MainCommentButtonViewComponentTagHelper __MainCommentButtonViewComponentTagHelper;
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Profile Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle sm-prof-img com-prof-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Tools/Images/ProfileImageFemaleTemplate.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Tools/Images/ProfileImageMaleTemplate.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserProfileView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("fullname"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
  
    var userId = User.GetUserId();

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
 if (Model.CommentViewModel.MainComments.Count != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("id", " id=\"", 144, "\"", 179, 1);
#nullable restore
#line 7 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 149, Model.CommentViewModel.PostId, 149, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"main-comment-body\">\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
         foreach (var mainComment in Model.CommentViewModel.MainComments.OrderByDescending(x => x.Created))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"comment-body-div\"");
            BeginWriteAttribute("id", " id=\"", 372, "\"", 392, 1);
#nullable restore
#line 11 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 377, mainComment.Id, 377, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <span>\r\n");
#nullable restore
#line 13 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                     if (mainComment.User.UserInfo.ProfileImage != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "19d176a9c73a7049a39fa3fc5401a2b89aa984fb9074", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            BeginWriteTagHelperAttribute();
            WriteLiteral("~/Tools/ProfileImages/");
#nullable restore
#line 15 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                                            WriteLiteral(mainComment.User.UserInfo.ProfileImage.ImageName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("src", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 15 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                    }
                    else
                    {
                        if (mainComment.User.UserInfo.Gender == GenderEnum.Female)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "19d176a9c73a7049a39fa3fc5401a2b89aa984fb12150", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 22 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "19d176a9c73a7049a39fa3fc5401a2b89aa984fb13678", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 26 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </span>\r\n                <div class=\"group-comment-div\">\r\n                    <div class=\"comment-author\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19d176a9c73a7049a39fa3fc5401a2b89aa984fb15302", async() => {
#nullable restore
#line 31 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                                                                                                                              Write(mainComment.User.UserInfo.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 31 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                                                                                                                                                                   Write(mainComment.User.UserInfo.LastName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                                                                                WriteLiteral(mainComment.User.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"comment-text-div\">\r\n                        <div");
            BeginWriteAttribute("id", " id=\"", 1792, "\"", 1812, 1);
#nullable restore
#line 34 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 1797, mainComment.Id, 1797, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"comment-after-edit\">\r\n                            ");
#nullable restore
#line 35 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                       Write(mainComment.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <input type=\"hidden\" name=\"PostId\"");
            BeginWriteAttribute("value", " value=\"", 1952, "\"", 1990, 1);
#nullable restore
#line 36 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 1960, Model.CommentViewModel.PostId, 1960, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("id", " id=\"", 2044, "\"", 2064, 1);
#nullable restore
#line 37 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 2049, mainComment.Id, 2049, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"numOfSubComsInMainCom\"");
            BeginWriteAttribute("value", " value=\"", 2095, "\"", 2135, 1);
#nullable restore
#line 37 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 2103, mainComment.SubComments.Count(), 2103, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                        </div>\r\n                        <div class=\"comment-time-div\">\r\n                            ");
#nullable restore
#line 40 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
                       Write(mainComment.GetTimeDuration());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 2337, "\"", 2360, 1);
#nullable restore
#line 41 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 2345, mainComment.Id, 2345, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"replyMainComment\" />\r\n                            <button");
            BeginWriteAttribute("onclick", " onclick=\"", 2423, "\"", 2467, 3);
            WriteAttributeValue("", 2433, "ShowSubCommentDiv(", 2433, 18, true);
#nullable restore
#line 42 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 2451, mainComment.Id, 2451, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2466, ")", 2466, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"leave-comment-btn\">Reply</button>\r\n\r\n                            <div");
            BeginWriteAttribute("id", " id=\"", 2545, "\"", 2565, 1);
#nullable restore
#line 44 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 2550, mainComment.Id, 2550, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"mainCommBtnDiv\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("vc:main-comment-button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19d176a9c73a7049a39fa3fc5401a2b89aa984fb22777", async() => {
                WriteLiteral("\r\n                                ");
            }
            );
            __MainCommentButtonViewComponentTagHelper = CreateTagHelper<global::WebSite.Forum.Components.MainComment.Views_Forum_Components_MainComment_Default.__Generated__MainCommentButtonViewComponentTagHelper>();
            __tagHelperExecutionContext.Add(__MainCommentButtonViewComponentTagHelper);
#nullable restore
#line 46 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
__MainCommentButtonViewComponentTagHelper.vm = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("vm", __MainCommentButtonViewComponentTagHelper.vm, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 47 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
__MainCommentButtonViewComponentTagHelper.mainCommentId = mainComment.Id;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("main-comment-id", __MainCommentButtonViewComponentTagHelper.mainCommentId, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n\r\n\r\n\r\n                            <div");
            BeginWriteAttribute("id", " id=\"", 2944, "\"", 2964, 1);
#nullable restore
#line 53 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
WriteAttributeValue("", 2949, mainComment.Id, 2949, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"sub-comment-component\" style=\"display:none\">\r\n\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n\r\n\r\n\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 64 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 66 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Forum\Components\MainComment\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserInfoCollectionViewModel> Html { get; private set; } = default!;
        #nullable disable
        [Microsoft.AspNetCore.Razor.TagHelpers.HtmlTargetElementAttribute("vc:main-comment-button")]
        public class __Generated__MainCommentButtonViewComponentTagHelper : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
        {
            private readonly global::Microsoft.AspNetCore.Mvc.IViewComponentHelper __helper = null;
            public __Generated__MainCommentButtonViewComponentTagHelper(global::Microsoft.AspNetCore.Mvc.IViewComponentHelper helper)
            {
                __helper = helper;
            }
            [Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeNotBoundAttribute, global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewContextAttribute]
            public global::Microsoft.AspNetCore.Mvc.Rendering.ViewContext ViewContext { get; set; }
            public WebSite.ViewModels.UserInfoCollectionViewModel vm { get; set; }
            public System.Int32 mainCommentId { get; set; }
            public override async global::System.Threading.Tasks.Task ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput __output)
            {
                (__helper as global::Microsoft.AspNetCore.Mvc.ViewFeatures.IViewContextAware)?.Contextualize(ViewContext);
                var __helperContent = await __helper.InvokeAsync("MainCommentButton", ProcessInvokeAsyncArgs(__context));
                __output.TagName = null;
                __output.Content.SetHtmlContent(__helperContent);
            }
            private Dictionary<string, object> ProcessInvokeAsyncArgs(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext __context)
            {
                Dictionary<string, object> args = new Dictionary<string, object>();
                if (__context.AllAttributes.ContainsName("vm"))
                {
                    args[nameof(vm)] = vm;
                }
                if (__context.AllAttributes.ContainsName("main-comment-id"))
                {
                    args[nameof(mainCommentId)] = mainCommentId;
                }
                return args;
            }
        }
    }
}
#pragma warning restore 1591