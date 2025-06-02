using Exam1.Problem4;

namespace Exam1
{
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        static void Main()
        {
            /*
            var expressionEvaluator = new ExpressionEvaluator(); //e.g. 5, +, 3, *, 2)
            expressionEvaluator.EnterNumber(5);
            expressionEvaluator.EnterOperator('+');
            expressionEvaluator.EnterNumber(3);
            expressionEvaluator.EnterOperator('*');
            expressionEvaluator.EnterNumber(2);
            expressionEvaluator.Undo();
            Console.WriteLine(string.Join("", expressionEvaluator.Evaluate())); //5+3*
            */
            //problem2

            var printer = new Problem2Printing(["Printer1", "Printer2"]);
            printer.EnqueueJob("Text 1");
            printer.EnqueueJob("Text 2");
            printer.EnqueueJob("Text 3");
            printer.AssignNext();
            printer.AssignNext();
            printer.Status();
            printer.CompleteJob("Printer1", "Text 1");
            printer.Status();


            var browser = new Problem3Browser();

            browser.Go("firturl");
            browser.Go("secondUrg");
            browser.Go("threeUr");

            browser.Back();     // secondUrg
            browser.Back();     // firturl
            browser.Forward();  // secondUrg

            browser.Go("fourUrl"); // 
            browser.Current();  // fourUrl


            ////problem 4
            
            var service = new OrderService();
            service.ProcessOrders();
        }
    }
}