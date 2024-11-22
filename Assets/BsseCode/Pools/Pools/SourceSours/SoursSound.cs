using System.Collections;
using System.Collections.Generic;
using BsseCode.Pools.Pools;
using UnityEngine;
using Zenject;

public class SoursSound : MonoBehaviour, IPoolsElement
{
    public AudioSource Source { get; private set; }
    
    private IPoolController _poolController;


    [Inject]
    public void Construct(IPoolController poolController)
    {
        _poolController = poolController;
    }
  
    void Start()
    {
        Source = gameObject.GetComponent<AudioSource>(); 
    }


    public void Deactivate()
    {
        _poolController.ReturnToPool(this);
    }
}
