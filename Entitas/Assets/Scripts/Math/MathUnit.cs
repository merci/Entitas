using System;
using UnityEngine;

public class MathUnit
{
    //比较委托
    public delegate int DelCompare<T>(T t1, T t2);

    /// <summary>
    /// 直接插入算法 稳定排序
    /// InsetSort<int>(arr, (int t1, int t2) =>{return t1 - t2;});
    /// </summary>
    public static void InsetSort<T>(T[] arr, DelCompare<T> del)
    {
        //首先从第二个元素开始遍历
        for (int i = 1; i < arr.Length; i++)
        {
            int j = i - 1;
            T temp = arr[i];
            //因为当前数的左边都已是排序好的数列，因此无需当前数与左边数列每个都进行比较，只要某个数比当前数小，则剩下未比较的数也一定比当前数小
            while (j >= 0 && del(arr[j], temp) > 0)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = temp;
        }
    }

    /// <summary>
    /// 简单选择排序  不稳定排序
    /// SelectSort<int>(arr, (int t1, int t2) =>{return t1 - t2;});
    /// </summary>
    public static void SelectSort<T>(T[] arr,DelCompare<T> del)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            //记录最小值索引
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if(del(arr[minIndex], arr[j]) > 0)
                {
                    minIndex = j;
                }
            }
            if(minIndex != i)
            {
                T temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
        }
    }





    /// <summary>
    /// 冒泡排序
    /// BubbleSort<int>(arr, (int t1, int t2) =>{return t1 - t2;});
    /// </summary>
    public static void BubbleSort<T>(T[] arr, DelCompare<T> del)
    {
        for (int i = 0; i < arr.Length -1; i++)
        {
            for (int j = 0; j < arr.Length - 1-i; j++)
            {
                if(del(arr[j], arr[j+ 1])> 0)
                {
                    T temp = arr[j+1];
                    arr[j + 1] = arr[j];
                    arr[j] = temp;
                }
            }
        }
    }


    /// <summary>
    /// 快排排序
    /// QuickSort<int>(arr, 0, arr.Length-1, (int t1, int t2) => {return t1 - t2;});
    /// </summary>
    public static void QuickSort<T>(T[] arr,int left,int right, DelCompare<T> del)
    {
        if(left < right)
        {
            int i = Division(arr, left, right, del);
            //对枢轴的左边部分进行排序
            QuickSort<T>(arr, i + 1, right, del);
            //对枢轴的右边部分进行排序
            QuickSort<T>(arr, left, i - 1, del);
        }

      
    }

    private static int Division<T>(T[] arr, int left, int right, DelCompare<T> del)
    {
        while (left < right)
        {
            T num = arr[left]; //将首元素作为枢轴
            if (del(num, arr[left + 1])  > 0 )
            {
                arr[left] = arr[left + 1];
                arr[left + 1] = num;
                left++;
            }
            else
            {
                T temp = arr[right];
                arr[right] = arr[left + 1];
                arr[left + 1] = temp;
                right--;
            }
        }

        return left; //指向的此时枢轴的位置
    }

} 
