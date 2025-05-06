--面向对象实现
--万物之父  所有面向对象的基类 Object
Object = {}
--封装
--实例化方法  给空表(obj)设置原表  以及__index元方法
function Object:new()
    local obj = {}   --代表一个新的地址
    self.__index = self 
    setmetatable(obj, self) 
    return obj
end
--继承
function Object:subClass(className)
    --根据名字生产一个类(表)
    _G[className] = {}   
    --设置元表为父类 
    local obj = _G[className]
    obj.base = self
    --给子类设置元表  以及__index元方法
    self.__index = self
    setmetatable(obj, self)
end

--声明一个类
Object:subClass("GameObject")
GameObject.Posx = 0
GameObject.Posy = 0
function GameObject:Move()
    self.Posx = 1 + self.Posx
    self.Posy = 1 + self.Posy
    print(self.Posx..","..self.Posy)
end

--实例化对象
local gameObject = GameObject:new()
print(gameObject.Posx..","..gameObject.Posy) --输出0,0
gameObject:Move() --调用方法

GameObject:subClass("Player")
function Player:Move()
    self.base.Move(self)
    self.Posx = 2 + self.Posx
    self.Posy = 2 + self.Posy
    print(self.Posx..","..self.Posy)
end

local player = Player:new()
print(player.Posx..","..player.Posy) --输出0,0
player:Move() --调用方法