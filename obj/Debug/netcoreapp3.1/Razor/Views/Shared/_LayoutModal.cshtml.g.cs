#pragma checksum "C:\Users\Navas\Desktop\HEROKO\ecommerce22.06.2020GABRIELNAVAS__VARIAS FOTOS_PROJETO_ATUAL_COM_MODAL\Views\Shared\_LayoutModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e19fb3f9645840db6b5ddba729d9b3abd610ca2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LayoutModal), @"mvc.1.0.view", @"/Views/Shared/_LayoutModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e19fb3f9645840db6b5ddba729d9b3abd610ca2", @"/Views/Shared/_LayoutModal.cshtml")]
    public class Views_Shared__LayoutModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Navas\Desktop\HEROKO\ecommerce22.06.2020GABRIELNAVAS__VARIAS FOTOS_PROJETO_ATUAL_COM_MODAL\Views\Shared\_LayoutModal.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e19fb3f9645840db6b5ddba729d9b3abd610ca23076", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <title>");
#nullable restore
#line 12 "C:\Users\Navas\Desktop\HEROKO\ecommerce22.06.2020GABRIELNAVAS__VARIAS FOTOS_PROJETO_ATUAL_COM_MODAL\Views\Shared\_LayoutModal.cshtml"
      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <!-- Font Awesome -->
    <link rel=""stylesheet"" href=""/template/plugins/fontawesome-free/css/all.min.css"">
    <!-- Ionicons -->
    <link rel=""stylesheet"" href=""https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css"">
    <!-- Tempusdominus Bbootstrap 4 -->
    <link rel=""stylesheet"" href=""/template/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"">
    <!-- iCheck -->
    <link rel=""stylesheet"" href=""/template/plugins/icheck-bootstrap/icheck-bootstrap.min.css"">
    <!-- JQVMap -->
    <link rel=""stylesheet"" href=""/template/plugins/jqvmap/jqvmap.min.css"">
    <!-- Theme style -->
    <link rel=""stylesheet"" href=""/template/dist/css/adminlte.min.css"">
    <!-- overlayScrollbars -->
    <link rel=""stylesheet"" href=""/template/plugins/overlayScrollbars/css/OverlayScrollbars.min.css"">
    <!-- Daterange picker -->");
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""/template/plugins/daterangepicker/daterangepicker.css"">
    <!-- summernote -->
    <link rel=""stylesheet"" href=""/template/plugins/summernote/summernote-bs4.css"">
    <!-- Google Font: Source Sans Pro -->
    <link href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700"" rel=""stylesheet"">


    ");
#nullable restore
#line 37 "C:\Users\Navas\Desktop\HEROKO\ecommerce22.06.2020GABRIELNAVAS__VARIAS FOTOS_PROJETO_ATUAL_COM_MODAL\Views\Shared\_LayoutModal.cshtml"
Write(RenderSection("css", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
#nullable restore
#line 38 "C:\Users\Navas\Desktop\HEROKO\ecommerce22.06.2020GABRIELNAVAS__VARIAS FOTOS_PROJETO_ATUAL_COM_MODAL\Views\Shared\_LayoutModal.cshtml"
Write(RenderSection("js", false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e19fb3f9645840db6b5ddba729d9b3abd610ca26484", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"wrapper\">\r\n        ");
#nullable restore
#line 45 "C:\Users\Navas\Desktop\HEROKO\ecommerce22.06.2020GABRIELNAVAS__VARIAS FOTOS_PROJETO_ATUAL_COM_MODAL\Views\Shared\_LayoutModal.cshtml"
   Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    </div>



    <!-- jQuery -->
    <script src=""/template/plugins/jquery/jquery.min.js""></script>
    <!-- jQuery UI 1.11.4 -->
    <script src=""/template/plugins/jquery-ui/jquery-ui.min.js""></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>$.widget.bridge('uibutton', $.ui.button)</script>
    <!-- Bootstrap 4 -->
    <script src=""/template/plugins/bootstrap/js/bootstrap.bundle.min.js""></script>
    <!-- ChartJS -->
    <script src=""/template/plugins/chart.js/Chart.min.js""></script>
    <!-- Sparkline -->
    <script src=""/template/plugins/sparklines/sparkline.js""></script>
    <!-- JQVMap -->
    <script src=""/template/plugins/jqvmap/jquery.vmap.min.js""></script>
    <script src=""/template/plugins/jqvmap/maps/jquery.vmap.usa.js""></script>
    <!-- jQuery Knob Chart -->
    <script src=""/template/plugins/jquery-knob/jquery.knob.min.js""></script>
    <!-- daterangepicker -->
    <script src=""/template/plugins/moment/moment.min.js""></scr");
                WriteLiteral(@"ipt>
    <script src=""/template/plugins/daterangepicker/daterangepicker.js""></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src=""/template/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js""></script>
    <!-- Summernote -->
    <script src=""/template/plugins/summernote/summernote-bs4.min.js""></script>
    <!-- overlayScrollbars -->
    <script src=""/template/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js""></script>
    <!-- AdminLTE App -->
    <script src=""/template/dist/js/adminlte.js""></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src=""/template/dist/js/pages/dashboard.js""></script>
    <!-- AdminLTE for demo purposes -->
    <script src=""/template/dist/js/demo.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
