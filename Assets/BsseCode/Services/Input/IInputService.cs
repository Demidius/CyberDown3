using System.Numerics;
using Vector2 = UnityEngine.Vector2;

namespace BsseCode.Services.Input
{
    public interface IInputService : IService
    {
        Vector2 GetMovementInput(); // Метод для получения ввода на передвижение
    }
}