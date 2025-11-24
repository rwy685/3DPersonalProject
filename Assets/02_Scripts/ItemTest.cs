using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemTest : MonoBehaviour
{
    void Start()
    {
        // 자동 생성된 로더 호출
        ItemLoader loader = new ItemLoader();  // Resources/JSON/Item.json 읽음

        // key 값으로 불러오기
        var item1000 = loader.GetByKey(1000);

        Debug.Log($"이름: {item1000.name}");
        Debug.Log($"공격력: {item1000.value}");
        Debug.Log($"설명: {item1000.Description}");
    }
}

