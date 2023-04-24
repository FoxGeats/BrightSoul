
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePosition : MonoBehaviour
{

    //���Ӻ����㷨��
    //�ж������ڵ�ľ��룬��������ڵ㶨������ǰ�����Ϊ�������루�ı��ӽڵ�λ�ã��ò�ֵ�����㣩
    private float nodeDistance = 10f;  //�ڵ㶨��
    public Transform lastNodeTran;   //��һ���ڵ��λ��
    float realDistance;      //��ʵ����
    Rigidbody2D rig;
    float allowValue = 0.2f;  //��������ֵ

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Judge();
        /*Deceleration();*/
    }
    void Judge()
    {
        //���������ʱ����ƽ����ȿ�����
        realDistance = Vector3.Magnitude(lastNodeTran.position - transform.position);
        if (realDistance > nodeDistance * nodeDistance || realDistance < nodeDistance * nodeDistance - allowValue) //��ƽ�����Ƚ�
            
            {
            //�Ѿ�����
            transform.position = Vector3.Lerp(lastNodeTran.position, transform.position, nodeDistance / realDistance);
        }
    }
    void Deceleration() //����
    {
        if (rig.velocity.sqrMagnitude > 25)
        {
            rig.velocity /= 3;
        }
    }
}
