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
