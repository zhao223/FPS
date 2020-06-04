using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    public GameObject needPrefab;
    public List<GameObject> objsArray = new List<GameObject>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject obj = PoolManager.poolDic["BulletPool"].BirthGameObject(needPrefab, Vector3.zero,Quaternion.identity);
            objsArray.Add(obj);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (objsArray.Count > 0)
            {
                PoolManager.poolDic["BulletPool"].RecoverGameObject(objsArray[0]);
                //Destroy(objsArray[0]);
                objsArray.RemoveAt(0);
            }
        }
    }
}
