# 3D_Game-9  
## UI效果制作实现Quest Log公告牌  
### 实现效果  
- 点击三种颜色按钮，内容会折叠或者显示出来，右边是滚动条  
![avatar](https://github.com/MockingT/3D_Game-9/blob/master/pictures/show.png)  
### 实现步骤  
- 首先创建一个canvas，然后在content中每个button下都添加一个text，作为button对应的内容。分别为canvas添加一个背景图（这里我直接将图片从assets里拉入canvas中），紧接着为canvas的scroll view也添加一张背景图作为公告牌的背景图。文件结构大致如下：  
![avatar](https://github.com/MockingT/3D_Game-9/blob/master/pictures/structure.png)
