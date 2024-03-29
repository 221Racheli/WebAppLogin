﻿using entities;

namespace Repository
{
    public interface IUserRepository
    {
        Task<User> addUserAsync(User user);
        Task<bool> existEmailAsync(string userName);
        Task<User> foundUserAsync(User userToSearch);
        Task<User> getUserAsync(int id);
        Task<User> updateUserAsync(User userToUpdate, int id);
    }
}