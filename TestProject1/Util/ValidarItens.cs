using OpenQA.Selenium;

namespace TestMAXIPROD.Util
{
    public static class ValidarItens
    {
        public static void ValidarGrid(IWebDriver driver, Dictionary<string, string> _valores)
        {
            // Dicionario contendo como chave a coluna da grid e o valor contendo a posição de cada elemento da grid.
            Dictionary<string, By> gridItens = new()
            {
                {"colunaDescricao", By.XPath("//tbody[1]/tr[1]/td[4]")},
                {"colunaTipoVenda", By.XPath("//tbody/tr[1]/td[10]/div[1]/span[2]")},
                {"colunaEstado", By.XPath("//tbody[1]/tr[1]/td[31]")},
                {"colunaProcedencia", By.XPath("//tbody[1]/tr[1]/td[7]")},
                {"colunaPrecoVenda", By.XPath("//tbody[1]/tr[1]/td[10]/div[1]/span[1]")}
            };
            // Chamada da função validar, passando meus valores e a localização dos elmentos das colunas da grid.
            Validar(driver, _valores["descricao"], gridItens["colunaDescricao"]);
            Validar(driver, _valores["tipoVenda"], gridItens["colunaTipoVenda"]);
            Validar(driver, _valores["estado"], gridItens["colunaEstado"]);
            Validar(driver, _valores["procedencia"], gridItens["colunaProcedencia"]);
            Validar(driver, _valores["precoVenda"], gridItens["colunaPrecoVenda"]);
        }
        private static void Validar(IWebDriver driver, string valorTeste, By localizacao)
        {
            string valorGrid = driver.FindElement(localizacao).Text;
            // Valido se meu valor a ser testado está de acordo com o valor apresentado na grid.
            if (!valorTeste.Equals(valorGrid.Replace("/", "")))
            {
                throw new WebDriverException("Valor digitado " + valorTeste + " não confere com o valor " + valorGrid + " apresentado na grade.");                
            }
        }
    }
}