using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public GameObject cdbargr;
    public Texture2D unarmedS;
    public Texture2D swordS;
    public Texture2D hammerS;
    public Texture2D spearS;
    public Texture2D gunS;
    public PrimaryItems pItems;

    private void Start()
    {
        Cursor.SetCursor(unarmedS, new Vector2(16, 16), CursorMode.Auto);
    }

    private void FixedUpdate()
    {
        if (pItems.itemEquipped == "Unarmed")
        {
            Cursor.SetCursor(unarmedS, new Vector2(16, 16), CursorMode.Auto);
        }
        else if (pItems.itemEquipped == "Sword")
        {
            Cursor.SetCursor(swordS, new Vector2(16, 16), CursorMode.Auto);
        }
        else if (pItems.itemEquipped == "Hammer")
        {
            Cursor.SetCursor(hammerS, new Vector2(16, 16), CursorMode.Auto);
        }
        else if (pItems.itemEquipped == "Gun")
        {
            Cursor.SetCursor(gunS, new Vector2(16, 16), CursorMode.Auto);
        }
        else if (pItems.itemEquipped == "Spear")
        {
            Cursor.SetCursor(spearS, new Vector2(16, 16), CursorMode.Auto);
        }
    }
}
