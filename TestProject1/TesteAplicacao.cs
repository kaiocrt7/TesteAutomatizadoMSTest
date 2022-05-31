using OpenQA.Selenium;
using TestMAXIPROD.Util;
using TestMAXIPROD.Pages;
using TestMAXIPROD.Paginas;
using OpenQA.Selenium.Edge;

namespace TestProject1
{
    public class TesteAplicacao
    {
        private IWebDriver driver;

        [SetUp]
        public void Iniciar()
        {
            driver = Util.Iniciar();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://sistema.maxiprod.com.br/");
            // Teste para identificar se foi poss�vel acesso a aplica��o MAXIPROD.
            StringAssert.Contains("MAXIPROD", driver.Title);
        }

        // Teste do Cadastro de Usu�rio com email: kaiocrt7@gmail.com e senha: kaio@123.
        [TestCase("kaiocrt7@gmail.com", "kaio@123")]
        public void TesteLogin(string nome, string senha)
        {
            Login login = new Login(driver);
            login.AcessarLogin(nome, senha);
            // Valida��o se foi poss�vel acessar o site ap�s logar.
            ValidarLogin.Sessao(driver);            
            // Valida��o se existe a palavra "online" no titulo da pagina
            Assert.IsTrue(driver.Title.Contains("online"));           
        }
        
        // Valores a serem testados para o cadastro do novo item.
        [TestCase("Produto Novo", "200,50", "199,50")]
        public void TesteCadastroItem(string _descricao, string _precoVenda, string _precoMinimo)
        {
            Login login = new Login(driver);
            CadastrarItem cadastrarItem = new CadastrarItem(driver);

            login.AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

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
            Login login = new Login(driver);
            EditarItem editarItem = new EditarItem(driver);
            CadastrarItem cadastrarItem = new CadastrarItem(driver);

            login.AcessarLogin("kaiocrt7@gmail.com", "kaio@123");

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
        [TestCase("112998")]
        public void TesteCodigoExternoItem(string _codigoExterno)
        {
            Login login = new Login(driver);
            CodigosExternosItens codigosExternos = new CodigosExternosItens(driver);

            login.AcessarLogin("kaiocrt7@gmail.com", "kaio@123");
                        
            ValidarLogin.Sessao(driver);
            
            codigosExternos.Acessar(); // acessar a op��o codigo externo do menu           
            codigosExternos.Novo(); // clicar no bot�o novo
            codigosExternos.Preencher(_codigoExterno); // preencher o formulario com o valor do teste
            codigosExternos.Salvar(); // salvar o cadastro

            Thread.Sleep(1000);
            // Valido seu meu c�digo externo est� contido em minha p�gina.
            StringAssert.Contains(_codigoExterno, driver.PageSource);
        }
        // Fechar o navegador ap�s os testes.
        [TearDown]
        public void Encerrar()
        {
            Util.Finalizar(driver);
        }
    }
}