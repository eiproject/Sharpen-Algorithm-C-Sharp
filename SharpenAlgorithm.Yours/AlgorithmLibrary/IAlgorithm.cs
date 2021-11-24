using SharpenAlgorithm.Yours.Model;

namespace SharpenAlgorithm.Yours.AlgorithmLibrary
{
  interface IAlgorithm
  {
    Response FirstTry();
    Response Optimized();
  }
}
