using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNode : MonoBehaviour
{

    //�������ӵ���ʾ
    //���LineRender���������Size���ڽڵ��������ýڵ��λ��
    public Transform node0;
    public Transform node1;


    Vector3[] allNodes;

    LineRenderer lineRen;

    private void Start()
    {
        lineRen = GetComponent<LineRenderer>();
        Debug.Log(lineRen);
        //lineRen.positionCount = 6;
        //�½�һ������
        lineRen.positionCount = 2;


        Debug.Log(lineRen.positionCount);
    }
    private void Update()
    {
        /*allNodes = new Vector3[6] { node0.position, node1.position, node2.position, node3.position, node4.position, node5.position };*/
        allNodes = new Vector3[2] { node0.position, node1.position};
        lineRen.SetPositions(allNodes);
    }
}

