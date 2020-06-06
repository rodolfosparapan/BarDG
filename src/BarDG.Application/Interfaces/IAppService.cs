using Flunt.Notifications;
using System.Collections.Generic;

namespace BarDG.Application.Interfaces
{
    public interface IAppService
    {
        bool Valido { get; }
        bool Invalido { get; }
        List<Notification> Notificacoes { get; }
    }
}