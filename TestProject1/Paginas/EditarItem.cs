using OpenQA.Selenium;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Pages
{
    public class EditarItem
    {
        private readonly IWebDriver driver;
        private Dictionary<string, By> formItens;
        private Dictionary<string, string> valores;

        public EditarItem(IWebDriver _driver)
        {
            driver = _driver;

            // Dicidionário contendo a chave com o nome do elemento e o valor com a localização de cada elemento para edição do item.
            formItens = new Dictionary<string, By>()
            {
                {"iconeAtualizar", By.XPath("//body/div[2]/div[2]/div[6]/div[1]/div[1]/a[1]")},
                {"iconeEditar", By.XPath("//img[@title='Editar']")},
                {"campoDescricao",  By.Name("Descricao")},                
                {"campoPrecoVenda", By.XPath("//body/div[@id='ModalItens']/div[2]/form[1]/div[2]/span[1]/span[3]/div[1]/div[1]/span[1]/div[1]/div[2]/span[1]/div[1]/div[1]")},
                {"linkVendas",  By.XPath("//body/div[@id='ModalItens']/div[2]/form[1]/div[2]/span[1]/span[3]/span[2]")},
                {"campoPrecoMin", By.Name("PrecoMinimoDeVenda")},
                {"campoEstado", By.XPath("//tbody/tr[1]/td[1]/div[1]/span[5]/span[1]/div[1]/div[2]/select[1]/option[1]")},
                {"campoProcedencia", By.XPath("//tbody[1]/tr[1]/td[1]/span[2]/div[1]/div[2]/select[1]/option[1]")},
                {"campoTipoVenda", By.XPath("//tbody[1]/tr[1]/td[1]/span[3]/div[1]/div[2]/select[1]/option[27]")},                
                {"btnSalvarEFechar", By.Id("SalvarEFechar")}
            };
            // Dicionário para registrar os valores a serem preenchidos nos campos do formulário, a fim de obter a validação dos dados posteriormente.
            valores = new Dictionary<string, string>();
        }
        // Atualizar a grid dos itens.
        public void AtualizarGrade()
        {
            Acao.Clicar(driver, formItens["iconeAtualizar"]);
        }
        // Clicar no ícone de Edição da grade.
        public void Editar()
        {
            Thread.Sleep(1000);
            Acao.Clicar(driver, formItens["iconeEditar"]);            
        }
        // Alterar a descricao do item cadastrado.
        public void PreencherFormulario(string _descricao)
        {
            // Preenche o dicionário com a descricao de teste do item.
            valores["descricao"] = _descricao;

            Thread.Sleep(2000);
            driver.FindElement(formItens["campoDescricao"]).Clear();
            Acao.PreencherCampo(driver, formItens["campoDescricao"], valores["descricao"]);

            // Registro em meu dicionário os valores que serão apresentados na grid para realizar a validação posteriormente.            
            valores["estado"] = Acao.ObterTexto(driver, formItens["campoEstado"]);
            valores["procedencia"] = Acao.ObterTexto(driver, formItens["campoProcedencia"]);
            valores["tipoVenda"] = Acao.ObterTexto(driver, formItens["campoTipoVenda"]);            

            Acao.Clicar(driver, formItens["linkVendas"]);
            Thread.Sleep(500);
            valores["precoVenda"] = Acao.ObterTexto(driver, formItens["campoPrecoVenda"]);            
        }
        // Clicar no botão Salvar e Fechar após a edição do item.
        public void FinalizarCadastro()
        {            
            Acao.Clicar(driver, formItens["btnSalvarEFechar"]);
        }
        // Metodo responsavel pela validação da Edição do Item, sendo passado como parâmetro meu dicionário com os valores testados.
        public void Validar()
        {
            Thread.Sleep(500);
            ValidarItens.ValidarGrid(driver, valores);
        }
    }
}
