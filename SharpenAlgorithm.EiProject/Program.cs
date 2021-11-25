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
      RNG rng = new RNG();
      Run app = new Run(db);
      db.RandNumbers = rng.CreateUniqueRandomIntArray(100, 0, 500);
      
      Thread.Sleep(1000);
      Console.WriteLine("Stabilizing ...");
      Thread.Sleep(1000);
      app.Start();
      Console.ReadKey();
    }
  }
}
