using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class InstanceObject : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> _waste;
    public GameObject _posSpon;
    public float _betweenTime;
    private bool _hasInstance = true;
    private bool _end = true;
    void Start()
    {
        StartCoroutine(WaitEndGame());
    }

    // Update is called once per frame
    void Update()
    {
        RandomWaste();
    }

    private void RandomWaste()
    {
        int x = Random.Range(-10, 10);
        int _wasteR = Random.Range(0, 8);
        if (_hasInstance)
        {
            _hasInstance = false;
            Vector3 pos = new Vector3(x, _posSpon.transform.position.y, 0);
            Instantiate(_waste[_wasteR], pos, Quaternion.identity);
            StartCoroutine(WaitInstance(_end));
        }
    }

    private IEnumerator WaitInstance(bool a)
    {
        if(a)
        { 
            yield return new WaitForSeconds(_betweenTime);
            _hasInstance = true;
        }
    }

    private IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(100f);
        _end = false;
        yield return new WaitForSeconds(5f);
        _waste[8].SetActive(true);
    }

    
}
