using MarsRover.Models;

namespace MarsRover.Interfaces
{
    public interface IMovementService
    {
        string HandleMovement(Commands commands);
    }
}