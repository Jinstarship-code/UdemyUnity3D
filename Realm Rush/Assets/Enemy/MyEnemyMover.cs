using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MyEnemy))]
public class MyEnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    List<Node> path = new List<Node>();
    MyEnemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;
    void Awake() 
    {
        enemy = GetComponent<MyEnemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void OnEnable()
    {
        FindPath();
        RetrunToStart();
        StartCoroutine(FollowPath());
    }


    void FindPath()
    {
        path.Clear();
        path = pathfinder.GetNewPath();
    }

    void RetrunToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.GetStartCoordinates);
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    
    IEnumerator FollowPath()
    {
        for(int i = 0; i<path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
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
