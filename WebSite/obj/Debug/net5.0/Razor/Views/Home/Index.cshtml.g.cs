#pragma checksum "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "977c24d3063213097ba1484c8beef3630511095a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(WebSite.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"977c24d3063213097ba1484c8beef3630511095a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bab4879c651ac470e4594aaa22e3a0c9a836e21", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Giorgi\Desktop\Stuffs\Practice\MarsLand\WebSite\Views\Home\Index.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<main>
    <!-- The Modal -->
    <div id=""myModal"" class=""modal"">

        <!-- Modal content -->
        <div class=""modal-content"">
            <span class=""close"">&times;</span>
            <p>This Website is in developing mode, so make sure to use Desktop version of this site in order to nicely display things.</p>
        </div>

    </div>
</main>


<script>
    // Get the modal
    var modal = document.getElementById(""myModal"");


    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName(""close"")[0];

    if (document.readyState === 'loading' || document.readyState === 'complete') {
        modal.style.display = ""block"";
    }



    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = ""none"";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.");
            WriteLiteral("style.display = \"none\";\r\n        }\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591