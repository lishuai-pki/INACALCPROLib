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
        private List<IInaCalcAtom> _atomList = new List<IInaCalcAtom>();
        private InaCalcPro _inaCalcProClass;

        public InaCalcAtoms(InaCalcPro inaCalcProClass)
        {
            _inaCalcProClass = inaCalcProClass;
        }

        public IInaCalcAtom this[object vntAtom]
        {
            get
            {
                if (vntAtom == null)
                {
                    throw new System.ArgumentNullException("vntAtom can't be null.");
                }

                if (int.TryParse(vntAtom.ToString(), out int index))
                {
                    return _atomList[index];
                }

                var atom = _atomList.Find(a => string.Compare(a.Name, vntAtom.ToString(), true) == 0);
                if (atom == null)
                {
                    atom = new InaCalcAtom(vntAtom.ToString(), _inaCalcProClass);
                    _atomList.Add(atom);
                }
                return atom;
            }
        }

        public int Count => _atomList.Count;

        public IEnumerator GetEnumerator()
        {
            return _atomList.GetEnumerator();
        }
    }
}
