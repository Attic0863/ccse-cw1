using ccse_cw1.Exceptions;
using ccse_cw1.Models;
using ccse_cw1.Services;
using Microsoft.EntityFrameworkCore;

namespace ccse_cw1.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        private async Task<ApplicationUser> GetUserOrThrow(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) throw new UserNotFoundException();

            return user;
        }

        public async Task<ApplicationUser> ModifyUserDetails(string userId, ApplicationUser modifiedUser)
        {
            var user = await GetUserOrThrow(userId);

            user.FirstName = modifiedUser.FirstName;
            user.LastName = modifiedUser.LastName;
            user.Address = modifiedUser.Address;
            user.PassportNo = modifiedUser.PassportNo;

            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return user;
        }


    }
}
