--将Json数据加载到Lua中的表进行存储

--首先应该把Json表 从AB包加载出来
--加载的Json文件 TextAsset对象
local txt = ABMgr:LoadRes("json", "ItemData", typeof(TextAsset))
--获取它的文本信息 进行Json解析
print(txt.text)
local itemList = Json.decode(txt.text)
--加载出来是一个像数组结构的数据
--不方便我们通过 id去获取里面的内容所以 我们用一张新表转存一次
--而且这张 新的道具表 在任何地方 都能够被使用
ItemData = {}
for _,value in pairs(itemList) do
    ItemData[value.id] = value   --转为用id 存储表
end
