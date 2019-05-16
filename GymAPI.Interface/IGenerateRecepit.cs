using GymAPI.ViewModels;

namespace GymAPI.Interface
{
    public interface IGenerateRecepit
    {
        GenerateRecepitViewModel Generate(int paymentId);
    }
}
