using SharpenAlgorithm.EiProject.AlgorithmLibrary;
using SharpenAlgorithm.EiProject.AlgorithmLibrary.Search;
using SharpenAlgorithm.EiProject.AlgorithmLibrary.Sort;
using SharpenAlgorithm.EiProject.Database;
using SharpenAlgorithm.EiProject.Model;
using System;
using System.Diagnostics;
using System.Threading;

namespace SharpenAlgorithm.EiProject.RunningTest
{
  enum StatusCode
  {
    OK,
    Fail
  }

  class Run
  {
    private Stopwatch _watch;
    private InputDatabase _db;
    private int _trueCount;
    private int _falseCount;
    private int _notImplementedCount;
    private double _firstTryTimer;
    private double _optimizationTimer;
    private bool _isFirstTrySuccess;
    private bool _isOptimizationSuccess;
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
      ResetTimer();
      ResetStatus();

      for (int i = 0; i< 100; i++)
      {
        StatusCode status = FirstTryTest(algorithm);
        if (status == StatusCode.Fail) break;
      }
      if (_isFirstTrySuccess) LogResultOK(algorithm, _firstTryTimer);

      for (int i = 0; i < 100; i++)
      {
        StatusCode status = OptimizedTest(algorithm);
        if (status == StatusCode.Fail) break;
      }
      if (_isOptimizationSuccess) LogResultOK(algorithm, _optimizationTimer);

      if (_isFirstTrySuccess == true && _isOptimizationSuccess == true) 
        GetOptimizationResult();
    }

    private void ResetTimer()
    {
      _firstTryTimer = 0;
      _optimizationTimer = 0;
    }

    private void ResetStatus()
    {
      _isFirstTrySuccess = false;
      _isOptimizationSuccess = false;
    }

    private StatusCode FirstTryTest(IAlgorithm algorithm)
    {
      try
      {
        _watch.Start();
        Response response = algorithm.FirstTry(); 
        _watch.Stop();
        CheckResponse(response, ref _isFirstTrySuccess);
        UpdateFirstTryTimer();
        return StatusCode.OK;
      }
      catch (NotImplementedException)
      {
        LogNotImplemented(algorithm);
        return StatusCode.Fail;
      }
      catch (FalseResultException)
      {
        LogResultFalse(algorithm);
        return StatusCode.Fail;
      }
      finally
      {
        _watch.Stop();
      }
    }

    private void UpdateFirstTryTimer()
    {
      double elapsed = _watch.Elapsed.TotalMilliseconds;
      _firstTryTimer = _firstTryTimer != 0 ? elapsed : (_firstTryTimer + elapsed) / 2;
    }

    private StatusCode OptimizedTest(IAlgorithm algorithm)
    {
      try
      {
        _watch.Start();
        Response response = algorithm.Optimized();
        _watch.Stop();
        CheckResponse(response, ref _isOptimizationSuccess);
        UpdateOptimizationTimer();
        return StatusCode.OK;
      }
      catch (NotImplementedException)
      {
        LogNotImplemented(algorithm);
        return StatusCode.Fail;
      }
      catch (FalseResultException)
      {
        LogResultFalse(algorithm);
        return StatusCode.Fail;
      }
      finally
      {
        _watch.Stop();
      }
    }

    private void UpdateOptimizationTimer()
    {
      double elapsed = _watch.Elapsed.TotalMilliseconds;
      _optimizationTimer = _optimizationTimer != 0 ? elapsed : (_optimizationTimer + elapsed) / 2;
    }

    private void CheckResponse(Response response, ref bool status)
    {
      if (!response.Status) throw new FalseResultException();
      status = true;
    }

    private void GetOptimizationResult()
    {
      Console.WriteLine($"=> Optimization: {(_firstTryTimer - _optimizationTimer)/_firstTryTimer*100}%");
    }

    private void LogResultOK(IAlgorithm algorithm, double elapsed)
    {
      Console.WriteLine(
        algorithm.GetType().Name + " => " +
        "Elapsed: " + elapsed + "ms");
      _trueCount++;
    }

    private void LogResultFalse(IAlgorithm algorithm)
    {
      Console.WriteLine(algorithm.GetType().Name +
          ", Result False");
      _falseCount++;
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
