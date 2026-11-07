using System;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    /* 
    PLAN:
    1. Create a new array 'result' the same size as the 'select' array.
    2. Initialize two variables, index1 and index2, to 0 to track positions in list1 and list2.
    3. Loop through the 'select' array.
    4. If the current select value is 1, assign list1[index1] to the result array and increment index1.
    5. If the current select value is 2, assign list2[index2] to the result array and increment index2.
    */
    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] result = new int[select.Length];
        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
            {
                result[i] = list1[index1];
                index1++;
            }
            else if (select[i] == 2)
            {
                result[i] = list2[index2];
                index2++;
            }
        }

        return result;
    }
}