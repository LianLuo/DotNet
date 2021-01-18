## ECMAScript 5
本书主要讨论`ECMAScript 3`，因为这是该语言最为广泛发布的版本。然而，最新的标准是`ECMAScript 5.1`（版本4是以废弃而告终的一个版本）。大多数现代浏览器都支持`ES5`。你应该知道`ES5`中有哪些新内容，即便你当前必须支持遗留的浏览器。
更新主要来自3个方面：
+ 引入了严格模式。
+ 对象和属性特性。
+ 一些新的API。

### 6.1 严格模式
严格模式是不向后兼容的，因此，它是一项可选的功能。一旦要选择每项功能或每项程序使用严格模式，可以使用如下命令：
```javascript
"use strict";
```
由于这只是一条字符串语句，旧的浏览器不会抱怨，而是会直接忽略它。但是，支持严格模式的引擎则会更严格对待你的代码，从而不允许某些`JavaScript`功能和结构，因为多年来已经证明，这些功能和结构所带来的麻烦比所实现的功能还要大。本书不会介绍任何这种不好的做法，因此，本书的内容都值得学习的。
在严格模式中，会触发错误的一些功能举例如下：
+ 使用with语句。
+ 使用未声明的变量。
+ 使用`arguments.callee`或者`arguments.caller`。
+ 试图给只读的属性赋值（例如，window.Infinity = 0;）。
+ 试图删除不可配置的属性（稍后，你将会看到可配置的含义）。
+ 带有重复的属性的对象直接量。
名称重复的函数（因为，令人惊讶的是，在`ES3`中，function(a,a,a){}是没有问题的）。

如下是一个简单的示例，它说明了严格模式和非严格模式的区别：
```javascript
// 非严格模式
var obj = (function(){
    return {a:1,a:2};
})();

obj; //{a:2}

// 严格模式
var obj = (function(){
    "use strict";
    return {a:1,a:2};
})(); // SyntaxError: duplicate property
```

### 6.2 属性特性
`ES5`中第二个发生变化的部分，就是引入了属性特性。实际上，这些特性总是存在的，只不过以前程序员不能修改它们。
一个属性有一个value特性，还有3个布尔特性，它们定义了该属性是否是：
+ 可枚举的。
+ 可写的。
+ 可配置的。

我们可以用一种叫做描述符（descriptors）的特殊对象来定义一个属性的特性。如下是一个示例：
```javascript
var stealth_descriptor = {
    value:"can't touch this",
    emumeran;e:false, // 不能出现在一个for-in循环中
    writable:false, // 不能修改我的值
    configurable:false // 不能删除我或修改我的特性
};
```

---
**注意：** 不可配置的属性只能够将它们的writable特性设置为不可写的。

---
属性描述使得我们对属性的可变性有了更多的控制。例如，它们允许你创建带有常量的不可删除的属性。尽管很多的`ES5 API`也可以在`ES3`中实现，属性描述符则没有。在`ES3`中，我们所创建的所有属性都是可变的。
在下一节中，我们将会看到关于使用属性描述符的更多细节和示例。
### 6.3 新的对象API
让我们来看看允许操作属性特性的新的对象API，也就是：
+ Object.create()
+ Object.defineProperty()
+ Object.defineProperties()
+ Object.getOwnPropertyDescriptor()

#### 6.3.1 Object.create()
该方法可以用来创建新的对象，并且同时：
+ 定义继承。
+ 定义对象的属性。
+ 定义属性的特性。

