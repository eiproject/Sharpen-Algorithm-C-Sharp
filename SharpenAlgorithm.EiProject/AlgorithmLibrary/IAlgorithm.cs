using SharpenAlgorithm.EiProject.Model;

namespace SharpenAlgorithm.EiProject.AlgorithmLibrary
{
  interface IAlgorithm
  {
    Response FirstTry();
    Response Optimized();
  }
}
