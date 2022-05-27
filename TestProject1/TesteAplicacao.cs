using AutomacaoMaxiprod.Pages;
using OpenQA.Selenium;
using TestMAXIPROD.Util;
using TestMAXIPROD.Pages;
using TestMAXIPROD.Paginas;

namespace TestProject1
{
    public class TesteAplicacao
    {
        private const string url = "https://sistema.maxiprod.com.br/";

        // Teste do Cadastro de Usuário.
        [Test]
        public void TesteCadastroUsuario()
        {
            IWebDriver driver = Util.Iniciar();
            Login login = new Login(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            login.AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

            ValidarLogin.Acesso(driver);
            ValidarLogin.Sessao(driver);

            Util.Finalizar(driver);
            Assert.Pass();
        }
        
        // Teste do cadastro de Item.
        [Test]
        public void TesteCadastroItem()
        {
            IWebDriver driver = Util.Iniciar();
            Login login = new Login(driver);
            CadastrarItem cadastrarItem = new CadastrarItem(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            login.AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

            ValidarLogin.Acesso(driver);
            ValidarLogin.Sessao(driver);

            cadastrarItem.AcessarItem();
            cadastrarItem.NovoItem();
            cadastrarItem.PreencherFormulario();
            cadastrarItem.FinalizarCadastro();
            cadastrarItem.AtualizarGrade();

            Util.Finalizar(driver);
            Assert.Pass();
        }
        
        // Teste de edição do Item.
        [Test]
        public void TesteEditarItem()
        {
            IWebDriver driver = Util.Iniciar();
            Login login = new Login(driver);
            EditarItem editarItem = new EditarItem(driver);
            CadastrarItem cadastrarItem = new CadastrarItem(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            login.AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

            ValidarLogin.Acesso(driver);
            ValidarLogin.Sessao(driver);

            Thread.Sleep(1200);
            cadastrarItem.AcessarItem();
            cadastrarItem.NovoItem();
            cadastrarItem.PreencherFormulario();
            cadastrarItem.FinalizarCadastro();
            cadastrarItem.AtualizarGrade();

            editarItem.AtualizarGrade();
            editarItem.Editar();
            editarItem.PreencherFormulario();
            editarItem.FinalizarCadastro();
            editarItem.AtualizarGrade();
            editarItem.Validar();

            Util.Finalizar(driver);
            Assert.Pass();
        }

        [Test]
        public void TesteCodigoExternoItem()
        {
            IWebDriver driver = Util.Iniciar();
            Login login = new Login(driver);

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            login.AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

            ValidarLogin.Acesso(driver);
            ValidarLogin.Sessao(driver);

            Thread.Sleep(900);

            CodigosExternosItens codigosExternos = new CodigosExternosItens(driver);
            codigosExternos.Acessar();            
            codigosExternos.Novo();
            codigosExternos.Preencher();
            codigosExternos.Salvar();

            Util.Finalizar(driver);
            Assert.Pass();
        }
    }
}