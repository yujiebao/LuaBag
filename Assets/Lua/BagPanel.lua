--一个面板对应一个表
BagPanel = {}
--成员变量
BagPanel.panelObj = nil
--各个控件
BagPanel.btnClose = nil
BagPanel.togEquip = nil
BagPanel.togItem = nil   
BagPanel.togGem = nil
BagPanel.svBag = nil
BagPanel.Content = nil
--存储当前显示的格子
BagPanel.Items = {}
BagPanel.nowType = -1
--成员方法
--初始化方法
function BagPanel:Init()
    if BagPanel.panelObj == nil then
        --实例化面板对象
        self.panelObj = ABMgr:LoadRes("ui","BagPanel",typeof(GameObject))
        self.panelObj.transform:SetParent(Canvas,false)
        --找到对应的控件
        self.btnClose = self.panelObj.transform:Find("Btnclose"):GetComponent(typeof(Button))
        --找三个toggle
        local toggles = self.panelObj.transform:Find("Group")
        self.togEquip = toggles.transform:Find("ToggleEquip"):GetComponent(typeof(Toggle))
        self.togItem = toggles.transform:Find("ToggleItem"):GetComponent(typeof(Toggle))
        self.togGem = toggles.transform:Find("ToggleGem"):GetComponent(typeof(Toggle))
        --sv相关
        self.svBag = self.panelObj.transform:Find("svBag"):GetComponent(typeof(ScrollRect))
        self.Content = self.svBag.transform:Find("Viewport"):Find("Content")
        --加事件
        --关闭按钮
        self.btnClose.onClick:AddListener(function()
            self:HideMe()
        end)
        --单选框事件
        --toggle 对应委托 是UnityAction<bool>
        self.togEquip.onValueChanged:AddListener(function(isOn)
            if isOn then
                self:ChangeType(1)
            end
        end)
        self.togItem.onValueChanged:AddListener(function(isOn)
            if isOn then
                self:ChangeType(2)
            end
        end)
        self.togGem.onValueChanged:AddListener(function(isOn)
            if isOn then
                self:ChangeType(3)
            end
        end)
    end
end

--显示隐藏
function BagPanel:ShowMe()
    self:Init()
    if self.nowType == -1 then
        self:ChangeType(1)   --第一次打开更新页签
    end
    self.panelObj.gameObject:SetActive(true)
end
function BagPanel:HideMe()
    self.panelObj.gameObject:SetActive(false)
end

--逻辑处理函数  用来切页签
function BagPanel:ChangeType(type)
    if self.nowType == type then
        return
    end
    self.nowType = type
    print("切换到第"..type)
    --切页  根据玩家信息 来进行格子的创建
    
    --更新前  把老格子删除
    for i = 1, #self.Items do
        self.Items[i]:Destroy()
    end
    self.Items = {}
    --再根据当前选择的类型 来创建新的格子
    --根据 传入的type数据来选择 显示的数据
    local nowItems = nil
    if type == 1 then
    nowItems = PlayerData.equips
    elseif type ==2 then
    nowItems = PlayerData.items
    else
    nowItems = PlayerData.games
    end
    --创建格子
    for  i=1,#nowItems do
    -- --有格子资源在这加载格子资源实例化改变图片和文本 以及位置即可
    -- local grid = {}   --临时生成格子对象  保证每一次都新生成一个格子对象
    -- --用一张新表代表格子对象里面的属性 存储对应想要的信息
    -- grid.obj = ABMgr:LoadRes("ui","ItemGrid",typeof(GameObject))
    -- --设置父对象
    -- grid.obj.transform:SetParent(self.Content,false)
    -- --继续设置他的位置
    -- grid.obj.transform.localPosition = Vector3((i-1)%4*175,math.floor((i-1)/4*175),0)
    -- --找控件
    -- grid.imgIcon = grid.obj.transform:Find("Image"):GetComponent(typeof(Image))
    -- grid.Text = grid.obj.transform:Find("Text"):GetComponent(typeof(TextMeshProUGUI))

    -- --设置图标
    -- --通过 道具ID去读取 道具配置表 得到 图标信息
    -- local data = ItemData[nowItems[i].id]
    -- --根据道具路径名字 先加载图集
    -- local strs = string.split(data.icon,"_")  --注意这个方法不使用string中的如何属性 写"."而不能写":"  写":"会将调用者传入作为第一个参数而出错

    -- --加载图集
    -- local atlas = ABMgr:LoadRes("ui",strs[1],typeof(SpriteAtlas))  --,typeof(SpriteAtlas)

    -- --加载图标
    -- grid.imgIcon.sprite = atlas:GetSprite(strs[2])
    -- --设置数量
    -- grid.Text.text = nowItems[i].num

    --根据数据  创建一个格子对象
    local grid = ItemGrid:new()
    --实例化对象 设置位置
    grid:Init(self.Content,i%4*175,math.floor(i/4)*175)
    grid:InitData(nowItems[i])
    --把他存起来
    table.insert(self.Items,grid)
    end
end