using System;
using BackPropagation.ActivationFunctions.Delegates;

namespace BackPropagation.ActivationFunctions
{
    public class ActivationFunctionProvider
    {
        public static (ActivationFunction, ActivationFunction) GetActivations(ActivationType type)
        {
            switch (type)
            {
                case ActivationType.Sigmoid: return (ActivationFunctions.Sigmoid, ActivationFunctions.SigmoidPrime);
                case ActivationType.Tanh: return (ActivationFunctions.Tanh, ActivationFunctions.TanhPrime);
                case ActivationType.LeCunTanh:
                    return (ActivationFunctions.LeCunTanh, ActivationFunctions.LeCunTanhPrime);
                case ActivationType.ReLU: return (ActivationFunctions.ReLU, ActivationFunctions.ReLUPrime);
                case ActivationType.LeakyReLU:
                    return (ActivationFunctions.LeakyReLU, ActivationFunctions.LeakyReLUPrime);
                case ActivationType.AbsoluteReLU:
                    return (ActivationFunctions.AbsoluteReLU, ActivationFunctions.AbsoluteReLUPrime);
                case ActivationType.Softmax: return (ActivationFunctions.Softmax, null);
                case ActivationType.Softplus: return (ActivationFunctions.Softplus, ActivationFunctions.Sigmoid);
                case ActivationType.ELU: return (ActivationFunctions.ELU, ActivationFunctions.ELUPrime);
                case ActivationType.Identity: return (ActivationFunctions.Identity, ActivationFunctions.Identityprime);
                default:
                    throw new ArgumentOutOfRangeException(nameof(ActivationType), "Unsupported activation function");
            }
        }
    }
}