using Microsoft.EntityFrameworkCore;
using SurveySystem.Contract;
using SurveySystem.Models;

namespace SurveySystem.Infrastructure
{
    public abstract class Repository<T>:IRepository<T> 
    {
        

        public abstract void Delete(int id);

        public abstract List<T> GetAll();

        public abstract T GetById(int id);

        public abstract void Insert(T entity);

        public abstract void Update(int id, T entity);
    }
}
