using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMoveTowardsCastle : MonoBehaviour
{
    public enum CastleSelection{
        CastlePointA = 0,
        CastlePointB = 1,
        CastlePointC = 2,
        CastlePointD = 3,
    }

    public Transform[] CastlePositions = new Transform[4];
    public Transform selectedCastle;    
    public CastleSelection homeBaseCastle;

    // Start is called before the first frame update
    void Start()
    {
        SetCastlePositions();
        PickRandomCastle();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsCastle();
    }

    void MoveTowardsCastle()
    {
        float stepSpeed = this.GetComponent<EnemyStats>().movementSpeed * Time.deltaTime;
        transform.position = UnityEngine.Vector3.MoveTowards(transform.position, selectedCastle.position, stepSpeed);
    }

#region GettingPositionData
    private void SetCastlePositions()
    {
        CastlePositions[0] = GameObject.Find("CastlePointA").transform;
        CastlePositions[1] = GameObject.Find("CastlePointB").transform;
        CastlePositions[2] = GameObject.Find("CastlePointC").transform;
        CastlePositions[3] = GameObject.Find("CastlePointD").transform;

        foreach (var position in CastlePositions)
            if (position == null){
                Debug.Log("There is no castle positions for " + this.gameObject.name);
                Debug.Break();
            }            
    }

    void PickRandomCastle()
    {
        int randomCastle = Random.Range(0, CastlePositions.Length);
        selectedCastle = CastlePositions[randomCastle];

        if (randomCastle == (int)homeBaseCastle) {
            PickRandomCastle();
        }
    }
#endregion GettingPositionData

}
