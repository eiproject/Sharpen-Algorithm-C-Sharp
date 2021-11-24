using SharpenAlgorithm.Yours.Database;
using SharpenAlgorithm.Yours.RunningTest;
using System;

namespace SharpenAlgorithm.Yours
{
  class Program
  {
    static void Main(string[] args)
    {
      InputDatabase db = new InputDatabase();
      Run app = new Run(db);
      app.Start();

      Console.ReadKey();
    }
  }
}
