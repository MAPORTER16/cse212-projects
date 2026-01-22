/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create queue with valid size of 5
        // Expected Result: max_size should be 5
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(5);
        Console.WriteLine(cs1);
        Console.WriteLine("Expected: max_size=5");
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Create queue with invalid size of 0
        // Expected Result: max_size should default to 10
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(0);
        Console.WriteLine(cs2);
        Console.WriteLine("Expected: max_size=10");
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Create queue with invalid size of -3
        // Expected Result: max_size should default to 10
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(-3);
        Console.WriteLine(cs3);
        Console.WriteLine("Expected: max_size=10");
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Try to serve a customer when queue is empty
        // Expected Result: Should display error message
        Console.WriteLine("Test 4");
        var cs4 = new CustomerService(10);
        cs4.ServeCustomer();
        Console.WriteLine("Expected: Error message for empty queue");
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Add customer, then serve to verify FIFO order
        // Expected Result: Should display the customer that was added
        Console.WriteLine("Test 5");
        var cs5 = new CustomerService(10);
        cs5.AddNewCustomerTest("Alice", "A001", "Login issue");
        Console.WriteLine("Queue after adding Alice: " + cs5);
        cs5.ServeCustomer();
        Console.WriteLine("Queue after serving: " + cs5);
        Console.WriteLine("Expected: Alice was displayed and queue is now empty");
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 6
        // Scenario: Add 2 customers to queue of size 2, then try to add a 3rd
        // Expected Result: First 2 should be added, 3rd should show error message
        Console.WriteLine("Test 6");
        var cs6 = new CustomerService(2);
        cs6.AddNewCustomerTest("Bob", "B001", "Password reset");
        cs6.AddNewCustomerTest("Carol", "C001", "Billing question");
        Console.WriteLine("Queue with 2 customers: " + cs6);
        Console.WriteLine("Attempting to add 3rd customer to full queue:");
        cs6.AddNewCustomerTest("Dave", "D001", "Account locked");
        Console.WriteLine("Queue after trying to add 3rd: " + cs6);
        Console.WriteLine("Expected: Error message and queue still has size=2");
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 7
        // Scenario: Add 3 customers and serve them to verify FIFO order
        // Expected Result: Customers should be served in the order they were added (Bob, Carol, Dave)
        Console.WriteLine("Test 7");
        var cs7 = new CustomerService(10);
        cs7.AddNewCustomerTest("Bob", "B001", "Password reset");
        cs7.AddNewCustomerTest("Carol", "C001", "Billing question");
        cs7.AddNewCustomerTest("Dave", "D001", "Account locked");
        Console.WriteLine("Queue with 3 customers: " + cs7);
        Console.WriteLine("Serving customer 1:");
        cs7.ServeCustomer();
        Console.WriteLine("Serving customer 2:");
        cs7.ServeCustomer();
        Console.WriteLine("Serving customer 3:");
        cs7.ServeCustomer();
        Console.WriteLine("Queue after serving all: " + cs7);
        Console.WriteLine("Expected: Bob, Carol, Dave served in that order");
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    public void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
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
    /// Helper method for testing - adds a customer without prompting for input
    /// </summary>
    public void AddNewCustomerTest(string name, string accountId, string problem)
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    public void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in the queue.");
            return;
        }

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
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}