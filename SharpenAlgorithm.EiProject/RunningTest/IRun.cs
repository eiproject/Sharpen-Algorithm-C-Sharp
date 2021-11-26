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
    /// Run a stabilizer, a set of Thread'Sleep() to stabilize the thread memory
    /// </summary>
    void Stabilizer();
    /// <summary>
    /// Start to test all algorithm
    /// </summary>
    void Start();

    /// <summary>
    /// Create custom Stress Test. Default = 1000
    /// </summary>
    /// <param name="stressTestNumber"></param>
    void CreateCustomStressTest(int stressTestNumber);
  }
}
