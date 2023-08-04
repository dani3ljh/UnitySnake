using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
  [Header("Objects")]
  [SerializeField] private GameObject square;
  [SerializeField] private Transform squareFolder;

  [Header("Colors")]
  [SerializeField] private Color snake;
  [SerializeField] private Color food;
  [SerializeField] private Color background;

  private SpriteRenderer[,] squareRenderers;

  private readonly int HEIGHT = 10;
  private readonly int WIDTH = 10;

  private float scale;

  void Start() {
    squareRenderers = new SpriteRenderer[HEIGHT, WIDTH];

    scale = GetSquareScale(HEIGHT);

    for (int x = 0; x < WIDTH; x++) {
      float xValue = x * scale + (scale - WIDTH) / 2f;

      for (int y = 0; y < HEIGHT; y++) {
        squareRenderers[x, y] = Instantiate(
          square,
          new Vector3(xValue, GetYPosition(scale, y)),
          squareFolder.rotation,
          squareFolder
        ).GetComponent<SpriteRenderer>();

        squareRenderers[x, y].color = background;
      }
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
