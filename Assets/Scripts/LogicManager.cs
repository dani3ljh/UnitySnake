using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour {
  public readonly int WIDTH = 10;
  public readonly int HEIGHT = 10;

  public Snake snake;

  void Start() {
    snake = new Snake(WIDTH, HEIGHT, Direction.Right);
  }
}

public class Snake {
  bool?[,] snakeBody;
  Direction dir;

  public Snake(int width, int height, Direction dir) {
    this.snakeBody = new bool?[width, height];
    this.dir = dir;
  }
}

public enum Direction {
  Top,
  Right,
  Down,
  Left,
}
