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
    private int[] _inputArray;
    public BubbleSort(int[] inputArray)
    {
      _inputArray = inputArray;
    }

    public Response FirstTry()
    {
      return new Response();
    }

    public Response Optimized()
    {
      throw new NotImplementedException();
    }
  }
}
