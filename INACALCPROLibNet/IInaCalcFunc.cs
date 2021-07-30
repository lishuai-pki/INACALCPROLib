using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [ComVisible(true)]
    [Guid("526E30B2-A522-45B5-90F4-61C5F686DDE3")]
    public interface IInaCalcFunc
    {
        [DispId(0)]
        string Name { get; set; }
        [DispId(2)]
        string Format { get; set; }
        [DispId(3)]
        string Descr { get; set; }
        [DispId(4)]
        EInaFuncCategory Category { get; set; }
        [DispId(5)]
        List<EInaValueType> ParamValueTypes { get; set; }
        [DispId(6)]
        EInaValueType OutputValueType { get; set; }
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("57E8501C-3B4A-4BC7-B936-ACDE0135C4B3")]
    public class InaCalcFunc : IInaCalcFunc
    {
        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Format { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Descr { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public EInaFuncCategory Category { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public List<EInaValueType> ParamValueTypes { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public EInaValueType OutputValueType { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
