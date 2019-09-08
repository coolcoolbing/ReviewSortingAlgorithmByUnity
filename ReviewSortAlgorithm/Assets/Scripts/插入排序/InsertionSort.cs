using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 插入排序
/// </summary>
public class InsertionSort : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //InsertSort();
        //InsertSort1();
        ShellSort();
    }

    //直接插入排序：每次将待排序的一个记录，按其关键字的大小插入到前面已排好序的子序列中的适当位置
    /// <summary>
    /// 带岗哨的直接插入排序。R[0]作为岗哨，用R[0]保存当前要处理的记录，这种是边查找边后移，r[0]==r[0]时肯定会停下来
    /// 时间复杂度为n^2,当数组已接近拍好序时，插入排序是一个很好的选择
    /// </summary>
    void InsertSort()
    {
        int[] array = { 0,49, 38, 65, 97, 76, 13, 27, 49 };
        
        for(int i = 2; i < array.Length; i++)
        {
            array[0] = array[i];
            for(int j = i - 1; array[0] < array[j]; j--)
            {
                array[j + 1] = array[j];//往后移动一位
                array[j] = array[0]; //插入
            }
        }
        Show(array);
    }

    /// <summary>
    /// 不带岗哨的直接插入排序。与带岗哨的区别：先找插入位置，再往后腾出插入位置。每次需是否越界检查
    /// 每取一个下标，都要判断取值是否越界，所以效率比带岗哨的要多一步
    /// 时间复杂度为N^2.
    /// </summary>
    void InsertSort1()
    {
        print("InsertSort1");
        int[] array = { 49, 38, 65, 97, 76, 13, 27, 49 };

        for (int i = 1; i < array.Length; i++)
        {
            int k=i;
            //找插入点
            for (int j = i-1 ;j>=0&&array[i] < array[j] ; j--)
            {
                k = j;//记录插入点
            }
            
             int temp = array[i];

             for (int j = i-1 ; j >=k; j--)//全部往后后再插入
             {
                    array[j + 1] = array[j];//往后移动一位
             }

             array[k] = temp; //插入

        }
        Show(array);
    }

    /// <summary>
    /// 折半插入排序。直接插入排序的基础上用二分法找插入位置。时间复杂度是n^2
    /// </summary>
    void BinInsertSort()
    {

    }

    /// <summary>
    /// 谢尔排序。假设原序列已经基本有序。最后一次做插入排序时就可以节省大量时间。
    /// 平均的时间复杂度为n^1.3
    /// 算法步骤：
    /// 1.自己设置一个递减序列d。递减序列怎么选，至今为解决
    /// 2.然后逐步选取若干两个元素相距为di的子记录集合进行插入排序，
    /// 3.直到di=1时做完最后一次插入排序。
    /// </summary>
    void ShellSort()
    {
        //案例是以a[1]开始的
        int[] a = {0, 19, 41, 11, 17, 47, 43, 13, 37, 31, 23 };
        int[] d = { 5, 2, 1 };  //递减序列

        int i=0, j, k,temp;
        
        for(k = 0; k < d.Length; k++)
        {
            int h = d[k];
            for (i = h+1 ; i < a.Length; i++)
            {
                temp = a[i];
                j = i - h;//初始位置
                //插入排序
                while (j > 0&&temp < a[j]  )
                {
                    a[j + h] = a[j];//往后移
                    j = j - h;
                }
                a[j + h] = temp;//插入记录
            }
        }
        Show(a);
    }
    /// <summary>
    /// 显示排序的序列
    /// </summary>
    void Show(int[] array)
    {
        foreach (var i in array) { print(i); }
    }
}
