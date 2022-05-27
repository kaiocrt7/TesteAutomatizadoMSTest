using OpenQA.Selenium;
using System.Collections.Generic;
using TestMAXIPROD.Util;

namespace AutomacaoMaxiprod.Pages
{
    internal class CadastrarUsuario
    {
        private readonly IWebDriver driver;
        private readonly By btnCadastro;
        private readonly Dictionary<string, By> formCadastro;
        private readonly Dictionary<string, string> cadastro;

        public CadastrarUsuario(IWebDriver driver)
        {
            this.driver = driver;
            btnCadastro = By.ClassName("btnRegistrar");

            cadastro = new Dictionary<string, string>()
            {
                {"nome", "REALIZAR TESTE"},
                {"razao", "Teste Técnico: Analista de testes"},
                {"regime", "Lucro real"},
                {"uf", "GO"},
                {"municipio", "Goiânia"},
                {"telefone", "(62) 981142862"},
                {"email", "testandoinfo222@gmail.com"},
                {"senha", "test@123"},
                {"confirmar", "test@123"}
            };

            formCadastro = new Dictionary<string, By>()
            {
                {"nome", By.Name("Usuario.Nome")},
                {"razao", By.Name("RazaoSocial")},
                {"regime", By.Name("RegimeTributario")},
                {"uf", By.Name("IdUF")},
                {"municipio",  By.Name("Endereco.IdMunicipio")},
                {"telefone", By.Name("Endereco.Telefone1")},
                {"email", By.Name("Usuario.Email")},
                {"senha", By.Name("Usuario.NovaSenha")},
                {"confirmar", By.Name("Usuario.ConfirmaNovaSenha")},
                {"termos", By.Name("AceiteTermoDeUso")}
            };            
        }

        public void NovoCadastro()
        {
            Acao.Clicar(driver, btnCadastro);
        }

        public void PreencherFormulario()
        {
            Acao.PreencherCampo(driver, formCadastro["nome"], cadastro["nome"]);
            Acao.PreencherCampo(driver, formCadastro["razao"], cadastro["razao"]);
            Acao.Selecionar(driver, formCadastro["regime"], cadastro["regime"]);
            Acao.Selecionar(driver, formCadastro["uf"], cadastro["uf"]);
            Thread.Sleep(500);
            Acao.Selecionar(driver, formCadastro["municipio"], cadastro["municipio"]);
            Acao.PreencherCampo(driver, formCadastro["telefone"], cadastro["telefone"]);
            Acao.PreencherCampo(driver, formCadastro["email"], cadastro["email"]);
            Acao.PreencherCampo(driver, formCadastro["senha"], cadastro["senha"]);
            Acao.PreencherCampo(driver, formCadastro["confirmar"], cadastro["confirmar"]);
            Acao.Clicar(driver, formCadastro["termos"]);
        }

        public void FinalizarCadastro()
        {
            Acao.Clicar(driver, By.XPath("//body/div[2]/div[2]/form[1]/div[2]/input[1]"));
        }
    }
}

