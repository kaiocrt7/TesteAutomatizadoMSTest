using OpenQA.Selenium;
using TestMAXIPROD.Util;
using TestMAXIPROD.Pages;
using TestMAXIPROD.Paginas;

namespace TestMAXIPROD.Testes
{
    public class TesteAplicacao
    {
        private IWebDriver driver;

        [SetUp]
        public void Iniciar()
        {
            driver = ConexaoWebDriver.Iniciar();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sistema.maxiprod.com.br/");
            // Teste para identificar se foi poss�vel acesso a aplica��o MAXIPROD.
            StringAssert.Contains("MAXIPROD", driver.Title);
        }

        // Valores a serem testados para o cadastro do novo item.
        [TestCase("Produto Novo", "200,50", "199,50")]
        public void TesteCadastroItem(string _descricao, string _precoVenda, string _precoMinimo)
        {
            CadastrarItem cadastrarItem = new CadastrarItem(driver);

            new Login(driver).AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

            ValidarLogin.Sessao(driver);

            cadastrarItem.AcessarItem(); // acessar o menu Itens
            cadastrarItem.NovoItem(); // clicar no bot�o novo item
            cadastrarItem.PreencherFormulario(_descricao, _precoVenda, _precoMinimo); // preencher o formulario com os valores informados no teste
            cadastrarItem.FinalizarCadastro(); // clicar em salvar o cadastro
            cadastrarItem.AtualizarGrid(); // atualizar grid
            cadastrarItem.ValidarCadastro(); // validar se o item cadastrado esta de acordo com o apresentado na grid

            // Valida��o se existe em minha p�gina a descri��o do meu item cadastrado.
            StringAssert.Contains(_descricao, driver.PageSource);
        }

        // Valor a ser testado na edi��o do item.
        [TestCase("Produto Alterado")]
        public void TesteEditarItem(string _descricao)
        {
            EditarItem editarItem = new EditarItem(driver);
            CadastrarItem cadastrarItem = new CadastrarItem(driver);

            new Login(driver).AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

            ValidarLogin.Sessao(driver);

            cadastrarItem.AcessarItem(); // acessar o menu Itens
            cadastrarItem.NovoItem(); // clicar no bot�o novo item
            cadastrarItem.PreencherFormulario("Produto A", "150", "149"); // preencher o formulario para cadastrar o item que ser� alterado
            cadastrarItem.FinalizarCadastro(); // clicar em salvar o cadastro

            editarItem.AtualizarGrade(); // atualizar grid
            editarItem.Editar(); // clicar no icone de edi��o
            editarItem.PreencherFormulario(_descricao); // preencher o formulario com minha descri��o
            editarItem.FinalizarCadastro(); // clicar em salvar a edi��o
            editarItem.AtualizarGrade(); // atualizar grid
            editarItem.Validar(); // validar se o item editado esta de acordo com o apresentado na grid

            // Valida��o se existe em minha p�gina a descri��o do meu item ap�s a edi��o.
            StringAssert.Contains(_descricao, driver.PageSource);
        }
        // Valor a ser testado no cadastro do codigo externo

        // Fechar o navegador ap�s os testes.
        [TearDown]
        public void Encerrar()
        {
            ConexaoWebDriver.Finalizar(driver);
        }
    }
}