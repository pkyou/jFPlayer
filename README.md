# jFPlayer
## 1. 依赖
- .NET framework 4.5 安装visual studio时可以一并下载
## 2. 开发工具 
- visual studio 
- 下载并安装 https://visualstudio.microsoft.com/downloads/
## 3. 版本控制器
- git 
- 下载并安装 https://git-scm.com/download/win
## 4. 代码下载
### 4.1 生成ssh key
- 打开powershell
- 运行命令 `ssh-keygen -t rsa -C "your_email@example.com"` 邮箱换成自己的
### 4.1 添加 ssh key 公钥到 github
- powershell 中运行命令 `type ~/.ssh/id_rsa.pub` 可以查看生成的公钥，将公钥添加到github仓库（我来添加）
### 4.2 下载代码
- Powershell中cd到任意文件夹，该文件夹下将存放源代码
- 执行命令 `git clone git@github.com:pkyou/jFPlayer.git` 后，会新建名为`jFPlayer`的文件夹，文件夹内即为源代码
### 4.3 打开工程
打开visual studio
File-->open-->project/solution, 选到 4.2中`jFPlayer`文件夹里的`.sln`工程文件，就可打开项目

### 4.4 视频文件
当前版本视频文件存在方式为指定目录指定文件名 `jFPlayer\WpfApplication1\bin\Debug\video.mp4`
# 当前开发进度
- [x] 播放视频源
- [x] 双击全屏/退出全屏
- [x] 获取播放进度/从开始播放计时
- [x] 配置串口信息
- [x] 发送串口指令
- [x] 指定时间发送指定串口命令
# 阶段2
- [ ] 拉伸分辨率
- [ ] 退出 有问题
- [ ] 软件背景
- [ ] 按钮样式
- [ ] 播放全屏
# 待确定
- [ ] 视频源分辨率
