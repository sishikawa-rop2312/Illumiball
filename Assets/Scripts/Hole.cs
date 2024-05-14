using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    // どのボールを吸い寄せるかをタグで指定
    public string targetTag;
    // bool isHolding;
    public bool IsHolding { get; set; }

    // // ボールが入っているかを返す
    // public bool IsHolding()
    // {
    //     return isHolding;
    // }

    // ホールにボールが入ったとき実行
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            IsHolding = true;
        }
    }

    // ホールからボールが出たとき実行
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            IsHolding = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // コライダに触れているオブジェクトのRididbodyコンポーネントを取得
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        // ボールがどの方向にあるかを計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();  // ベクトルの長さを強制的に1にする（穴の大きさが異なるので統一するため）

        // タグに応じてボールに力を加える
        if (other.CompareTag(targetTag))
        {
            // 中心地点でボールを止めるため速度を減速させる（この処理がないと中心点止まらずにブラブラする）
            r.velocity *= 0.9f;

            r.AddForce(direction * -20.0f, ForceMode.Acceleration); // ForceMode.Acceleration: 徐々に
        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration); // ForceMode.Acceleration: 徐々に
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
