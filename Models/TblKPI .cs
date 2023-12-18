using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveySystem.Models
{
    public class TblKPI
    {
        [Key]
        [Display(Name ="Indicator Num")]
        public int KPIDNum { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Description { get; set; }
        [Display(Name = "Measurement Unit")]

        public bool MeasurementUnit { get; set; }
        [Display(Name = "Target Value")]

        public int TargetValue { get; set; }
        [ForeignKey("Department")]
        [Display(Name = "Department")]

        public int DepNO { get; set; }
        public Department? Department { get; set; }

    }
}
