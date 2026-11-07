using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and record the expected results.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with varying priorities, then dequeue them.
    // Expected Result: "High", "Medium", "Low"
    // Defect(s) Found: Dequeue did not actually remove the item, it just read it. Also, the loop condition 'index < _queue.Count - 1' missed checking the final element in the queue.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 5);
        pq.Enqueue("Medium", 3);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the exact same priority to check FIFO tie-breaking.
    // Expected Result: "First", "Second", "Third"
    // Defect(s) Found: The '>=' comparison in Dequeue meant the LATEST added item with the same priority was chosen, violating the FIFO rule. Fixed by using '>'.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 2);
        pq.Enqueue("Second", 2);
        pq.Enqueue("Third", 1);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from a completely empty queue.
    // Expected Result: Throws an InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None in this specific case, the exception logic was already present and correct.
    public void TestPriorityQueue_3()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}