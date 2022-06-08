using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private static ServiceLocator instance;
    public static ServiceLocator Instance { get { return instance; } }

    Dictionary<Type, object> _services;

    private void Awake()
    {
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
        return (T) service;
    }
    
}
