using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [ComVisible(true)]
    [Guid("007D7BC0-D363-41DB-88C7-79FCF40667D1")]
    public interface IInaCalcFuncArgVals : IEnumerable
    {
        [DispId(-4)]
        new IEnumerator GetEnumerator();

        [DispId(1)]
        int Count { get; }

        /// <summary>
        /// index starts at 1
        /// </summary>
        /// <param name="lIndex"></param>
        /// <returns></returns>
        [DispId(0)]
        object this[int lIndex] { get; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("546FFD9B-3D81-4545-BD65-6E6E24490B6C")]
    public class InaCalcFuncArgVals : IInaCalcFuncArgVals
    {
        public object this[int lIndex] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
