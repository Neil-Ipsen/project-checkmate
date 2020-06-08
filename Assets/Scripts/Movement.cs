using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public PieceObject[,] pieceObject = new PieceObject[8,8];
    public GameObject redPiecePrefab;
    public GameObject blackPiecePrefab;

    private void Start() {
        startingOrientation();
    }

    private Vector3 pieceOffset = new Vector3(-10.5f, -10.5f);

    private void startingOrientation() {
        for(int y=0; y < 3; y++) {
            for(int x = 0; x < 8; x += 2) {
                renderPiece(x, y);
            }
        }
    }

    private void renderPiece(int x, int y) {
        GameObject newRed = Instantiate(redPiecePrefab) as GameObject;
        newRed.transform.SetParent(transform);
        PieceObject p = newRed.GetComponent<PieceObject>();
        pieceObject[x, y] = p;
        movement(p, x, y);
    }

    private void movement(PieceObject p, int x, int y) {
        p.transform.position = (Vector3.right * x) + (Vector3.forward * y) + pieceOffset;
    }
}
