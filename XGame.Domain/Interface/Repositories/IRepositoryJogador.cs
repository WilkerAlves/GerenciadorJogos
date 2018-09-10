using System;
using XGame.Domain.Arguments.Jogador;

namespace XGame.Domain.Interface.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(string email, string senha);
        Guid AdicionarJogado(AdicionarJogadorRequest request);
    }
}
