using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject position;
    public GameObject projectile;
    public float force;

    private int maxPoints = 0;
    private int points = 0;
    private int ammo = 0;

    private bool playing = false;
    private bool win = false;
    private bool losing = false;

    private bool toShoot = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (!playing)
            return;

        if (ammo <= 0)
        {
            if (!losing && !win)
            {
                losing = true;
                StartCoroutine(GoToLoseScene());
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || toShoot)
            Shoot();
        toShoot = false;
    }

    public void ToShoot()
    {
        toShoot = true;
        Debug.Log("BUTTON CLICKED");
    }

    private void Shoot()
    {
        --ammo;

        GameObject current = Instantiate(projectile);
        current.transform.SetPositionAndRotation(position.transform.position, position.transform.rotation);
        current.GetComponent<Rigidbody>().AddForce(position.transform.forward * force);
    }

    public void AddPoint()
    { 
        ++points;
        if (points == maxPoints && !win)
        {
            win = true;
            StartCoroutine(GoToWinScene());
        }
    }

    public void SetUp(int ammo, int maxPoints)
    {
        points = 0;
        this.maxPoints = maxPoints;
        this.ammo = ammo;

        playing = true;
    }

    public void CleanUp()
    {
        points = 0;
        maxPoints = 0;
        ammo = 0;

        playing = false;
    }

    IEnumerator GoToWinScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("WinScene");
    }

    IEnumerator GoToLoseScene()
    {
        yield return new WaitForSeconds(4.0f);
        if (!win)
            SceneManager.LoadScene("LoseScene");
    }
}
