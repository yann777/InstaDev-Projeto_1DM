#pragma checksum "C:\Users\User\OneDrive\Área de Trabalho\InstaDev-Projeto_1DM\Views\Perfil\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e77bf523c5265feda7dd4f9741b355c76fcad299"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Perfil_index), @"mvc.1.0.view", @"/Views/Perfil/index.cshtml")]
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
#line 1 "C:\Users\User\OneDrive\Área de Trabalho\InstaDev-Projeto_1DM\Views\_ViewImports.cshtml"
using InstaDev_Projeto_1DM;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\OneDrive\Área de Trabalho\InstaDev-Projeto_1DM\Views\_ViewImports.cshtml"
using InstaDev_Projeto_1DM.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e77bf523c5265feda7dd4f9741b355c76fcad299", @"/Views/Perfil/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d08ce984e7ec58e67bf2c1fbecdafb602c2d537", @"/Views/_ViewImports.cshtml")]
    public class Views_Perfil_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Cadastro>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\User\OneDrive\Área de Trabalho\InstaDev-Projeto_1DM\Views\Perfil\index.cshtml"
  
    ViewData["Title"] = "Perfil";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<header>\r\n        <div class=\"logo\"><img src=\"../images/Instadev.svg\"");
            BeginWriteAttribute("alt", " alt=\"", 130, "\"", 136, 0);
            EndWriteAttribute();
            WriteLiteral(@"></div>
        <div class=""search-box"">
         <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-search"" viewBox=""0 0 16 16""><path d=""M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z""/></svg>
            <input type=""search"" name=""pesquisar"" id=""pesquisa"" placeholder=""Pesquisar""><i class=""bi bi-search""></i>
        </div><!--barra de pesquisa-->
        <div class=""info-perfil"">
            <ul class=""icons"">
                <li><a href=""../Home""><img src=""../images/house.svg""");
            BeginWriteAttribute("alt", " alt=\"", 811, "\"", 817, 0);
            EndWriteAttribute();
            WriteLiteral("></a></li>\r\n                <li><a href=\"#\"><img src=\"../images/plane 1.svg\"");
            BeginWriteAttribute("alt", " alt=\"", 894, "\"", 900, 0);
            EndWriteAttribute();
            WriteLiteral("></a></li>\r\n                <li><a href=\"#\"><img src=\"../images/compass 1.svg\"");
            BeginWriteAttribute("alt", " alt=\"", 979, "\"", 985, 0);
            EndWriteAttribute();
            WriteLiteral("></a></li>\r\n                <li><a href=\"#\"><img src=\"../images/heart.svg\"");
            BeginWriteAttribute("alt", " alt=\"", 1060, "\"", 1066, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a></li>
                <li onclick=""botaoMenu()"" class=""perfil2""><a  class=""perfil"" href=""../Perfil""></a></li>
                <ul class=""menu-perfil"" id=""menu-perfil"">
                    <li><a href=""../Perfil"">Perfil</a></li>
                    <li><a href=""#"">Sair</a></li>
                </ul>
            </ul>          
        </div>

</header>

<div class=""container"">
    <div class=""infos-perfil"">
        <div class=""foto-perfil"">

        </div>
            <div class=""info"">
                <p>Username</p>
                <div class=""seguidores"">
                    <p>publicações</p>
                    <p>seguindo</p>
                    <p>seguidores</p>
                </div>
            <div class=""usuario"">
                <h5>Enzzo Lima<!--Nome do perfil--></h5>
                <a href=""#"">Sair</a>
                <a href=""#"">Editar perfil</a>
            </div>
        </div>
    </div>
    <div class=""publicacoes"">
       <h4>PUBLICAÇÕES</h4>
          ");
            WriteLiteral(@"  <div class=""publicacao"">
                <div class=""imagem"">

                </div>
                <div class=""info-publicacao"">
                        <div class=""imagemperfilpublicacao"">

                        </div>
                        <div class=""nomeelocalizacao"">
                            <p>Enzzo Lima<!--NomeCompleto--></p>
                            <a href=""#""><p>São Paulo, Brasil<!--Localização--></p></a>
                        </div>
                        <div class=""icons-publicacao"">         
                                <img src=""../images/heart.svg"" alt=""Curtir"">
                                <img src=""../images/Comentarios.svg"" alt=""Comentarios"">
                        </div>
                        <div class=""curtidas"">
                            <p>200 Curtidas</p>
                        </div>
                        <div class=""comentarios"">
                            <div class=""comentarios-pessoas"">
                                <a href=");
            WriteLiteral(@"""#"">fausto_silva<!--nome de usuarios--></a>
                                <p>Oloco bixo!<!--comentario de algum usuario--></p>
                                <img src=""../images/heart.svg"" alt=""Curtir"">
                            </div>
                        </div>
                </div>
                </div>
            </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Cadastro> Html { get; private set; }
    }
}
#pragma warning restore 1591
