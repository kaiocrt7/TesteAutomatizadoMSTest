using AutomacaoMaxiprod.Pages;
using OpenQA.Selenium;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Pages
{
    public class Login
    {
        private readonly IWebDriver driver;
        private readonly CadastrarUsuario cadastrarUsuario;
        private readonly Dictionary<string, By> formLogin;
        private readonly By btnEntrar;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            this.cadastrarUsuario = new CadastrarUsuario(driver);

            btnEntrar = By.Name("nextBtn");

            formLogin = new Dictionary<string, By>()
            {
                {"email", By.Name("Email")},
                {"senha", By.Name("Senha")}
            };            
        }
        
        public void AcessarLogin(string _email, string _senha)
        {
            Acao.PreencherCampo(driver, formLogin["email"], _email);
            Acao.PreencherCampo(driver, formLogin["senha"], _senha);

            Acao.Clicar(driver, btnEntrar);

            Thread.Sleep(1200);
            if (!ValidarLogin.Acesso(driver))
            {
                cadastrarUsuario.NovoCadastro();
                cadastrarUsuario.PreencherFormulario();
                cadastrarUsuario.FinalizarCadastro();                
            }
            Thread.Sleep(1500);
        }
    }
}
