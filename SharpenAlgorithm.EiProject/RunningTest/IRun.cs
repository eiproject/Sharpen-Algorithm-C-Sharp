using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.RunningTest
{
  interface IRun
  {
    /// <summary>
    /// Start to test all algorithm with specify number of Stress Testing
    /// </summary>
    /// <param name="stressTestNumber"></param>
    void Start(int stressTestNumber);
  }
}
