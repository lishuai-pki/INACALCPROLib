using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [ComVisible(true)]
    [Guid("EA834B1E-9747-4001-8BB8-0C3A1C2B4ED7")]
    public interface IInaCalcFuncArgTypes : IEnumerable
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
        EInaValueType this[int lIndex] { get; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("976185A8-65F4-4468-8CF2-513E06058DA8")]
    public class InaCalcFuncArgTypes : IInaCalcFuncArgTypes
    {
        public EInaValueType this[int lIndex] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
