using BarDG.Domain.Interfaces;
using Flunt.Notifications;
using System.Collections.Generic;

namespace BarDG.Domain.Services
{
    public abstract class ServiceBase : IService
    {
        public List<Notification> Notificacoes { get; protected set; } = new List<Notification>();
        public bool Valido => Notificacoes.Count == 0;
        public bool Invalido => !Valido;

        protected void AdicionarNotificacao(Notification notificacao)
        {
            Notificacoes.Add(notificacao);
        }

        protected void AdicionarNotificacoes(IEnumerable<Notification> notificacoes)
        {
            Notificacoes.AddRange(notificacoes);
        }

        protected void AdicionarNotificacao(string campo, string mensagem)
        {
            AdicionarNotificacao(new Notification(campo, mensagem));
        }
    }
}