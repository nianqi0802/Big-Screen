using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Tested : MonoBehaviour
{
    private float m_GameTime = 0f;
    private System.Collections.Generic.List<float> m_MusicTimes;        // 从配置表获得的每一个时间点
    private int m_MusicIndex = 0;       // 记录现在进行到几个时间点了

    private void Update()
    {
        // 这样时间就会以大概0.02秒的速度每帧叠加
        m_GameTime += Time.deltaTime;
        //达到时间点
        if (m_GameTime > m_MusicTimes[m_MusicIndex])
        {
            //创建prefab,设置速度
            m_MusicIndex++;
            if (m_MusicIndex == m_MusicTimes.Count)
            {
                // 游戏结束
            }
        }
    }
}