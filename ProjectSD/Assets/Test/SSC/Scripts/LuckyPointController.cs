using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LuckyPointController : MonoBehaviour
{
    // 럭키 포인트 지점 오브젝트들을 인스펙터창에서 직접 할당
    [SerializeField] private GameObject[] luckyPoint;
    private void Start()
    {
        int i = 0;

        // 최초에는 10개의 약점만 활성화 한다.
        while (i < 10)
        {
            int rand = Random.Range(0, luckyPoint.Length);

            // 랜덤으로 뽑은 약점이 이미 활성화 된 상태면 반복문 재진입
            if (luckyPoint[rand].GetComponent<Collider>().enabled == true)
            {
                continue;
            }

            // 중복되지 않은 랜덤값을 받았다면 해당하는 인덱스의 럭키포인트 콜라이더 활성화 및 색상 변경
            luckyPoint[rand].GetComponent<Collider>().enabled = true;
            luckyPoint[rand].GetComponent<MeshRenderer>().materials[0].color = Color.blue;

            i++;
        }
    }

    // Bullet으로부터 실행요청 약점바꾸는 메소드
    public void ChangePoint(GameObject obj)
    {
        // Bullet이 부딪힌 오브젝트를 전달받고 해당 약점 콜라이더 비활성화 및 색상 변경
        obj.GetComponent<Collider>().enabled = false;
        obj.GetComponent<MeshRenderer>().materials[0].color = Color.white;

        int rand = 0;

        while(true)
        {
            rand = Random.Range(0, luckyPoint.Length);

            // 이후 새로 활성화할 약점 찾기
            // 1. 전달받은 오브젝트와 이름이 일치하거나
            // 2. 새로 뽑은 인데스의 오브젝트가 이미 활성화 중이라면 새로뽑기
            if(obj.name == luckyPoint[rand].name ||
                luckyPoint[rand].GetComponent<Collider>().enabled == true)
            {
                continue;
            }

            // 이후 무한 While문 탈출
            break;
        }

        // 전달된 랜덤값의 인덱스로 해당 약점 활성화
        luckyPoint[rand].GetComponent<Collider>().enabled = true;
        luckyPoint[rand].GetComponent<MeshRenderer>().materials[0].color = Color.blue;

    }
}
