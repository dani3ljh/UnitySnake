using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour {
  [Header("Objects")]
  [SerializeField] private GameObject square;
  [SerializeField] private Transform squareFolder;

  [Header("Colors")]
  [SerializeField] private Color snake;
  [SerializeField] private Color food;
  [SerializeField] private Color background;

  private SpriteRenderer[,] squareRenderers;
  private LogicManager lm;

  void Start() {
    lm = GetComponent<LogicManager>();

    squareRenderers = new SpriteRenderer[lm.WIDTH, lm.HEIGHT];

    float scale = GetSquareScale(lm.HEIGHT);

    for (int x = 0; x < lm.WIDTH; x++) {
      float xValue = x * scale + (scale - lm.WIDTH) / 2f;

      for (int y = 0; y < lm.HEIGHT; y++) {
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
}
