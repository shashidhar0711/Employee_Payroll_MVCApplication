using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Employee_Payroll_MVCApplication.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int EmpId { set; get; }

        public string Name { set; get; }

        public string Gender { set; get; }

        public int DepartmentId { set; get; }

        [ForeignKey("DepartmentId")]
        public Department Department { set; get; }

        public int SalaryId { get; set; }

        [ForeignKey("SalaryId")]

        public Salary Salary { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public string Description { get; set; }
    }
}