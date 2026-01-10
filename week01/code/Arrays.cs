using System.ComponentModel;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create an array to hold our multiples
        // The size is 'length' (not hardcoded!)
        double[] results = new double[length];
         

           // Step 2: Loop through each position in the array
            // i will be 0, 1, 2, 3, 4... up to (length - 1)
        for (int i = 0; i < length; i++)
        {
            // Step 3 & 4: Calculate the multiple and store it
            // When i=0: number * (0+1) = number * 1 = first multiple
            // When i=1: number * (1+1) = number * 2 = second multiple
            // When i=2: number * (2+1) = number * 3 = third multiple
            results[i] = number * (i + 1);
        }

        return results; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // Step 1: Figure out where to split the list
        //         If we rotate by 3, we take the last 3 items
        //         So the split point is at: data.Count - amount
        //         For a list of 9 items, rotating by 3: split at 9 - 3 = 6

        // Step 2: Get the two parts
        //         Part A: items that stay in back (from start to split point)
        //         Part B: items that move to front (from split point to end)

        // Step 3: Clear the original list

        // Step 4: Add Part B first (the items that were at the end)

        // Step 5: Add Part A second (the items that were at the start)

        // IMPLEMENTATION:
        int splitIndex = data.Count - amount;

        //Get Part A: items from 0 to splitIndex
        List<int> partA = data.GetRange(0, splitIndex);

        //Get Part B: items from splitIdex to end
        List<int> partB = data.GetRange(splitIndex, amount);

        //Clear the origina list
        data.Clear();

        //Add Part B first (what was at the end)
        data.AddRange(partB);

        //Add Part A second (what was at the start)
        data.AddRange(partA);
    }
}
