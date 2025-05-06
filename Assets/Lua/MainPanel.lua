--只要是一个新的对象(面板)我们就新建一张表
MainPanel = {}

--不是必须写  因为lua的特性 不存在声明变量的概念
--这样写的目的 是当别人看这个lua代码时 知道这个表(对象)有什么变量很重要  相当于先展示 哪些变量很重要

--关联的面板对象
MainPanel.panelObj = nil
--面板控件
MainPanel.btnRole = nil
MainPanel.btnSkill = nil

--需要做 实例化面板对象
--为这个面板 处理对应的逻辑 比如按钮点击等等

--初始化面板  实例化对象 控件事件监听
function MainPanel:Init()
    if self.panelObj == nil then
        --1.实例化面板对象 + 设置父对象
    self.panelObj = ABMgr:LoadRes("ui","MainPanel",typeof(GameObject))
    self.panelObj.transform:SetParent(Canvas,false)   --第二个参数 不保持原有坐标缩放 避免UI变化
    --2.找到对应的控件
    self.btnRole = self.panelObj.transform:Find("BtnRole"):GetComponent(typeof(Button))
    --3.做对应的逻辑 比如按钮点击事件监听
    --但传入自己的函数中国
    --如果直接.传入自己的函数 那么在函数内部 没有办法用self获取内容
    --需要包裹
    -- self.btnRole.onClick:AddListener(self.ButtonRoleClick)    
    self.btnRole.onClick:AddListener(function()
        self:ButtonRoleClick()
    end)
    end
end

function  MainPanel:ShowMe()
    self:Init()
    self.panelObj.gameObject:SetActive(true)
end

function  MainPanel:HideMe()
    self.panelObj.gameObject:SetActive(false)
end

function  MainPanel:ButtonRoleClick()
    print("点击了角色按钮")
    print(self.btnRole)
    BagPanel:ShowMe()
end