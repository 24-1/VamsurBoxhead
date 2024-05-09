using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
   // 프리펩들은 보관할 변수
   public GameObject[] prefabs; // 프리펩들을 담을 배열
   // 풀 담당을 하는 리스트들
   List<GameObject>[] pools; // 프리펩들을 담을 리스트 배열

   void Awake()
   {
      // 프리펩들을 담을 리스트 배열 초기화
      pools = new List<GameObject>[prefabs.Length];
      for(int index = 0; index < prefabs.Length; index++)
      {
         pools[index] = new List<GameObject>();
      }
   }

   public GameObject Get(int index)
   {
        GameObject select = null;

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(select == null)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
   }
}
