#if NET10_0
using System.Numerics;

/// <summary>
/// Option to specify math operation and value for it.
/// </summary>
/// <typeparam name="T">Any number.</typeparam>
/// <param name="Math">The mathematical operation to associate with the value.</param>
/// <param name="Value">The numeric value to be used with the specified mathematical operation.</param>
public record class MathValue<T>(MathOption Math, T Value)
    where T : INumber<T>
{
    /// <summary>
    /// Calculate math with a given input.
    /// </summary>
    /// <param name="inValue">The input value.</param>
    /// <returns>The new value.</returns>
    public T MathCalculation(T inValue)
    {
        return Math.MathCalculation(inValue, Value);
    }

    /// <summary>
    /// Calculate math with a given input.
    /// </summary>
    /// <param name="inValue">The reference for value to change with.</param>
    public void MathCalculation(ref T inValue)
    {
        inValue = Math.MathCalculation(inValue, Value);
    }
}
#endif
