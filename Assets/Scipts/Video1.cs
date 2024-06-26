using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Video1 : MonoBehaviour
{
    [SerializeField] GameObject hand;
    [SerializeField] Transform door;

    [SerializeField] GameObject nurse;
    [SerializeField] GameObject babyWithNurse, sheet;
    private Animator nurseAnim;
    [SerializeField] Transform[] nursePathTransforms;

    [SerializeField] GameObject mom;
    private Animator momAnim;
    [SerializeField] GameObject angrySymbol;
    [SerializeField] GameObject angryPaticleEmoji;
    [SerializeField] GameObject speechBubble;

    [SerializeField] Animator boyAnim;

    [SerializeField] Image fade;

    [SerializeField] GameObject startingScene;
    [SerializeField] GameObject endScene;

    private void Start()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(ZoomView());
        //StartCoroutine(NurseEnter_Enum());s
        GetRefrence();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            fade.DOFade(1, 0.8f).OnComplete(() => { SwitchScene(); fade.DOFade(0, 0.8f).SetDelay(1f); });
        }
    }

    public void SwitchScene()
    {
        startingScene.SetActive(false);
        endScene.SetActive(true);
        hand.SetActive(false); 
        CameraManager.Instance.ChangeCamera(2);
        NurseEnter();
    }

    void GetRefrence()
    {
        nurseAnim = nurse.GetComponent<Animator>();
        momAnim = mom.GetComponent<Animator>();
    }

    IEnumerator ZoomView()
    {
        yield return new WaitForSeconds(1.5f);
        CameraManager.Instance.ChangeCamera(1);
        hand.SetActive(true);
    }

    public void NurseEnter()
    {
        StartCoroutine(NurseEnter_Enum());
    }

    IEnumerator NurseEnter_Enum()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3[] pathPositions = new Vector3[nursePathTransforms.Length];
        for (int i = 0; i < pathPositions.Length; i++)
        {
            pathPositions[i] = nursePathTransforms[i].position; 
        }
        nurse.transform.DOPath(pathPositions, 4, PathType.CatmullRom, PathMode.Full3D, 5).SetLookAt(-1).SetEase(Ease.Linear).OnComplete(() => 
        {
            nurse.transform.DORotateQuaternion(nursePathTransforms[3].rotation, 0.5f);
            nurseAnim.SetTrigger("Idle"); 
        });
        door.DORotateQuaternion(Quaternion.Euler(0, 250, 0), 0.8f).SetDelay(0.8f);
        yield return new WaitForSeconds(3);
        CameraManager.Instance.ChangeCamera(3);
        yield return new WaitForSeconds(3.5f);
        babyWithNurse.SetActive(false);
        sheet.SetActive(false);
        nurseAnim.SetTrigger("Give");
        momAnim.SetTrigger("Take");
        yield return new WaitForSeconds(2f);
        nurse.transform.DORotateQuaternion(Quaternion.Euler(0, -90, 0), 0.5f);
        nurse.transform.DOMoveX(-30, 2.5f).SetDelay(0.2f).OnStart(() => { nurseAnim.SetTrigger("Walk"); }).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.5f);
        CameraManager.Instance.ChangeCamera(4);
        yield return new WaitForSeconds(1.5f);
        momAnim.SetTrigger("Open");
        yield return new WaitForSeconds(2f);
        angrySymbol.SetActive(true);
        yield return new WaitForSeconds(1f);
        boyAnim.SetTrigger("Shock");
        momAnim.SetTrigger("Shock");
        CameraManager.Instance.ChangeCamera(5);
        speechBubble.SetActive(true);
        speechBubble.transform.DOScale(Vector3.one, 0.7f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(2f);
        angryPaticleEmoji.SetActive(true);
    }
}
