using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace TestMAXIPROD.Util
{
    public static class Util
    {
        // Iniciar uma nova aba no navegador para visualizar o teste. 
       public static IWebDriver Iniciar()
        {
            return new EdgeDriver();
        }

        // Fechar a aba iniciada para o teste.        
        public static void Finalizar(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
