using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace INACALCPROLib
{
    [Guid("1331C8A9-E566-4A5F-8D89-32BB8FA2D58D")]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(_IInaCalcProEvents))]
    public class InaCalcPro : IInaCalcPro
    {
        public IInaCalcAtoms Atoms => throw new NotImplementedException();

        public int AutoCalc { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RestrictVariables { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public EInaErrorValue LastError => throw new NotImplementedException();

        public string LastErrorDescr => throw new NotImplementedException();

        public IInaCalcFuncs Funcs => throw new NotImplementedException();

        public int LangId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int AutoCalcManual { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AboutBox()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int DoFormulaBuilder(ref string strFormula, int bShowRef = 1)
        {
            throw new NotImplementedException();
        }

        public object Eval(string strFormula)
        {
            throw new NotImplementedException();
        }

        public int ParseFormula(string strFormula)
        {
            throw new NotImplementedException();
        }

        public object ParseValue(string strValue, EInaValueType eValType = EInaValueType.inaValEmpty)
        {
            throw new NotImplementedException();
        }

        public string PrintValue(object vntValue)
        {
            throw new NotImplementedException();
        }

        public void Recalc()
        {
            throw new NotImplementedException();
        }
    }
}
