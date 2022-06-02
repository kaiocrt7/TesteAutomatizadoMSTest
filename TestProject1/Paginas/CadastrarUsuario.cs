using OpenQA.Selenium;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Pages
{
    internal class CadastrarUsuario
    {
        private readonly IWebDriver driver;
        private readonly Dictionary<string, By> formCadastro;

        public CadastrarUsuario(IWebDriver driver)
        {
            this.driver = driver;
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
        public void PreencherFormulario(string nome, string razao, string regime, string uf, string municipio, string telefone,
            string email, string senha, string confirmar)
        {
            Acao.PreencherCampo(driver, formCadastro["campoNome"], nome);
            Acao.PreencherCampo(driver, formCadastro["campoRazao"], razao);
            Acao.Selecionar(driver, formCadastro["campoRegime"], regime);
            Acao.Selecionar(driver, formCadastro["campoUf"], uf);
            Thread.Sleep(500);
            Acao.Selecionar(driver, formCadastro["campoMunicipio"], municipio);
            Acao.PreencherCampo(driver, formCadastro["campoTelefone"], telefone);
            Acao.PreencherCampo(driver, formCadastro["campoEmail"], email);
            Acao.PreencherCampo(driver, formCadastro["campoSenha"], senha);
            Acao.PreencherCampo(driver, formCadastro["campoConfirmarSenha"], confirmar);
            Acao.Clicar(driver, formCadastro["campoTermos"]);
        }
        // Finalizar o cadastrado do Usuario.
        public void FinalizarCadastro()
        {
            Acao.Clicar(driver, formCadastro["btnCadastrar"]);
        }
    }
}

