﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WidePictBoard.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly Func<Exception, IActionResult> _exceptionHandler;
        public BaseController(Func<Exception, IActionResult> exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        protected async Task<IActionResult> ValidateAndRun(Func<Task<IActionResult>> func)
        {
            try
            {
                return await func.Invoke();
            }
            catch (Exception e)
            {
                //TODO Need logger here
                
                return _exceptionHandler.Invoke(e);
            }
        }
    }
}