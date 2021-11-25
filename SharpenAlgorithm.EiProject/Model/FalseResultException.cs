using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.Model
{
  class FalseResultException : Exception
  {
    private string _message;
    public FalseResultException()
    {

    }

    public FalseResultException(string message)
    {
      _message = message;
    }

    public override string Message => _message;
  }
}
