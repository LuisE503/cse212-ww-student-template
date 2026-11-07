using System;
using System.Collections.Generic;

/// <summary>
/// Maintain a Customer Service Queue. Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test Cases

        // Test 1
        // Scenario: Add a customer and serve them.
        // Expected Result: It should prompt for info, then display the exact customer info when served.
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(2);
        Console.WriteLine("--> Type a Name, ID, and Problem for Test 1:");
        cs1.AddNewCustomer(); 
        cs1.ServeCustomer();
        // Defect(s) Found: ServeCustomer was removing the customer from the queue BEFORE saving their data, causing a crash or wrong data.

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Try to serve a customer when the queue is completely empty.
        // Expected Result: It should print an error message instead of crashing.
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(2);
        cs2.ServeCustomer();
        // Defect(s) Found: ServeCustomer had no check for an empty queue, which threw an IndexOutOfRangeException.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Try to add more customers than the maximum size allowed.
        // Expected Result: The 3rd attempt should print "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(2);
        Console.WriteLine("--> Type info for Customer 1:");
        cs3.AddNewCustomer();
        Console.WriteLine("--> Type info for Customer 2:");
        cs3.AddNewCustomer();
        Console.WriteLine("--> Attempting to add Customer 3 (Queue should be full):");
        cs3.AddNewCustomer();
        // Defect(s) Found: AddNewCustomer used '> _maxSize' instead of '>= _maxSize', allowing one extra customer to bypass the limit.
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class. Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information. Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // CORRECCIÓN 1: Se cambió > por >= para respetar el límite máximo correctamente.
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // CORRECCIÓN 2: Se agregó la validación para evitar que el programa colapse si la cola está vacía.
        if (_queue.Count <= 0) {
            Console.WriteLine("No Customers in Queue to Serve.");
            return;
        }

        // CORRECCIÓN 3: El cliente debe guardarse en la variable ANTES de ser eliminado de la cola.
        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}