using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [ComVisible(true)]
    [Guid("7DE71A23-6D26-40B4-9813-6DC3413CD798")]
    public interface IInaCalcFuncs : IEnumerable
    {
        [DispId(2)]
        IInaCalcFunc Add(string strName, EInaFuncCategory funcCat = EInaFuncCategory.inaFuncCustom, string strFormat = "0", string strDescr = "0");
        [DispId(3)]
        void Remove(object vntIndex);
        [DispId(4)]
        void Reset();
        [DispId(-4)]
        new IEnumerator GetEnumerator();

        [DispId(1)]
        int Count { get; }

        /// <summary>
        /// if vntFunc is a number, index starts at 1
        /// </summary>
        /// <param name="vntFunc"></param>
        /// <returns></returns>
        [DispId(0)]
        IInaCalcFunc this[object vntFunc] { get; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("1D480447-8104-4E1A-97CC-E352C3547692")]
    public class InaCalcFuncs : IInaCalcFuncs
    {
        public IInaCalcFunc this[object vntFunc] => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public IInaCalcFunc Add(string strName, EInaFuncCategory funcCat = EInaFuncCategory.inaFuncCustom, string strFormat = "0", string strDescr = "0")
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Remove(object vntIndex)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
