using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawner : MonoBehaviour
{
    private Vector3 Min;
    private Vector3 Max;
    private float _xAxis;
    private float _yAxis;
    private float _xAxis2;
    private float _yAxis2;
    private float _zAxis;
    private float _zAxis2;//If you need this, use it
    private Vector3 _randomPosition;
    private Vector3 _randomPosition2;

    int jumlah;
    public GameObject fast;
    public GameObject slow;

    private void Start()
    {
        SetRanges();

    }
    private void Update()
    {
        _xAxis = UnityEngine.Random.Range(-170, 170);
        _zAxis = UnityEngine.Random.Range(-170, 170);
        _randomPosition = new Vector3(_xAxis, 20, _zAxis);
        _xAxis2 = UnityEngine.Random.Range(-170, 170);
        _zAxis2 = UnityEngine.Random.Range(-170, 170);
        _randomPosition2 = new Vector3(_xAxis2, 20, _zAxis2);

        InstantiateRandomObjects();
    }
    //Here put the ranges where your object will appear, or put it in the inspector.
    private void SetRanges()
    {
        Min = new Vector3(-170, 20, -170); //Random value.
        Max = new Vector3(170, 20, 170); //Another ramdon value, just for the example.
    }
    private void InstantiateRandomObjects()
    {
        if (jumlah < 500)
        {
            Instantiate(fast, _randomPosition, Quaternion.identity);
            Instantiate(slow, _randomPosition2, Quaternion.identity);
            jumlah++;
        }


    }
}
