using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMAXIPROD.Pages;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Testes
{
    public class TesteUsuario
    {
        private IWebDriver driver;
        private CadastrarUsuario cadastrarUsuario;
        [SetUp]
        public void Iniciar()
        {            
            driver = ConexaoWebDriver.Iniciar();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sistema.maxiprod.com.br/");

            cadastrarUsuario = new CadastrarUsuario(driver);

            Assert.IsTrue(driver.PageSource.Contains("Login | MAXIPROD"));
        }

        [TestCase("Kaio Cesar", "Testando Cadastro", "Lucro real", "GO", "Goianira", "981142862", "kaiocrt7@gmail.com", "kaio@123", "kaio@123")]
        public void DadoQueTentoCadastrarEmailExistente(string nome, string razao, string regime, string uf, string municipio, string telefone,
            string email, string senha, string confirmar)
        {
            cadastrarUsuario.NovoCadastro();
            cadastrarUsuario.PreencherFormulario(nome, razao, regime, uf, municipio, telefone, email, senha, confirmar);
            cadastrarUsuario.FinalizarCadastro();

            Assert.IsTrue(driver.PageSource.Contains("Já existe um usuário/assinante cadastrado com este e-mail. Deseja fazer login com este e-mail?"));
        }

        [TestCase("Kaio Cesar", "Testando Cadastro", "Lucro real", "GO", "Goianira", "981142862", "", "kaio@123", "kaio@123")]
        public void DadoQueTentoCadastrarUsuarioSemEmail(string nome, string razao, string regime, string uf, string municipio, string telefone,
            string email, string senha, string confirmar)
        {
            cadastrarUsuario.NovoCadastro();
            cadastrarUsuario.PreencherFormulario(nome, razao, regime, uf, municipio, telefone, email, senha, confirmar);
            cadastrarUsuario.FinalizarCadastro();

            Assert.IsTrue(driver.PageSource.Contains("É necessário especificar o e-mail."));
        }

        [TestCase("Kaio Cesar", "Testando Cadastro", "Lucro real", "GO", "Goianira", "981142862", "kaioalvarez0@gmail.com", "kaio", "kaio@123")]
        public void DadoQueTentoCadastrarUsuarioComSenhasDistintas(string nome, string razao, string regime, string uf, string municipio, string telefone,
            string email, string senha, string confirmar)
        {
            cadastrarUsuario.NovoCadastro();
            cadastrarUsuario.PreencherFormulario(nome, razao, regime, uf, municipio, telefone, email, senha, confirmar);
            cadastrarUsuario.FinalizarCadastro();

            Assert.IsTrue(driver.PageSource.Contains("As senhas não conferem"));
        }

        [TearDown]
        public void Finalizar()
        {
            ConexaoWebDriver.Finalizar(driver);
        }
    }
}
