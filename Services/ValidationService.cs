using MarsRover.Common;
using MarsRover.Interfaces;
using MarsRover.Models;
using System.Text.RegularExpressions;

namespace MarsRover.Services
{
    public class ValidationService : IValidationService
    {
        public bool ValidateInput(Commands commands)
        {
            if (commands.commands.Length > 5)
            {
                return false;
            }

            foreach (var command in commands.commands)
            {
                if (!Regex.IsMatch(command, Constants.MovementAmountRegex) && !Constants.Directions.Contains(command.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}