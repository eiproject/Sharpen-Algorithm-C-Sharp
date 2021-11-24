using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.Utility
{
  class RNG
  {
    public RNG()
    {
      Random a = new Random();

      for (int i = 0; i < 10000; i++)
      {
        Console.Write(a.Next(0, 5000).ToString() + ", ");
      }
    }
  }
}
