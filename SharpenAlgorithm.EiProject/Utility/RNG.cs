using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.Utility
{
  /// <summary>
  /// Random Number Generator
  /// </summary>
  class RNG
  {
    private Random _random;
    public RNG()
    {
      _random = new Random(); 
    }

    /// <summary>
    /// Create random array of integer
    /// </summary>
    /// <param name="arraySize"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public int[] CreateRandomIntArray(int arraySize, int min, int max)
    {
      int[] result = new int[arraySize];
      for (int i = 0; i < arraySize; i++)
      {
        result[i] = _random.Next(min, max);
      }
      return result;
    }

    /// <summary>
    /// Create random array of integer which the array only contain unique value
    /// </summary>
    /// <param name="arraySize"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public int[] CreateUniqueRandomIntArray(int arraySize, int min, int max)
    {
      if (max - min < arraySize) throw new ArgumentException("Your min and max value is not enough to fullfill the array size");
      int[] result = new int[arraySize];
      for (int i = 0; i < arraySize; i++)
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
