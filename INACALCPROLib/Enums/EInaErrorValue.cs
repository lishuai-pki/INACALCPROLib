using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [Guid("DB797C51-C4E2-46EE-8BEA-84147C529A2A")]
    [ComVisible(true)]
    public enum EInaErrorValue
    {
        inaErrNone = 0,
        inaErrSyntax = 1,
        inaErrCircRef = 2,
        inaErrTypeMismatch = 3,
        inaErrDiv0 = 4,
        inaErrIndefinite = 5,
        inaErrInfinite = 6,
        inaErrInvalidDate = 7,
        inaErrFunc = 8,
        inaErrValue = 9,
        inaErrCustFunc = 10,
        inaErrRef = 11,
        inaErrCount = 12
    }
}
