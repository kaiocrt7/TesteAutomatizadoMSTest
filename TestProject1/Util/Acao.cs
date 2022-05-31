using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestMAXIPROD.Util
{
    // Classe responsável por contralar as ações utilizadas no teste.
    public static class Acao
    {
        // Realizar as ações de preenchimento de campos.
        public static void PreencherCampo(IWebDriver driver, By localizacao, string valor)
        {
            driver.FindElement(localizacao).SendKeys(valor);
        }

        // Realizar as ações de clicar.
        public static void Clicar(IWebDriver driver, By localizacao)
        {
            driver.FindElement(localizacao).Click();
        }

        // Realizar as ações de selecionar combobox.
        public static void Selecionar(IWebDriver driver, By localizacao, string valor)
        {
            new SelectElement(driver.FindElement(localizacao)).SelectByText(valor);
        }

        // Realizar as ações de obter texto do campo.
        public static string ObterTexto(IWebDriver driver, By localizacao)
        {
            return driver.FindElement(localizacao).Text;
        }
    }
}
