﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureExample.Application.CQRS
{
    internal interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }
}
