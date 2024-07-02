using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Model
{
    public class UserRepositroy : IUserRepository
    {
        // private readonly ApplicationDbContext _context;
        // public UserRepositroy(ApplicationDbContext context)
        // {
        //     _context = context;

        // }

        // public async Task<List<User>> GetAllAsync()
        // {
        //     return await _context.User.ToListAsync();
        // }

        // public async Task<User?> GetByIdAsync(int id)
        // {
        //     return await _context.User.FindAsync(id);
        // }

        // public async Task<User> CreateAsync(User userModel)
        // {
        //     await _context.User.AddAsync(userModel);
        //     await _context.SaveChangesAsync();
        //     return userModel;
        // }

        // public async Task<User> UpdateAsync(int id, UpdateRequestDto updateUserDto)
        // {
        //     var existingUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == id);
        //     if (existingUser == null)
        //     {
        //         return null;

        //     }
        //     existingUser.Email = updateUserDto.Email;
        //     existingUser.Name = updateUserDto.Name;
        //     existingUser.Mobile = updateUserDto.Mobile;

        //     await _context.SaveChangesAsync();
        //     return existingUser;
        //     // return Ok(userModel.ToUserDto());
        // }

        // public async Task<User?> DeleteAsync(int id)
        // {
        //     var userModel = await _context.User.FirstOrDefaultAsync(x => x.UserId == id);
        //     if (userModel == null)
        //     {
        //         return null;
        //     }
        //     _context.User.Remove(userModel);

        //     await _context.SaveChangesAsync();

        //     return userModel;

        // }
        public Task<User> CreateAsync(User userModel)
        {
            throw new NotImplementedException();
        }

        public Task<User?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(int id, UpdateRequestDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}