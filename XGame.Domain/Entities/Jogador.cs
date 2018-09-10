using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            Senha = senha;

            if (email.IsInvalid())
            {
                AddNotifications(email);
            }

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(j => j.Senha,6,32,"A senha deve possuir entre 6 e 32 caracteres");
        }

        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public EnumSituacaoJogador Status { get; set; }

    }
}
