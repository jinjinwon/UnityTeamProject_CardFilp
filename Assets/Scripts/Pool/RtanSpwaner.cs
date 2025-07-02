using System.Collections.Generic;
using UnityEngine;
public class RtanSpwaner : MonoBehaviour
{
    [SerializeField] private int spwanCount = 10;
    [SerializeField] private GameObject rtanPrefab;
    private List<Rtan> list_Rtans = new List<Rtan>();

    private void Start()
    {
        Initialized();
        InvokeRepeating("Spawn", 5f, 10f);
    }

    private void Initialized()
    {
        for (int j = 0; j < spwanCount; j++)
        {
            GameObject go = Instantiate(rtanPrefab);

            if (go.TryGetComponent(out Rtan catObj))
            {
                catObj.Initialized();
                list_Rtans.Add(catObj);
            }
        }
    }

    private void Spawn()
    {
        // 일반 고양이 생성
        RtanSpawn();
    }

    private void RtanSpawn()
    {
        for (int i = 0; i < list_Rtans.Count; i++)
        {
            if (list_Rtans[i].gameObject.activeSelf == true)
                continue;

            list_Rtans[i].OnSpawnRtan();
            break;
        }
    }
}
