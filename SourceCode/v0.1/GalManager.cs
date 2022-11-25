using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GalManager : MonoBehaviour
{

    //CG����ϵͳ
    public GameObject CGPlayer;
    //������Ƶϵͳ
    public AudioSource DialogueAudio;
    //BGM������
    public AudioSource BGM;
    //����
    public Image Background;
    //��ɫ1ͼƬ
    public Image ActorImage1;
    //��ɫ��ͼƬ
    //public Image ActorImage2;
    //�Ի���ɫ�����ı�
    public Text ActorName;
    //�Ի��ı�
    public Text ContentText;
    //�����Ի�����
    public List<Message> messages;
    //��ǰ�Ի�λ��
    public int index = 0;
    //��ɶԻ�����ת�ĳ���(Ĭ�ϻص�����ҳ)
    public int PageNumber = 1;



    // Start is called before the first frame update
    void Start()
    {
        

        //�����������
        messages = new List<Message>();
        //�����ﴴ���Ի�
        //�����Ի�
        //msg = new Message() { Name = "��ɫ����", Content = "�Ի�����", ImageName = "��ɫͼƬ���ƣ�/Resource/Actor�ļ����£�" Audio = "��Ƶ����" };
        //messages.Add(msg);
        //�л�����
        //msg = new Message() { type= MessageType.Background,Background = "��������"};
        //messages.Add(msg);
        //����BGM
        // msg = new Message() { type = MessageType.BGM, BGM = "��Ƶ����"};
        // messages.Add(msg);
        //������ת
        //msg = new Message() { type = MessageType.SceneLoad };
        //messages.Add(msg);
        
        //eg

        Message
            msg = new Message() { type = MessageType.Background, Background = "BG2" };
        messages.Add(msg);

        msg = new Message() { type = MessageType.BGM, BGM = "BGM1YS"};
        messages.Add(msg);
        msg = new Message() { Name = "1024", Content = "������Ե�һ�仰", ImageName = "BYJC" };
        messages.Add(msg);
        msg = new Message() { Name = "1024", Content = "������Ե�һ�仰", ImageName = "BYJC" };
        messages.Add(msg);
        msg = new Message() { Name = "1024", Content = "������Ե�һ�仰", ImageName = "BYJC" };
        messages.Add(msg);
        msg = new Message() { type = MessageType.SceneLoad };
        messages.Add(msg);

    }

    Message GetMessage()
    {
        if (index < messages.Count)
        {
            //��������λ��
            return messages[index++];
        }
        //����Խ�磬����null
        return null;
    }

    void Update()
    {
        //������㴥��
        Input.multiTouchEnabled = true;

        //���������
        if (Input.GetMouseButtonDown(0))
        {
            //���жԻ�
            Message();
        }

    }
    
    void Message()
    {
        //��ȡһ��Ի�
        Message msg = GetMessage();
        //����Ի���Ϊnull����ǰ�жԻ�
        if (msg != null)
        {
            //����Ϊ��Ϣ
            if (msg.type == MessageType.Message)
            {
                
                //�ڶԻ�ǰ��ͣ����CG
                CGPlayer.SetActive(false);
                //��ȡ��ɫͼƬ����
                ActorImage1.sprite = Resources.Load<Sprite>("Actor/" + msg.ImageName);
                //ActorImage2.sprite = Resources.Load<Sprite>("Actor/" + msg.ImageName);

                //��ʾ��ɫ����
                ActorName.text = msg.Name;
                //��ʾ�Ի�����
                ContentText.text = msg.Content;
                //���ŶԻ�
                //����ͣ��һ���Ի�
                DialogueAudio.Stop();
                DialogueAudio.PlayOneShot(Resources.Load<AudioClip>("Audio/ActorAudio/" + msg.Audio));

            }

            //����Ϊ�л�����
            if (msg.type == MessageType.Background)
            {
                //��ȡ����ͼƬ
                Background.sprite = Resources.Load<Sprite>("Background/" + msg.Background);
                //�Զ���һ��
                Message();

            }
            //BGM������
            if (msg.type == MessageType.BGM)
            {
                BGM.PlayOneShot(Resources.Load<AudioClip>("Audio/BGM/" + msg.BGM));
                //�Զ���һ��
                Message();
            }

            //Debug�����Ϣ
            if (msg.type == MessageType.Debug)
            {
                Debug.Log("������Ϸ");
            }
            //������ת��
            if (msg.type == MessageType.SceneLoad)
            {
                //��ת����
                SceneManager.LoadScene(PageNumber);

            }
            

        }
    }

}
