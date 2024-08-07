using Business.Helpers;
using Data;
using Data.Entities;
using System;

namespace Business.DTO
{
    public class PurchaseRepository
    {

        public BusinessResponse<Purchase> SetWithRelations(Purchase entity)
        {
            var response = new BusinessResponse<Purchase>();
            try
            {
                using (var dbContext = new DBContext())
                {
                    dbContext.Purchases.Add(entity);
                    dbContext.SaveChanges();
                    response.UnitResp = entity;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Msg = "Error en guardado";
                Logging.LogException(ex);
            }
            return response;
        }
    }
}
