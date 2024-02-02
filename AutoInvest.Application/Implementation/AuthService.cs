using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Enums;
using AutoInvest.Domain.Models;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AutoInvest.Application.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public AuthService(IMapper mapper, UserManager<User> userManager, IEmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<StandardResponse<IdentityResult>> RegisterUser(RegisterUserDto registerUserDto)
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
            var emailResult = await _emailService.SendEmail(user.Email, "Email Confirmation AutoInvest", "We are sending this email to confirm your account");
            if (!emailResult.Succeeded)
            {
                return StandardResponse<IdentityResult>.Failed("Request failed. email not sent", 400);
            }
            return StandardResponse<IdentityResult>.Succeeded("Request successful", result, 200);
        }
    }
}
