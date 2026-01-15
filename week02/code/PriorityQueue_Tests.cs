using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
      
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Add items to the queue and verify they are added to the back
    // Expected Result: Items should be in the queue in the order they were added
    // Defect(s) Found:
    public void TestPriorityQueue_EnqueueAddsToBack()
    {
        var priorityQueue = new PriorityQueue();

        //Add three items with the SAME priority
        // This way we can verify they stay in the order added (FIFO)
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 1);
        priorityQueue.Enqueue("Third", 1);

        //If they were added to the back correctly, and dequeue works correctly,
        //we should get them in the order: First, Second, Third
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());

    }

    [TestMethod]
    //Scenario: Enqueue items with different priorities and verify highest priority is dequeued first
    //Expected Result: Item with priority 5 should be dequeued first, then 3, then 1
    //Defect(s) Found:
    public void TestPriorityQueue_DequeueHighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        //add items in a mixed order
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        //Dequeue should return the highest priority first (5)
        Assert.AreEqual("High", priorityQueue.Dequeue());

        //then the next highest (3)
        Assert.AreEqual("Medium", priorityQueue.Dequeue());

        //Finally the lowest (1)
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }
}
