﻿using SocNet.BLL.Models;
using SocNet.BLL.Exceptions;
using SocNet.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SocNet.DAL.Entities;

namespace SocNet.BLL.Services;

internal class UserService
{
    IUserRepository userRepository;
    public UserService()
    {
        userRepository = new UserRepository();
    }

    public void Register(UserRegistrationData userRegistrationData)
    {
        if (String.IsNullOrEmpty(userRegistrationData.FirstName))
            throw new ArgumentNullException();
        if (String.IsNullOrEmpty(userRegistrationData.LastName))
            throw new ArgumentNullException();
        if (String.IsNullOrEmpty(userRegistrationData.Password))
            throw new ArgumentNullException();
        if (String.IsNullOrEmpty(userRegistrationData.Email))
            throw new ArgumentNullException();
        if (userRegistrationData.Password.Length < 8)
            throw new ArgumentNullException();
        if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
            throw new ArgumentNullException();
        if (userRepository.FindByEmail(userRegistrationData.Email) != null)
            throw new ArgumentNullException();

        var userEntity = new UserEntity()
        {
            firstname = userRegistrationData.FirstName,
            lastname = userRegistrationData.LastName,
            password = userRegistrationData.Password,
            email = userRegistrationData.Email
        };

        if (this.userRepository.Create(userEntity) == 0)
            throw new Exception();
    }

    public User Authenticate(UserAuthenticationData userAuthenticationData)
    {
        var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);
       
        if (findUserEntity is null) 
            throw new UserNotFoundException();

        if (findUserEntity.password != userAuthenticationData.Password)
            throw new WrongPasswordException();

        return ConstructUserModel(findUserEntity);
    }

    public User FindByEmail(string email)
    {
        var findUserEntity = userRepository.FindByEmail(email);
        if (findUserEntity is null)
            throw new UserNotFoundException();

        return ConstructUserModel(findUserEntity);
    }

    public void Update(User user)
    {
        var updatableUserEntity = new UserEntity()
        {
            id = user.Id,
            firstname = user.FirstName,
            lastname = user.LastName,
            password = user.Password,
            email = user.Email,
            photo = user.Photo,
            favourite_movie = user.FavoriteMovie,
            favorite_book = user.FavoriteBook
        };
    }

    private User ConstructUserModel(UserEntity userEntity)
    {
        return new User(userEntity.id,
                        userEntity.firstname,
                        userEntity.lastname,
                        userEntity.password,
                        userEntity.email,
                        userEntity.photo,
                        userEntity.favourite_movie,
                        userEntity.favorite_book);
    }
}
