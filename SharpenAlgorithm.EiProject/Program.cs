using SharpenAlgorithm.EiProject.Database;
using SharpenAlgorithm.EiProject.RunningTest;
using System;

namespace SharpenAlgorithm.EiProject
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
