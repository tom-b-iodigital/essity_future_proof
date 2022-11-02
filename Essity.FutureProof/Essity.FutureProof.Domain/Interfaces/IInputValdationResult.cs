namespace Essity.FutureProof.Domain.Interfaces
{
    public interface IInputValdationResult
    {
        string Msg { get; }
        bool Result { get; }
    }
}