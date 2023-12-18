using SurveySystem.Contract;
using SurveySystem.Models;

namespace SurveySystem.Infrastructure
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly Context context;

        public DepartmentRepository(Context context) {
            this.context = context;
        }

        public override void Delete(int id)
        {
            var item =GetById(id);
            if (item != null)
            {
                context.Departments.Remove(item);
                context.SaveChanges();
            }
        }

        public override List<Department> GetAll()
        {
           var items =context.Departments.ToList();
            return items;
        }

        public override Department GetById(int id)
        {
            var item=context.Departments.FirstOrDefault(x => x.Id == id);
            return item;
        }

        public override void Insert(Department entity)
        {
            context.Departments.Add(entity);
            context.SaveChanges();  
        }

        public override void Update(int id, Department entity)
        {
            var item=GetById(id);
            if(item != null)
            {
                item.Id=entity.Id;
                item.Name=entity.Name;  
                context.SaveChanges();  
            }
        }
    }
}
