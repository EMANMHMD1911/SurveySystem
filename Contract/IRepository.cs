namespace SurveySystem.Contract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(int id,T entity);
        void Delete(int id);
    }
}
