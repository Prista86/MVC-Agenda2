using System;

namespace MVC_Agenda2.DB.Entities
{
    public class Person
    {
        public Guid? ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string NumeroCellulare { get; set; }
        public string IndirizzoEmail { get; set; }
    }
}
