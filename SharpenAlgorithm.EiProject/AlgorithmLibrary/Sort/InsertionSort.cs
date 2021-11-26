using SharpenAlgorithm.EiProject.Database;
using SharpenAlgorithm.EiProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.AlgorithmLibrary.Sort
{
  class InsertionSort : IAlgorithm
  {
    private InputDatabase _db;
    public InsertionSort(InputDatabase db)
    {
      _db = db; ;
    }
    public Response FirstTry()
    {
      int[] inputArray = new int[_db.RandNumbers.Length];
      _db.RandNumbers.CopyTo(inputArray, 0);

      bool isSwapping = true;
      int currentIndexEvaluated = 0;
      while (isSwapping)
      {
        for (int i = 0; i < currentIndexEvaluated; i++)
        {
          if (inputArray[currentIndexEvaluated] < inputArray[i])
          {
            Swap(ref inputArray[currentIndexEvaluated], ref inputArray[i]);
          }
        }
        currentIndexEvaluated++;
        if (currentIndexEvaluated > inputArray.Length - 1) isSwapping = false;
      }

      return new Response()
      {
        ResultArr = inputArray,
        Status = inputArray.SequenceEqual(_db.SortedNumbers)
      };
    }

    public Response Optimized()
    {
      int[] inputArray = new int[_db.RandNumbers.Length];
      _db.RandNumbers.CopyTo(inputArray, 0);

      bool isSwapping = true;
      int currentIndexEvaluated = 1;
      while (isSwapping)
      {
        for (int i = 0; i < currentIndexEvaluated; i++)
        {
          if (inputArray[currentIndexEvaluated] < inputArray[i])
          {
            Swap(ref inputArray[currentIndexEvaluated], ref inputArray[i]);
          }
        }
        currentIndexEvaluated++;
        if (currentIndexEvaluated > inputArray.Length - 1) isSwapping = false;
      }

      return new Response()
      {
        ResultArr = inputArray,
        Status = inputArray.SequenceEqual(_db.SortedNumbers)
      };
    }

    private void Swap(ref int a, ref int b)
    {
      int c = a;
      a = b;
      b = c;
    }

  }
}
