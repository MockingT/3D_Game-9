# 3D_Game-9  
## UI效果制作实现Quest Log公告牌  
### 实现效果  
- 点击三种颜色按钮，内容会折叠或者显示出来，右边是滚动条  
![avatar](https://github.com/MockingT/3D_Game-9/blob/master/pictures/show.png)  
### 实现步骤  
- 首先创建一个canvas，然后在content中每个button下都添加一个text，作为button对应的内容。分别为canvas添加一个背景图（这里我直接将图片从assets里拉入canvas中），紧接着为canvas的scroll view也添加一张背景图作为公告牌的背景图。文件结构大致如下：  
![avatar](https://github.com/MockingT/3D_Game-9/blob/master/pictures/structure.png)  
- 要注意的一点是将自己选好的图片拉入到assets中之后作为背景图，需要在图片的Inspector中将其的Texture Type改成Sprite（2D and UI）。  
![avatar](https://github.com/MockingT/3D_Game-9/blob/master/pictures/pic.png)  
- 之后在Scroll View的Viewport中的Content中调整好button和对应的text的位置（为了后面使用代码将text部分旋转折叠隐藏做准备），而Scrollbar Horizontal和Vertical则是纵向横向滚动轮，可以对他们进行调整。大功告成之后，效果就如上面的展示图所示。  
### 代码部分  
- 为了实现点击按钮时，对应的text会折叠起来，我写好一个脚本，然后挂在到每一个button上。脚本里对当前的button添加了一个点击监听函数。其中is_collapsed（bool）的作用是判断当前是折叠还是展开的状态。  

      // Use this for initialization
      void Start () {
          Button button = this.gameObject.GetComponent<Button>();
          // add the listener to the button
          button.onClick.AddListener(Click_button);
      }
      void Click_button()
      {
        //judge the state 
        if (is_collapsed == false)
        {
            StartCoroutine(rotateIn());
        }
        else
        {
            StartCoroutine(rotateOut());
        }
      }  
     
- 然后为展开/折叠添加了旋转的动画，为了有渐变效果，于是一帧帧地变化。当折叠变化到最后时，用一个string类型保存当前文本内容，并将当前text的内容变为无，当展开变化到最后就令其内容变为上一次保存的文本内容。  

      IEnumerator rotateIn()
      {
          float rx = 0;
          float xy = 120;
          for (int i = 0; i < frame; i++)
          {
              rx -= 90f / frame;
              xy -= 120f / frame;
              text.transform.rotation = Quaternion.Euler(rx, 0, 0);
              text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xy);
              if (i == frame - 1)
              {
                  //save the text and delete the original text so it can go up
                  _text = text.text;
                  text.text = "";
                  is_collapsed = true;
              }
              yield return null;
          }
      }

      IEnumerator rotateOut()
      {
          float rx = -90;
          float xy = 0;
          for (int i = 0; i < frame; i++)
          {
              rx += 90f / frame;
              xy += 120f / frame;
              text.transform.rotation = Quaternion.Euler(rx, 0, 0);
              text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xy);
              if (i == 0)
              {
                  //return to the orginal state
                  text.text = _text;
                  is_collapsed = false;
              }
              yield return null;
          }
      }  
      
- 脚本写完，一个个挂载到button上，将脚本里的Text选定为对应的文本名字即可。
