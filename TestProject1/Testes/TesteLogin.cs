using OpenQA.Selenium;
using TestMAXIPROD.Util;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMAXIPROD.Pages;

namespace TestMAXIPROD.Testes
{
    public class TesteLogin
    {
        private IWebDriver driver;
        private Login login;
        [SetUp]
        public void Iniciar()
        {
            driver = ConexaoWebDriver.Iniciar();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sistema.maxiprod.com.br/");

            login = new Login(driver);

            Assert.IsTrue("Login | MAXIPROD".Equals(driver.Title));
        }

        [TestCase("kaioalvarez01223@gmail.com", "testando")]
        [TestCase("kaiocrt7@gmail.com", "testando")]
        public void DadoQueEuTentoAcessarEmailOuSenhaInvalidos(string email, string senha)
        {
            login.AcessarLogin(email, senha);
            Assert.IsFalse(login.ValidarLogin());
        }

        // Teste do Cadastro de Usuário com email: kaiocrt7@gmail.com e senha: kaio@123.
        [TestCase("kaiocrt7@gmail.com", "kaio@123")]
        public void DadoQueEuTentoAcessarLoginValido(string nome, string senha)
        {
            login.AcessarLogin(nome, senha);
            if (login.ValidarLogin())
            {
                Assert.IsTrue(driver.Title.Contains("online"));
            }
        }

        [TearDown]
        public void Finalizar()
        {
            ConexaoWebDriver.Finalizar(driver);
        }
    }
}
