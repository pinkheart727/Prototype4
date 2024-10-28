using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPushed = false;
    public GameObject projectile;
    public float shootDelay;
    public GameObject spawnPoint;
    private bool canShoot = true;
    public Material defaultMaterial;
    public Material usedMaterial;
    public MeshRenderer myMR;

    private void Start()
    {
        myMR = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isPushed)
        {
            isPushed = true;
            Debug.Log("I AM BUN THE BUTTON");
            StartCoroutine(ButtonReset());
            myMR.material = usedMaterial;
            canShoot = false;
            Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
            StartCoroutine(ShootDelay());
        }
    }

    IEnumerator ButtonReset()
    {
        yield return new WaitForSeconds(5);
        myMR.material = defaultMaterial;
        isPushed = false;
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }
}
