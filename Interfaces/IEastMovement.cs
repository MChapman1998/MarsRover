namespace MarsRover.Interfaces
{
    public interface IEastMovement
    {
        int MoveEast(ref bool perimeterReached, int movementNumber);
    }
}