using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ray_controller : MonoBehaviour
{
    public float fireRate = 0.25f;                                      
    public float weaponRange = 1000f;                                     
    public Transform gunEnd;                                            
    private Camera fpsCam;                                              
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);    
    private AudioSource gunAudio;                                       
    private LineRenderer laserLine;                                     
    private float nextFire;

    int score = 0;
    public Text scoretext;
    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        fpsCam = GetComponentInChildren<Camera>();

        scoretext.text = "Score: " + score.ToString();
    }


    void Update()
    {

        scoretext.text = "Score: " + score.ToString();
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;

            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                ball_collider ball = hit.collider.GetComponent<ball_collider>();
                if(ball != null)
                {
                    ball.disappear();
                    score += 1;
                }
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
            }

            nextFire = Time.time + fireRate;
        }


    }

    private IEnumerator ShotEffect()
    {
        gunAudio.Play();
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }

}

