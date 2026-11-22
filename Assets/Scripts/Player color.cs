using Fusion;
using TMPro;
using UnityEngine;

public class Playercolor : NetworkBehaviour
{
    [SerializeField] private SpriteRenderer bodies;
    [SerializeField] private Color[] playercolor;

    [Networked] private int colorindex { get; set; }

    public override void Spawned()
    {
        if(Object.HasStateAuthority)
        {
            int playerID = Object.StateAuthority.PlayerId;
            int someColorIndex = playerID % playercolor.Length;

            colorindex = someColorIndex;
        }

        applyPlayerColor();
    }

    private void applyPlayerColor()
    {
        var currentColor = playercolor[colorindex];
        bodies.color = currentColor;
    }
}
