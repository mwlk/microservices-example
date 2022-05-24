using System;

namespace TiendaServicios.api.author.Models
{
    public class GradoAcademico
    {
        public int GradoAcademicoId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? DateGrade { get; set; }

        public int AuthorId { get; set; }
        public Author BookAuthor { get; set; }

        public string AcademyGradeGuid { get; set; }
    }
}