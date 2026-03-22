
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestMoodleTest
{
    public class MoodleTests :IDisposable
    {

        IWebDriver driver = new ChromeDriver();

        public void Dispose ()
        {
            driver.Quit();
        }


        [Fact]
        public void TrySite()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Assert.Equal("Сервис заметок", driver.Title);
            Thread.Sleep(3000);
            
            driver.Close();
        }

        [Fact]
        public void ClickRegistrBtn()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            IWebElement btnregistrTab = driver.FindElement(By.XPath("//*[@id=\"registerTab\"]"));
            btnregistrTab.Click();
            IWebElement btnreg = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            

            Assert.Equal("Зарегистрироваться", btnreg.Text);
            Thread.Sleep(3000);
            
            driver.Close();
        }

        [Fact]
        public void ClickRegistrBtn_Then_ClickLoginBtn ()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            IWebElement btnregistrTab = driver.FindElement(By.XPath("//*[@id=\"registerTab\"]"));
            btnregistrTab.Click();
            Thread.Sleep(3000);
            IWebElement btnLoginTab = driver.FindElement(By.XPath("//*[@id=\"loginTab\"]"));
            btnLoginTab.Click();





            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));


            Assert.Equal("Войти", btnLog.Text);
            Thread.Sleep(1000);
            
            driver.Close();
        }



        

        [Fact]
        public void InputWrongValueAndPassword_LogTab ()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);
            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("qwe");
            Thread.Sleep(500);
            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("qwerty");
            Thread.Sleep(500);
            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();

            Thread.Sleep(500);
            IWebElement Exception = driver.FindElement(By.XPath("//*[@id=\"message\"]/span"));

            Assert.Equal("Неверный логин или пароль.", Exception.Text);
            Thread.Sleep(1000);
            
            driver.Close();
        }



        [Fact]
        public void InputWrongValueAndPassword_RegTab ()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);
            IWebElement btnregistrTab = driver.FindElement(By.XPath("//*[@id=\"registerTab\"]"));
            btnregistrTab.Click();
            Thread.Sleep(500);
            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("qwe");
            Thread.Sleep(500);
            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("qwerty");
            Thread.Sleep(500);
            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();

            Thread.Sleep(500);
            IWebElement Exception = driver.FindElement(By.XPath("//*[@id=\"message\"]/span"));

            Assert.Equal("Пользователь с таким логином уже существует.", Exception.Text);
            Thread.Sleep(1000);
            
            driver.Close();
        }



        [Fact]
        public void Login_Scripts ()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);
            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);
            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            Thread.Sleep(500);
            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();

            Thread.Sleep(500);
            

            Assert.Equal("Сервис заметок", driver.Title);
            Thread.Sleep(1000);
            
            driver.Close();
        }

        
        [Fact]
        public void Logout_Scripts ()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);

            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);

            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            Thread.Sleep(500);

            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();
            Thread.Sleep(500);



            IWebElement btnLogout = driver.FindElement(By.XPath("//*[@id=\"logoutBtn\"]"));
            btnLogout.Click();
            Thread.Sleep(500);



            IWebElement exitmess = driver.FindElement(By.XPath("//*[@id=\"message\"]/span"));
            
            Thread.Sleep(500);





            Assert.Equal("Вы вышли из системы.", exitmess.Text);
            Thread.Sleep(1000);
            
            driver.Close();
        }


        [Fact]
        public void CreateNewNote_NameYUIOP ()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);

            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);

            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            Thread.Sleep(500);

            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();
            Thread.Sleep(500);

            IWebElement NewNote = driver.FindElement(By.XPath("//*[@id=\"newNoteBtn\"]"));
            NewNote.Click();
            Thread.Sleep(500);


            IWebElement newnotetitle = driver.FindElement(By.XPath("//*[@id=\"noteTitle\"]"));
            newnotetitle.SendKeys("YUIOP");
            Thread.Sleep(500);



            IWebElement newnotedesc = driver.FindElement(By.XPath("//*[@id=\"noteContent\"]"));
            newnotedesc.SendKeys("YUIOP");
            Thread.Sleep(500);


            IWebElement savebtn = driver.FindElement(By.XPath("//*[@id=\"saveBtn\"]"));
            savebtn.Click();
            Thread.Sleep(500);




            IWebElement CreatedNote = driver.FindElement(By.XPath("//*[@id=\"notesList\"]/li[1]/strong"));
            
            Thread.Sleep(500);

            










            Assert.Equal("YUIOP", CreatedNote.Text);
            Thread.Sleep(1000);
            
            driver.Close();
        }




        [Fact]
        public void CreateNewNote_NameBUIOP_ThenDel ()
        {
            
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);

            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);

            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            Thread.Sleep(500);

            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();
            Thread.Sleep(500);

            IWebElement NewNote = driver.FindElement(By.XPath("//*[@id=\"newNoteBtn\"]"));
            NewNote.Click();
            Thread.Sleep(500);


            IWebElement newnotetitle = driver.FindElement(By.XPath("//*[@id=\"noteTitle\"]"));
            newnotetitle.SendKeys("BUIOP");
            Thread.Sleep(500);



            IWebElement newnotedesc = driver.FindElement(By.XPath("//*[@id=\"noteContent\"]"));
            newnotedesc.SendKeys("BUIOP");
            Thread.Sleep(500);


            IWebElement savebtn = driver.FindElement(By.XPath("//*[@id=\"saveBtn\"]"));
            savebtn.Click();
            Thread.Sleep(500);




            IWebElement CreatedNote = driver.FindElement(By.XPath("//*[@id=\"notesList\"]/li[1]"));
            CreatedNote.Click();
            Thread.Sleep(500);


            IWebElement DelBtn = driver.FindElement(By.XPath("//*[@id=\"deleteBtn\"]"));
            DelBtn.Click();
            Thread.Sleep(500);


            var confirm = driver.SwitchTo().Alert();
            confirm.Accept();




            IWebElement searchI = driver.FindElement(By.XPath("//*[@id=\"searchInput\"]"));
            searchI.SendKeys("BUIOP");
            Thread.Sleep(500);



            IWebElement mess = driver.FindElement(By.XPath("//*[@id=\"message\"]/span"));
            
            Thread.Sleep(500);


            


            Assert.Equal("Заметка удалена.", mess.Text);
            Thread.Sleep(500);
            driver.Close();
        }


        [Fact]
        public void CheckNoteTitleIsRequired()
        {

            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);

            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);

            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            Thread.Sleep(500);

            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();
            Thread.Sleep(500);

            IWebElement NewNote = driver.FindElement(By.XPath("//*[@id=\"newNoteBtn\"]"));
            NewNote.Click();
            Thread.Sleep(500);


            IWebElement newnotetitle = driver.FindElement(By.XPath("//*[@id=\"noteTitle\"]"));
            

            Thread.Sleep(500);



            Assert.Equal("true", newnotetitle.GetAttribute("required"));
            Thread.Sleep(500);
            driver.Close();
        }


        
        [Fact]
        public void CheckHasShareBtnNote()
        {
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);

            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);
            
            Thread.Sleep(500);
            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();
            Thread.Sleep(500);
          

            IWebElement BTNSHARE = driver.FindElement(By.XPath("//*[@id=\"shareBtn\"]"));

            


            Assert.False(BTNSHARE.Displayed);
            Thread.Sleep(1000);

            driver.Close();
        }




        [Fact]
        public void CheckingOnlyYourNotes()
        {
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);

            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);

            Thread.Sleep(500);
            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();
            Thread.Sleep(1000);

            IWebElement box = driver.FindElement(By.Id("noteScopeFilter"));
            box.Click();
            Thread.Sleep(1000);
            IWebElement option = driver.FindElement(By.XPath("//*[@id=\"noteScopeFilter\"]/option[2]"));
            option.Click();
            Thread.Sleep(1000);


            IWebElement UL = driver.FindElement(By.Id("notesList"));


            var Lis = UL.FindElements(By.TagName("li"));
            foreach (var li in Lis)
            {

                IWebElement small = li.FindElement(By.TagName("small"));
                Assert.False(small.Text.Contains("Автор"));
            }







            driver.Close();
        }




        [Fact]
        public void CheckingOnlyGeneralNotes()
        {
            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);

            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);

            Thread.Sleep(500);
            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();
            Thread.Sleep(1000);

            IWebElement box = driver.FindElement(By.Id("noteScopeFilter"));
            box.Click();
            Thread.Sleep(1000);
            IWebElement option = driver.FindElement(By.XPath("//*[@id=\"noteScopeFilter\"]/option[3]"));
            option.Click();
            Thread.Sleep(1000);


            IWebElement UL = driver.FindElement(By.Id("notesList"));


            var Lis = UL.FindElements(By.TagName("li"));
            foreach (var li in Lis)
            {

                IWebElement small = li.FindElement(By.TagName("small"));
                Assert.True(small.Text.Contains("Автор"));
            }







            driver.Close();
        }




        

        [Fact]//bugreport
        public void ShareTwice()
        {

            driver.Navigate().GoToUrl("https://test.webmx.ru/");
            Thread.Sleep(500);

            IWebElement inputLogin = driver.FindElement(By.XPath("//*[@id=\"authUsername\"]"));
            inputLogin.SendKeys("mad");
            Thread.Sleep(500);

            IWebElement inputPassword = driver.FindElement(By.XPath("//*[@id=\"authPassword\"]"));
            inputPassword.SendKeys("16207002");
            Thread.Sleep(500);

            IWebElement btnLog = driver.FindElement(By.XPath("//*[@id=\"authSubmit\"]"));
            btnLog.Click();
            Thread.Sleep(500);

            IWebElement NewNote = driver.FindElement(By.XPath("//*[@id=\"newNoteBtn\"]"));
            NewNote.Click();
            Thread.Sleep(500);


            IWebElement newnotetitle = driver.FindElement(By.XPath("//*[@id=\"noteTitle\"]"));
            newnotetitle.SendKeys("BUIOP");
            Thread.Sleep(500);



            IWebElement newnotedesc = driver.FindElement(By.XPath("//*[@id=\"noteContent\"]"));
            newnotedesc.SendKeys("BUIOP");
            Thread.Sleep(500);


            IWebElement savebtn = driver.FindElement(By.XPath("//*[@id=\"saveBtn\"]"));
            savebtn.Click();
            Thread.Sleep(500);




            IWebElement CreatedNote = driver.FindElement(By.XPath("//*[@id=\"notesList\"]/li[1]"));
            CreatedNote.Click();
            Thread.Sleep(500);

            IWebElement SHARENAME = driver.FindElement(By.XPath("//*[@id=\"shareUsername\"]"));
            SHARENAME.SendKeys("smak@gmail.com");
            Thread.Sleep(500);




            IWebElement btnShare = driver.FindElement(By.XPath("//*[@id=\"shareBtn\"]"));
            btnShare.Click();
            Thread.Sleep(500);

            IWebElement mess = driver.FindElement(By.XPath("//*[@id=\"message\"]/span"));
            
            Thread.Sleep(500);


            SHARENAME.SendKeys("smak@gmail.com");
            btnShare.Click();


            Assert.NotEqual("Доступ успешно выдан.", mess.Text);
            Thread.Sleep(500);
            driver.Close();
        }
    }
}
