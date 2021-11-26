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
  interface IRNG
  {
    /// <summary>
    /// Create random array of integer
    /// </summary>
    /// <param name="arraySize"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    int[] CreateRandomIntArray(int arraySize, int min, int max);

    /// <summary>
    /// Create random array of integer which the array only contain unique value
    /// </summary>
    /// <param name="arraySize"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    int[] CreateUniqueRandomIntArray(int arraySize, int min, int max);
  }
}
