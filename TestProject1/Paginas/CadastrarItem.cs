using OpenQA.Selenium;
using TestMAXIPROD.Menus;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Pages
{
    internal class CadastrarItem
    {
        private readonly IWebDriver driver;
        private Dictionary<string, By> formCadastroItem;
        private Dictionary<string, string> valores;

        public CadastrarItem(IWebDriver _driver)
        {
            driver = _driver;

            // Dicidionário contendo a chave com o nome do elemento e o valor com a localização de cada elemento do formulario Cadastrar Item.
            formCadastroItem = new Dictionary<string, By>()
            {
                {"btnNovoItem", By.XPath("//body/div[2]/div[2]/div[6]/div[1]/input[1]") },
                {"campoDescricao",  By.Name("Descricao")},
                {"linkVendas",  By.XPath("//body/div[@id='ModalItens']/div[2]/form[1]/div[2]/span[1]/span[3]/span[2]")},
                {"campoPrecoVenda", By.Name("PrecoVenda")},
                {"campoPrecoMin", By.Name("PrecoMinimoDeVenda")},
                {"campoEstado", By.XPath("//tbody/tr[1]/td[1]/div[1]/span[5]/span[1]/div[1]/div[2]/select[1]/option[1]")},
                {"campoTipoVenda", By.XPath("//tbody[1]/tr[1]/td[1]/span[3]/div[1]/div[2]/select[1]/option[27]")},
                {"campoProcedencia", By.XPath("//tbody[1]/tr[1]/td[1]/span[2]/div[1]/div[2]/select[1]/option[1]")},
                {"btnSalvarEFechar", By.Id("SalvarEFechar")},
                {"iconeAtualizarGrid", By.XPath("//body/div[2]/div[2]/div[6]/div[1]/div[1]/a[1]")},
                {"iconeOrdenarGrid", By.XPath("//tbody/tr[1]/th[3]/a[1]")}
            };
            // Dicionário para registrar os valores a serem preenchidos nos campos do formulário, a fim de obter a validação dos dados posteriormente.
            valores = new Dictionary<string, string>();                    
        }

        // Acessar a opção Itens do menu Itens.
        public void AcessarItem()
        {
            MenuItens.Itens(driver);
        }
        
        // Clicar no botão para cadastro de um Novo.
        public void NovoItem()
        {
            Acao.Clicar(driver, formCadastroItem["btnNovoItem"]);
        }
        
        // Preencher formulario de cadastro do Item.
        public void PreencherFormulario(string _descricao, string _precoVenda, string _precoMinimo)
        {
            // Preenche o dicionário com os valores a serem testados.
            valores["descricao"] = _descricao;
            valores["precoVenda"] = _precoVenda;
            valores["precoMinimo"] = _precoMinimo;

            Thread.Sleep(2000);
            // Preenche os campos do formulario com os valores a serem testados.
            Acao.PreencherCampo(driver, formCadastroItem["campoDescricao"], valores["descricao"]);
            Acao.Clicar(driver, formCadastroItem["linkVendas"]);
            Acao.PreencherCampo(driver, formCadastroItem["campoPrecoVenda"], valores["precoVenda"]);
            Acao.PreencherCampo(driver, formCadastroItem["campoPrecoMin"], valores["precoMinimo"]);

            // Obter os valores preenchidos automaticamente que serão apresentados na grid.
            valores["estado"] = Acao.ObterTexto(driver, formCadastroItem["campoEstado"]);
            valores["tipoVenda"] = Acao.ObterTexto(driver, formCadastroItem["campoTipoVenda"]);
            valores["procedencia"] = Acao.ObterTexto(driver, formCadastroItem["campoProcedencia"]);            
        }
       
        // Clicar no botão Salver e Fechar para finalizar o cadastro.
        public void FinalizarCadastro()
        {
            Acao.Clicar(driver, formCadastroItem["btnSalvarEFechar"]);                        
        }

        // Atualizar a grid após o cadastro do item.
        public void AtualizarGrid()
        {
            Acao.Clicar(driver, formCadastroItem["iconeAtualizarGrid"]);
            Thread.Sleep(700);
            // Ordeno a coluna Codigo da grid de forma decrescente para validar o último item cadastrado.
            Acao.Clicar(driver, formCadastroItem["iconeOrdenarGrid"]);
            Thread.Sleep(1000);            
        }
        // Metodo responsavel pela validação do cadastro, sendo passado como parâmetro meu dicionário com os valores testados.
        public void ValidarCadastro()
        {
            ValidarItens.ValidarGrid(driver, valores);
        }
    }
}
