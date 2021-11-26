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

  class Run : IRun
  {
    private Stopwatch _watch;
    private InputDatabase _db;
    private int _trueCount;
    private int _falseCount;
    private int _notImplementedCount;
    private int _stressTestNumber;
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
      _stressTestNumber = 1000;
    }

    public void Stabilizer()
    {
      Thread.Sleep(1000);
      Console.WriteLine("Stabilizing ...");
      Thread.Sleep(1000);
    }

    public void Start()
    {
      Console.WriteLine("Starting!");
      FullTest();
      LogSummery();
    }

    public void CreateCustomStressTest(int stressTestNumber)
    {
      _stressTestNumber = stressTestNumber;
    }

    private void FullTest()
    {
      SingleTest(new BubbleSort(_db));
      SingleTest(new HeapSort(_db));
      SingleTest(new MergeSort(_db));
      SingleTest(new QuickSort(_db));
      SingleTest(new InsertionSort(_db));
      SingleTest(new SelectionSort(_db));

      SingleTest(new JumpSearch(_db));
      SingleTest(new LinearSearch(_db));
      SingleTest(new BinarySearch(_db));
      SingleTest(new ExponentialSearch(_db));
      SingleTest(new InterpolationSearch(_db));
    }

    private void SingleTest(IAlgorithm algorithm)
    {
      ResetTimer();
      ResetStatus();

      // first try test 
      for (int i = 0; i < _stressTestNumber; i++)
      {
        StatusCode status = RunFirstTryMethod(algorithm);
        if (status == StatusCode.Fail) break;
      }
      if (_isFirstTrySuccess) LogResultOK(algorithm, _firstTryTimer);

      // optimization test
      for (int i = 0; i < _stressTestNumber; i++)
      {
        StatusCode status = RunOptimizationMethod(algorithm);
        if (status == StatusCode.Fail) break;
      }
      if (_isOptimizationSuccess) LogResultOK(algorithm, _optimizationTimer);

      // Get result
      if (_isFirstTrySuccess == true && _isOptimizationSuccess == true) 
        GetPercentageOfOptimizationResult();
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

    private StatusCode RunFirstTryMethod(IAlgorithm algorithm)
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
        _watch.Reset();
      }
    }

    private void UpdateFirstTryTimer()
    {
      double elapsed = _watch.Elapsed.TotalMilliseconds;
      _firstTryTimer = _firstTryTimer != 0 ? elapsed : (_firstTryTimer + elapsed) / 2;
    }

    private StatusCode RunOptimizationMethod(IAlgorithm algorithm)
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
        _watch.Reset();
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

    private void GetPercentageOfOptimizationResult()
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
