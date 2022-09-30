using UnityEngine;

public class ExitWindow : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetExitWindowOn()
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        playerManager.enabled = false;
    }
    public void SetExitWindowOff()
    {
        animator.SetTrigger("Disable");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
