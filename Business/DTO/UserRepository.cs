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
                    ;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = ex.Message;
            }

            return response;
        }

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
