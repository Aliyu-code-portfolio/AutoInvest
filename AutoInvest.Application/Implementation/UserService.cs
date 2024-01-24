using AutoInvest.Application.Abstraction;
using AutoInvest.Domain.Models;
using AutoInvest.Infrastructure.Repository.Abstraction;
using AutoInvest.Shared.DTO.Request;
using AutoInvest.Shared.DTO.Response;
using AutoInvest.Shared.DTO.StandardResponse;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInvest.Application.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepositoryBase<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StandardResponse<string>> DeleteRegister(string userId)
        {
            var user =await _repository.FindByCondition(u => u.Id == userId, false).FirstOrDefaultAsync();
            if (user != null)
            {
                return StandardResponse<string>.Failed("User not found", 404);
            }
            _repository.Delete(user);
            await _repository.SaveChangesAsync();
            return StandardResponse<string>.Succeeded("Delete successful", "Success", 204);
        }

        public async Task<StandardResponse<IEnumerable<UserResponseDto>>> GetAllRegisterUser()
        {
            var users = await _repository.FindAll(false).ToListAsync();
            var usersDtos = _mapper.Map<IEnumerable<UserResponseDto>>(users);
            return StandardResponse<IEnumerable<UserResponseDto>>.Succeeded("Request success", usersDtos, 200);
        }

        public async Task<StandardResponse<UserResponseDto>> GetRegisterUserById(string userId)
        {
            var user =await _repository.FindByCondition(u => u.Id == userId, false).FirstOrDefaultAsync();
            if (user != null)
            {
                return StandardResponse<UserResponseDto>.Failed("User not found", 404);
            }
            var userDto = _mapper.Map<UserResponseDto>(user);
            return StandardResponse<UserResponseDto>.Succeeded("Request success", userDto, 200);
        }
    }
}
