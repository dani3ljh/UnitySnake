using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  [Header("Objects")]
  [SerializeField] private GameObject square;
  [SerializeField] private Transform squareFolder;

  private SpriteRenderer[,] squareRenderers;

  private readonly int HEIGHT = 10;
  private readonly int WIDTH = 10;

  [Header("Colors")]
  [SerializeField] private Color snake;
  [SerializeField] private Color food;

  private float scale;

  void Start() {
    squareRenderers = new SpriteRenderer[HEIGHT, WIDTH];

    scale = GetSquareScale(HEIGHT);

    for (int y = 0; y < HEIGHT; y++) {
      squareRenderers[0, y] = Instantiate(
        square,
        new Vector3(0, GetYPosition(scale, y)),
        squareFolder.rotation,
        squareFolder
      ).GetComponent<SpriteRenderer>();
    }

    // Test code
    squareRenderers[0, 0].color = snake;
    squareRenderers[0, 1].color = food;
    squareRenderers[0, 2].color = snake;
  }

  private float GetSquareScale(int height) {
    return 10f/(float)height;
  }

  private float GetYPosition(float scale, int y) {
    return 5f-(scale/2+y*scale);
  }

  void Update() {
    
  }
}
