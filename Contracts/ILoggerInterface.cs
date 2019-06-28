using NLog;
using System;
using AccountAPI.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountAPI.Models;
using Microsoft.EntityFrameworkCore;
using AccountAPI.Repositories;

namespace AccountAPI.Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(ControllerContext ControllerContext, string Message);
        void LogWarn(ControllerContext ControllerContext, string Message);
        void LogDebug(ControllerContext ControllerContext, string Message);
        void LogError(ControllerContext ControllerContext, string Message);
    }
}