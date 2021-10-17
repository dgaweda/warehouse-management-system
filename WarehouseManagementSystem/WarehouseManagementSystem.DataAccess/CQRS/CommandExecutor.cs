﻿using DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly WMSDatabaseContext context;
        public CommandExecutor(WMSDatabaseContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command) => command.Execute(context);
    }
}
