using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerCRUD.Web.Data
{
    public class JobAdvertisement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
 
        public int AdvId { get; set; } = 0;

        public  string WorkForm { get; set; }

        public string Gender { get; set; }

        public string Qualification {get; set; }

        public string UniversityDep {get; set; }

        public string Country { get; set;}

        public string Category {get; set;}

        public string Department {get; set;}

        public string Page {get; set; }

        public string Company { get; set;}

        public DateTime ReleaseDate {get; set;}

        public int NumberOfPerson {get; set;}

        public string MilitaryStatus {get; set;}

        public int Age {get; set;}

        public string Experience {get; set;}
        
        public string ForeignLang {get; set;}

        public string ApplicationDate {get; set;}

        public string EducationLevel {get; set; }

        public string Sector {get; set;}

        public int AdvNumber {get; set;}

        public DateTime UpdatedDate {get; set;}

        public string Position {get; set; }

        public string Site {get; set;}

        public int Salary {get; set;}

        public string PositionLevel {get; set;}
    }
}