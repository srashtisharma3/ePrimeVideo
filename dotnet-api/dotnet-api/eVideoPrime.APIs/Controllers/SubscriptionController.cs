﻿using eVideoPrime.Core.Entities;
using eVideoPrime.Models;
using eVideoPrime.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVideoPrime.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        ISubscriptionService _SubscriptionService;
        public SubscriptionController(ISubscriptionService SubscriptionService)
        {
            _SubscriptionService = SubscriptionService;
        }

        [HttpGet]
        public IEnumerable<Subscription> GetAll()
        {
            return _SubscriptionService.GetAll();
        }

        [HttpGet]
        public IEnumerable<SubscriptionModel> GetAllUserSubscription()
        {
            return _SubscriptionService.GetAllUserSubscription();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _SubscriptionService.Delete(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
