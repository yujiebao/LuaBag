Object:subClass("BasePanel")

BasePanel.panelobj = nil
--模拟一个字典  键为 控件名 值为控件本身
BagPanel.controls = {}

function BasePanel:Init(name)
    if self.panelobj == nil then
        self.panelObj = ABMgr:LoadRes("ui",name,typeof(GameObject))
        self.panelObj.transform:SetParent(Canvas,false)
        --GetComponentInChildren
        --使用UIBehavior找所有的UI控件存起来
        -- 可能会找到一些没用的控件 为了避免 找各种无用控件 我们定一个规则 拼面板时 控件命名一定按规范来
        --Button btn名字
        --Toggle tog名字
        --Image img名字
        --ScrollRect sv名字
        local allControls = self.panelObj.transform:GetComponentsInChildren(typeof(UIBehavior))   
        for i=0,allControls.Length -1 do
            local controlName = allControls[i].name  
            --筛选 出我们想要的控件
            if string.find(controlName,"btn") ~= nil or
               string.find(controlName,"tog") ~= nil or 
               string.find(controlName,"img") ~= nil or  
               string.find(controlName,"sv") ~= nil  or
               string.find(controlName,"txt") ~= nil
               then
                local typeName = allControls[i].GetType().name
                if self.controls[controlName] ~= nil then   
                    -- table.insert(self.controls[controlName],allControls[i])     --处理同名控件  用表存储
                    
                    --最终使用{btnRole = {Image = 控件, Button = 控件},togItem ={Toggle = 控件}}  表示的是一个Button上有BUtton和Image控件
                    self.controls[controlName][typeName] = allControls[i]    
                end
                else
                    self.controls[controlName] = {[typeName] = allControls[i]}
            end
        end 
    end
end

function BasePanel:ShowMe()
    self:Init()
    self.obj.gameObject:SetActive(true)

end

function BasePanel:HideMe()
    self.obj.gameObject:SetActive(false)
end