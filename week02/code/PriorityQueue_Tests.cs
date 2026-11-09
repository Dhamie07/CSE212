using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities (Low: 1, Medium: 3, High: 5) and dequeue them.
    // Expected Result: Items are dequeued in order of highest priority value first (High -> Medium -> Low).
    // Defect(s) Found: When I ran this test, I found that the queue wasn't sorting or searching by priority on dequeue; it was just behaving like a standard FIFO queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items where two items share the exact same highest priority.
    // Expected Result: The item closest to the front of the queue (FIFO order) with that highest priority is removed first.
    // Defect(s) Found: I noticed that when multiple items shared the same high priority, my test failed because the queue didn't respect FIFO ordering for ties.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First High", 5);
        priorityQueue.Enqueue("Second High", 5);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("First High", priorityQueue.Dequeue());
        Assert.AreEqual("Second High", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the exact message "The queue is empty."
    // Defect(s) Found: When testing an empty queue, I found it threw an ArgumentOutOfRangeException instead of the required InvalidOperationException with the message "The queue is empty.".
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}