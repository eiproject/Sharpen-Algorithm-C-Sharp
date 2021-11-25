using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.Utility
{
  class RNG
  {
    private Random _random;
    public RNG()
    {
      _random = new Random(); 
    }
    public int[] CreateRandomIntArray(int arrSize, int min, int max)
    {
      int[] result = new int[arrSize];
      for (int i = 0; i < arrSize; i++)
      {
        result[i] = _random.Next(min, max);
      }
      return result;
    }

    public int[] CreateUniqueRandomIntArray(int arrSize, int min, int max)
    {
      int[] result = new int[arrSize];
      for (int i = 0; i < arrSize; i++)
      {
        int rand = _random.Next(min, max);
        while (result.Contains(rand))
        {
          rand = _random.Next(min, max);
        }
        result[i] = rand;
      }
      return result;
    }
  }
}
