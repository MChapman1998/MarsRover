using MarsRover.Common;
using MarsRover.Interfaces;
using MarsRover.Models;
using System.Text.RegularExpressions;

namespace MarsRover.Services
{
    public class MovementService(INorthMovement northMovement, ISouthMovement southMovement, IEastMovement eastMovement, IWestMovement westMovement) : IMovementService
    {
        private readonly INorthMovement _northMovement = northMovement;
        private readonly ISouthMovement _southMovement = southMovement;
        private readonly IEastMovement _eastMovement = eastMovement;
        private readonly IWestMovement _westMovement = westMovement;
        private bool perimeterReached = false;

        public string HandleMovement(Commands commands)
        {
            perimeterReached = false;
            foreach (var command in commands.commands)
            {
                if (Regex.IsMatch(command, Constants.MovementAmountRegex))
                {
                    RoverLocation.RoverInstance.CurrentLocation = ChangeLocation(command);
                }
                else
                {
                    RoverLocation.RoverInstance.CurrentDirection = ChangeDirection(command);
                }

                if (perimeterReached)
                {
                    break;
                }
            }

            return $"{RoverLocation.RoverInstance?.CurrentLocation} {RoverLocation.RoverInstance?.CurrentDirection}";
        }

        private string? ChangeDirection(string newDirection)
        {
            switch (newDirection.ToLower())
            {
                case "left":
                    return Constants.LeftDirectionChange[RoverLocation.RoverInstance.CurrentDirection];
                case "right":
                    return Constants.RightDirectionChange[RoverLocation.RoverInstance.CurrentDirection];
                default:
                    return RoverLocation.RoverInstance?.CurrentDirection;
            }
        }

        private int ChangeLocation(string movementAmount)
        {
            int movementNumber = int.Parse(movementAmount[..^1]);
            switch (RoverLocation.RoverInstance?.CurrentDirection)
            {
                case "north":
                    return _northMovement.MoveNorth(ref perimeterReached, movementNumber);
                case "south":
                    return _southMovement.MoveSouth(ref perimeterReached, movementNumber);
                case "east":
                    return _eastMovement.MoveEast(ref perimeterReached, movementNumber);
                case "west":
                    return _westMovement.MoveWest(ref perimeterReached, movementNumber);
                default:
                    return 0;
            }
        }
    }
}