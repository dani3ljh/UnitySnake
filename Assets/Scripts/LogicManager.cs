using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour {
  public readonly int WIDTH = 15;
  public readonly int HEIGHT = 15;

  public Snake snake;

  void Start() {
    Point[] points = new Point[] {
      new Point(0, 7),
      new Point(1, 7),
      new Point(2, 7),
      new Point(3, 7),
    };
    snake = new Snake(points, WIDTH, HEIGHT, Direction.Right);
  }

  public void MoveSnake(Snake snake) {
    if (snake.length < 1) return;
    // TODO
  }

  public void Tick() {
    MoveSnake(snake);
  }
}

public class Snake {
  public Point?[] snakeBody;
  public int length;
  public Direction dir;

  public Snake(Point[] points, int width, int height, Direction dir) {
    this.snakeBody = new Point?[width * height];
    this.dir = dir;
    this.length = points.Length;
    for (int i = 0; i < points.Length; i++) {
      snakeBody[i] = points[i];
    }
  }
}

public enum Direction {
  Top,
  Right,
  Down,
  Left,
}

public class Point {
  public int x;
  public int y;

  public Point(int x, int y) {
    this.x = x;
    this.y = y;
  }
}
