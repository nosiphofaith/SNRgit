using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FileUpLoad1.Data
{
    public class FileUpLoad1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FileUpLoad1Context() : base("name=FileUpLoad1Context")
        {
        }

        public System.Data.Entity.DbSet<FileUpLoad1.Models.ApplDocs> ApplDocs { get; set; }

        public System.Data.Entity.DbSet<FileUpLoad1.Models.Category> Categories { get; set; }
    }
}
