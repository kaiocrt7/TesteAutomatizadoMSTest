using OpenQA.Selenium;
using TestMAXIPROD.Util;

namespace AutomacaoMaxiprod.Pages
{
    internal class CadastrarUsuario
    {
        private readonly IWebDriver driver;
        private readonly Dictionary<string, By> formCadastro;
        private readonly Dictionary<string, string> cadastroUsuario;

        public CadastrarUsuario(IWebDriver driver)
        {
            this.driver = driver;

            // Dicionario com as informações a serem preenchidas para o cadastro do novo usuário.
            cadastroUsuario = new Dictionary<string, string>()
            {
                {"nome", "Kaio Cesar Alves da Silveira."},
                {"razao", "Teste Técnico: Analista de testes"},
                {"regime", "Lucro real"},
                {"uf", "GO"},
                {"municipio", "Goiânia"},
                {"telefone", "(62) 981142862"},
                //{"email", "testandoinfo222@gmail.com"},
                {"senha", "testando@123"},
                {"confirmar", "testando@123"}
            };
            // Dicidionário contendo a chave com o nome do elemento e o valor com a localização de cada elemento para cadastro do usuário.
            formCadastro = new Dictionary<string, By>()
            {
                {"btnCadastre-se", By.ClassName("btnRegistrar")},
                {"campoNome", By.Name("Usuario.Nome")},
                {"campoRazao", By.Name("RazaoSocial")},
                {"campoRegime", By.Name("RegimeTributario")},
                {"campoUf", By.Name("IdUF")},
                {"campoMunicipio",  By.Name("Endereco.IdMunicipio")},
                {"campoTelefone", By.Name("Endereco.Telefone1")},
                {"campoEmail", By.Name("Usuario.Email")},
                {"campoSenha", By.Name("Usuario.NovaSenha")},
                {"campoConfirmarSenha", By.Name("Usuario.ConfirmaNovaSenha")},
                {"campoTermos", By.Name("AceiteTermoDeUso")},
                {"btnCadastrar",  By.XPath("//body/div[2]/div[2]/form[1]/div[2]/input[1]")}
            };            
        }
        // Clicar no botão Cadastre-se agora.
        public void NovoCadastro()
        {
            Acao.Clicar(driver, formCadastro["btnCadastre-se"]);
        }
        // Preencher o formulario com o email passado pela tela de Login, caso não foi possivel logar pelo email ainda nao estar cadastrado.
        public void PreencherFormulario(string _email)
        {
            Acao.PreencherCampo(driver, formCadastro["campoNome"], cadastroUsuario["nome"]);
            Acao.PreencherCampo(driver, formCadastro["campoRazao"], cadastroUsuario["razao"]);
            Acao.Selecionar(driver, formCadastro["campoRegime"], cadastroUsuario["regime"]);
            Acao.Selecionar(driver, formCadastro["campoUf"], cadastroUsuario["uf"]);
            Thread.Sleep(500);
            Acao.Selecionar(driver, formCadastro["campoMunicipio"], cadastroUsuario["municipio"]);
            Acao.PreencherCampo(driver, formCadastro["campoTelefone"], cadastroUsuario["telefone"]);
            Acao.PreencherCampo(driver, formCadastro["campoEmail"], _email);
            Acao.PreencherCampo(driver, formCadastro["campoSenha"], cadastroUsuario["senha"]);
            Acao.PreencherCampo(driver, formCadastro["campoConfirmarSenha"], cadastroUsuario["confirmar"]);
            Acao.Clicar(driver, formCadastro["campoTermos"]);
        }
        // Finalizar o cadastrado do Usuario.
        public void FinalizarCadastro()
        {
            Acao.Clicar(driver, formCadastro["btnCadastrar"]);
        }
    }
}

