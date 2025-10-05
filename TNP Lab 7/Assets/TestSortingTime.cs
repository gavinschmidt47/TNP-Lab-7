using UnityEngine;
using System.Runtime.InteropServices;

public class TestSortingTime : MonoBehaviour
{
    [DllImport("DLLSort", EntryPoint = "TestSort")]
    public static extern void TestSort(int[] a, int length);

    public int[] a;
    public int[] b;

    void Start()
    {
        // Create an array of 1,000,000 unique integers in the range [1,000,000, 1,000,000,000]
        a = new int[1000000];
        b = new int[1000000];
        System.Random rand = new System.Random();
        System.Collections.Generic.HashSet<int> uniqueNumbers = new System.Collections.Generic.HashSet<int>();
        while (uniqueNumbers.Count < a.Length)
        {
            int num = rand.Next(1000000, 1000000001); // upper bound is exclusive
            uniqueNumbers.Add(num);
        }
        uniqueNumbers.CopyTo(a);
        uniqueNumbers.CopyTo(b);

        MeasureNativePlugin();
        MeasureManagedCode();
    }

    void MeasureNativePlugin()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        TestSort(b, b.Length);
        stopwatch.Stop();
        Debug.Log($"Native plugin sorting took: {stopwatch.ElapsedMilliseconds} ms");
    }

    void MeasureManagedCode()
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        System.Array.Sort(a);
        stopwatch.Stop();
        Debug.Log($"Managed code sorting took: {stopwatch.ElapsedMilliseconds} ms");
    }
}
