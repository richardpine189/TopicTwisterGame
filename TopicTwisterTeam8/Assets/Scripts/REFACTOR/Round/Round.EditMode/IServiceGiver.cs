using System;
using System.Collections.Generic;
using UnityEngine;


public interface IServiceGiver
{
    public T GetService<T>();
}

public interface IServiceRegister
{
    public void RegisterService<T>(T service);
}

public class ServiceLocator : IServiceGiver, IServiceRegister
{
    private static ServiceLocator instance;
    public static ServiceLocator Instance { get { return instance; } }

    Dictionary<Type, object> _services;

    public ServiceLocator()
    {
        if(instance == null)
        {
            instance = new ServiceLocator();
        }
        instance = this;
        _services = new Dictionary<Type, object>();

    }
    public void RegisterService<T>(T service)
    {
        var type = typeof(T);
        _services.Add(type, service);

    }

    public T GetService<T>()
    {
        var type = typeof(T);
        _services.TryGetValue(type, out var service);
        return (T)service;
    }
}