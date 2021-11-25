using SharpenAlgorithm.Yours.AlgorithmLibrary;
using SharpenAlgorithm.Yours.AlgorithmLibrary.Search;
using SharpenAlgorithm.Yours.AlgorithmLibrary.Sort;
using SharpenAlgorithm.Yours.Database;
using SharpenAlgorithm.Yours.Model;
using System;
using System.Diagnostics;

namespace SharpenAlgorithm.Yours.RunningTest
{
  class Run
  {
    private Stopwatch _watch;
    private InputDatabase _db;
    public Run(InputDatabase db)
    {
      _watch = new Stopwatch();
      _db = db;
    }

    public void Start()
    {
      Console.WriteLine("Starting!");
      FullTest(_db.Ages);
    }

    private void FullTest(int[] inputArray)
    {
      SingleTest(new BubbleSort(inputArray));
      SingleTest(new HeapSort(inputArray));
      SingleTest(new InsertionSort(inputArray));
      SingleTest(new MergeSort(inputArray));
      SingleTest(new QuickSort(inputArray));
      SingleTest(new SelectionSort(inputArray));

      SingleTest(new BinarySearch(inputArray));
      SingleTest(new ExponentialSearch(inputArray));
      SingleTest(new InterpolationSearch(inputArray));
      SingleTest(new JumpSearch(inputArray));
      SingleTest(new LinearSearch(inputArray));
    }

    private void SingleTest(IAlgorithm algorithm)
    {
      FirstTryTest(algorithm);
      OptimizedTest(algorithm);
    }

    private void FirstTryTest(IAlgorithm algorithm)
    {
      _watch.Start();
      try
      {
        Response response = algorithm.FirstTry();
        Console.WriteLine(algorithm.GetType().Name + " " + _watch.Elapsed.TotalMilliseconds + "ms");
      }
      catch (NotImplementedException)
      {
        Console.WriteLine(algorithm.GetType().Name + ", Not Implemented");
      }
      finally
      {
        _watch.Reset();
      }
    }

    private void OptimizedTest(IAlgorithm algorithm)
    {
      _watch.Start();
      try
      {
        Response response = algorithm.Optimized();
        Console.WriteLine(algorithm.GetType().Name + " " + _watch.Elapsed.TotalMilliseconds + "ms");
      }
      catch (NotImplementedException)
      {
        Console.WriteLine(algorithm.GetType().Name + ", Not Implemented");
      }
      finally
      {
        _watch.Reset();
      }
    }
  }
}
