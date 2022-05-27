using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestMAXIPROD.Util;

namespace TestMAXIPROD.Menus
{
    public static class MenuItens
    {
        public static void Itens(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//body/div[2]/div[1]/div[2]/div[3]/ul[1]/li[4]/span[1]"))).Perform();
            Acao.Clicar(driver, By.XPath("//body/div[2]/div[1]/div[2]/div[3]/ul[1]/li[4]/ul[1]/li[1]/a[1]"));
        }

        public static void CodigosExternos(IWebDriver driver)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//body/div[2]/div[1]/div[2]/div[3]/ul[1]/li[4]/span[1]"))).Perform();
            Acao.Clicar(driver, By.XPath("//body/div[2]/div[1]/div[2]/div[3]/ul[1]/li[4]/ul[1]/li[2]/a[1]"));
        }
    }
}
