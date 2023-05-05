# ONI_DebugSwitch
手动增删debug_enable.txt文件太麻烦？忘记关闭开发模式导致成就冻结？缺氧游戏Debug模式一键开关小工具解决你的烦恼！


软件压缩包下载路径：
https://github.com/CJH3213/ONI_DebugSwitch/releases


实现原理：
① 通过注册表卸载目录自动找到缺氧安装路径；
② 检测目标路径下是否有 debug_enable.txt 并以此判断Debug模式是否开启；
③ 通过在目标路径下创建/删除 debug_enable.txt 文件实现开启/关闭Debug模式。


使用方法：

打开软件后，软件会搜索缺氧游戏安装路径并显示在下拉列表，

如果希望手动指定路径，点击右侧按钮即可浏览文件，
目录深度直到 OxygenNotIncluded_Data 文件夹，
例如Steam安装的缺氧，该文件夹路径为：
..\SteamLibrary\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data

更改路径后会重新检查该路径下是否存在 debug_enable.txt 文件

点击左上按钮即可创建/删除 debug_enable.txt 文件

部分执行日志会在下方文本框显示。
