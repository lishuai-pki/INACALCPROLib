using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [ComVisible(true)]
    [Guid("7B85807E-38A8-48AD-9D1E-FA6E12C86090")]
    public interface IInaCalcAtoms
    {
        [DispId(-4)]
        IEnumerator GetEnumerator();

        [DispId(1)]
        int Count { get; }

        [DispId(0)]
        IInaCalcAtom this[object vntAtom] { get; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("5978D41B-10E7-455D-9AC8-124BB65384C5")]
    public class InaCalcAtoms : IInaCalcAtoms
    {
        public IInaCalcAtom this[object vntAtom] => throw new System.NotImplementedException();

        public int Count => throw new System.NotImplementedException();

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
