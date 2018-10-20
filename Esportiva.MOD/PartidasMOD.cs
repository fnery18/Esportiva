using System;

namespace Esportiva.MOD
{
    public class PartidasMOD
    {
        public int Id { get; set; }
        public string NomePartida { get; set; }
        public DateTime DataPartida { get; set; }
        public int Time1_Id { get; set; }
        public int Time2_Id { get; set; }
        public string LocalCompeticao { get; set; }
        public string Competicao { get; set; }
    }
}
