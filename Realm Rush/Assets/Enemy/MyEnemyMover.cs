using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    void OnEnable()
    {
        FindPath();
        RetrunToStart();
        StartCoroutine(FollowPath());
    }


    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void RetrunToStart()
    {
        transform.position = path[0].transform.position;
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

        gameObject.SetActive(false);
    }
}

/*
   - OnEnable : 인스펙터뷰에서 체크를 통해서 게임 오브젝트를 활성화 할 때 사용됩니다. 활성화 할 때마다 호출 됩니다.


*/
