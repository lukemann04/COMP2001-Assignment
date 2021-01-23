using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace COMP2001_API.Models
{
    public class DataAccess
    {
        private readonly COMP2001_LMannContext _context;

        public DataAccess(COMP2001_LMannContext context)
        {
            _context = context;
        }
        public void DeleteUser(DeleteUser deleteUser)
        {
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC DeleteUser @UserID",
            new SqlParameter("@UserID", deleteUser.UserID.ToString()));
            return;
        }
        public void Register(Register register)
        {
            string salt = GetSaltHash(5);

            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC Register @UserFirstName, @UserLastName, @UserEmail, @UserPassword",
            new SqlParameter("@UserFirstName", register.UserFirstName.ToString()),
            new SqlParameter("@UserLastName", register.UserLastName.ToString()),
            new SqlParameter("@UserEmail", register.UserEmail.ToString()),
            new SqlParameter("@UserPassword", HashPassword(register.UserPassword.ToString(), salt))
            );
            return;
        }
        public void UpdateUser(UpdateUser updateUser)
        {
            string salt = GetSaltHash(5);

            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC UpdateUser @UserFirstName, @UserLastName, @UserEmail, @UserPassword, @UserID",
            new SqlParameter("@UserFirstName", updateUser.UserFirstName.ToString()),
            new SqlParameter("@UserLastName", updateUser.UserLastName.ToString()),
            new SqlParameter("@UserEmail", updateUser.UserEmail.ToString()),
            new SqlParameter("@UserPassword", HashPassword(updateUser.UserPassword.ToString(), salt)),
            new SqlParameter("@UserID", updateUser.UserID.ToString())
            );
            return;
        }
        public void ValidateUser(ValidateUser validateUser)
        {
            var rowsaffected = _context.Database.ExecuteSqlRaw("EXEC ValidateUser @UserEmail, @UserPassword",
                new SqlParameter("@UserEmail", validateUser.UserEmail.ToString()),
                new SqlParameter("@UserPassword", validateUser.UserPassword.ToString())
                );
            return;
        }
        

        //Password Hashing
        public static string HexToString(byte[] inS)
        {
            StringBuilder hex = new StringBuilder(inS.Length * 2);
            foreach (byte b in inS)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }
        public string GetSaltHash(int size)
        {
            var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            var buff = new Byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public string HashPassword(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed hashstring = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);

            return HexToString(hash);
        }



    }
}
