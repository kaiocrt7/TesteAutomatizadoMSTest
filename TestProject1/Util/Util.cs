using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestMAXIPROD.Util
{
    public static class Util
    {
        // Iniciar uma nova aba no navegador para visualizar o teste.
        [SetUp]
        public static IWebDriver Iniciar()
        {
            return new EdgeDriver();
        }

        // Fechar a aba iniciada para o teste.
        [TearDown]
        public static void Finalizar(IWebDriver driver)
        {
            Acao.Clicar(driver, By.XPath("//a[@id='logout-button']"));
            driver.Quit();
        }
    }
}