考虑如下的代码段：
```javascript
var human = {name: "John"},
var programmer = Object.create(human,{
    secret:stealth_descriptor,
    skill:{value:"Code ninja"}
});
```
programmer对象通过\_\_proto\_\_的方式继承自\_\_proto\_\_对象，因此，它有一个（但并不是自身的）name属性：
```javascript
programmer.name; // "John"
programmer.hasOwnProperty('name'); // false
programmer.__proto__.hasOwnProperty('name'); // true
```
另外两个属性是自身的属性：
```javascript
programmer.hasOwnProperty('secret'); // true
programmer.hasOwnProperty('skill'); // true
```
对secret属性使用了一个完整的描述符：stealth_descriptor设置了值以及3个特性。
skill属性只是定义了一个值。这意味着所有的特性设置为其默认值，即都是false。
如果直接设置一个属性而不使用描述符，所有的特性都是true，就像在ES3中的情况一样：
```javascript
programmer.likes = ['pizza','beer','coffee']
```

---
**注意：** Object.create()类似于begetObject()（在本书4.6节讨论过），再加上额外的描述符。

---
本书前面解释过，“空”的对象（例如，var o = {};）并非真是空的，因为它们从`Object.prototype`继承了诸如toString()的方法。好了，在`ES5`中，可以使用如下代码创建真正空的对象：
```javascript
var o = Object.create(null); // 没有继承什么
typeof o.toString; // "undefined"
```
#### 6.3.2 Object.getOwnPropertyDescriptor()
`getOwnPropertyDescriptor()`方法允许我们检查描述符对象：
```javascript
Object.getOwnPropertyDescriptor(progammer,'secret').configurable; // false
Object.getOwnPropertyDescriptor(programmer,'likes').configurable; // true
```
#### 6.3.3 Object.defineProperty() 和 Object.defineProperies()
`Object.defineProperty()`和`Object.defineProperties()`这两个方法，允许我们在对象创建之后，稍后使用一个描述符来定义属性。
```javascript
Object.defineProperty(programmer,'hello', stealth_descriptor);
Object.defineProperties(programmer,{
    goodbye:stealth_descriptor,
    bye:stealth_descriptor
});
```
#### 6.3.4 限制对象修改
在`ES3`中，所有的对象都是可变的，只是在内建的对象中有少数例外。有时候，允许修改对象不是一个好主意，因为对象的用户可能不仅会修补对象，而且会改变对象。在`ES5`中，我们可以限制对对象的访问。例如，可以通过将对象的writable属性设置为false，从而使选定的属性变为只读的。
但是，可以通过如下的方法，来限定对整个对象的访问：
+ 阻止扩展（例如，不允许新的属性）。
+ “封存”一个对象，这意味着除了让对象不可扩展，还让所有的属性变成不可配置的（不能删除它们）。
+ “冻结”一个对象，就像是封存一个对象，但是，还有一个额外的步骤，就是将所有属性设置为不可写的。

考虑如下这个常规的对象：
```javascript
var pizza = {
    tomatoes:true,
    cheese:true
};
```
我们总是可以添加更多的属性：
```javascript
pizza.pepperoni = 'lots';
```
我们可以修改并删除属性，因为这些属性都是可配置和可写的：
```javascript
pizza.cheese = "mozzarella";
delete pizza.pepperoni; // true
```
然而，如果阻止扩展，我们将不再能够添加属性。可以使用`Object.isExtensible()`来检查对象是否可以扩展，并且使用`Object.preventExtensions()`来阻止扩展。
```javascript
Object.isExtensible(pizza); // true
Object.preventExtensions(pizza); // 返回`pizza`对象
Object.isExtensiable(pizza); // false

pizza.broccoli = "eww"; // 错误，不再能够添加属性
typeof pizza.broccoli; // "undefined"
```
此外，我们可以使用`seal()`来阻止删除对象属性：
```javascript
Object.isSealed(pizza); // false
Object.seal(pizza); // 返回`pizza`对象
Object.isSealed(pizza); // true

delete pizza.cheese; // 错误，不能删除
pizza.cheese; // "mozzarella"
```
但是，在这种情况下，我们仍然可以改变一个属性：
```javascript
pizza.cheese = "ricotta";
```
但是，一旦`freeze()`了一个对象，其所有属性都变成不可写了：
```javascript
Object.isFreezen(pizza); // false
Object.freeze(pizza); // 返回`pizza`对象
Object.IsFreezen(pizza); // true

pizza.cheese = "gorgonzola"; // 错误，`cheese`是只读
pizza.cheese; // "ricotta"
```
因此，概括起来：
+ `freeze()`做了`seal()`所有的事情，此外再将所有的属性的writable特性设置为false。
+ `seal()`做了`preventExtensions()`所有事情，此外将所有属性的`configurable`特性设置为false。
+ `preventExtensions()`没有设置任何特性，但是，它不允许你在此之后添加更多的属性。
+ 这些操作都是不可逆的（例如，没有unfreeze(),defrost(),allowExtensions()等方法）。

