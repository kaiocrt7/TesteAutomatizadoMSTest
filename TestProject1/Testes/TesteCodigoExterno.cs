using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMAXIPROD.Pages;
using TestMAXIPROD.Paginas;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Testes
{
    public class TesteCodigoExterno
    {
        private IWebDriver driver;
        private CodigosExternosItens codigosExternos;
        private Login login;
        
        [SetUp]
        public void Iniciar()
        {
            driver = ConexaoWebDriver.Iniciar();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sistema.maxiprod.com.br/");

            codigosExternos = new CodigosExternosItens(driver);
            login = new Login(driver);
            Assert.That(driver.PageSource.Contains("Login | MAXIPROD"));
        }

        [TestCase("112998882")]
        public void TesteCodigoExternoItem(string _codigoExterno)
        {
            login.AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

            if (login.ValidarLogin())
            {
                ValidarLogin.Sessao(driver);

                codigosExternos.Acessar(); // acessar a opção codigo externo do menu           
                codigosExternos.Novo(); // clicar no botão novo
                codigosExternos.Preencher(_codigoExterno); // preencher o formulario com o valor do teste
                codigosExternos.Salvar(); // salvar o cadastro

                Thread.Sleep(1000);
                // Valido seu meu código externo está contido em minha página.
                StringAssert.Contains(_codigoExterno, driver.PageSource);
            }            
        }

        [TearDown]
        public void Finalizar()
        {
            ConexaoWebDriver.Finalizar(driver);
        }
    }
}
