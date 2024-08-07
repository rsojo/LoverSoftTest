using Business.Helpers;
using Data;
using Data.Entities;
using System;

namespace Business.DTO
{
    public class PurchaseRepository
    {
        /// <summary>
        /// Sets the purchase entity with its relations and saves it to the database.
        /// </summary>
        /// <param name="entity">The purchase entity to be set.</param>
        /// <returns>A BusinessResponse containing the saved purchase entity.</returns>
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
