using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour {
  [Header("Objects")]
  [SerializeField] private GameObject square;
  [SerializeField] private Transform squareFolder;

  [Header("Colors")]
  [SerializeField] private Color snakeColor;
  [SerializeField] private Color foodColor;
  [SerializeField] private Color bgColor;

  private SpriteRenderer[,] squareRenderers;
  private LogicManager lm;

  void Start() {
    lm = GetComponent<LogicManager>();

    squareRenderers = new SpriteRenderer[lm.WIDTH, lm.HEIGHT];

    float scale = GetSquareScale(lm.HEIGHT);

    for (int x = 0; x < lm.WIDTH; x++) {
      float xValue = x * scale - lm.WIDTH * scale / 2f;

      for (int y = 0; y < lm.HEIGHT; y++) {
        Transform tile = Instantiate(
          square,
          new Vector3(xValue, GetYPosition(scale, y)),
          squareFolder.rotation,
          squareFolder
        ).transform;

        tile.localScale = new Vector3(scale, scale, scale);

        squareRenderers[x, y] = tile
          .GetChild(0)
          .gameObject
          .GetComponent<SpriteRenderer>();

        squareRenderers[x, y].color = bgColor;
      }
    }

    Tick();
  }

  public void Tick() {
    for (int i = 0; i < lm.snake.snakeBody.Length; i++) {
      Point? body = lm.snake.snakeBody[i];
      if (body == null) break;
      squareRenderers[body.x, body.y].color = snakeColor;
    }
  }

  private float GetSquareScale(int height) {
    return 10f/(float)height;
  }

  private float GetYPosition(float scale, int y) {
    return 5f-(scale/2+y*scale);
  }
}
