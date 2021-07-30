using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [Guid("32FF1D8A-D890-47BD-A5FA-BE78AE3AF98F")]
    [ComVisible(true)]
    public enum EInaValueType
    {
        inaValEmpty = 0,
        inaValText = 1,
        inaValNumber = 2,
        inaValDate = 4,
        inaValBool = 8,
        inaValError = 16
    }
}
