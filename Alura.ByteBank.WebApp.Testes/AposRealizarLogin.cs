using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin
    {
        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            var login = driver.FindElement(By.Id("Email")); //Selecionar elementos do HTML
            var senha = driver.FindElement(By.Id("Senha")); //Selecionar elementos do HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar")); //Selecionar elementos do HTML

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha01");

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("Agência", driver.PageSource);

        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            var login = driver.FindElement(By.Id("Email")); //Selecionar elementos do HTML
            var senha = driver.FindElement(By.Id("Senha")); //Selecionar elementos do HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar")); //Selecionar elementos do HTML

            //login.SendKeys("andre@email.com");
            //senha.SendKeys("senha01");

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("The Email field is required.", driver.PageSource);
            Assert.Contains("The Senha field is required.", driver.PageSource);


        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://localhost:44309/UsuarioApps/Login");

            var login = driver.FindElement(By.Id("Email")); //Selecionar elementos do HTML
            var senha = driver.FindElement(By.Id("Senha")); //Selecionar elementos do HTML
            var btnLogar = driver.FindElement(By.Id("btn-logar")); //Selecionar elementos do HTML

            login.SendKeys("andre@email.com");
            senha.SendKeys("senha010"); //Senha Inválida

            //Act
            btnLogar.Click();

            //Assert
            Assert.Contains("Login", driver.PageSource);


        }
    }
}
