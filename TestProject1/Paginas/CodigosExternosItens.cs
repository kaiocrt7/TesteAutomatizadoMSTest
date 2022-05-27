using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using TestMAXIPROD.Menus;
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

            formAcoes = new Dictionary<string, By>()
            {
                {"btnNovo", By.XPath("//body[1]/div[2]/div[2]/div[5]/div[1]/input[1]")},
                {"iconePesquisarItem", By.XPath("//body/div[4]/div[2]/form[1]/div[2]/span[1]/span[1]/div[1]/div[2]/button[1]")},
                {"iconeAtualizar", By.XPath("//body/div[5]/div[2]/div[4]/div[1]/div[1]/a[1]")},
                {"selecionarItem", By.XPath("//tbody[1]/tr[1]/td[2]")},
                {"iconePesquisarCF", By.XPath("//body/div[4]/div[2]/form[1]/div[2]/span[1]/span[2]/div[1]/div[2]/button[1]")},
                {"selecionarEmpresa", By.XPath("//tbody[1]/tr[1]/td[4]/div[1]")},
                {"codigoExterno", By.Name("CodigoExterno")},
                {"unidade", By.Name("IdValorOpcaoUnidade")},
                {"btnSalvar", By.Name("submitbutton") }
            };
        }

        public void Acessar()
        {
            MenuItens.CodigosExternos(driver);
        }

        public void Novo()
        {
            Thread.Sleep(900);
            Acao.Clicar(driver, formAcoes["btnNovo"]);
        }

        public void Preencher()
        {
            Actions acao = new Actions(driver);
            Thread.Sleep(1000);
            Acao.Clicar(driver, formAcoes["iconePesquisarItem"]);
            Thread.Sleep(1000);
            Acao.Clicar(driver, formAcoes["iconeAtualizar"]);
            Thread.Sleep(1000);
            IWebElement elemento1 = driver.FindElement(formAcoes["selecionarItem"]);            
            acao.DoubleClick(elemento1).Perform();
            Thread.Sleep(1000);
            Acao.Clicar(driver, formAcoes["iconePesquisarCF"]);
            Thread.Sleep(1000);
            IWebElement elemento2 = driver.FindElement(formAcoes["selecionarEmpresa"]);
            acao.DoubleClick(elemento2).Perform();

            Acao.PreencherCampo(driver, formAcoes["codigoExterno"], "9996852");
            Acao.Selecionar(driver, formAcoes["unidade"], "un");
        }
        
        public void Salvar()
        {
            Acao.Clicar(driver, formAcoes["btnSalvar"]);
        }
    }
}
