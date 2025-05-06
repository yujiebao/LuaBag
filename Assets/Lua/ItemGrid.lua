--用到之前讲过的知识 object
--生成一个table 集成object  主要目的是要它里面实现的继承方法subclass和new
Object:subClass("ItemGrid")
--成员变量
ItemGrid.obj = nil
ItemGrid.imgIcon = nil
ItemGrid.Text = nil

--成员函数
--实例化格子对象
function ItemGrid:Init(father,posX,posY)
    self.obj = ABMgr:LoadRes("ui","ItemGrid",typeof(GameObject))
    --设置父对象
    self.obj.transform:SetParent(father,false)
    --继续设置他的位置
    self.obj.transform.localPosition = Vector3(posX,posY,0)
    --找控件
    self.imgIcon = self.obj.transform:Find("Image"):GetComponent(typeof(Image))
    self.Text = self.obj.transform:Find("Text"):GetComponent(typeof(TextMeshProUGUI))    
end

--初始化格子信息
--data是外面传入的道具信息  包含num和id
function ItemGrid:InitData(data)
     --通过 道具ID去读取 道具配置表 得到 图标信息
    local itemdata = ItemData[data.id]
    --根据道具路径名字 先加载图集
    local strs = string.split(itemdata.icon,"_")  --注意这个方法不使用string中的如何属性 写"."而不能写":"  写":"会将调用者传入作为第一个参数而出错

    --加载图集
    local atlas = ABMgr:LoadRes("ui",strs[1],typeof(SpriteAtlas))  --,typeof(SpriteAtlas)

    --加载图标
    self.imgIcon.sprite = atlas:GetSprite(strs[2])
    --设置数量
    self.Text.text = itemdata.num
end
--加自己的逻辑
function ItemGrid:Destroy()
    GameObject.Destroy(self.obj)
    self.obj = nil
end