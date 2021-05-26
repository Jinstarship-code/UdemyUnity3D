using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyEnemy))]
public class MyEnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    MyEnemy enemy;
    void OnEnable()
    {
        FindPath();
        RetrunToStart();
        StartCoroutine(FollowPath());
    }

    private void Start() 
    {
        enemy = GetComponent<MyEnemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();

            if(waypoint !=null)
                path.Add(waypoint);
        }
    }

    void RetrunToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    
    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;

            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition,endPosition,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }

        FinishPath();
    }
}

/*
   - OnEnable : 인스펙터뷰에서 체크를 통해서 게임 오브젝트를 활성화 할 때 사용됩니다. 활성화 할 때마다 호출 됩니다.




     * Path finding
    - Breadth-first Search : 방향(up,down,left,right)의 순서를 정하고, 시작점부터 도착점까지 방향의 순서대로 그래프를 만들어서 최적의 경로가 나오는 것을 선택
    - Dijkstra
    - A* 

*/
