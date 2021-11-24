using SharpenAlgorithm.Yours.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.Yours.AlgorithmLibrary.Sort
{
  class BubbleSort : IAlgorithm
  {
    private int[] _inputArray;
    public BubbleSort(int[] inputArray)
    {
      _inputArray = inputArray;
    }

    public Response FirstTry()
    {
      int[] inputArray = new int[_inputArray.Length];
      _inputArray.CopyTo(inputArray, 0);

      for (int i = 0; i < inputArray.Length - 1; i++) { 
        for (int id = 0; id < inputArray.Length - 1; id++)
        {
          if (inputArray[id] > inputArray[id+1])
          {
            int a = inputArray[id];
            inputArray[id] = inputArray[id+1];
            inputArray[id+1] = a;
          }
        }
      }
      return new Response() {ResultArr = inputArray};
    }

    public Response Optimized()
    {
      int[] inputArray = new int[_inputArray.Length];
      _inputArray.CopyTo(inputArray, 0);

      for (int i = 0; i < inputArray.Length - 1; i++)
      {
        for (int id = 0; id < inputArray.Length - 1; id++)
        {
          if (inputArray[id] > inputArray[id + 1])
          {
            int a = inputArray[id];
            inputArray[id] = inputArray[id + 1];
            inputArray[id + 1] = a;
          }
        }
      }
      return new Response(){ResultArr = inputArray};
    }
  }
}
