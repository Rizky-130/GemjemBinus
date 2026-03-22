using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    Rigidbody2D rb;
    public GameManager gameManager;

    bool isResetting = false;
    float resetTimer = 0f;

    List<RaycastResult> results = new List<RaycastResult>();
    GameObject lastHovered;

    [Header("Movement")]
    public float sensitivity = 0.8f;
    Vector3 minBounds;
    Vector3 maxBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // ambil batas layar dari kamera
        Camera cam = Camera.main;

        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minBounds = bottomLeft;
        maxBounds = topRight;
    }

    void FixedUpdate()
    {
        if (isResetting)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f)
                isResetting = false;

            return;
        }

        // 🔥 pakai delta movement, bukan posisi mouse
        float moveX = Input.GetAxis("Mouse X") * sensitivity;
        float moveY = Input.GetAxis("Mouse Y") * sensitivity;

        Vector2 move = new Vector2(moveX, moveY);

        Vector2 newPos = rb.position + move;

        float offset = 0.2f; // sesuaikan ukuran cursor

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + offset, maxBounds.x - offset);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + offset, maxBounds.y - offset);

        rb.MovePosition(newPos);
        CheckUIClick();
        CheckUI();
    }

    public void ResetToSpawn(Vector3 pos)
    {
        rb.position = pos;

        isResetting = true;
        resetTimer = 0.1f;
    }
    public void CheckUIClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Camera.main.WorldToScreenPoint(transform.position);

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<UnityEngine.UI.Button>())
                {
                    result.gameObject.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
                }
            }
        }
    }
    void CheckUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Camera.main.WorldToScreenPoint(transform.position);

        results.Clear();
        EventSystem.current.RaycastAll(pointerData, results);

        GameObject currentHovered = null;

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Button>())
            {
                currentHovered = result.gameObject;
                break;
            }
        }

        // HOVER MASUK
        if (currentHovered != lastHovered)
        {
            if (lastHovered != null)
                ExecuteEvents.Execute(lastHovered, pointerData, ExecuteEvents.pointerExitHandler);

            if (currentHovered != null)
                ExecuteEvents.Execute(currentHovered, pointerData, ExecuteEvents.pointerEnterHandler);
        }

        lastHovered = currentHovered;
    }
}