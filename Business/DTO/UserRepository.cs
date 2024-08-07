using Business.Helpers;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UserRepository
    {
        /// <summary>
        /// Registers a new user in the database.
        /// </summary>
        /// <param name="entity">The user entity to register.</param>
        /// <returns>A BusinessResponse containing the registered user.</returns>
        public BusinessResponse<User> Register(User entity)
        {
            var response = new BusinessResponse<User>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    dbContext.Users.Add(entity);
                    dbContext.SaveChanges();
                    response.UnitResp = entity;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// Checks if a user with the specified email exists in the database.
        /// </summary>
        /// <param name="email">The email to check.</param>
        /// <returns>A BusinessResponse indicating whether the user exists or not.</returns>
        public BusinessResponse<bool> UserExists(string email)
        {
            var response = new BusinessResponse<bool>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    if (dbContext.Users.FirstOrDefault(p => p.Email == email) != null)
                    {
                        response.UnitResp = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Logs in a user with the specified email and password.
        /// </summary>
        /// <param name="email">The email of the user to log in.</param>
        /// <param name="password">The password of the user to log in.</param>
        /// <returns>A BusinessResponse containing the logged in user.</returns>
        public BusinessResponse<User> Login(string email, string password)
        {
            var response = new BusinessResponse<User>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    response.UnitResp = dbContext.Users.FirstOrDefault(p => p.Email == email && p.Password == password);
                }
                if (response.UnitResp == null)
                {
                    response.Error = true;
                    response.Msg = "Correo o password incorrecta";
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }

            return response;
        }
    }
}
