using Cinemachine;
using UnityEngine;
public class InventoryScp : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera m_Camera;
    [SerializeField]
    float transition_Speed;

    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    Animator animator;
    bool loadInventory;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && inventoryUI.activeInHierarchy == true)
        {
            inventoryUI.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && inventoryUI.activeInHierarchy == false)
        {
            inventoryUI.SetActive(true);
        }
    }
}



