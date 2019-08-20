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

namespace AccountAPI.Services
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager() { }

        public void LogDebug(ControllerContext ControllerContext, string Message)
        {
            logger.Debug($"Controller: {ControllerContext.RouteData.Values["controller"].ToString()} - Method: {ControllerContext.RouteData.Values["action"].ToString()} - {Message}");
        }
 
        public void LogError(ControllerContext ControllerContext, string Message)
        {
            logger.Error($"Controller: {ControllerContext.RouteData.Values["controller"].ToString()} - Method: {ControllerContext.RouteData.Values["action"].ToString()} - {Message}");
        }
 
        public void LogInfo(ControllerContext ControllerContext, string Message)
        {
            logger.Info($"Controller: {ControllerContext.RouteData.Values["controller"].ToString()} - Method: {ControllerContext.RouteData.Values["action"].ToString()} - {Message}");
        }
 
        public void LogWarn(ControllerContext ControllerContext, string Message)
        {
            logger.Warn($"Controller: {ControllerContext.RouteData.Values["controller"].ToString()} - Method: {ControllerContext.RouteData.Values["action"].ToString()} - {Message}");
        }
    }
}