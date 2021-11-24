﻿using SharpenAlgorithm.EiProject.AlgorithmLibrary;
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
        TimeSpan elapsed = _watch.Elapsed;
        Console.WriteLine(algorithm.GetType().Name + " " + elapsed.TotalSeconds + "s");
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
        TimeSpan elapsed = _watch.Elapsed;
        Console.WriteLine(algorithm.GetType().Name + " " + elapsed.TotalSeconds + "s");
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
