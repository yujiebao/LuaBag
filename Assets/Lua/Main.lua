print("准备就绪")
--初始化脚本
require("InitClass")
require("SplitTools")
require("Object")
--初始化 道具表信息
require("ItemData")
--玩家信息
--1.从本地读取本地存储有几种方式PlayerPrefs Json 2进制
--2.网络游戏 从服务器获取
require("PlayerData")
--之后的逻辑可以直接使用

require("MainPanel")
MainPanel:ShowMe()

require("BagPanel")
require("ItemGrid")
-- BagPanel:ShowMe()