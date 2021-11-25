using SharpenAlgorithm.EiProject.AlgorithmLibrary;
using SharpenAlgorithm.EiProject.AlgorithmLibrary.Search;
using SharpenAlgorithm.EiProject.AlgorithmLibrary.Sort;
using SharpenAlgorithm.EiProject.Database;
using SharpenAlgorithm.EiProject.Model;
using System;
using System.Diagnostics;

namespace SharpenAlgorithm.EiProject.RunningTest
{
  class Run
  {
    private Stopwatch _watch;
    private InputDatabase _db;
    private int _trueCount;
    private int _falseCount;
    private int _notImplementedCount;
    public Run(InputDatabase db)
    {
      _watch = new Stopwatch();
      _db = db;
      _trueCount = 0;
      _falseCount = 0;
      _notImplementedCount = 0;
    }

    public void Start()
    {
      Console.WriteLine("Starting!");
      FullTest(_db.RandNumbers);
      LogSummery();
    }

    private void FullTest(int[] inputArray)
    {
      SingleTest(new BubbleSort(_db));
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
        LogResponse(algorithm, response);
      }
      catch (NotImplementedException)
      {
        LogNotImplemented(algorithm);
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
        LogResponse(algorithm, response);
      }
      catch (NotImplementedException)
      {
        LogNotImplemented(algorithm);
      }
      finally
      {
        _watch.Reset();
      }
    }

    private void LogResponse(IAlgorithm algorithm, Response response)
    {
      Console.WriteLine(
        algorithm.GetType().Name + " => " +
        "Status: " + response.Status + " " + 
        "Elapsed: " + _watch.Elapsed.TotalMilliseconds + "ms");

      if (response.Status)
      {
        _trueCount++;
      }
      else
      {
        _falseCount++;
      }
    }

    private void LogNotImplemented(IAlgorithm algorithm)
    {
      Console.WriteLine(algorithm.GetType().Name +
          ", Not Implemented");
      _notImplementedCount++;
    }

    private void LogSummery()
    {
      Console.WriteLine(
$@"|------------------------------------------|
|---------------- SUMMARY -----------------|
| True result     : {_trueCount}{new string(' ', 23 - _trueCount.ToString().Length)}|
| False result    : {_falseCount}{new string(' ', 23 - _falseCount.ToString().Length)}|
| Not implemented : {_notImplementedCount}{new string(' ', 23 - _notImplementedCount.ToString().Length)}|
|------------------------------------------|
");
    }
  }
}
