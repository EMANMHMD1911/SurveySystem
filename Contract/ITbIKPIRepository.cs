using SurveySystem.Models;

namespace SurveySystem.Contract
{
    public interface ITbIKPIRepository:IRepository<TblKPI>
    {
        List<TblKPI> GetByDeptId(int deptid);
        double gettotal(List<TblKPI> items);

    }
}
