using SharpenAlgorithm.EiProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.AlgorithmLibrary.Search
{
  class InterpolationSearch : IAlgorithm
  {
    private int[] _inputArray;
    public InterpolationSearch(int[] inputArray)
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
