using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
namespace INACALCPROLib
{

    [ComVisible(true)]
    [Guid("8F62006B-0ECC-4DC5-816D-16A10CFAC6C5")]
    public interface IInaCalcStringEnum : IEnumerable
    {
        [DispId(-4)]
        new IEnumerator GetEnumerator();

        [DispId(1)]
        int Count { get; }

        [DispId(0)]
        string this[int lIndex] { get; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("FD26D577-69A6-41F0-8D8F-2F2BD2178E78")]
    public class InaCalcStringEnum : IInaCalcStringEnum
    {
        public string this[int lIndex] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
