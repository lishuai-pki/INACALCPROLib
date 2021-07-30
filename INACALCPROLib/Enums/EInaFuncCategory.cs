using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [Guid("0B13D3B8-070B-46A8-8858-3AD43A03900B")]
    [ComVisible(true)]
    public enum EInaFuncCategory
    {
        inaFuncArithmetical = 1,
        inaFuncMathematical = 2,
        inaFuncText = 3,
        inaFuncStatistical = 4,
        inaFuncFinancial = 5,
        inaFuncLogical = 6,
        inaFuncDateTime = 7,
        inaFuncCustom = 8
    }
}
