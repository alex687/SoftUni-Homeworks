﻿namespace Bookmarks.Infrastructure.ModelBinders
{
    using System;
    using System.Web.Mvc;

    using Bookmarks.Models;

    public class EntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (!typeof(IEntity).IsAssignableFrom(modelType))
            {
                return null;
            }

            Type modelBinderType = typeof (EntityModelBinder<>).MakeGenericType(modelType);
            var modelBinder = ObjectFactory.GetInstance(modelBinderType);
            return (IModelBinder)modelBinder;
        }
    }
}