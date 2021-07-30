namespace INACALCPROLib.MathEquations
{
    interface IMathEquation
    {
        /// <summary>
        /// equation name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// result value type
        /// </summary>
        /// <param name="argTypes">paramter types</param>
        /// <returns></returns>
        EInaValueType GetValueType(IInaCalcFuncArgTypes argTypes);

        /// <summary>
        /// result value
        /// </summary>
        /// <param name="argVals">parameter values</param>
        /// <returns></returns>
        object GetResult(IInaCalcFuncArgVals argVals);
    }
}
