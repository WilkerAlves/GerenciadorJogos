using XGame.Domain.Interface.Arguments;

namespace XGame.Domain.Arguments.Jogador
{
    public class AutenticarJogadorResponse :IResponse
    {
        public string PrimeiroNome { get; set; }
        public string Email { get; set; }

    }
}