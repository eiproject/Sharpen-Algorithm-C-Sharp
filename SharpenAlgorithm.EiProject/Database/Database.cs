using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpenAlgorithm.EiProject.Database
{
  /// <summary>
  /// Create Input Database, SortedNumbers is auto generated 
  /// on RandNumbers setter.
  /// </summary>
  class InputDatabase
  {
    public int[] RandNumbers { 
      get
      {
        return _randNumbers;
      }
      set {
        _randNumbers = value;
        _sortedNumbers = (int[])value.Clone();
        Array.Sort(_sortedNumbers);
      }
    }
    public int[] SortedNumbers { get { return _sortedNumbers; } }

    private int[] _randNumbers;
    private int[] _sortedNumbers;
  }
}