#### 6.3.5 循环替代
在`ES3`中，如果想要得到所有的属性列表（就像是PHP中的array_keys()），那么，必须执行一个for-in循环。在ES5中，我们可以使用`Object.keys()`或`Object.getOwnPropertyNames()`。keys()方法给出了所有可枚举的属性（那些将会出现在一个for-in循环中的属性），而getOwnPropertyNames()返回了所有的自身属性，包括可以枚举和不可枚举的。
如果你不是用描述符来设置`enumerable`属性的话，这两个方法是相同的：
```javascript
var pizza = {tomatoes:true,cheese:true};
Object.keys(pizza); // ["tomatoes","cheese"]
Object.getOwnPropertyNames(pizza); // ["tomatoes","cheese"]
```
这两个方法都只是操作自身属性，它们不会返回从原型继承的任何内容。让我们创建一个对象pizza_v20，它继承了pizza并且添加了一些新的属性：
```javascript
var pizza_v20 = Object.create(pizza,{
    salami:{value:'lots', enumerable:true},
    sauce:{value'secret'}
});
```
keys()将不会返回sauce，因为它不是可枚举的，但是，getOwnPropertyNames()将返回所有的属性：
```javascript
Object.keys(pizza_v20); // ['salami']
Object.getOwnPropertyNames(pizza_v20); // ["salami","sauce"]
```
这二者都不会返回任何的pizza属性，因为这些属性都是继承而来的：
```javascript
pizza_v20.cheese; // true
pizza_v20.__proto__ === pizza; // true
```
#### 6.3.6 Object.getPropetyOf()
在ES5中，所有新奇的内容都包含在Object()之中，让我们来看看getPropertyOf()方法。在`ES3`中，如果怀疑一个对象并且需要咨询它是否真的是原型的时候，我们只能使用`isPropertyOf()`来检查。
在ES5中，我们可以直接询问，“谁是原型？”
```javascript
Object.getPropertyOf(pizza_v20) === pizza; // true
```
正如你所看到的，这和使用\_\_proto\_\_是相同的，但是记住\_\_proto\_\_不是标准的（并且在IE中是不存在的）。ES5承认至少需要一个可读的\_\_proto\_\_，并且引入了getPropertyOf()作为替换（而可写的版本仍然是一个激烈辩论的主题）。
### 6.4 数组的添加
在`ES5`中，有几个方法添加给了`Array.prototype`，并且还给`Array`构造器添加了一个方法。
#### 6.4.1 Array.isArray()
`Array.isArray()`给出了一种巧妙的方法，可以区分`JavaScript`中的数组和对象（记住，数组也是对象）。
如果想要给方法增加*shim* 并且也在ES3中使用它，我们可以使用`Object.prototype.toString()`技术，就像本书前面所介绍的那样：
```javascript
if(!Array.isArray{
    Array.isArray = function(candidate){
        return Object.prototype.toString.call(candidate) === '[object Array]';
    };
}

Array.isArray([]); // true
```
这个方法等同于PHP中的is_array()。
#### 6.4.2 indexOf()和lastIndexOf()
`Array.prototype.indexOf()`和`Array.prototype.lastIndexOf()`这两个新方法，提供了更多的方法在数组中进行搜索。
`Array.prototype.indexOf()`返回了一个元素初次出现的索引：
```javascript
var a = ['one','and','two','and','three','and','four'];
a.indexOf('three'); // 4
```
这接近于PHP的array_search()方法。
`Array.prototype.indexOf()`返回初次出现的位置，但`Array.prototype.lastIndexOf()`返回了最后一次出现的位置：
```javascript
var a = ['one','and','two','and','three','and','four'];
a.indexOf('and'); // 1
a.lastIndexOf('and'); // 5
```
针对元素的搜索，会使用严格比较来找到匹配：
```javascript
[1,2,100,'100'].indexOf('100'); // 3
[1,2,100,'100'].indexOf(100); // 2
```
也可以在indexOf()中指定开始位置，在lastIndexOf()中指定结束位置，从而开始搜索：
```javascript
var arr = [100,1,2,100];
arr.indexOf(100); // 0
arr.indexOf(100,2); // 3

arr.lastIndexOf(100); // 3
arr.lastIndexOf(100,2); // 0
```
#### 6.4.3 遍历数组元素
`ES5`添加了`Array.prototype.forEach()`，它允许你遍历所有的数组元素，而不需要使用一个循环结构。`Array.protype.forEach()`使用一个回调函数，在其中我们可以对每个元素或整个数组执行一项操作。
如下是一个快速示例，它记录了传递给回调函数的参数。
```javascript
['a','b','c'].forEach(function(){
    console.log(arguments);
});
```
控制台中的结果是：
```text
['a',0,Array[3]]
['b',1,Array[3]]
['c',2,Array[3]]
```
正如你所看到的，其格式是：
[元素，元素的索引，整个数组]
#### 6.4.4 过滤
`every()`和`some()`这两个新方法，允许我们迭代所有的数组元素并且返回一个布尔值，它表明数组元素是否满足你在一个回调函数中所提供的检查。假设你想要检查一个数组是否包含偶数数字。检查如下所示：
```javascript
function isEven(num){
    return num % 2 === 0;
}
```
并且测试如下：
```javascript
// 是否所有的数字都是偶数？
[1,2,4].every(isEven); // false

// 是否至少某些（甚至一个）数字是偶数？
[1,2,4].some(isEven); // true
```
#### 6.4.6 Map/Reduce
类似于PHP的array_map()和array_reduce()，在ES5中，我们有`Array.prototype.map()`和`Array.prototype.reduce()`，此外，还有一个`Array.prototype.reduceRight()`。map()返回一个新的数组，其中每个元素都已经由你所定制的回调函数修改过。
如下的这个函数，将一个字符转化为其HTML实体的形式：
```javascript
function entity(char){
    return "&#" + char.charCodeAt(0)+';';
}
```
现在，让我们将其应用于一个数组的所有元素：
```javascript
var input = ['a','b','c'];
var out = input.map(entity);
out; // ["&#97;", "&#98;", "&#99;"]
```
`Array.prototype.reduce()`接收一个数组，并且使用一个回调函数，将其简化为一个简单值。
假设想要将一个数组中的所有数字求和，并且加上100作为结果。假设想要从100开始，并且迭代地加上下一个值来求和：
```javascript
function sum(running_sum, value, index, array){
    console.log(arguments);
    return running_sum + value;
}
[1,2,3].reduce(sum,100); // 106;
```
在迭代过程中，我们会在控制台看到如下内容：
```text
[100, 1, 0, Array[3]]
[101, 2, 1, Array[3]]
[103, 3, 2, Array[3]]
```
`Array.prototype.reduceRight()`也是一样的，只不过它从右向左地来循环数组元素，这意味着它从最后的元素开始并且向下移动。
在这个示例中，结果是相同的，但是，我们在控制台中看到不同的输出：
```javascript
[1,2,3].reduceRight(sum,100); // 106
```
输出是：
```text
[100, 3, 2, Array[3]]
[103, 2, 1, Array[3]]
[105, 1, 0, Array[3]]
```
### 6.5 字符串截断
`ES5`引入了`String.prototype.trim()`，它类似于PHP的trim()函数。
```javascript
" hello ".trim(); // "hello"
```
并且，这是ES5中与字符串相关的唯一的添加。

