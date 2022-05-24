using System;
using System.Collections.Generic;

namespace TiendaServicios.api.author.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public ICollection<GradoAcademico> AcademyGradeList { get; set; }
        public string AuthorGuid { get; set; }
    }
}
