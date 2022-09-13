using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private static ServiceLocator _instance;
    public static ServiceLocator Instance => _instance ?? (_instance = new ServiceLocator());

    Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public void RegisterService<T>(T service)
    {
        var type = typeof(T);
        _services.Add(type, service);
        
    }

    public T GetService<T>()
    {
        var type = typeof(T);
        _services.TryGetValue(type, out var service);
        return (T) service;
    }  
}
