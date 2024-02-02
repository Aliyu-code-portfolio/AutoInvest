using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Enums;
using AutoInvest.Domain.Models;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AutoInvest.Application.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly ITokenService _tokenService;

        public AuthService(IMapper mapper, UserManager<User> userManager, IEmailService emailService, ITokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _tokenService = tokenService;
        }


        public async Task<StandardResponse<IdentityResult>> RegisterUser(RegisterUserDto registerUserDto, HttpRequest httpRequest)
        {
            var user = _mapper.Map<User>(registerUserDto);
            user.UserName = user.Email;
            var result =await _userManager.CreateAsync(user, registerUserDto.Password);
            if (!result.Succeeded)
            {
                return StandardResponse<IdentityResult>.Failed("Request failed", result, 401);
            }
            if(registerUserDto.RegistrationType==UserType.Client)
            {
                await _userManager.AddToRoleAsync(user, "Client");
            }
            else if(registerUserDto.RegistrationType == UserType.Dealer)
            {
                await _userManager.AddToRoleAsync(user, "Dealer");
            }
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var tokenAsByte = System.Text.Encoding.UTF8.GetBytes(token);
            var tokenIn64String = Convert.ToBase64String(tokenAsByte);
            var callback_url = httpRequest.Scheme + "://" + httpRequest.Host + $"/api/auth/confirm-email/{user.Email}/{tokenIn64String}";
            var emailResult = await _emailService.SendEmail(user.Email, "Email Confirmation AutoInvest", $"We are sending this email to confirm your account. {callback_url}");
            if (!emailResult.Succeeded)
            {
                return StandardResponse<IdentityResult>.Failed("Request failed. email not sent", 400);
            }
            return StandardResponse<IdentityResult>.Succeeded("Request successful", result, 200);
        }
        public async Task<StandardResponse<IdentityResult>> ConfirmEmail(string email, string tokenIn64String)
        {
            var user =await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return StandardResponse<IdentityResult>.Failed("Invalid credentials", 400);
            }
            if (user.EmailConfirmed)
            {
                return StandardResponse<IdentityResult>.Failed("Invalid credentials", 400);
            }
            var tokenAsbyte = Convert.FromBase64String(tokenIn64String);
            var token = System.Text.Encoding.UTF8.GetString(tokenAsbyte);
            var confirmationResult =await _userManager.ConfirmEmailAsync(user, token);
            if (!confirmationResult.Succeeded)
            {
                return StandardResponse<IdentityResult>.Failed("Request failed", confirmationResult, 400);
            }
            return StandardResponse<IdentityResult>.Succeeded("Request successsful", confirmationResult, 200);
        }

        public async Task<StandardResponse<string>> LoginUser(LoginRequestDto loginRequestDto)
        {
            var user =await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user == null)
            {
                return StandardResponse<string>.Failed("Invalid credentials", 401);
            }
            if (!user.EmailConfirmed)
            {
                return StandardResponse<string>.Failed("Email not confirmed yet", 401);
            }
            if(!await _userManager.CheckPasswordAsync(user, loginRequestDto.Password))
            {
                return StandardResponse<string>.Failed("Invalid credentials", 401);
            }
            var token = await _tokenService.CreateToken(user);
            return StandardResponse<string>.Succeeded("Login successful", token, 200);
        }
    }
}
