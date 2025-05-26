using DataStructures;

namespace Exam1
{
    /*
     * ### 2. Print Server Load Balancer

        Description:

        A shared print server distributes incoming print tasks to multiple printers to keep them busy. You need to simulate the assignment logic:

        1. EnqueueJob(string jobId): A new print job arrives and is placed in the waiting line.

        2. AssignNext(): Pull the next job from the front of the line and send it to the least-busy printer.

        3. CompleteJob(string printerId, string jobId): The printer finishes its current job and becomes available again.

        4. Status(): Report the list of waiting jobs in order and each printer’s current job (or idle).

        Ensure that jobs are handled strictly in arrival order, and assignment always takes the oldest waiting job.

    BEST STRUCTURE: Queue because in this case I need to send the firt item that is on the queue 
    */
    public class Problem2Printing
    {
        private readonly CustomQueue<string> _customQueue = new();
        private readonly Dictionary<string, string?> _printersDictionary = new();

        public Problem2Printing(IEnumerable<string> printerID) {
            foreach (var id in printerID)
                _printersDictionary[id] = null;
        }

        public void EnqueueJob(string jobId) { 
            _customQueue.Enqueue(jobId);
            Console.WriteLine($"Job '{jobId}' added to the queue.");
        }

        public void AssignNext() {
            if (_customQueue.Count > 0) {
                foreach (var printer in _printersDictionary.Keys) {
                    if (_printersDictionary[printer] == null)
                    {
                        _printersDictionary[printer] = _customQueue.Dequeue();
                        Console.WriteLine($"La tarea fue asigada '{printer}'" );
                        break;
                    }
                } 
            }
        }

        public void CompleteJob(string printerId, string jobId) {
            if (!_printersDictionary.ContainsKey(printerId))
            {
                Console.WriteLine($"Printer '{printerId}' no existe.");
                return;
            }

            var current = _printersDictionary[printerId];

            if (current == null)
            {
                Console.WriteLine($"Printer '{printerId}' no tiene nada para completar");
            }
            else if (current == jobId)
            {
                Console.WriteLine($"Printer '{printerId}' job completado '{jobId}'.");
                _printersDictionary[printerId] = null;
            }
            else
            {
                Console.WriteLine($"Printer '{printerId}' tiene la siguente tarea '{current}', no esta '{jobId}'.");
            }
        }

        public void Status()
        {
            Console.WriteLine("\n--- Print Status ---");
            foreach (var printer in _printersDictionary)
            {
                Console.WriteLine($"{printer.Key}: {printer.Value}");
            }
            Console.WriteLine("----------------------------\n");
        }

    }
}
