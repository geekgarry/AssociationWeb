/*
Navicat SQL Server Data Transfer

Source Server         : college
Source Server Version : 140000
Source Host           : localhost:1433
Source Database       : studentassociation
Source Schema         : association

Target Server Type    : SQL Server
Target Server Version : 140000
File Encoding         : 65001

Date: 2019-01-25 00:01:58
*/


-- ----------------------------
-- Table structure for [association].[activitycomment]
-- ----------------------------
DROP TABLE [association].[activitycomment]
GO
CREATE TABLE [association].[activitycomment] (
[id] varchar(44) NOT NULL ,
[stuid] varchar(44) NULL ,
[activitycomment] varchar(200) NULL ,
[associationactivityid] varchar(44) NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of activitycomment
-- ----------------------------
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'1', N'2019012345', N'好看！给你个赞！', N'1', N'2019-01-02 20:15:01.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'2', N'2019012345', N'rexhdrhbsdgb', N'20190102203838656', N'2019-01-18 00:14:12.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901180043154315487', N'2019012345', N'的v工作', N'1', N'2019-01-18 00:43:15.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901180043474347698', N'2019012345', N'是v噶士大夫部队不对发现不少东西不信不信', N'1', N'2019-01-18 00:43:47.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901180052315231269', N'2019012345', N'文革是个保守的高标准v', N'20190102203838656', N'2019-01-18 00:52:31.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901180123552355534', N'2019012345', N'恶搞吧VGa预测以后v局部可见不可见', N'1', N'2019-01-18 01:23:55.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901180148424842704', N'2019012345', N'而蛊惑人心的', N'20190102203838656', N'2019-01-18 01:48:42.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901180151225122285', N'2019011234', N'第三附属公司', N'20190102203838656', N'2019-01-18 01:51:22.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901180153385338607', N'2019011234', N'顺丰速递发生过啥', N'20190102203838656', N'2019-01-18 01:53:38.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'20190118015705575787', N'2019011234', N'二公子速递公司大概白色的', N'20190102203838656', N'2019-01-18 01:57:05.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901180159515951690', N'2019012345', N'恶搞vs大概vs v', N'1546261286', N'2019-01-18 01:59:51.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'20190118020034034545', N'2019012345', N'额公司的个别地方很费工夫加盟和v没不v', N'1546261286', N'2019-01-18 02:00:34.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'20190118020055055264', N'2019012345', N'热额好吧都符合你发到你现场', N'1546251899', N'2019-01-18 02:00:55.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'2019011802010515893', N'2019012345', N'地方还不得发布现场表现机会，', N'1546251899', N'2019-01-18 02:01:05.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'20190118193806386912', N'2019012345', N'的是不是真的废话必须', N'20190102203838656', N'2019-01-18 19:38:06.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'20190118193904394692', N'2019012345', N'下飞奔iu规格不i公布i不i必备', N'20190102203838656', N'2019-01-18 19:39:04.000');
GO
INSERT INTO [association].[activitycomment] ([id], [stuid], [activitycomment], [associationactivityid], [create_time]) VALUES (N'201901232249284928611', N'2019011234', N'古币u比哦不uvui哔哔哔，u与ui不i', N'1546251899', N'2019-01-23 22:49:28.000');
GO

-- ----------------------------
-- Table structure for [association].[administrator]
-- ----------------------------
DROP TABLE [association].[administrator]
GO
CREATE TABLE [association].[administrator] (
[id] int NOT NULL IDENTITY(1,1) NOT FOR REPLICATION ,
[username] varchar(44) NULL ,
[password] varchar(44) NULL ,
[create_time] datetime NULL 
)


GO
ALTER TABLE [association].[administrator] ENABLE CHANGE_TRACKING
WITH (TRACK_COLUMNS_UPDATED = ON)
GO
DBCC CHECKIDENT(N'[association].[administrator]', RESEED, 4)
GO

-- ----------------------------
-- Records of administrator
-- ----------------------------
SET IDENTITY_INSERT [association].[administrator] ON
GO
INSERT INTO [association].[administrator] ([id], [username], [password], [create_time]) VALUES (N'1', N'admin', N'123456', N'2018-12-28 09:55:17.000');
GO
INSERT INTO [association].[administrator] ([id], [username], [password], [create_time]) VALUES (N'2', N'geekcc', N'123456', N'2018-12-28 09:55:44.000');
GO
INSERT INTO [association].[administrator] ([id], [username], [password], [create_time]) VALUES (N'3', N'abc', N'123456', N'2019-01-05 20:29:00.000');
GO
INSERT INTO [association].[administrator] ([id], [username], [password], [create_time]) VALUES (N'4', N'xieyiyi', N'123456', N'2019-01-23 19:13:55.000');
GO
SET IDENTITY_INSERT [association].[administrator] OFF
GO

-- ----------------------------
-- Table structure for [association].[applyjoin]
-- ----------------------------
DROP TABLE [association].[applyjoin]
GO
CREATE TABLE [association].[applyjoin] (
[id] varchar(44) NOT NULL ,
[stuid] varchar(44) NULL ,
[associationid] varchar(44) NULL ,
[hobbyspeciality] varchar(200) NULL ,
[applyreason] varchar(222) NULL ,
[personalintro] varchar(222) NULL ,
[auditstatus] int NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of applyjoin
-- ----------------------------
INSERT INTO [association].[applyjoin] ([id], [stuid], [associationid], [hobbyspeciality], [applyreason], [personalintro], [auditstatus], [create_time]) VALUES (N'1', N'2019012345', N'22', N'erbesb而失败的人心态好难听瑞达恒瑞达恒', N'的人体会不到人头还不打扰她会不同瑞达恒', N'的人体会不到任何不同的人合同的任何人都', N'1', N'2019-01-02 20:43:10.000');
GO
INSERT INTO [association].[applyjoin] ([id], [stuid], [associationid], [hobbyspeciality], [applyreason], [personalintro], [auditstatus], [create_time]) VALUES (N'20190115200721581', N'2019012345', N'24', N'我仙子是滴哦v你哦你', N'收到贵司大概u返还三方v看胜率那看来', N'跟不上的vu故事vios多久哦怕v就ops紧哦碰复苏感觉哦死', N'0', N'2019-01-15 20:07:21.000');
GO
INSERT INTO [association].[applyjoin] ([id], [stuid], [associationid], [hobbyspeciality], [applyreason], [personalintro], [auditstatus], [create_time]) VALUES (N'20190118195102752', N'2019012345', N'23', N'散热会给别惹公布的手法不行的不', N'的想法办公室的效果不v蓄电池v不惜成本', N'东西不v相当不寻常不错不错v不错想办法', N'0', N'2019-01-18 19:51:02.000');
GO
INSERT INTO [association].[applyjoin] ([id], [stuid], [associationid], [hobbyspeciality], [applyreason], [personalintro], [auditstatus], [create_time]) VALUES (N'20190123005615119', N'2019123456', N'22', N'塞格瑞v好几位不v放假不我看了个v女色，欸还给你哦阿雯不敢', N'饿死人基本覆盖i文化i发货i哦热风，欸我不管vi哦啊部位', N'额虽然贵几百位妇女和i哦请问发给i哦，ui我广佛i全归我我的恶果i哦而我，额u日光和i哦呃鸿儒不过', N'1', N'2019-01-23 00:56:15.000');
GO

-- ----------------------------
-- Table structure for [association].[apprise]
-- ----------------------------
DROP TABLE [association].[apprise]
GO
CREATE TABLE [association].[apprise] (
[id] varchar(44) NOT NULL ,
[stuid] varchar(44) NULL ,
[apprisecontent] varchar(150) NULL ,
[suggestcontent] varchar(200) NULL ,
[associationid] varchar(44) NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of apprise
-- ----------------------------
INSERT INTO [association].[apprise] ([id], [stuid], [apprisecontent], [suggestcontent], [associationid], [create_time]) VALUES (N'20190109210817840', N'2019012345', N'希望可以让更多的人参与到项目中', N'我们希望可以尽快完成这个项目', N'22', N'2019-01-09 21:08:17.000');
GO
INSERT INTO [association].[apprise] ([id], [stuid], [apprisecontent], [suggestcontent], [associationid], [create_time]) VALUES (N'20190118012726706', N'2019012345', N'阿三做任何事故哇范围饿死鬼', N'如果不舍得不舍得', N'23', N'2019-01-18 01:27:26.000');
GO
INSERT INTO [association].[apprise] ([id], [stuid], [apprisecontent], [suggestcontent], [associationid], [create_time]) VALUES (N'20190124174513849', N'2019012345', N'而后被然后百度日本和设备', N'的风格不发生变化突然大喊女人他对你回复东方宾馆东方', N'22', N'2019-01-24 17:45:13.000');
GO
INSERT INTO [association].[apprise] ([id], [stuid], [apprisecontent], [suggestcontent], [associationid], [create_time]) VALUES (N'234', N'2019012345', N'突然很荣幸和别人发的表格大小不', N'风格和你不吃饭会帮您发出', N'22', N'2019-01-01 14:15:29.000');
GO

-- ----------------------------
-- Table structure for [association].[associationactivity]
-- ----------------------------
DROP TABLE [association].[associationactivity]
GO
CREATE TABLE [association].[associationactivity] (
[id] varchar(44) NOT NULL ,
[personalincharge] varchar(44) NULL ,
[activitytitle] varchar(44) NULL ,
[activitycontent] varchar(225) NULL ,
[associationid] varchar(44) NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of associationactivity
-- ----------------------------
INSERT INTO [association].[associationactivity] ([id], [personalincharge], [activitytitle], [activitycontent], [associationid], [create_time]) VALUES (N'1', N'张启灵', N'盗墓', N'盗墓笔记非常好看，云南虫谷好看！', N'22', N'2018-12-31 16:47:16.000');
GO
INSERT INTO [association].[associationactivity] ([id], [personalincharge], [activitytitle], [activitycontent], [associationid], [create_time]) VALUES (N'1546251899', N'是擦v都是', N'色如黑白色染红热水', N'日正式报告虽然她会变色后表示如果不', N'22', N'2019-01-22 22:23:30.000');
GO
INSERT INTO [association].[associationactivity] ([id], [personalincharge], [activitytitle], [activitycontent], [associationid], [create_time]) VALUES (N'1546261286', N'笔记本', N'哭缘故不i不必', N'就一同参与vu据几百块就能避开你可不能结婚很纠结', N'22', N'2018-12-31 21:01:25.000');
GO
INSERT INTO [association].[associationactivity] ([id], [personalincharge], [activitytitle], [activitycontent], [associationid], [create_time]) VALUES (N'20190102203838656', N'单干户', N'开安全主题班会', N'注意安全，放假要注意人身安全！', N'22', N'2019-01-02 20:38:38.000');
GO
INSERT INTO [association].[associationactivity] ([id], [personalincharge], [activitytitle], [activitycontent], [associationid], [create_time]) VALUES (N'367e857fe0e84ec3b734a583d3c8075c', N'豆腐干', N'都是vs知道v广东深圳', N'的风格v的v不丢包v基本素质，iu高帅富i赛覅俗话，i是的版本', N'22', N'2019-01-21 21:49:29.000');
GO

-- ----------------------------
-- Table structure for [association].[associationinfo]
-- ----------------------------
DROP TABLE [association].[associationinfo]
GO
CREATE TABLE [association].[associationinfo] (
[id] int NOT NULL IDENTITY(25,1) NOT FOR REPLICATION ,
[username] varchar(44) NULL ,
[password] varchar(44) NULL ,
[associationname] varchar(44) NULL ,
[associationintro] varchar(260) NULL ,
[teacherincharge] varchar(44) NULL ,
[stuincharge] varchar(44) NULL ,
[create_time] datetime NULL 
)


GO
DBCC CHECKIDENT(N'[association].[associationinfo]', RESEED, 41)
GO

-- ----------------------------
-- Records of associationinfo
-- ----------------------------
SET IDENTITY_INSERT [association].[associationinfo] ON
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'22', N'geek', N'123456', N'GEEK社', N'					低俗化给sign vs焦虑恐惧的被饭局看百度空间v健康幸福的vkd
				', N'制表人', N'反病毒', N'2018-12-28 15:52:37.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'23', N'hls', N'123456', N'滑轮社', N'土地然后你的人拿人头的好男人他电话不通', N'田归农', N'法国', N'2018-12-28 15:53:26.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'24', N'abc', N'123456', N'动漫社', N'人都会变seth虽然', N'软通货', N'带头人', N'2018-12-29 16:27:00.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'25', N'ymq', N'123456', N'羽毛球社', N'幅度不大方便', N'东方人', N'地方', N'2019-01-19 20:34:23.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'26', N'lqlq', N'123456', N'篮球社', N'的三个代表大型', N'范甘迪', N'闪光灯', N'2019-01-19 20:37:26.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'27', N'tqd', N'123456', N'跆拳道社', N'地方会被放大信号不行的', N'速度', N'兄弟', N'2019-01-19 20:38:16.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'28', N'yys', N'123456', N'英语学习社', N'发给你的股份呢', N'大夫', N'成不成', N'2019-01-19 20:39:33.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'29', N'football', N'123456', N'足球社', N'突然大叫大喊能否改成内核部分从概念车', N'苟富贵', N'法国红酒', N'2019-01-19 20:40:05.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'30', N'dance', N'12345', N'舞蹈社', N'的方法不对相比大幅波动嘘嘘', N'风格化', N'度但是', N'2019-01-19 20:42:00.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'31', N'singer', N'123456', N'合唱团', N'风格和化肥合同和共和国', N'从下班', N'大幅度', N'2019-01-19 20:43:29.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'32', N'stuass', N'123456', N'学生会', N'似懂非懂v方式vs速递公司', N'徐州发', N'豆腐干', N'2019-01-19 20:45:29.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'33', N'media', N'123456', N'新媒体中心', N'绝壁逼比淋巴结结婚，v看老板看见包括', N'大饭店', N'宣传', N'2019-01-19 20:46:37.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'34', N'corpass', N'123456', N'社团联合会', N'梵蒂冈的符号标点符号股东分红', N'非官方', N'法国官方', N'2019-01-19 20:47:53.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'35', N'youngster', N'123456', N'青年志愿者联合会', N'的符号标点符号比你幸福的好吧能否成功', N'兄弟v在', N'阿斯顿', N'2019-01-19 20:49:07.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'36', N'artist', N'123456', N'大学生艺术团', N'都是v发生过v发短信北方那帮发v从', N'从不错', N'相持不下', N'2019-01-19 20:50:57.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'37', N'taiqiu', N'123456', N'台球社', N'地方vs是vv发射点发生', N'第三代', N'法国发过', N'2019-01-19 20:56:03.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'38', N'body', N'123456', N'健身协会', N'大部分v新发布的风格不符v从', N'地方v从', N'从vv', N'2019-01-19 20:54:19.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'39', N'film', N'123456', N'电影协会', N'啊是否v的思想改变的想法不错地方', N'下次v', N'下次v', N'2019-01-19 20:55:24.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'40', N'shuhua', N'123456', N'书画社', N'发的是下个补丁发布的分析', N'出生地', N'地方士大夫', N'2019-01-19 20:57:36.000');
GO
INSERT INTO [association].[associationinfo] ([id], [username], [password], [associationname], [associationintro], [teacherincharge], [stuincharge], [create_time]) VALUES (N'41', N'drama', N'123456', N'话剧社', N'个电话呢股份南海从法国', N'日本色', N'阿强万', N'2019-01-20 21:54:39.000');
GO
SET IDENTITY_INSERT [association].[associationinfo] OFF
GO

-- ----------------------------
-- Table structure for [association].[associationnotice]
-- ----------------------------
DROP TABLE [association].[associationnotice]
GO
CREATE TABLE [association].[associationnotice] (
[id] varchar(44) NOT NULL ,
[noticetitle] varchar(44) NULL ,
[noticecontent] varchar(300) NULL ,
[associationid] varchar(44) NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of associationnotice
-- ----------------------------
INSERT INTO [association].[associationnotice] ([id], [noticetitle], [noticecontent], [associationid], [create_time]) VALUES (N'201901022039403940158', N'今天有个班会', N'关于放假的，还有优秀毕业生的选举！', N'22', N'2019-01-02 20:39:40.000');
GO
INSERT INTO [association].[associationnotice] ([id], [noticetitle], [noticecontent], [associationid], [create_time]) VALUES (N'20190122231937077', N'的人特别感人的华人对他', N'的如果vs个人的体会别人的谈话不', N'22', N'2019-01-22 23:19:37.000');
GO
INSERT INTO [association].[associationnotice] ([id], [noticetitle], [noticecontent], [associationid], [create_time]) VALUES (N'20190122231949529', N'推广和如果让他大概很多人', N'额分认识我greg热点个人头的合同然后你突然，而攻防兼备fbi文风', N'22', N'2019-01-22 23:19:49.000');
GO
INSERT INTO [association].[associationnotice] ([id], [noticetitle], [noticecontent], [associationid], [create_time]) VALUES (N'20190122232004198', N'如风光背后吧覅文化i哦分5454', N'二哥如果v可悲包容是否v紧哦碰v都是的，usb滴哦草你死得好v此时佛i是你的vgosh哪里看，i哦好vi是覅噢色u黑色ui', N'22', N'2019-01-22 23:20:04.000');
GO
INSERT INTO [association].[associationnotice] ([id], [noticetitle], [noticecontent], [associationid], [create_time]) VALUES (N'20190122232045467', N'欸u日法规文化i工会为佛吉高睿额', N'v佛山东莞vv而非被哦是女i哦是哦的，iu梵蒂冈覅哦啊好i哦亲我的hop分恶恶个，人体的表格是如果别人色', N'22', N'2019-01-22 23:20:45.000');
GO
INSERT INTO [association].[associationnotice] ([id], [noticetitle], [noticecontent], [associationid], [create_time]) VALUES (N'23', N'如果我是刚刚发现不会', N'散热的好像被虚弱复活不断循环播放的韩国和你还敢地方新版电信版电信版东方早报vs都是带着v发的', N'22', N'2019-01-01 13:00:48.000');
GO
INSERT INTO [association].[associationnotice] ([id], [noticetitle], [noticecontent], [associationid], [create_time]) VALUES (N'cf44883541d74b0f8da6bdbc4014a71b', N'的发布会的发现个东西', N'大概vs大概vs的官方的不v发短信上班，的风格iv不是对v不服地说这个v备份空间，地方bois你睇波过v', N'22', N'2019-01-21 21:50:25.000');
GO

-- ----------------------------
-- Table structure for [association].[campusnew]
-- ----------------------------
DROP TABLE [association].[campusnew]
GO
CREATE TABLE [association].[campusnew] (
[id] varchar(44) NOT NULL ,
[newtitle] varchar(44) NULL ,
[newcontent] varchar(488) NULL ,
[editorid] varchar(44) NULL ,
[editorname] varchar(68) NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of campusnew
-- ----------------------------
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'09ec1764aea841788685b238afbe2020', N'鹅肉i个ios的波动', N'大概vs的v科技时代v看辛苦拒不接受考虑你开心的女婿的发表开心呢下次那边，才能，不你放心开机不能看', N'1', N'admin', N'2019-01-19 16:21:08.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'0c2e32a42884401e9458299f90169ea7', N'地租比如果你的关系', N'这地方v例子吧vi裤子女考虑考虑吧v不是在昆明流口水道可道方面，复兴门的麻烦的', N'22', N'GEEK社', N'2019-01-09 10:06:21.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'1669dd9af13f480dbaa225c3ffa6bf1f', N'的分红并非东西必须的小说', N'辅导班v得想办法v不v不防水隔热率热水管发布反动必须的', N'22', N'GEEK社', N'2019-01-21 16:37:12.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'2', N'元旦快乐', N'祝大家元旦快乐！谢谢大家！', N'22', N'GEEK社', N'2019-01-01 21:05:19.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'3e01661b099a49cba378f3f566602da4', N'贵热不是饿死鬼后i发的', N'i速度v和i哦欸哦v好呢死哦等会ios电话', N'1', N'admin', N'2019-01-19 18:55:49.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'4e455e33d4c74ec8b7a61842d6e12d3b', N'答复', N'的方式是第三方的公司的非官方的', N'1', N'admin', N'2019-01-19 18:56:05.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'661b5726302f48a98261b204abc9f3be', N'饿死人工费高点', N'山东分公司高浮雕鬼地方', N'1', N'admin', N'2019-01-19 18:55:41.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'6e1dc31f164d4ff892eb7cb78b6591ee', N'电风扇广东', N'地址发个电风扇广泛但是效果', N'1', N'admin', N'2019-01-19 18:55:33.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'b7f59ee52526408a8298a587e40b84ba', N'诚实地发挥i手动阀速度', N'送进宫施耐德工控v黑的吧vs的肯定不v看，iu发v不到岁不i师傅呢哈哈是', N'1', N'admin', N'2019-01-19 18:56:18.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'c807172a4829484097ba70170420f7a7', N'如果不到个vs大概v的', N'饿上下功夫不放心的速度v下的不大方便发放到别的想法必须的表达方式知道，如果不i饿死u和', N'1', N'admin', N'2019-01-19 16:21:23.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'd1f16f8636e7449f916d0361c57724df', N'士大夫沙发上', N'速度v方式大部分东西不要看看美誉哦ip，大概不是打工v得瑟个vs的vs v企鹅', N'1', N'admin', N'2019-01-19 16:24:43.000');
GO
INSERT INTO [association].[campusnew] ([id], [newtitle], [newcontent], [editorid], [editorname], [create_time]) VALUES (N'eb74315814d541ac96d5cdae01a7e881', N'然后被很多不', N'的观点不想吃不想吃不错v不错v不错v补偿办法才能发v放心不下都放不下的发表下', N'1', N'admin', N'2019-01-19 16:27:58.000');
GO

-- ----------------------------
-- Table structure for [association].[friendshiplink]
-- ----------------------------
DROP TABLE [association].[friendshiplink]
GO
CREATE TABLE [association].[friendshiplink] (
[id] int NOT NULL IDENTITY(1,1) NOT FOR REPLICATION ,
[linkname] varchar(44) NULL ,
[linkurl] varchar(55) NULL 
)


GO
ALTER TABLE [association].[friendshiplink] ENABLE CHANGE_TRACKING
GO
DBCC CHECKIDENT(N'[association].[friendshiplink]', RESEED, 4)
GO

-- ----------------------------
-- Records of friendshiplink
-- ----------------------------
SET IDENTITY_INSERT [association].[friendshiplink] ON
GO
INSERT INTO [association].[friendshiplink] ([id], [linkname], [linkurl]) VALUES (N'1', N'新工科创新实验室', N'http://xxx.xxx');
GO
INSERT INTO [association].[friendshiplink] ([id], [linkname], [linkurl]) VALUES (N'2', N'csdn博客', N'https://csdn.net/waiter456');
GO
INSERT INTO [association].[friendshiplink] ([id], [linkname], [linkurl]) VALUES (N'3', N'我的github', N'https://github.com/geekgarry');
GO
INSERT INTO [association].[friendshiplink] ([id], [linkname], [linkurl]) VALUES (N'4', N'麦客互娱', N'http://xxx.xxx');
GO
SET IDENTITY_INSERT [association].[friendshiplink] OFF
GO

-- ----------------------------
-- Table structure for [association].[resources]
-- ----------------------------
DROP TABLE [association].[resources]
GO
CREATE TABLE [association].[resources] (
[id] varchar(44) NOT NULL ,
[dtitle] varchar(88) NULL ,
[dcontent] varchar(200) NULL ,
[dtype] varchar(99) NULL ,
[dfileposition] varchar(99) NULL ,
[upid] varchar(44) NULL ,
[upidname] varchar(66) NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of resources
-- ----------------------------
INSERT INTO [association].[resources] ([id], [dtitle], [dcontent], [dtype], [dfileposition], [upid], [upidname], [create_time]) VALUES (N'20190107234009409233', N'实现热火上线', N'二哥v', N'东西', N'/UpFile/1fccdcd813483d9bcb1b4389742d8ae2.jpg', N'1', N'admin', N'2019-01-07 23:40:09.000');
GO
INSERT INTO [association].[resources] ([id], [dtitle], [dcontent], [dtype], [dfileposition], [upid], [upidname], [create_time]) VALUES (N'201901181959535953214', N'风景', N'十多个vs大不大小不小', N'图片', N'/UpFile/001 (2).jpg', N'1', N'admin', N'2019-01-18 19:59:53.000');
GO
INSERT INTO [association].[resources] ([id], [dtitle], [dcontent], [dtype], [dfileposition], [upid], [upidname], [create_time]) VALUES (N'20190118210059059574', N'四分之三', N'的风格不是打工吧', N'压缩文件', N'/UpFile/6321cde4-6644-4bb1-99fc-626c7fd0b184.zip', N'22', N'GEEK社', N'2019-01-18 21:00:59.000');
GO
INSERT INTO [association].[resources] ([id], [dtitle], [dcontent], [dtype], [dfileposition], [upid], [upidname], [create_time]) VALUES (N'201901212259275927801', N'地址vzs', N'都是v工地施工v饿死', N'图片', N'/UpFile/63d418671bdaac380ae14a7c45ad359a.jpg', N'22', N'GEEK社', N'2019-01-21 22:59:27.000');
GO

-- ----------------------------
-- Table structure for [association].[stumember]
-- ----------------------------
DROP TABLE [association].[stumember]
GO
CREATE TABLE [association].[stumember] (
[id] varchar(44) NOT NULL ,
[realname] varchar(44) NULL ,
[nickname] varchar(44) NULL ,
[stuclass] varchar(44) NULL ,
[phonenumber] varchar(30) NULL ,
[password] varchar(33) NULL ,
[hobbyspeciality] varchar(44) NULL ,
[personalintro] varchar(420) NULL ,
[associationids] varchar(44) NULL ,
[collegedepartment] varchar(33) NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of stumember
-- ----------------------------
INSERT INTO [association].[stumember] ([id], [realname], [nickname], [stuclass], [phonenumber], [password], [hobbyspeciality], [personalintro], [associationids], [collegedepartment], [create_time]) VALUES (N'2019011234', N'朱艳雯', N'wen', N'通信工程1501', N'3452523523', N'123456', N'突然怀念投入的纪念日它的艰难的', N'地图然后那人电话你的然后你的', N'23,22,', N'工学院', N'2018-12-28 15:54:11.000');
GO
INSERT INTO [association].[stumember] ([id], [realname], [nickname], [stuclass], [phonenumber], [password], [hobbyspeciality], [personalintro], [associationids], [collegedepartment], [create_time]) VALUES (N'2019012345', N'辰晨', N'iamcc', N'计算机系统工程1501', N'13235665666', N'123456', N'让他和别人都听你说人话不正式公布的地方东方', N'人生不是特别好通过货币地方官党规党法可能可能豆腐干', N'24,23,22,', N'工学院', N'2018-12-28 15:51:35.000');
GO
INSERT INTO [association].[stumember] ([id], [realname], [nickname], [stuclass], [phonenumber], [password], [hobbyspeciality], [personalintro], [associationids], [collegedepartment], [create_time]) VALUES (N'2019011456', N'郑成功', N'Success', N'生物工程1501', N'12345665478', N'123456', null, null, N'', N'工学院', N'2019-01-24 17:54:54.000');
GO
INSERT INTO [association].[stumember] ([id], [realname], [nickname], [stuclass], [phonenumber], [password], [hobbyspeciality], [personalintro], [associationids], [collegedepartment], [create_time]) VALUES (N'2019012345', N'荣国', N'rong', N'软件1501', N'13556659889', N'123456', null, null, null, N'工学院', N'2019-01-04 16:24:46.000');
GO
INSERT INTO [association].[stumember] ([id], [realname], [nickname], [stuclass], [phonenumber], [password], [hobbyspeciality], [personalintro], [associationids], [collegedepartment], [create_time]) VALUES (N'2019123456', N'高峰会', N'gao', N'软件1501', N'12345678', N'123456', N'的发表速度发货吧地方根本大法大法', N'的发表的发表发布反动表现出，是大概是这个vs的v', N'22,', N'工学院', N'2019-01-04 16:27:32.000');
GO

-- ----------------------------
-- Table structure for [association].[ucomment]
-- ----------------------------
DROP TABLE [association].[ucomment]
GO
CREATE TABLE [association].[ucomment] (
[id] varchar(44) NOT NULL ,
[comment] varchar(255) NULL ,
[objid] varchar(44) NULL ,
[tostuid] varchar(44) NULL ,
[create_time] datetime NULL 
)


GO

-- ----------------------------
-- Records of ucomment
-- ----------------------------

-- ----------------------------
-- Indexes structure for table activitycomment
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[activitycomment]
-- ----------------------------
ALTER TABLE [association].[activitycomment] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table administrator
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[administrator]
-- ----------------------------
ALTER TABLE [association].[administrator] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table applyjoin
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[applyjoin]
-- ----------------------------
ALTER TABLE [association].[applyjoin] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table apprise
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[apprise]
-- ----------------------------
ALTER TABLE [association].[apprise] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table associationactivity
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[associationactivity]
-- ----------------------------
ALTER TABLE [association].[associationactivity] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table associationinfo
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[associationinfo]
-- ----------------------------
ALTER TABLE [association].[associationinfo] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table associationnotice
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[associationnotice]
-- ----------------------------
ALTER TABLE [association].[associationnotice] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table campusnew
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[campusnew]
-- ----------------------------
ALTER TABLE [association].[campusnew] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table friendshiplink
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[friendshiplink]
-- ----------------------------
ALTER TABLE [association].[friendshiplink] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table resources
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[resources]
-- ----------------------------
ALTER TABLE [association].[resources] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table stumember
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[stumember]
-- ----------------------------
ALTER TABLE [association].[stumember] ADD PRIMARY KEY ([id])
GO

-- ----------------------------
-- Indexes structure for table ucomment
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table [association].[ucomment]
-- ----------------------------
ALTER TABLE [association].[ucomment] ADD PRIMARY KEY ([id])
GO
