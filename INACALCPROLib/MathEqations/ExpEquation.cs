using System;

namespace INACALCPROLib.MathEquations
{
    class ExpEquation : IMathEquation
    {
        public string Name { get; set; } = "Exp";

        public object GetResult(IInaCalcFuncArgVals argVals)
        {
            if (argVals == null || argVals.Count != 1)
            {
                throw new ArgumentException($"{nameof(Name)} must has a parameter");
            }

            double para;
            try
            {
                para = Convert.ToDouble(argVals[1]);
            }
            catch (Exception ex)
            {
                throw new Exception($"parameter of {nameof(Name)} must be a number");
            }

            return Math.Exp(para);
        }

        public EInaValueType GetValueType(IInaCalcFuncArgTypes argTypes)
        {
            if (argTypes == null || argTypes.Count != 1)
            {
                throw new ArgumentException($"{nameof(Name)} must has a parameter");
            }

            return EInaValueType.inaValNumber;
        }
    }
}
