using OpenQA.Selenium;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Pages
{
    public class Login
    {
        private readonly IWebDriver driver;
        private readonly CadastrarUsuario cadastrarUsuario;
        private readonly Dictionary<string, By> formLogin;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            this.cadastrarUsuario = new CadastrarUsuario(driver);
            // Dicionario com a chave indicando o elmento e o valor contendo a localização de cada elemento da tela de login.
            formLogin = new Dictionary<string, By>()
            {
                {"campoEmail", By.Name("Email")},
                {"campoSenha", By.Name("Senha")},
                {"btnEntrar",  By.Name("nextBtn")}
            };
        }
        // Realizar o login a aplicação.
        public void AcessarLogin(string _email, string _senha)
        {
            Acao.PreencherCampo(driver, formLogin["campoEmail"], _email);
            Acao.PreencherCampo(driver, formLogin["campoSenha"], _senha);

            Acao.Clicar(driver, formLogin["btnEntrar"]);
            // Validação para identificar se o email ja possui cadastro, caso não possui cadastro o teste irá criar um novo cadastro com o email informado.
            Thread.Sleep(2000);            
        }
        // Validação após a tentativa de logar na aplicação.
        public bool ValidarLogin()
        {
            Thread.Sleep(1500);
            if (driver.PageSource.Contains("simBtn"))
            {
                // Se tiver sessão do usuário em aberto.
                Acao.Clicar(driver, By.Name("simBtn"));
                Thread.Sleep(1700);
                return true;
            }
            else
            if (driver.PageSource.Contains("E-mail e/ou senha inválidos."))
            {
                // Se o email informado não tiver cadastro na aplicação, return false.
                return false;
            }
            return true;            
        }
    }
}
