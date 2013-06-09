using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Data.Entity;
using Skwerl.Models;


namespace Skwerl.Controllers
{
    public class Validated
    {

        //adds error reporting to db save attempts
        public static void SaveIt(UsersContext db)
        {
             try
                {
                    db.SaveChanges();
                }
             catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                        {
                           System.Diagnostics.Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                           eve.Entry.Entity.GetType().Name, eve.Entry.State);
                           foreach (var ve in eve.ValidationErrors)
                                {
                                    System.Diagnostics.Debug.WriteLine(" - Property: \"{0}\", Error: \"{1}\"",
                                         ve.PropertyName, ve.ErrorMessage);
                                }
                        }
                }

         }


    }
}