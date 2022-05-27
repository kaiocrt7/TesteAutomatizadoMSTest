using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestMAXIPROD.Menus;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Pages
{
    internal class CadastrarItem
    {
        private readonly IWebDriver driver;
        private readonly string descricao;
        private string tipoVenda;
        private readonly string precoVenda;
        private readonly string precoMinimo;
        private string estado;
        private string procedencia;
        private Dictionary<string, By> formAcoes;

        public CadastrarItem(IWebDriver driver)
        {
            this.driver = driver;
            // Preencher com os dados que serão testados no cadastro do Item.
            descricao = "Produto Novo";
            precoVenda = "200,50";
            precoMinimo = "199,00";

            formAcoes = new Dictionary<string, By>()
            {
                {"btnNovoItem", By.XPath("//body/div[2]/div[2]/div[6]/div[1]/input[1]") },
                {"linkVendas",  By.XPath("//body/div[@id='ModalItens']/div[2]/form[1]/div[2]/span[1]/span[3]/span[2]")},
                {"btnFinalizar", By.Id("SalvarEFechar")},
                {"iconeAtualizar", By.XPath("//body/div[2]/div[2]/div[6]/div[1]/div[1]/a[1]")},
                {"iconeOrdenar", By.XPath("//tbody/tr[1]/th[3]/a[1]") },
                {"campoDescricao",  By.Name("Descricao")},
                {"campoPrecoVenda", By.Name("PrecoVenda")},
                {"campoPrecoMin", By.Name("PrecoMinimoDeVenda")},
                {"campoEstado", By.XPath("//tbody/tr[1]/td[1]/div[1]/span[5]/span[1]/div[1]/div[2]/select[1]/option[1]")},
                {"campoTipoVenda", By.XPath("//tbody[1]/tr[1]/td[1]/span[3]/div[1]/div[2]/select[1]/option[27]")},
                {"campoProcedencia", By.XPath("//tbody[1]/tr[1]/td[1]/span[2]/div[1]/div[2]/select[1]/option[1]")}
            };   
        }

        // Acessar o menu Itens.
        public void AcessarItem()
        {
            MenuItens.Itens(driver);
        }
        
        // Clicar no botão Novo.
        public void NovoItem()
        {
            Acao.Clicar(driver, formAcoes["btnNovoItem"]);
        }
        
        // Preencher o formulario com os valores informados no método construtor.
        public void PreencherFormulario()
        {      
            Thread.Sleep(2000);

            Acao.PreencherCampo(driver, formAcoes["campoDescricao"], descricao);
            Acao.Clicar(driver, formAcoes["linkVendas"]);
            Acao.PreencherCampo(driver, formAcoes["campoPrecoVenda"], precoVenda);
            Acao.PreencherCampo(driver, formAcoes["campoPrecoMin"], precoMinimo);
                        
            // Obter valores preenchidos automaticamente que serão apresentados na grid.
            estado = Acao.ObterTexto(driver, formAcoes["campoEstado"]);
            tipoVenda = Acao.ObterTexto(driver, formAcoes["campoTipoVenda"]);
            procedencia = Acao.ObterTexto(driver, formAcoes["campoProcedencia"]);            
        }
       
        // Clicar no botão Salver e Fechar.
        public void FinalizarCadastro()
        {
            Acao.Clicar(driver, formAcoes["btnFinalizar"]);                        
        }

        // Atualizar a grid após o cadastro do item.
        public void AtualizarGrade()
        {
            Acao.Clicar(driver, formAcoes["iconeAtualizar"]);

            // Ordeno a coluna Codigo da grid de forma decrescente para validar sempre o último item cadastrado.
            Acao.Clicar(driver, formAcoes["iconeOrdenar"]);
            Thread.Sleep(1000);
            //Validar os itens apresentados na grid após cadastro.
            ValidarItens.ValidarGrid(driver, descricao, "//body[1]/div[2]/div[2]/div[6]/div[3]/table[1]/tbody[1]/tr[1]/td[4]");
            ValidarItens.ValidarGrid(driver, tipoVenda, "//tbody/tr[1]/td[10]/div[1]/span[2]");
            ValidarItens.ValidarGrid(driver, estado, "//body[1]/div[2]/div[2]/div[6]/div[3]/table[1]/tbody[1]/tr[1]/td[31]");
            ValidarItens.ValidarGrid(driver, procedencia, "//body[1]/div[2]/div[2]/div[6]/div[3]/table[1]/tbody[1]/tr[1]/td[7]");
            ValidarItens.ValidarGrid(driver, precoVenda, "//body[1]/div[2]/div[2]/div[6]/div[3]/table[1]/tbody[1]/tr[1]/td[10]/div[1]/span[1]");
        }
    }
}
