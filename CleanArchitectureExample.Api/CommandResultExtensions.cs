using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureExample.Application.CQRS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CleanArchitectureExample.Api
{
    public static class CommandResultExtensions
    {
        public static ActionResult ToActionResult(this CommandResult commandResult)
        {
            if (commandResult.Outcome == CommandOutcome.Success)
            {
                return new OkResult();
            }

            return new BadRequestObjectResult(JsonConvert.SerializeObject(commandResult.ValidationErrors));
        }
    }
}
