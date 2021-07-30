using System;
using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [Guid("430B2C8F-B005-4298-A606-6FE144F7C804")]
    [ComVisible(true)]
    public interface IInaCalcAtom
    {
        [DispId(6)]
        void Clear();

        [DispId(0)]
        dynamic Value { get; set; }
        [DispId(1)]
        string Name { get; }
        [DispId(2)]
        string Formula { get; set; }
        [DispId(3)]
        EInaValueType ReturnType { get; }
        [DispId(4)]
        IInaCalcStringEnum FormulaRefs { get; }
        [DispId(5)]
        IInaCalcStringEnum FormulaDeps { get; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("5F37284C-1F7B-4899-B55A-FA256FD815CC")]
    public class InaCalcAtom : IInaCalcAtom
    {
        public dynamic Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name => throw new NotImplementedException();

        public string Formula { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EInaValueType ReturnType => throw new NotImplementedException();

        public IInaCalcStringEnum FormulaRefs => throw new NotImplementedException();

        public IInaCalcStringEnum FormulaDeps => throw new NotImplementedException();

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
