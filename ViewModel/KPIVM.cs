using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SurveySystem.ViewModel
{
    public class KPIVM
    {


        [Key]
        [Display(Name = "Indicator Num")]
        public int KPIDNum { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string Description { get; set; }
        [Display(Name = "Measurement Unit")]

        public bool MeasurementUnit { get; set; }
        [Display(Name = "Target Value")]

        public int TargetValue { get; set; }
    }
}
