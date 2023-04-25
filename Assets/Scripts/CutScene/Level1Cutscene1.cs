using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Level1Cutscene1 : MonoBehaviour
    {
        public float titleWaitTime;
        public float titleShowTime;
        public float guassianBlurTime;
        public float soundFXWaitTime;

        public UnityEvent OnGaussianEnd;

        public IEnumerator CutsceneWalkThrough()
        {
            Debug.Log("�ݳ���ʼ����Ļ��ȫ�ڽ�������˹ģ����ʼ��Invalid��ɫ������");
            yield return new WaitForSeconds(titleWaitTime);
            Debug.Log("��Ϸ������֣�");
            yield return new WaitForSeconds(titleShowTime);
            Debug.Log("��Ϸ������ʧ����˹ģ���������ҵƹ�Զȥ");
            yield return new WaitForSeconds(guassianBlurTime);
            Debug.Log("��˹ģ������!������ɫ�����������ų���");
            OnGaussianEnd.Invoke();
            yield return new WaitForSeconds(soundFXWaitTime);
            Debug.Log("��־����Ч���֣�");

        }

        #region Life Cycle
        private void Start()
        {
            StartCoroutine(CutsceneWalkThrough());
        }
        #endregion
    }
}
