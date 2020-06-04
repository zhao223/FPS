using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static Dictionary<string, Pools> poolDic = new Dictionary<string, Pools>();
    public static void Add(Pools p)
    {
        if (poolDic.ContainsKey(p.name))
        {
            return;
        }
        else
        {
            poolDic.Add(p.name, p);
        }
    }
}
