using DataStructures;

namespace Exam1
{
    public class Problem3Browser
    {
        /*
         ### 3. Browser History Navigation

            Description:

            Build a console app that simulates a web browser’s back and forward buttons. Users can:

            1. Navigate to a new URL (e.g. go https://example.com)

            2. Press “back” to return to the previous page (This can be a method)

            3. Press “forward” to go forward again (only if they’ve gone back before) (this can be a method)

            4. View their current page at any time

            Your implementation should efficiently handle an arbitrary sequence of these commands and report the current URL after each operation.
        best structure: I think LINKEDLIST, because I can move to forward or back between nodes
         */

        private readonly CustomLinkedList<string> _history = new();
        private int _currentIndex = -1;

        public void Go(string url)
        {
            _history.AddLast(url);
            _currentIndex++;
            Console.WriteLine($"Navigated to: {url}");
        }

        public void Back()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                Console.WriteLine($"Went back to: {_history.Get(_currentIndex)}");
            }
            else
            {
                Console.WriteLine("No previous page.");
            }
        }

        public void Forward()
        {
            if (_currentIndex < _history.Count - 1)
            {
                _currentIndex++;
                Console.WriteLine($"Went forward to: {_history.Get(_currentIndex)}");
            }
            else
            {
                Console.WriteLine("No forward page.");
            }
        }

        public void Current()
        {
            if (_currentIndex >= 0 && _currentIndex < _history.Count)
            {
                Console.WriteLine($"Current page: {_history.Get(_currentIndex)}");
            }
            else
            {
                Console.WriteLine("No pages visited yet.");
            }
        }
    }
}
