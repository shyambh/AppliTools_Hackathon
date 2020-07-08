using Applitools;
using Applitools.Selenium;
using System;
using System.Drawing;
using NUnit.Framework;
using OpenQA.Selenium;

namespace ApplitoolsTutorial
{
    public class UFGDemo: BaseClass
    {
        [Test]
		public void Task1()
		{
            try
            
            {
                GoToApplication();
				eyes.Open(webDriver, "Demo App", "Cross-Device Elements Test", new Size(800, 600));
                eyes.Check("Cross-Device Elements Test", Target.Window().Fully().WithName("Main Shopping Page"));

				// Call Close on eyes to let the server know it should display the results
				eyes.CloseAsync();

			}
			catch (Exception e)
			{
				eyes.AbortAsync();
			}

        }


        [Test]
        public void Task2()
        {
            try

            {
                GoToApplication();
                // Call Open on eyes to initialize a test session
                eyes.Open(webDriver, "Demo App", "Filter Results", new Size(800, 600));

                webDriver.FindElement(By.Id("ti-filter")).Click();
                
                if(IsElementPresentByCssOrXpath("//label[text()=\"Black \"]/span[contains(@class,'checkmark')]", false))
                    webDriver.FindElement(By.XPath("//label[text()=\"Black \"]/span[contains(@class,'checkmark')]")).Click();

                else
                {
                    webDriver.FindElement(By.Id("ti-filter")).Click();
                }
                webDriver.FindElement(By.Id("filterBtn")).Click();

                eyes.Check("Filter Results", Target.Region(By.Id("product_grid")));

                // Call Close on eyes to let the server know it should display the results
                eyes.CloseAsync();
            }
            catch (Exception e)
            {
                eyes.AbortAsync();
            }
        }

        [Test]
        public void Task3()
        {
            try

            {
                GoToApplication();
                // Call Open on eyes to initialize a test session
                eyes.Open(webDriver, "Demo App", "Product Details test", new Size(800, 600));

                webDriver.FindElement(By.Id("ti-filter")).Click();

                if (IsElementPresentByCssOrXpath("//label[text()=\"Black \"]/span[contains(@class,'checkmark')]", false))
                    webDriver.FindElement(By.XPath("//label[text()=\"Black \"]/span[contains(@class,'checkmark')]")).Click();

                else
                {
                    webDriver.FindElement(By.Id("ti-filter")).Click();
                }
                webDriver.FindElement(By.Id("filterBtn")).Click();

                webDriver.FindElement(By.Id("product_1")).Click();

                eyes.Check("Product Details test", Target.Window().Fully().WithName("Main Shopping Page"));

                // Call Close on eyes to let the server know it should display the results
                eyes.CloseAsync();
            }
            catch (Exception e)
            {
                eyes.AbortAsync();
            }

        }
    }
}
