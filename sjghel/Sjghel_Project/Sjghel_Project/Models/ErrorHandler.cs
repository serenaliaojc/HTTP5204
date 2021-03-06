﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Sjghel_Project.Models
{
    public static class ErrorHandler
    {
        public static string DbUpdateHandler(DbUpdateException dbEx)
        {
            string message = "";
            SqlException ex = dbEx.GetBaseException() as SqlException;
            if (ex != null)
            {
                switch (ex.Number)
                {
                    case 547:
                        message += "There is a parent/foreign relation violated. You are either trying to remove and entry that other entries are dependent on or adding entries that with dependencies that don't exist.";
                        break;
                    case 2627:
                        message += "An entry with this identifier already exists";
                        break;
                    default:
                        message = "An unknown database error has occured. Please try again later.";
                        break;
                }
            }

            return message;
        }
    }
}