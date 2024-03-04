namespace MarsRover.Interfaces
{
    public interface INorthMovement
    {
        int MoveNorth(ref bool perimeterReached, int movementNumber);
    }
}