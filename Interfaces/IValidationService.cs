using MarsRover.Models;

namespace MarsRover.Interfaces
{
    public interface IValidationService
    {
        bool ValidateInput(Commands commands);
    }
}