﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.Services;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RolesController(RoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
                return NotFound();
            return Ok(role);
        }
        [HttpPost]
        public IActionResult Post([FromBody] RoleDTO roleDTO)
        {
            if (roleDTO == null)
                return BadRequest();
            _roleService.AddRole(roleDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDTO roleDTO)
        {
            if (roleDTO == null || id != roleDTO.Id)
                return BadRequest();
            _roleService.UpdateRole(roleDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _roleService.DeleteRole(id);
            return NoContent();
        }
    }
}
