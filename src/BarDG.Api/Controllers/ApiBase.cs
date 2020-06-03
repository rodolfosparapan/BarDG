using BarDG.Domain.Common;
using BarDG.Domain.Common.Interfaces;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BarDG.Api.Controllers
{
    public abstract class ApiBase : ControllerBase
    {
        private List<Notification> notificacoes { get; set; }
        private readonly IService appService;

        protected ApiBase(IService service)
        {
            notificacoes = new List<Notification>();
            this.appService = service;
        }

        protected bool ValidarRequest(IRequest request)
        {
            request.Validate();
            var requestBase = (RequestBase)request;

            if (requestBase.Invalid)
                notificacoes.AddRange(requestBase.Notifications);

            return requestBase.Valid;
        }

        protected new IActionResult Response(object result = null)
        {
            IActionResult actionResult;

            if (notificacoes.Any() || appService.Invalido)
            {
                actionResult = BadRequest(new
                {
                    sucesso = false,
                    erros = ObterErros()
                });
            }
            else
            {
                actionResult = Ok(result);
            }
            
            return actionResult;
        }

        private string[] ObterErros()
        {
            var erros = new List<string>();

            if (notificacoes != null)
                erros.AddRange(notificacoes.Select(n => n.Message));

            if (appService.Notificacoes != null)
                erros.AddRange(appService.Notificacoes.Select(n => n.Message));

            return erros.ToArray();
        }
    }
}