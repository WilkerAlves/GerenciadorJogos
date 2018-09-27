using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Enum;
using XGame.Domain.Extensions;
using XGame.Domain.Resources;
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

        public Jogador(Nome nome, Email email, string senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Senha = senha;
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(j => j.Senha, 6, 32,
                Message.X0_E_OBRIGATORIA_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERE.ToFormat("Senha","6","32"));

            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }

            AddNotifications(nome, email);
        }

        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; private set; }

        public override string ToString()
        {
            return $"{Nome.PrimeiroNome} {Nome.UltimoNome}";
        }
    }
}
