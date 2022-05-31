using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestMAXIPROD.Util
{
    public  class ValidarLogin
    {
        public static void Sessao(IWebDriver driver)
        {
            Thread.Sleep(1200);
            // Verifico se existe em minha página a descrição "ERP online | MAXIPROD" após realizar o login na aplicação.
            if (!driver.PageSource.Contains("ERP online | MAXIPROD"))
            {
                throw new WebDriverException("Erro, não foi possível acessar a página inicial.");
            }
            Thread.Sleep(500);
        }
    }
}
