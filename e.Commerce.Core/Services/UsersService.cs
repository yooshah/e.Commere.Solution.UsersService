﻿using AutoMapper;
using e.Commerce.Core.DTO;
using e.Commerce.Core.Entities;
using e.Commerce.Core.RepositoryContracts;
using e.Commerce.Core.ServiceContracts;


namespace e.Commerce.Core.Services
{
    internal class UsersService : IUsersService
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;


        public UsersService(IUsersRepository usersRepository,IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper=mapper;
        }


        public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
        {
            ApplicationUser user = new ApplicationUser()
            {
                PersonName = registerRequest.PersonName,
                Email = registerRequest.Email,
                Password = registerRequest.Password,
                Gender = registerRequest.Gender.ToString()
            };
            ApplicationUser? registeredUser = await _usersRepository.AddUser(user);
            if (registeredUser == null)
            {
                return null;
            }

         
            return new AuthenticationResponse(registeredUser.UserID, registeredUser.Email, registeredUser.PersonName, registeredUser.Gender, "token", Success: true);
        }
    }
}
