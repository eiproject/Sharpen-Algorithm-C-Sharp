using SharpenAlgorithm.Yours.Database;
using SharpenAlgorithm.Yours.RunningTest;
using System;
using System.Threading;

namespace SharpenAlgorithm.Yours
{
  class Program
  {
    static void Main(string[] args)
    {
      InputDatabase db = new InputDatabase();
      Run app = new Run(db);
      Thread.Sleep(3000);
      Console.WriteLine("Stabilizing ...");
      Thread.Sleep(3000);
      app.Start();
      Console.ReadKey();
    }
  }
}
