using SharpenAlgorithm.EiProject.Database;
using SharpenAlgorithm.EiProject.RunningTest;
using SharpenAlgorithm.EiProject.Utility;
using System;
using System.Threading;

namespace SharpenAlgorithm.EiProject
{
  class Program
  {
    static void Main(string[] args)
    {
      InputDatabase db = new InputDatabase();
      IRNG rng = new RNG();
      IRun app = new Run(db);

      db.RandNumbers = rng.CreateUniqueRandomIntArray(10, 0, 50);

      app.CreateCustomStressTest(10000);
      app.Stabilizer();
      app.Start();

      Console.ReadKey();
    }
  }
}
