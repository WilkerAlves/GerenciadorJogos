using System.Collections.Generic;
using XGame.Domain.Entities;

namespace XGame.Domain.Interface.Repositories
{
    public interface IRepositoryJogador
    {
        Jogador AutenticarJogador(string email, string senha);
        Jogador AdicionarJogador(Jogador request);
        IEnumerable<Jogador> ListaJogador();
    }
}
