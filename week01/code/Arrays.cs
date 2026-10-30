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
        // 1. Create a new array of doubles with the exact size specified by 'length'.
        var result = new double[length];

        // 2. Loop through each index to calculate and assign the multiples.
        // We multiply by (i + 1) so the first element is number * 1, the second is number * 2, etc.
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        // 3. Return the completed array.
        return result;
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
        // 1. Quick check to make sure we actually have something to rotate.
        if (data == null || data.Count <= 1 || amount <= 0)
            return;

        // 2. Normalize the amount using modulo just in case it's larger than the list size.
        amount = amount % data.Count;
        if (amount == 0)
            return;

        // 3. Figure out the index where the elements that need to move to the front begin.
        int splitIndex = data.Count - amount;

        // 4. Slice out the trailing elements that are moving to the front.
        var trailingItems = data.GetRange(splitIndex, amount);

        // 5. Remove those trailing elements from their original spot at the end.
        data.RemoveRange(splitIndex, amount);

        // 6. Insert them right back at the very beginning of the list (index 0).
        data.InsertRange(0, trailingItems);
    }
}
