namespace Esportiva.MOD
{
    public class AcontecimentosMOD
    {
        public int Id { get; set; }
        public int Jogador_Id { get; set; }
        public JogadorMOD Jogador { get; set; }
        public int Partida_Id { get; set; }
        public PartidasMOD Partida { get; set; }
        public int Tempo { get; set; }
        public int Time_Id { get; set; }
        public TimeMOD Time { get; set; }
        public int TipoAcontecimento_Id { get; set; }
        public TipoAcontecimentoMOD TipoAcontecimento { get; set; }
    }
}
