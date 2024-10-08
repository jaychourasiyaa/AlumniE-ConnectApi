﻿using AlumniE_ConnectApi.Contract.Interfaces;
using AlumniE_ConnectApi.Contract.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlumniE_ConnectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private IAuthorizationServices authorizationService;
        public AuthorizationController(IAuthorizationServices authorizationServices)
        {
            this.authorizationService = authorizationServices;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Login(string gmail, string password, string role)
        {
            try
            {
                string token = await authorizationService.LoginUser(gmail, password, role);
                return token;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
