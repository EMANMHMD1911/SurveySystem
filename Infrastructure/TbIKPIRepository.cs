using SurveySystem.Contract;
using SurveySystem.Models;

namespace SurveySystem.Infrastructure
{
    public class TbIKPIRepository : Repository<TblKPI>, ITbIKPIRepository
    {
        private readonly Context context;
        private readonly IDepartmentRepository departmentRepository;

        public TbIKPIRepository(Context context,IDepartmentRepository departmentRepository)
        {
            this.context = context;
            this.departmentRepository = departmentRepository;
        }

        public override void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                context.KPIs.Remove(item);
                context.SaveChanges();
            }
        }

        public override List<TblKPI> GetAll()
        {
            var items = context.KPIs.ToList();
            return items;
        }

        public List<TblKPI> GetByDeptId(int deptid)
        {
            var dept =context.Departments.FirstOrDefault(e=>e.Id==deptid);
           

            List<TblKPI> items=new List<TblKPI>();
            if (dept != null)
            {
                 items =context.KPIs.Where(e=>e.DepNO==deptid).ToList();
                return items;
            }
            return items;
        }

        public override TblKPI GetById(int id)
        {
            var item = context.KPIs.FirstOrDefault(x => x.KPIDNum == id);
            return item;
        }

        public double gettotal(List<TblKPI> items)
        {
            double num = 0, per = 0, total = 0;
            foreach (var item in items)
            {
                if (item.MeasurementUnit == true)
                {
                    num += item.TargetValue;
                }
                else
                {
                    per += item.TargetValue;
                }


            }
            double z = 1 - (per / 100);
            total = num / z;
            return total;
        }

        public override void Insert(TblKPI entity)
        {
            context.KPIs.Add(entity);
            context.SaveChanges();
        }

        public override void Update(int id, TblKPI entity)
        {
            var item = GetById(id);
            if (item != null)
            {
                item.KPIDNum = entity.KPIDNum;
                item.Description = entity.Description;
                item.TargetValue = entity.TargetValue;
                item.MeasurementUnit = entity.MeasurementUnit;
                item.DepNO=entity.DepNO;    
                context.SaveChanges();
            }
        }
    }
}
