using System;
using Xunit;
using OrderBot;

namespace OrderBot.tests
{
    public class OverUnderTest
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void TestWelcome()
        {
            Order oOrder = new Order();
            String sInput = oOrder.OnMessage("hello");
            Assert.True(sInput.Contains("Welcome"));
        }
        [Fact]
        public void TestStartOrderAnswerYesStep0()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            String sInput = oOrder.OnMessage("yes");
            Assert.True(sInput.Contains("size"));
        }
        [Fact]
        public void TestStartOrderAnswerNoStep0()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            String sInput = oOrder.OnMessage("no");
            Assert.True(sInput.Contains("See you"));
        }
        [Fact]
        public void TestSizeStep1()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(1);
            String sInput = oOrder.OnMessage("small");
            Assert.True(sInput.Contains("dough"));
        }
        [Fact]
        public void TestSizeAnswerBackStep1()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(1);
            String sInput = oOrder.OnMessage("back");
            Assert.True(sInput.Contains("Cannot go to previous step!"));
        }
        [Fact]
        public void TestDoughStep2()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(2);
            String sInput = oOrder.OnMessage("regula");
            Assert.True(sInput.Contains("crust"));
        }
        [Fact]
        public void TestCrustStep3()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(3);
            String sInput = oOrder.OnMessage("thin");
            Assert.True(sInput.Contains("sauce"));
        }
        [Fact]
        public void TestSauceStep4()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(4);
            String sInput = oOrder.OnMessage("tomato");
            Assert.True(sInput.Contains("topping"));
        }
        [Fact]
        public void TestToppingStep5()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(5);
            String sInput = oOrder.OnMessage("pepperoni");
            Assert.True(sInput.Contains("etc"));
        }
        [Fact]
        public void TestEtcStep6()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(6);
            String sInput = oOrder.OnMessage("caesar salad");
            Assert.True(sInput.Contains("Reminding"));
        }
        [Fact]
        public void TestRemindingAnswerYesStep7()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(7);
            String sInput = oOrder.OnMessage("yes");
            Assert.True(sInput.Contains("address"));
        }
        [Fact]
        public void TestRemindingAnswerBackStep7()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(7);
            String sInput = oOrder.OnMessage("back");
            Assert.True(sInput.Contains("etc"));
        }
        [Fact]
        public void TestAddressStep8()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(8);
            String sInput = oOrder.OnMessage("Lester st");
            Assert.True(sInput.Contains("Please pay at"));
        }
        [Fact]
        public void TestAddressAnswerBackStep8()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(8);
            String sInput = oOrder.OnMessage("back");
            Assert.True(sInput.Contains("Reminding"));
        }
        [Fact]
        public void TestCompleteStep9()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(9);
            String sInput = oOrder.OnMessage("done");
            Assert.True(sInput.Contains("Thank you for your pizza order. See you again"));
        }

        [Fact]
        public void TestWrongAnswerSizeStep1()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(1);
            String sInput = oOrder.OnMessage("hi");
            Assert.True(sInput.Contains("re-enter") && sInput.Contains("size"));
        }
        [Fact]
        public void TestWrongAnswerDoughStep2()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(2);
            String sInput = oOrder.OnMessage("hi");
            Assert.True(sInput.Contains("re-enter") && sInput.Contains("dough"));
        }
        [Fact]
        public void TestWrongAnswerCrustStep3()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(3);
            String sInput = oOrder.OnMessage("hi");
            Assert.True(sInput.Contains("re-enter") && sInput.Contains("crust"));
        }
        [Fact]
        public void TestWrongAnswerSauceStep4()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(4);
            String sInput = oOrder.OnMessage("hi");
            Assert.True(sInput.Contains("re-enter") && sInput.Contains("sauce"));
        }
        [Fact]
        public void TestWrongAnswerToppingStep5()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(5);
            String sInput = oOrder.OnMessage("hi");
            Assert.True(sInput.Contains("re-enter") && sInput.Contains("topping"));
        }
        [Fact]
        public void TestWrongAnswerEtcStep6()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(6);
            String sInput = oOrder.OnMessage("hi");
            Assert.True(sInput.Contains("re-enter") && sInput.Contains("etc"));
        }
        [Fact]
        public void TestWrongAnswerRemindingStep7()
        {
            Order oOrder = new Order();
            oOrder.OnMessage("hello");
            oOrder.SetStep(7);
            String sInput = oOrder.OnMessage("hi");
            Assert.True(sInput.Contains("Please re-enter. [yes] or [back]"));
        }
    }
}
