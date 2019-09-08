using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jiaohuanSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //BubbleSort();
        int[] r = { 0, 49, 38, 65, 97, 76, 13, 27, 49 };

        QuickSort(ref r,1,r.Length-1);
        print(Time.time);
        Show(r);
    }

    //冒泡排序。无序区从前往后依次将相邻记录的关键吗比较，若反序则交换
    //是稳定的排序。稳定的排序，时间复杂为n^2

    //不高效的冒泡排序。没有记录上限。后面已经交换过的还要比较
    //不高效的冒泡排序。没交换记录，无上限。要跑完两个循环，以为每次只能冒泡一个
    /// <summary>
    /// 高效的冒泡排序。用exchange记录有反序的位置，为下一趟节约比较次数
    /// 如果都有序则exchange为0
    /// </summary>
    void BubbleSort()
    {
        int[] r = {0,49,38,65,97,76,13,27,49 };
        int exchange = r.Length-1;

        while(exchange>0)
        {
            int bound = exchange;//有序区边界
            exchange = 0;

            for(int j = 0; j < bound; j++)
            {
                if (r[j] > r[j + 1])
                {
                    //int temp = r[j]; r[j] = r[j + 1]; r[j + 1] = temp;
                    Swap(ref r[j],ref r[j+1]);
                    exchange = j;
                }
            }
        }

        Show(r);
    }

    //快速排序.任选一个记录为基准，大于它的全部放前面，小于它的全部放后面，完成一趟排序
    //移动距离大，所以名副其实，这种排序确实快速，
    //平均时间复杂度降为nlog2n。最坏时间复杂度为n^2。空间复杂度为logn
    //每一趟排序前后同时开工，进行交换。不稳定的排序
    void QuickSort(ref int[] r, int first,int end)
    {
        
        if (first < end)
        {
            int x = r[first];  //枢轴记录
            int i = first; int j = end; //从这两边开始找

            while (i < j)
            {
                while (i < j && r[j] >= x) { j--; } //找<x的r[j]
                if (i < j) r[i] = r[j];
                while (i < j && r[i] <= x) { i++; }
                if (i < j) r[j] = r[i];
            }
            r[i] = x;

            //int pivot = Partition(ref r,first,end);
            QuickSort(ref r,first,i-1); //折半进行排序
            QuickSort(ref r,i+1, end); //折半进行排序
        }


    }

    //快速排序的划分函数
    int Partition(ref int[] r,int s,int t)
    {
        int x = r[s];  //枢轴记录
        int i = s; int j = t; //从这两边开始找

        while (i < j)
        {
            while (i<j&&r[j] <x) { j--; } //找<x的r[j]
            if (i < j) r[i] = r[j];
            while(i<j&& r[i] > x) { i++; }
            if (i < j) r[j] = r[i];
        }
        r[i] = x;
        return i;
    }

    /// <summary>
    /// 快速排序的非递归形式
    /// </summary>
    /// <param name="r"></param>
    /// <param name="first"></param>
    /// <param name="end"></param>
    void QuickSort2(ref int[] r, int first, int end) { }

    /// <summary>
    /// 交换两个整数
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    void Swap(ref int a,ref int b)
    {
        int temp = a; a = b; b = temp;
    }

    /// <summary>
    /// 显示排序的序列
    /// </summary>
    void Show(int[] array)
    {
        foreach (var i in array) { print(i); }
    }

   
}
