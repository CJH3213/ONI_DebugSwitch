# ONI_DebugSwitch
手动增删debug_enable.txt文件太麻烦？忘记关闭开发模式导致成就冻结？缺氧游戏Debug模式一键开关小工具解决你的烦恼！<br />
<br />

![image](https://github.com/CJH3213/Images-blog/blob/main/%E7%BC%BA%E6%B0%A7%E6%B8%B8%E6%88%8Fdebug%E5%BC%80%E5%85%B3_%E5%9B%BE%E7%89%87/%E8%BD%AF%E4%BB%B6%E7%A4%BA%E4%BE%8B.png?raw=true)
<center>
    <div style="color:#999; 
    border-bottom: 1px solid #d9d9d9;
    display: inline-block;
    ">软件展示</div>
</center>

<br />

***

<br />

## 软件压缩包下载路径：
<https://github.com/CJH3213/ONI_DebugSwitch/releases><br />
<br />

***

<br />

## 实现原理：
① 通过注册表卸载目录自动找到缺氧安装路径；  
② 检测目标路径下是否有 debug_enable.txt 并以此判断Debug模式是否开启；  
③ 通过在目标路径下创建/删除 debug_enable.txt 实现开启/关闭Debug模式。<br />
<br />

***

<br />

## 使用方法：

**注意：使用本软件开启/关闭Debug模式后，再启动游戏**，  

*软件没有什么黑科技，只是替代手动创建/删除 debug_enable.txt 文件的步骤。*<br />
<br />
①打开软件后，软件会搜索缺氧游戏安装路径并显示在下拉列表<br />
<br />
②如果希望手动指定路径，点击右侧按钮即可浏览文件，
目录深度直到 OxygenNotIncluded_Data 文件夹，  

>*例如Steam安装的缺氧，该文件夹路径为：*
\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data<br />

<br />
③更改路径后会重新检查该路径下是否存在 debug_enable.txt 文件<br />
<br />
④点击左上按钮即可创建/删除 debug_enable.txt 文件<br />
<br />
⑤部分执行日志会在下方文本框显示<br />
<br />
⑥软件会记录本次选择的目标路径，下次打开软件后会加载上次选择的路径。


