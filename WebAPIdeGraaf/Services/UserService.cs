using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPIdeGraaf.Models;
using WebAPIdeGraaf.Helpers;
using WebAPIdeGraaf.Services;

namespace WebAPIdeGraaf.Services
{
    public interface IUserService
    {
        Users Authenticate(string username, string password);
        IEnumerable<Users> GetAll();
        Users GetById(int id);

    }

    public class UserService : IUserService
    {
        private readonly degraafContext _context;
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<Users> _users = new List<Users>
        {
            //new Users { Id = 1, Name = "Test", Surname = "User", Email = "test", Password = "37268335dd6931045bdcdf92623ff819a64244b53d0e746d438797349d4da578" }
        };
        
        public readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, degraafContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public Users Authenticate(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            _context.Users.Attach(user);
            _context.SaveChanges();

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<Users> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }

        public Users GetById(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            // return user without password
            if (user != null)
                user.Password = null;

            return user;
        }
    }
}
