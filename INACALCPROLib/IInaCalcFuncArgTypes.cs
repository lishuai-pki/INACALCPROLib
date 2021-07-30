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
        private List<EInaValueType> _args;

        public InaCalcFuncArgTypes(List<EInaValueType> args)
        {
            _args = new List<EInaValueType>();

            if (args != null)
            {
                _args.AddRange(args);
            }
        }

        public EInaValueType this[int lIndex]
        {
            get
            {
                return _args[lIndex - 1];
            }
        }

        public int Count => _args.Count;

        public IEnumerator GetEnumerator()
        {
            return _args.GetEnumerator();
        }
    }
}
