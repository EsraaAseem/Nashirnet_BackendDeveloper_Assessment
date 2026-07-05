using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Application.Abstractions.IInterfaces.IExternalServices;
using ProductManagement.Application.IServices;
using ProductManagement.Application.Models.AuthModels;
using ProductManagement.Application.Models.Common;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _userRepository;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IJwtService _jwtService;
        private readonly IRoleRepo _roleRepo;

        public AuthService(
            IUserRepo userRepository,
            IPasswordHashService passwordHashService,
            IJwtService jwtService,
            IRoleRepo roleRepo)
        {
            _userRepository = userRepository;
            _passwordHashService = passwordHashService;
            _jwtService = jwtService;
            _roleRepo = roleRepo;
        }

        public async Task<GenericResponse<string>> RegisterAsync(RegisterRequest request)
        {
            var user = await CreateUserAsync(request);
            if (user == null)
                return GenericResponse<string>.BadRequestResponse("Email already exists.");

            return GenericResponse<string>.SuccessResponseWithMessage("Registered successfully.");
        }
        public async Task<GenericResponse<List<RoleDto>>> GetAllRoles()
        {
            var roles = await _roleRepo.GetAllRoles();
            List<RoleDto> rolesDto = roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            return GenericResponse<List<RoleDto>>.SuccessResponseWithData(rolesDto);
        }

        public async Task<GenericResponse<AuthResponse>> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user is null)
                return GenericResponse<AuthResponse>.FailedResponse(
                    HttpStatusCode.Unauthorized, "Invalid email or password.");

            var isValid = _passwordHashService.VerifyPasswordHash(
                request.Password,
                user.PasswordHash,
                user.PasswordSalt);

            if (!isValid)
                return GenericResponse<AuthResponse>.FailedResponse(
                    HttpStatusCode.Unauthorized, "Invalid email or password.");

            var accessToken = _jwtService.GenerateToken(
                user.Id, user.Email, user.Role.Name);

            return GenericResponse<AuthResponse>.SuccessResponseWithData(new AuthResponse
            {
                AccessToken = accessToken,
            });
        }
        private async Task<AppUser> CreateUserAsync(RegisterRequest request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser is not null)
                return null;
            _passwordHashService.CreatePasswordHash(
                request.Password,
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var user = new AppUser
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId=request.RoleId
            };



            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }
    }
}

