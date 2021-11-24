using SharpenAlgorithm.EiProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.AlgorithmLibrary.Search
{
  class LinearSearch : IAlgorithm
  {
    private int[] _inputArray;
    public LinearSearch(int[] inputArray)
    {
      _inputArray = inputArray;
    }
    public Response FirstTry()
    {
      throw new NotImplementedException();
    }

    public Response Optimized()
    {
      throw new NotImplementedException();
    }
  }
}
