using OpenQA.Selenium;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Pages
{
    public class EditarItem
    {
        private readonly IWebDriver driver;
        private readonly string descricao;
        private string tipoVenda;
        private string estado;
        private string precoVenda;
        private string procedencia;
        private Dictionary<string, By> formAcoes;

        public EditarItem(IWebDriver driver)
        {
            this.driver = driver;
            this.descricao = "Produto alterado";

            formAcoes = new Dictionary<string, By>()
            {
                {"iconeAtualizar", By.XPath("//body/div[2]/div[2]/div[6]/div[1]/div[1]/a[1]")},
                {"iconeEditar", By.XPath("//img[@title='Editar']")},
                {"campoDescricao",  By.Name("Descricao")},
                {"campoPrecoVenda", By.XPath("//body/div[@id='ModalItens']/div[2]/form[1]/div[2]/span[1]/span[3]/div[1]/div[1]/span[1]/div[1]/div[2]/span[1]/div[1]/div[1]")},
                {"campoPrecoMin", By.Name("PrecoMinimoDeVenda")},
                {"campoEstado", By.XPath("//tbody/tr[1]/td[1]/div[1]/span[5]/span[1]/div[1]/div[2]/select[1]/option[1]")},
                {"campoTipoVenda", By.XPath("//tbody[1]/tr[1]/td[1]/span[3]/div[1]/div[2]/select[1]/option[27]")},
                {"campoProcedencia", By.XPath("//tbody[1]/tr[1]/td[1]/span[2]/div[1]/div[2]/select[1]/option[1]")},
                {"linkVendas",  By.XPath("//body/div[@id='ModalItens']/div[2]/form[1]/div[2]/span[1]/span[3]/span[2]")},
                {"btnFinalizar", By.Id("SalvarEFechar")}
            };
        }
        public void AtualizarGrade()
        {
            Acao.Clicar(driver, formAcoes["iconeAtualizar"]);
        }
        // Clicar no ícone de Edição da grade.
        public void Editar()
        {
            Thread.Sleep(1000);
            Acao.Clicar(driver, formAcoes["iconeEditar"]);            
        }
        // Alterar a descricao do item cadastrado.
        public void PreencherFormulario()
        {
            Thread.Sleep(2000);
            driver.FindElement(formAcoes["campoDescricao"]).Clear();
            Acao.PreencherCampo(driver, formAcoes["campoDescricao"], descricao);

            // Obtenho os valores que serão apresentados na grid para realizar a validação posteriormente.            
            estado = Acao.ObterTexto(driver, formAcoes["campoEstado"]);
            tipoVenda = Acao.ObterTexto(driver, formAcoes["campoTipoVenda"]);
            procedencia = Acao.ObterTexto(driver, formAcoes["campoProcedencia"]);

            Acao.Clicar(driver, formAcoes["linkVendas"]);
            Thread.Sleep(600);
            precoVenda = Acao.ObterTexto(driver, formAcoes["campoPrecoVenda"]);            
        }
        // Clicar no botão Salvar e Fechar após a edição do item.
        public void FinalizarCadastro()
        {            
            Acao.Clicar(driver, formAcoes["btnFinalizar"]);
        }
        // Clicar no ícone para atualizar a grade após a edição do item.
        public void Validar()
        {
            Thread.Sleep(500);
            // Realizar a validação se os dados gravados estão de acordo com os apresentados na grid
            ValidarItens.ValidarGrid(driver, descricao, "/html[1]/body[1]/div[2]/div[2]/div[6]/div[3]/table[1]/tbody[1]/tr[1]/td[4]");
            ValidarItens.ValidarGrid(driver, tipoVenda, "//tbody/tr[1]/td[10]/div[1]/span[2]");
            ValidarItens.ValidarGrid(driver, estado, "//body[1]/div[2]/div[2]/div[6]/div[3]/table[1]/tbody[1]/tr[1]/td[31]");
            ValidarItens.ValidarGrid(driver, procedencia, "//body[1]/div[2]/div[2]/div[6]/div[3]/table[1]/tbody[1]/tr[1]/td[7]");
            ValidarItens.ValidarGrid(driver, precoVenda, "//body[1]/div[2]/div[2]/div[6]/div[3]/table[1]/tbody[1]/tr[1]/td[10]/div[1]/span[1]");
        }
    }
}
