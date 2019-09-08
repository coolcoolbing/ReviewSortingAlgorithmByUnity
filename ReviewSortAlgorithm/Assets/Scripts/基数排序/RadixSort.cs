using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadixSort : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	//基数排序是多关键字排序和分配排序的推广和特化

	//多关键字排序。就是数据有多个关键字。
    //MSD最高位优先排序。从最大关键字开始分堆。
    //LSD最低位。。。。与上相反

    //基数排序：先按关键字扫描进行分配到桶中，然后进行收集（将桶连接成新的序列），直到比较完所有关键字
    //1.分配
    //2.收集

    //基数排序是稳定的
    //时间复杂度为（d（n+r）），空间复杂度为o（n）

}
