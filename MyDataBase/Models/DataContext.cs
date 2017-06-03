using System.Data.Entity;

namespace MyDataBase.Models
{
    public class DataContext:DbContext
    {
        // Наследуем конструктор из DbContext, используя БД "MyDataBase"
        public DataContext() : base("MyDataBase")
        {
            
        }
        //Через AccessUsers осуществлять доступ к самой таблице в БД
        public DbSet<InfoUser> AccessUsers { get; set; }
    }
}
