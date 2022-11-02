namespace Essity.FutureProof.Domain.Interfaces
{
    public interface IInputValidator
    {
        IInputValdationResult ValidateInput(string input);

        IInputValidationFormatText ValidateAndFormatInput(string input);
    }
}
