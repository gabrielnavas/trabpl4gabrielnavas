#pragma checksum "C:\Users\Navas\Desktop\tentar por modal\ecommerce22.06.2020GABRIELNAVAS__VARIAS FOTOS_PROJETO_ATUAL\Views\CadastrarProduto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c79609e4c9579c2972716a3e9c058b4865138231"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CadastrarProduto_Index), @"mvc.1.0.view", @"/Views/CadastrarProduto/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c79609e4c9579c2972716a3e9c058b4865138231", @"/Views/CadastrarProduto/Index.cshtml")]
    public class Views_CadastrarProduto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/view/CadastrarProduto/index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Navas\Desktop\tentar por modal\ecommerce22.06.2020GABRIELNAVAS__VARIAS FOTOS_PROJETO_ATUAL\Views\CadastrarProduto\Index.cshtml"
  
    ViewData["Title"] = "Cadastrar Produto";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("css", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("js", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c79609e4c9579c2972716a3e9c058b48651382313631", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"
<div class=""col--sm-12 d-flex justify-content-center align-items-center flex-wrap"">

    <div class=""box box-info"">
        <div class=""box-header with-border ml-4"">
            <h3 class=""box-title"">Cadastrar Produto</h3>
            <h4 id=""divMsg""></h4>
        </div>
        <!-- /.box-header -->
        <!-- form start -->
        <div class=""box-body"">
            <form class=""form-horizontal"">

                <div class=""col-8 d-flex justify-content-between align-items-center flex-wrap"">
                    <div class=""col-sm-8"">
                        <div class=""form-group"">
                            <label for=""nome"" class=""col-sm-12"">Nome</label>

                            <div class=""col-sm-12"">
                                <input type=""text"" class=""form-control"" name=""nome"" id=""nome"" placeholder=""Nome..."">
                            </div>
                        </div>
                    </div>

                    <div class=""col-sm-4 "">
                    ");
            WriteLiteral(@"    <div class=""form-group"">
                            <label for=""categoria"" class=""col-sm-12"">Categoria</label>

                            <div class=""col-sm-11"">
                                <select name=""categoria"" id=""categoria"">
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class=""col-sm-3  d-flex justify-content-start align-items-start flex-wrap"">
                        <div class=""form-group"">
                            <label for=""valor"" class=""col-sm-12"">Valor de venda</label>

                            <div class=""col-sm-12"">
                                <input type=""number"" class=""form-control"" name=""valor"" id=""valor""
                                       placeholder=""Valor..."">
                            </div>
                        </div>
                    </div>


                    <div class=""col-sm-3  d-flex justify-content-start align-");
            WriteLiteral(@"items-start flex-wrap"">
                        <div class=""form-group"">
                            <label for=""estoque"" class=""col-sm-12"">Estoque inicial</label>

                            <div class=""col-sm-12"">
                                <input type=""number"" class=""form-control"" name=""estoque"" id=""estoque""
                                       placeholder=""Estoque..."">
                            </div>
                        </div>
                    </div>

                    <div class=""col-sm-2 d-flex justify-content-center align-items-end"">
                        <div class=""form-group"">
                            <label for=""foto"">Fotos do Produto</label> <br />
                            <input type=""file"" id=""foto"" multiple=""multiple"">

                            <p class=""help-block"">Anexar fotos do produto.</p>
                        </div>
                    </div>

                    <div class=""col-sm-12"">
                        <div class=""form-group"">");
            WriteLiteral(@"
                            <label for=""descricao"" class=""col-sm-2"">Descrição</label>

                            <div class=""col-sm-12"">
                                <textarea type=""text"" class=""form-control""
                                          rows=""5""
                                          name=""descricao""
                                          id=""descricao""
                                          placeholder=""Descrição do produto...""></textarea>
                            </div>
                        </div>
                    </div>

                </div>

            </form>
        </div>
        <!-- /.box-body -->
        <div class=""box-footer"">
            <div class=""col-sm-12 d-flex justify-content-start pl-3"">
                <div class=""col-sm-1 mr-3"">
                    <button type=""button"" class=""btn btn-info pull-right""
                            id=""btncadastrar""
                            onclick=""index.btnInserirProduto()"">
             ");
            WriteLiteral("           Cadastrar\r\n                    </button>\r\n                </div>\r\n                <!-- /.box-footer -->\r\n            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n</div>\r\n");
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
