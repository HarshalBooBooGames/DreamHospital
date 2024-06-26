using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Video2 : MonoBehaviour
{
    public Transform[] paths;
    public Transform[] exitAfter;
    public Animator nurse;
    bool took = true;
    public Animator cameraAnim;
    public GameObject CryPlace;
    public GameObject Puzzel;
    public Transform[] pathslast;
    public Transform[] exitAfterlast;
    public Animator nurselast;
    public Animator mummy;
    [SerializeField] Image fade;
    public bool startPuzzle;
    public GameObject Offbaby;
    public Outline[] outObj;

    public Transform[] secondPath;
    public Transform[] goBack;
    public Animator mummy2;
    [SerializeField] GameObject hand;
    public Animator ChooseAnimator;
    public void OffOutLine()
    {
        for (int i = 0; i < outObj.Length; i++)
        {
            outObj[i].enabled = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            fade.DOFade(1, 0.8f).OnComplete(() => { cameraAnim.Play("PuzzelStart"); SetForPuzzel(); fade.DOFade(0, 0.8f).SetDelay(1f); });
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            nurse.Play("Take");
            // StartCoroutine(OffBabyCo());
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            hand.SetActive(false);
            ChooseAnimator.gameObject.SetActive(false);
            if (Puzzel.activeInHierarchy)
            {

                nurselast.Play("nurseWalk");
                OffOutLine();
                cameraAnim.Play("AfterPuzzel");
                Vector3[] pathPositions = new Vector3[secondPath.Length];
                for (int i = 0; i < pathPositions.Length; i++)
                {
                    pathPositions[i] = secondPath[i].position;
                }
                nurselast.transform.DOPath(pathPositions, 3f, PathType.CatmullRom, PathMode.Full3D, 8).SetLookAt(-1).SetEase(Ease.Linear).OnComplete(() =>
                {
                    nurselast.transform.DORotateQuaternion(secondPath[1].rotation, 0.5f);
                    nurselast.Play("nurseIdle");
                });

            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (took)
            {
                took = false;
                nurse.Play("TakeAndWalk");
                Vector3[] pathPositions = new Vector3[exitAfter.Length];
                for (int i = 0; i < pathPositions.Length; i++)
                {
                    pathPositions[i] = exitAfter[i].position;
                }
                nurse.transform.DOPath(pathPositions, 2, PathType.CatmullRom, PathMode.Full3D, 7).SetLookAt(-1).SetEase(Ease.Linear).OnComplete(() =>
                {
                    nurse.transform.DORotateQuaternion(exitAfter[0].rotation, 0.5f);
                    nurse.Play("Idle");
                });
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Puzzel.activeInHierarchy)
            {
                if (startPuzzle)
                {
                    Vector3[] pathPositions = new Vector3[pathslast.Length];
                    for (int i = 0; i < pathPositions.Length; i++)
                    {
                        pathPositions[i] = pathslast[i].position;
                    }
                    nurselast.transform.DOPath(pathPositions, 2.5f, PathType.CatmullRom, PathMode.Full3D, 7).SetLookAt(-1).SetEase(Ease.Linear).OnComplete(() =>
                    {
                        // v2.nurse.transform.DORotateQuaternion(v2.paths[3].rotation, 0.5f);
                        nurselast.Play("nurseIdle");
                        cameraAnim.Play("PuzzelPlace");
                       // hand.SetActive(true);
                    });
                    startPuzzle = false;
                }

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            nurselast.Play("nurseWalkN");
            cameraAnim.Play("AfterGive");
            Vector3[] pathPositions = new Vector3[goBack.Length];
            for (int i = 0; i < pathPositions.Length; i++)
            {
                pathPositions[i] = goBack[i].position;
            }
            nurselast.transform.DOPath(pathPositions, 2.5f, PathType.CatmullRom, PathMode.Full3D, 7).SetLookAt(-1).SetEase(Ease.Linear).OnComplete(() =>
            {
                // v2.nurse.transform.DORotateQuaternion(v2.paths[3].rotation, 0.5f);

            });
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            nurselast.Play("nurseGive");
            mummy.Play("girlTake");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mummy.gameObject.SetActive(false);
            mummy2.gameObject.SetActive(true);
            cameraAnim.Play("Changing");
            mummy2.Play("ChangeDiper");
        }
    }
    public void SetForPuzzel()
    {
        CryPlace.SetActive(false);
        Puzzel.SetActive(true);
        startPuzzle = true;

    }
    public void OffBaby()
    {
        StartCoroutine(OffBabyCo());
    }
    IEnumerator OffBabyCo()
    {
        // yield return new WaitForSeconds(.85f);
        Offbaby.GetComponent<Animator>().enabled = false;
        Offbaby.SetActive(false);
        yield return null;
    }
}
