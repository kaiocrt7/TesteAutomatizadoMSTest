using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestMAXIPROD.Util
{
    public  class ValidarLogin
    {
        public static bool Acesso(IWebDriver driver)
        {
            if (driver.PageSource.Contains("simBtn"))
            {
                Acao.Clicar(driver, By.Name("simBtn"));
            }
            else
            if (driver.PageSource.Contains("E-mail e/ou senha inválidos."))
            {
                return false;
            }
            return true;
        }

        public static void Sessao(IWebDriver driver)
        {/*
            if (!Aguardar(driver).Until(ExpectedConditions.ElementIsVisible(By.Id("logout"))).Displayed)
            {
                throw new WebDriverException("Erro ao realizar o cadastro do novo usuário, não foi possível acessar a página inicial.");
            }*/
            Thread.Sleep(1200);
            if (!driver.PageSource.Contains("ERP online | MAXIPROD"))
            {
                throw new WebDriverException("Erro, não foi possível acessar a página inicial.");
            }
            Thread.Sleep(1200);
        }
        private static WebDriverWait Aguardar(IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
    }
}
