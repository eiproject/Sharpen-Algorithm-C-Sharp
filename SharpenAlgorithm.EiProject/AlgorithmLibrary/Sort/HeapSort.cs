using SharpenAlgorithm.EiProject.Database;
using SharpenAlgorithm.EiProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.AlgorithmLibrary.Sort
{
  class HeapSort : IAlgorithm
  {
    private InputDatabase _db;
    public HeapSort(InputDatabase db)
    {
      _db = db; ;
    }

    public Response FirstTry()
    {
      int[] inputArray = new int[_db.RandNumbers.Length];
      _db.RandNumbers.CopyTo(inputArray, 0);

      int arrLength = inputArray.Length;
      int[] result = new int[arrLength];
      for (int i = 0; i < arrLength; i++)
      {
        inputArray = CreateMaxHeap(inputArray);
        SwapMaxHeap(ref inputArray);
        result[result.Length - 1 - i] = inputArray[inputArray.Length - 1];
        inputArray = inputArray.Take(inputArray.Length - 1).ToArray();
      }

      return new Response()
      {
        ResultArr = result,
        Status = result.SequenceEqual(_db.SortedNumbers)
      };
    }

    private int[] CreateMaxHeap(int[] inputArray)
    {
      bool isSwapping = true;
      int leafesEachNode = 2;

      while (isSwapping)
      {
        isSwapping = false;
        for (int i = 0; i < inputArray.Length; i++)
        {
          for (int s = 0; s < leafesEachNode; s++)
          {
            if (i * 2 + s < inputArray.Length - 1)
            {
              int leafIndex = i == 0 ? 1 + s : i * 2 + s;
              if (inputArray[i] < inputArray[leafIndex])
              {
                Swap(ref inputArray[i], ref inputArray[leafIndex]);
                isSwapping = true;
              }
            }
          }
        }
      }
      return inputArray;
    }

    private void SwapMaxHeap(ref int[] inputArray)
    {
      int a = inputArray[0];
      inputArray[0] = inputArray[inputArray.Length - 1];
      inputArray[inputArray.Length - 1] = a;
    }

    private void Swap(ref int a, ref int b)
    {
      int c = a;
      a = b;
      b = c;
    }

    public Response Optimized()
    {
      int[] inputArray = new int[_db.RandNumbers.Length];
      _db.RandNumbers.CopyTo(inputArray, 0);

      int arrLength = inputArray.Length;
      int[] result = new int[arrLength];
      for (int i = 0; i < arrLength; i++)
      {
        inputArray = CreateMaxHeapOpt(inputArray);
        SwapMaxHeap(ref inputArray);
        result[result.Length - 1 - i] = inputArray[inputArray.Length - 1];
        inputArray = inputArray.Take(inputArray.Length - 1).ToArray();
      }

      return new Response()
      {
        ResultArr = result,
        Status = result.SequenceEqual(_db.SortedNumbers)
      };
    }

    private int[] CreateMaxHeapOpt(int[] inputArray)
    {
      bool isAllEvaluated = false;
      bool isSwapping = true;
      int leafesEachNode = 2;

      while (isSwapping)
      {
        isSwapping = false;
        isAllEvaluated = false;
        for (int i = 0; i < inputArray.Length; i++)
        {
          for (int s = 0; s < leafesEachNode; s++)
          {
            if (i * 2 + s < inputArray.Length - 1)
            {
              int leafIndex = i == 0 ? 1 + s : i * 2 + s;
              if (inputArray[i] < inputArray[leafIndex])
              {
                Swap(ref inputArray[i], ref inputArray[leafIndex]);
                isSwapping = true;
              }
            }
            else
            {
              isAllEvaluated = true;
              break;
            }
          }

          if (isAllEvaluated)
            break;
        }
      }
      return inputArray;
    }
  }
}
