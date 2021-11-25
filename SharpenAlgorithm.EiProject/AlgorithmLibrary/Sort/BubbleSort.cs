using SharpenAlgorithm.EiProject.Database;
using SharpenAlgorithm.EiProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.AlgorithmLibrary.Sort
{
  class BubbleSort : IAlgorithm
  {
    private InputDatabase _db;
    public BubbleSort(InputDatabase db)
    {
      _db = db;
    }

    public Response FirstTry()
    {
      int[] inputArray = new int[_db.RandNumbers.Length];
      _db.RandNumbers.CopyTo(inputArray, 0);
      
      // Logic start here
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
      

      return new Response() {
        ResultArr = inputArray,
        Status = inputArray.SequenceEqual(_db.SortedNumbers)
      };
    }

    public Response Optimized()
    {
      int a;
      int[] inputArray = new int[_db.RandNumbers.Length];
      _db.RandNumbers.CopyTo(inputArray, 0);

      // Logic start here
      for (int i = 0; i < inputArray.Length - 1; i++)
      {
        bool isSorting = false;
        for (int id = 0; id < inputArray.Length - 1; id++)
        {
          if (inputArray[id] > inputArray[id + 1])
          {
            // Swap the bubble
            a = inputArray[id];
            inputArray[id] = inputArray[id + 1];
            inputArray[id + 1] = a;
            if (!isSorting) isSorting = true;
          }
        }

        if (!isSorting)
        {
          //Console.WriteLine("Skip on " + i + "/" + inputArray.Length);
          break;
        }
      }
      return new Response()
      {
        ResultArr = inputArray,
        Status = inputArray.SequenceEqual(_db.SortedNumbers)
      };
    }
  }
}
