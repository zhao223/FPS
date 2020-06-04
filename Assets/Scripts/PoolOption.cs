using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//对象池
//序列化
[System.Serializable]
public class PoolOption 
{
    public string PrefabName;
    public GameObject Prefab;
    public int IntPreLoadNumber;

    [HideInInspector]
    public List<GameObject> ActiveGameObjectArray = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> InActiveGameObjectArray = new List<GameObject>();

    internal GameObject PreLoad(GameObject prefab,Vector3 Postion,Quaternion rotation)
    {
        GameObject obj = null;
        if (prefab)
        {
            obj = Object.Instantiate(prefab, Postion, rotation) as GameObject;
            obj.SetActive(false);
            
            InActiveGameObjectArray.Add(obj);
        }
        return obj;
    }
    internal GameObject Active(Vector3 pos,Quaternion rot)
    {
        GameObject obj;
        if(InActiveGameObjectArray.Count != 0)
        {
            obj = InActiveGameObjectArray[0];
            InActiveGameObjectArray.RemoveAt(0);
        }
        else
        {
            obj = Object.Instantiate(Prefab, pos, rot) as GameObject;
        }
        obj.transform.position = pos;
        obj.transform.rotation = rot;
        ActiveGameObjectArray.Add(obj);
        obj.SetActive(true);
        return obj;
    }
    internal void DeActive(GameObject obj)
    {
        InActiveGameObjectArray.Add(obj);
        ActiveGameObjectArray.Remove(obj);
        obj.SetActive(false);
    }
    internal int totalCount
    {
        get
        {
            int count = 0;
            count += this.ActiveGameObjectArray.Count;
            count += this.InActiveGameObjectArray.Count;
            return count;
        }
    }
    internal void ClearAllArray()
    {
        ActiveGameObjectArray.Clear();
        InActiveGameObjectArray.Clear();
    }
    internal void ClearUpUnused()
    {
        foreach (GameObject obj in InActiveGameObjectArray)
        {
            Object.Destroy(obj);
        }
        InActiveGameObjectArray.Clear();
    }
    
}
