﻿using Flunt.Validations;

namespace BarDG.Domain.Common.Interfaces
{
    public interface IRequest : IValidatable
    {
    }

    public interface IRequest<T> : IRequest
    {
        T ToDomain();
    }

    public interface IRequest<T, Model> : IRequest
    {
        T ToDomain(Model model);
    }
}