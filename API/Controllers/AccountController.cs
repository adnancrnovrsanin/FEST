using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Services;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService, IUserAccessor userAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized("Email not found");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded) return CreateUserObject(user);

            return Unauthorized("Invalid password");
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email)) {
                ModelState.AddModelError("email", "Email taken");
                return ValidationProblem();
            }

            Role role;
            switch(registerDto.Role) {
                case "ADMIN":
                    role = Role.ADMIN;
                    break;
                case "FESTIVAL_MANAGER":
                    role = Role.FESTIVAL_MANAGER;
                    break;
                case "THEATRE_MANAGER":
                    role = Role.THEATRE_MANAGER;
                    break;
                case "ACTOR":
                    role = Role.ACTOR;
                    break;
                case "REVIEWER":
                    role = Role.REVIEWER;
                    break;
                default:
                    ModelState.AddModelError("role", "Invalid role");
                    return ValidationProblem();
            }

            var user = new AppUser {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                Role = role
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded) {
                return CreateUserObject(user);
            }

            return BadRequest("Problem registering user");
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser() {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.Email == _userAccessor.GetEmail());

            if (user == null) return NotFound();

            return Ok(_mapper.Map<UserDto>(user));
        }

        private UserDto CreateUserObject(AppUser user) {
            return new UserDto {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}