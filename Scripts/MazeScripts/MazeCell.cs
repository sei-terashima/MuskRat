using System.Collections.Generic;
using UnityEngine;

// データモデルとしての迷路のセルを表現するクラス
public class MazeCellModel
{
    // セルの壁を列挙型で定義（上下左右）
    public enum Wall { Top, Bottom, Left, Right }

    // このセルが訪問済みかどうかを管理するフラグ
    public bool visited = false;

    // 各壁の状態（有無）を管理する辞書。初期値はすべて壁が存在する状態
    private Dictionary<Wall, bool> walls = new Dictionary<Wall, bool> {
        { Wall.Top, true },
        { Wall.Bottom, true },
        { Wall.Left, true },
        { Wall.Right, true }
    };

    // 指定された壁を取り除く（壁の状態をfalseにする）
    public void RemoveWall(Wall wall)
    {
        walls[wall] = false;
    }

    // 指定された壁が存在するかどうかを取得
    public bool HasWall(Wall wall)
    {
        return walls[wall];
    }
}

// UnityのMonoBehaviourを継承して、迷路セルを実際のオブジェクトとして表現するクラス
public class MazeCell : MonoBehaviour
{
    // 各方向の壁を表すGameObjectを格納する配列
    [SerializeField] private GameObject[] wallAarray = new GameObject[] { };

    // セルの壁の状態をモデルに基づいて設定する
    public void Setup(MazeCellModel mazeCellModel)
    {
        // モデルの状態に基づいて、各壁の可視性を設定する
        wallAarray[(int)MazeCellModel.Wall.Top].SetActive(mazeCellModel.HasWall(MazeCellModel.Wall.Top));

        // 全方向の壁についてループ処理で設定を反映
        for (int i = 0; i < (int)MazeCellModel.Wall.Right + 1; i++)
        {
            wallAarray[i].SetActive(mazeCellModel.HasWall((MazeCellModel.Wall)i));
        }
    }
}
