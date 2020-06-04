using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Pools : MonoBehaviour
{
    public Transform ThisGameObjectPosition;

    public List<PoolOption> poolsArray = new List<PoolOption>();

    private void Awake()
    {
        ThisGameObjectPosition = transform;
        PreLoadGameObject();
        PoolManager.Add(this);
    }
    void PreLoadGameObject()
    {
        for(int i = 0; i < poolsArray.Count; i++)
        {
            PoolOption option = poolsArray[i];
            for(int j = 0; j < option.IntPreLoadNumber; j++)
            {
                GameObject obj = option.PreLoad(option.Prefab, Vector3.zero, Quaternion.identity);
                obj.transform.parent = ThisGameObjectPosition;
            }
        }
    }
    public GameObject BirthGameObject(GameObject prefab,Vector3 pos,Quaternion rot)
    {
        GameObject obj = null;
        for(int i = 0; i < poolsArray.Count; i++)
        {
            PoolOption opt = this.poolsArray[i];
            if(opt.Prefab = prefab)
            {
                obj = opt.Active(pos, rot);
                if (obj == null) return null;
                if (obj.transform.parent != ThisGameObjectPosition)
                {
                    obj.transform.parent = ThisGameObjectPosition;
                }
            }
        }
        return obj;
    }
    public void RecoverGameObject(GameObject instance)
    {
        for(int i = 0; i < poolsArray.Count; i++)
        {
            PoolOption opt = this.poolsArray[i];
            if (opt.ActiveGameObjectArray.Contains(instance))
            {
                if (instance.transform.parent != ThisGameObjectPosition)
                    instance.transform.parent = ThisGameObjectPosition;
                opt.DeActive(instance);
            }
        }
    }
    public void DestoryUnused()
    {
        for(int i = 0; i < this.poolsArray.Count; i++)
        {
            PoolOption opt = this.poolsArray[i];
            opt.ClearUpUnused();
        }
    }
   
    public void OnDestroy()
    {
        for(int i = 0; i < this.poolsArray.Count; i++)
        {
            PoolOption opt = this.poolsArray[i];
            opt.ClearAllArray();
        }
    }
}
