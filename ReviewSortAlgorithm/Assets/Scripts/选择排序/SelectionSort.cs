using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 选择排序。每趟从待排序序列选一个记录放在已排好序的序列之后
/// </summary>
public class SelectionSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //EasySelectSort();
        //EasySelectSort1();
        HeapSort();
    }
	
    /// <summary>
    /// 简单选择排序。时间复杂度为n^2
    /// 从待排序列中选一个最小的放到已排好序的子序列后。此时算法是不稳定的
    /// 1.挑选。记录下标即可。不用每次都交换
    /// 2.放入
    /// </summary>
	void EasySelectSort()
    {
        int[] a = { 49, 38, 65, 49, 76, 13, 27, 97 };
        
        for(int i = 0; i < a.Length; i++)
        {
            int k = i;
            for(int j = i+1; j < a.Length; j++)
            {
                if (a[j] < a[k]) { k = j;   }
            }
            //找到之后再交换
            if (k != i)
            {
                int temp = a[i];
                a[i] = a[k];
                a[k] = temp;
            }
        }
        Show(a);
    }

    /// <summary>
    /// 改进的简单选择排序。时间复杂度为n^3
    /// 不立即交换而是先后移再插入，即可变成稳定的排序
    /// </summary>
    void EasySelectSort1()
    {
        int[] a = { 49, 38, 65, 49, 76, 13, 27, 97 };

        for (int i = 0; i < a.Length; i++)
        {
            int k = i;
            for (int j = i + 1; j < a.Length; j++)
            {
                if (a[j] < a[k]) { k = j; }
            }
            //找到之后再交换
            if (k != i)
            {
                int temp = a[k];
                //先后移，再插入
                for (int j = k-1 ; j >= i; j--)
                {
                    a[j+1 ] = a[j];
                }
                a[i] = temp;
            }
        }
        Show(a);
    }

    /// <summary>
    /// 堆排序。时间复杂度为nlog2n。不稳定的排序
    /// 堆：完全二叉树，根顶部最大或最小。子结点必比父节点大或小。完全二叉树可以自顶向下和从左向右看成一个序列
    /// 堆排序。构造成大根堆或小跟对，然后将堆顶与堆的最后一个记录交换。相当从堆选择最大或最小元素。
    /// 构造堆。根结点起逐步加入数据
    /// </summary>
    void HeapSort()
    {
        //堆排序中初始构造堆才是难点和关键。
        //思想：二叉树中最后一个非叶结点是第【n/2】个元素，从该节点开始依次将【n/2】，【n/2】-1作为当前节点，
        //逐一检查以其为根的子树是否构成大根堆，不是的话则交换构成大根堆。称为筛法算法
        int[] r = {0, 49, 38, 65, 97, 76, 13, 27, 49 };
        int n = r.Length - 1;

        //初始化建堆
        for(int i = n/ 2; i >= 1; i--)
        {
            print("i" + i);
            Sift(ref r, i, n);//自第【n/2】个记录进行筛选建堆
        }
        
        for(int i = n; i >= 2; i--)
        {
            int temp = r[1];
            r[1] = r[i];
            r[i] = temp;

            //初始建堆后根结点均已为大根堆
            Sift(ref r, 1, i - 1);
        }

        Show(r);
    }

    /// <summary>
    /// 筛法建堆
    /// </summary>
    /// <param name="r"></param>
    /// <param name="k">根</param>
    /// <param name="m"></param>
    void Sift(ref int[] r,int k,int m)
    {
        int i = k;     //根节点
        int j = i * 2; 
        int x = r[k];  //暂存根记录

        while (j <= m) //不能超出总数，判断有没有子树
        {
            if (j < m && r[j] < r[j + 1]){ j++;  }//指向较大的子树

            if (x >= r[j]) { break; } //根比子树大则结束
            else
            {
                //较大子树上移交换
                int temp = r[i];   r[i] = r[j]; r[j] = temp;

                x = r[j]; //交换后的子树继续作为根构建
                i = j;
                j = 2 * i;
            }
        }
    }

    /// <summary>
    /// 显示排序的序列
    /// </summary>
    void Show(int[] array)
    {
        foreach (var i in array) { print(i); }
    }
}
