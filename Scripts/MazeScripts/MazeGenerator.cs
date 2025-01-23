using System.Collections.Generic;
using UnityEngine;

// 迷路を生成するクラス
public class MazeGenerator : MonoBehaviour
{
    // 迷路の幅と高さ
    public int width, height;

    // 乱数生成器
    private System.Random random = new System.Random();

    // 迷路の各セルを管理する2次元配列
    private MazeCellModel[,] maze;

    // セルのPrefabとそのルート（親）オブジェクト
    public GameObject mazeCellPrefab;
    [SerializeField] private Transform root;

    // 各セルのスケール（大きさ）
    private float cellScale = 5f;

    // 迷路のゲームオブジェクトをクリア（削除）するメソッド
    public void ClearMaze()
    {
        // ルート配下のすべての子オブジェクトを取得し、一時リストに追加
        List<GameObject> tempList = new List<GameObject>();
        foreach (Transform child in root)
        {
            tempList.Add(child.gameObject);
        }

        // 一時リスト内の各オブジェクトを削除
        for (int i = 0; i < tempList.Count; i++)
        {
            DestroyImmediate(tempList[i]);
        }
    }

    // UnityのStartメソッドで迷路生成を開始
    public void Start()
    {
        GenerateMaze();
    }

    // 迷路全体を生成するメソッド
    public void GenerateMaze()
    {
        // 既存の迷路を削除
        ClearMaze();

        // 迷路セルモデルの初期化
        maze = new MazeCellModel[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                maze[x, y] = new MazeCellModel();
            }
        }

        // 再帰的なアルゴリズムで迷路を生成
        GenerateMaze(0, 0);

        // 生成した迷路モデルを基にゲームオブジェクトを配置
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float posX = x * cellScale; // X軸位置
                float posZ = y * cellScale; // Z軸位置

                // セルPrefabを生成し、ルートオブジェクトの子として配置
                MazeCell cell = Instantiate(
                    mazeCellPrefab,
                    new Vector3(posX, 0f, posZ),
                    Quaternion.identity,
                    root).GetComponent<MazeCell>();

                // セルのスケールを調整
                cell.transform.localScale *= cellScale;

                // セル名を設定（例: "0-0", "1-2"）
                cell.name = $"{x}-{y}";

                // モデルの状態に基づいてセルを設定
                cell.Setup(maze[x, y]);
            }
        }
    }

    // 再帰的に迷路を生成するメソッド
    private void GenerateMaze(int x, int y)
    {
        // 現在のセルを訪問済みに設定
        MazeCellModel currentCell = maze[x, y];
        currentCell.visited = true;

        // ランダムな方向にセルを訪問
        foreach (var direction in ShuffleDirections())
        {
            int newX = x + direction.Item1; // 移動後のX座標
            int newY = y + direction.Item2; // 移動後のY座標

            // 移動先が迷路の範囲内か確認
            if (newX >= 0 && newY >= 0 && newX < width && newY < height)
            {
                MazeCellModel neighbourCell = maze[newX, newY];

                // 未訪問の隣接セルを探索
                if (!neighbourCell.visited)
                {
                    // 隣接セルを訪問済みに設定
                    neighbourCell.visited = true;

                    // 壁を削除（現在のセルと隣接セルの壁を両方削除）
                    currentCell.RemoveWall(direction.Item3);
                    neighbourCell.RemoveWall(direction.Item4);

                    // 再帰的に次のセルを探索
                    GenerateMaze(newX, newY);
                }
            }
        }
    }

    // ランダムな方向をシャッフルして取得するメソッド
    private List<(int, int, MazeCellModel.Wall, MazeCellModel.Wall)> ShuffleDirections()
    {
        // 方向のリストを定義（上下左右）
        List<(int, int, MazeCellModel.Wall, MazeCellModel.Wall)> directions = new List<(int, int, MazeCellModel.Wall, MazeCellModel.Wall)> {
            (0, 1, MazeCellModel.Wall.Top, MazeCellModel.Wall.Bottom),
            (0, -1, MazeCellModel.Wall.Bottom, MazeCellModel.Wall.Top),
            (-1, 0, MazeCellModel.Wall.Left, MazeCellModel.Wall.Right),
            (1, 0, MazeCellModel.Wall.Right, MazeCellModel.Wall.Left)
        };

        // Fisher-Yatesアルゴリズムでシャッフル
        for (int i = 0; i < directions.Count; i++)
        {
            var temp = directions[i];
            int randomIndex = random.Next(i, directions.Count);
            directions[i] = directions[randomIndex];
            directions[randomIndex] = temp;
        }
        return directions;
    }
}
