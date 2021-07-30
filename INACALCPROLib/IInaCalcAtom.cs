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
        public InaCalcAtom(string name, InaCalcPro inaCalcProClass)
        {
            Name = name;
            _inaCalcProClass = inaCalcProClass;
        }

        private InaCalcPro _inaCalcProClass;
        public dynamic Value { get; set; }

        public string Name { get; }

        private string _formmula;
        public string Formula
        {
            get
            {
                var result = CustomFunctionCheckHelper.RemoveLogicalExpression(_formmula);
                return result;
            }

            set
            {
                if (_formmula != value)
                {
                    //check if expression illegal before set value                
                    CustomFunctionCheckHelper.Check(_inaCalcProClass, value, ref _returnType);
                }

                _formmula = value;
            }
        }

        private EInaValueType _returnType;
        public EInaValueType ReturnType
        {
            get
            {
                return _returnType;
            }
        }

        public IInaCalcStringEnum FormulaRefs { get; }

        public IInaCalcStringEnum FormulaDeps { get; }

        public void Clear()
        {

        }
    }
}
