using SharpenAlgorithm.EiProject.Database;
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
    private InputDatabase _db;
    public LinearSearch(InputDatabase db)
    {
      _db = db; ;
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
