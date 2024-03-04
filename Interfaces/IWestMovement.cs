namespace MarsRover.Interfaces
{
    public interface IWestMovement
    {
        int MoveWest(ref bool perimeterReached, int movementNumber);
    }
}