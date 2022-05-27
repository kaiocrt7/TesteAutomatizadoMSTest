using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMAXIPROD.Pages
{
    public static class ValidarItens
    {
        public static void ValidarGrid(IWebDriver driver, string valorTeste, string localizacao)
        {
            string valorGrade = driver.FindElement(By.XPath(localizacao)).Text;

            if (!valorTeste.Equals(valorGrade.Replace("/", "")))
            {
                throw new WebDriverException("Valor digitado " + valorTeste + " não confere com o valor " + valorGrade + " apresentado na grade.");
            }
        }
    }
}
