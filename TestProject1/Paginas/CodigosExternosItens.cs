using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TestMAXIPROD.Menus;
using TestMAXIPROD.Pages;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Paginas
{    
    public class CodigosExternosItens
    {
        private IWebDriver driver;
        private Dictionary<string, By> formAcoes;
        public CodigosExternosItens(IWebDriver driver)
        {
            this.driver = driver;
            // Dicidionário contendo a chave com o nome do elemento e o valor com a localização de cada elemento para cadastro do código externo.
            formAcoes = new Dictionary<string, By>()
            {
                {"btnNovo", By.XPath("//body[1]/div[2]/div[2]/div[5]/div[1]/input[1]")},
                {"iconePesquisarItem", By.XPath("//body/div[4]/div[2]/form[1]/div[2]/span[1]/span[1]/div[1]/div[2]/button[1]")},
                {"iconeAtualizarItem", By.XPath("//body/div[5]/div[2]/div[4]/div[1]/div[1]/a[1]")},
                {"selecionarItem", By.XPath("//tbody[1]/tr[1]/td[2]")},                
                {"btnOK", By.Name("ConfirmOk")},                
                {"iconePesquisarCF", By.XPath("//body/div[4]/div[2]/form[1]/div[2]/span[1]/span[2]/div[1]/div[2]/button[1]")},
                {"iconeAtualizarEmpresa", By.XPath("//body/div[6]/div[2]/div[4]/div[1]/div[1]/a[1]")},
                {"selecionarCF", By.XPath("//tbody[1]/tr[2]/td[4]/div[1]") },
                {"codigoExterno", By.Name("CodigoExterno")},
                {"unidade", By.Name("IdValorOpcaoUnidade")},
                {"valorConversao", By.Name("FatorDeConversaoUnidade")},
                {"btnSalvar", By.Name("submitbutton")}
            };
        }
        // Acessar a opção Codigos Externos do Menu Itens.
        public void Acessar()
        {
            MenuItens.CodigosExternos(driver);
        }
        // Clicar no botão para cadastrar o novo codigo externo.
        public void Novo()
        {
            Thread.Sleep(900);
            Acao.Clicar(driver, formAcoes["btnNovo"]);
        }
        // Preencher o formulario para cadastro do codigo externo.
        public void Preencher(string _codigoExterno)
        {
            Thread.Sleep(900);
            Acao.Clicar(driver, formAcoes["iconePesquisarItem"]);
            Thread.Sleep(1000);
            Acao.Clicar(driver, formAcoes["iconeAtualizarItem"]);
            Thread.Sleep(1000);
            Acao.Clicar(driver, (formAcoes["btnOK"]));
            Thread.Sleep(300);
            Acao.Clicar(driver, formAcoes["iconePesquisarCF"]);
            Thread.Sleep(1200);
            Acao.Clicar(driver, (formAcoes["iconeAtualizarEmpresa"]));
            Thread.Sleep(1500);
            Actions selecionarCF = new Actions(driver);
            selecionarCF.MoveToElement(driver.FindElement(formAcoes["selecionarCF"])).DoubleClick().Build().Perform();
            Acao.PreencherCampo(driver, formAcoes["codigoExterno"], _codigoExterno);
            Acao.Selecionar(driver, formAcoes["unidade"], "un");
            Thread.Sleep(700);
            Acao.PreencherCampo(driver, formAcoes["valorConversao"], "6");
        }
        // Salvar após a finalização do cadastro.
        public void Salvar()
        {
            Acao.Clicar(driver, formAcoes["btnSalvar"]);
        }
    }
}
