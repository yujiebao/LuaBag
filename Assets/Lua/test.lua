print("this is a test")
testNumber = 1
testBool = true
testString = "test"
testFloat = 1.0
local LocalNumber = 1     -- 通过C#不能直接获取Local变量

--无参无返回
testFunc = function()
    print("testFunc no in no out 无参无返回")
end
--有参有返回
testFunc2 = function(a)
    print("testFunc2 in out 有参有有返回")
    return a+1
end
--多返回
testFunc3 = function (a)
    print("testFunc3 multiply out 多返回")
    return a*a,1,2,3
end
--变长参数
testFunc4 = function(a,...)   --在unity中定义委托  第一个与后面变长类型一致时，不要分开写 直接一个params就行
    print("testFunc4 in out 变长参数")
    print(a)
    args = {...}
    for key, value in pairs(args) do
        print(key,value)
    end
end

--list
testList = {1,2,3,4,5}
testList2 = {1,"123",3,4,5}

--Dictionary
testDic = {
    ["1"] = 1,
    ["2"] = 2,
    ["3"] = 3,
    ["4"] = 4
}

testDic2 = {
    ["1"] = 1,
    [true] = 1,
    [false] = true,
    ['123'] = false
}

testClass = 
{
    testInt = 2,
    testBool = true,
    testString = "test",
    testFloat = 1.0,
    -- testList = {1,2,3,4,5},
    testfunc = function ()
        print("testClass.testfunc")
    end,
    -- testinClass =
    -- {
    --     testinInt = 5
    -- }
}