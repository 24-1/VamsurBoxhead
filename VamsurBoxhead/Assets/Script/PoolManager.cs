using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
   // ��������� ������ ����
   public GameObject[] prefabs; // ��������� ���� �迭
   // Ǯ ����� �ϴ� ����Ʈ��
   List<GameObject>[] pools; // ��������� ���� ����Ʈ �迭

   void Awake()
   {
      // ��������� ���� ����Ʈ �迭 �ʱ�ȭ
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
