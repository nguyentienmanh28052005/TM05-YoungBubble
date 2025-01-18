using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BubbleController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rb;
    private float _horizontal;
    public float _power;
    public float _powerJump;
    [SerializeField] private GameObject _visualPlayer;
    [SerializeField] private GameObject _soundEffBB;

    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    private void Move()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_horizontal, _rb.velocity.y);
        transform.Translate(_rb.velocity * Time.deltaTime * _power);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Waste")
        {
            _visualPlayer.SetActive(false);
            Instantiate(_soundEffBB, transform.position, Quaternion.identity);
            StartCoroutine(WaitLoadScene());
        }
        else if  (other.gameObject.tag == "SeaFloor")
        {
            //SceneManager.LoadScene("StartGameScene");
            Time.timeScale = 0;
            CanvasManager.Instance.OpenCanvas("CanvasWin");
        }
    }

    private IEnumerator WaitLoadScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("StartGameScene");
    }
    
    
}