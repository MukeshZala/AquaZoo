using AquaZooAPI.Data;
using AquaZooAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AquaZooAPI.Repository.IRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly AppSettings _settings; 

        public UserRepository(ApplicationDbContext db, IOptions<AppSettings> appSettings)
        {
            _db = db;
            _settings = appSettings.Value; 
        }

        public User Authenticate(string username, string password)
        {
            var user = _db.Users.SingleOrDefault<User>(x => x.Username.Equals(username) && x.Password.Equals(password));

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                 Subject= new ClaimsIdentity(new Claim[]
                 {
                     new Claim (ClaimTypes.Name, user.Id.ToString()),
                     //Below is for assigning role 
                     new Claim(ClaimTypes.Role, user.Role) 

                 }),
                 Expires = DateTime.UtcNow.AddDays(7),
                 SigningCredentials = new SigningCredentials (
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                     )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token) ;
            user.Password = ""; 
            return user; 


        }

        public bool IsUniqueUser(string username)
        {
            User unique = _db.Users.SingleOrDefault(u => u.Username.Equals(username));
            if (unique  != null)
                return false;
            else
                return true; 

        }

        public User Register(string username, string password)
        {
            User userObj = new User()
            {
                Username = username,
                Password = password
            };
            userObj.Role = "Admin";

            _db.Users.Add(userObj);
            _db.SaveChanges();
            userObj.Password = "";

            return userObj; 



        }
    }
}
