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
            foreach (var command in commands.commands) 
            {
                if (!Regex.IsMatch(command, "[0-9]{1,}[m]{1}") && !Constants.Directions.Contains(command.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}