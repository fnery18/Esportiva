using System;

namespace Esportiva.MOD
{
    public class PartidasMOD
    {
        public int Id { get; set; }
        public string NomePartida { get; set; }
        public DateTime DataPartida { get; set; }
        public int IdTime1 { get; set; }
        public TimeMOD Time1 { get; set; }
        public int IdTime2 { get; set; }
        public TimeMOD Time2 { get; set; }
        public string LocalCompeticao { get; set; }
        public string Competicao { get; set; }
    }
}
