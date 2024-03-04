namespace MarsRover.Interfaces
{
    public interface ISouthMovement
    {
        int MoveSouth(ref bool perimeterReached, int movementNumber);
    }
}