namespace SurveySystem.Models
{
    public class Department
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public List<TblKPI>? tblKPIs { get; set; }
    }
}