---
**注意：** 一些环境还提供了trimLeft()和trimRight()，但是，这些并不是标准的一部分。

---
### 6.6 Date中的新变化
添加了3个操作日期的新方法。
`Date.now()`是执行(new Date()).getTime()或+new Date()的一种较为简短的方式。它返回当前的时间戳：
```javascript
Date.now(); // 1610718570150
Date.now() === +new Date(); // true
```
Data.prototype.toISOString()是另一个字符串格式化函数：
```javascript
var date = new Date(2021, 1, 15);
date.toDateString(); // "Mon Feb 15 2021"
date.toISOString(); // "2021-02-14T16:00:00.000Z"
```
`toISOString()`是以JSON格式表示日期的一种方便的方式，并且由`JSON.stringify()`使用，稍后我们将介绍JSON.stringify()。实际上，还有`Date.prototype.toJSON()`，它返回的内容和toISOString()相同：
```javascript
var today = new Date();
today.toJSON() === today.toISOString(); // true
```
### 6.7 Function.prototype.bind()
由于函数是可以传递的对象，并且函数中的this取决于如何调用函数，这使得当你使用this并确信this应该是你期望内容的时候，还是会存在某种风险。考虑如下示例：
```javascript
var breakfast = {
    drink:'coffee',
    eat:'bacon',
    my:function(){
        return this.drink+' & '+this.eat;
    }
};

breakfast.my(); // "coffee & bacon"
```
这里一点也不奇怪。然而，你可能想要一个新的引用，例如：
```javascript
var morning = breakfast.my;
morning(); // "coffee & bacon"
```
在这种情况下，this是全局对象，并没有drink或eat属性。但是，你可以添加my()方法绑定到breakfast对象并使其像期望的那样工作：
```javascript
var morning = breakfast.my.bind(breakfast);
moring(); // "coffee & bacon"
```
### 6.8 JSON
作为对`ECMAScript 5`讨论的结束，我们来看看`JSON`对象。这是对`ES5`的一项添加，它将所有浏览器中（包括IE8+）已经实现的技术进行了标准化。`JSON`表示“JavaScript Object Notation”，这是使用JavaScript对象和数组直接量来编码任意数据的一种数据交换格式。
`JSON`有两个方法（遗憾的是，方法命名不太好），分别是`stringify()`和`parse()`，它们对应于PHP的`json_encode()`和`json_decode()`:
```javascript
JSON.stringify({hello:'world'}); // "{hello:'world'}"
JSON.parse("{hello:'world'}").hello; // 'world'
```
在不能本地支持`JSON`的环境中，我们可以使用如下的shim技术（[http://json.org](http://json.org)）。
### 6.9 Shims
shim，或者叫“polyfills”，是在较旧的环境中支持新的API的一种方法。由于在`JavaScript`中我们可以修改内建的对象和原型，因此，可以模拟新的API。如下shim技术的一个示例：
```javascript
if(!Date.now){
    Date.now = function(){
        return new Date().getTime();
    };
}
```
或者：
```javascript
if(!String.prototype.trim){
    String.prototype.trim = function(){
        return this.replace(/^\s+|\s+$/g,'');
    };
}
```
正如你所看到的，shim技术往往很小，并且，你可以在第一行代码之前加载它们，从而使得遗留的浏览器能够处理新的和漂亮的功能。
但是要注意，有一些功能无法使用shim的（例如，严格模式以及处理属性描述符的所有方法）。
要查看浏览器支持那些功能，请访问[http://kangax.github.com/ex5-compat-table/](http://kangax.github.com/ex5-compat-table/)。