using UnityEngine;

public class ExitWindow : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;
    private Animator animator;
    private bool isCursorWasActive;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetExitWindowOn()
    {
        isCursorWasActive = Cursor.visible;
        Debug.Log(isCursorWasActive);

        gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        playerManager.enabled = false;
    }
    public void SetExitWindowOff()
    {
        animator.SetTrigger("Disable");

        Cursor.visible = isCursorWasActive;
        Debug.Log(isCursorWasActive);
        Cursor.lockState = isCursorWasActive ? CursorLockMode.Confined : CursorLockMode.Locked;
        
        playerManager.enabled = true;
    }
    private void DisableCanvas()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        animator.ResetTrigger("Disable");
    }

    public void CloseApplication()
    {
        SceneManagement.ColseApplication();
    }
}
