using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Resources;

namespace XGame.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(n => n.PrimeiroNome, 3, 50,
                Message.X0_E_OBRIGATORIO_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERE.ToFormat("Primeiro Nome","3","50"))
                .IfNullOrInvalidLength(n => n.UltimoNome, 3, 50,
                Message.X0_E_OBRIGATORIO_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERE.ToFormat("Ultimo Nome", "3","50"));
        }

        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }  
    }
}
