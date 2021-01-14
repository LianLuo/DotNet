## ECMAScript 5
本书主要讨论ECMAScript 3，因为这是该语言最为广泛发布的版本。然而，最新的标准是ECMAScript 5.1（版本4是以废弃而告终的一个版本）。大多数现代浏览器都支持ES5。你应该知道ES 5中有哪些新内容，即便你当前必须支持遗留的浏览器。
更新主要来自3个方面：
+ 引入了严格模式。
+ 对象和属性特性。
+ 一些新的API。

### 6.1 严格模式
严格模式是不向后兼容的，因此，它是一项可选的功能。一旦要选择每项功能或每项程序使用严格模式，可以使用如下命令：
```javascript
"use strict";
```
由于这只是一条字符串语句，旧的浏览器不会抱怨，而是会直接忽略它。但是，支持严格模式的引擎则会更严格对待你的代码，从而不允许某些JavaScript功能和结构，因为多年来已经证明，这些功能和结构所带来的麻烦比所实现的功能还要大。本书不会介绍任何这种不好的做法，因此，本书的内容都值得学习的。
在严格模式中，会触发错误的一些功能举例如下：
+ 使用with语句。
+ 使用未声明的变量。
+ 使用arguments.callee或者arguments.caller。
+ 试图给只读的属性赋值（例如，window.Infinity = 0;）。
+ 试图删除不可配置的属性（稍后，你将会看到可配置的含义）。
+ 带有重复的属性的对象直接量。
名称重复的函数（因为，令人惊讶的是，在ES3中，function(a,a,a){}是没有问题的）。

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
ES5中第二个发生变化的部分，就是引入了属性特性。实际上，这些特性总是存在的，只不过以前程序员不能修改它们。
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
属性描述使得我们对属性的可变性有了更多的控制。例如，它们允许你创建带有常量的不可删除的属性。尽管很多的ES5 API也可以在ES3中实现，属性描述符则没有。在ES3中，我们所创建的所有属性都是可变的。
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

可虑如下的代码段：
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
本书前面解释过，“空”的对象（例如，var o = {};）并非真是空的，因为它们从Object.prototype继承了诸如toString()的方法。好了，在ES5中，可以使用如下代码创建真正空的对象：
```javascript
var o = Object.create(null); // 没有继承什么
typeof o.toString; // "undefined"
```
#### 6.3.2 Object.getOwnPropertyDescriptor()
getOwnPropertyDescriptor()方法允许我们检查描述符对象：
```javascript
Object.getOwnPropertyDescriptor(progammer,'secret').configurable; // false
Object.getOwnPropertyDescriptor(programmer,'likes').configurable; // true
```
#### 6.3.3 Object.defineProperty() 和 Object.defineProperies()
Object.defineProperty()和Object.defineProperties()这两个方法，允许我们在对象创建之后，稍后使用一个描述符来定义属性。
```javascript
Object.defineProperty(programmer,'hello', stealth_descriptor);
Object.defineProperties(programmer,{
    goodbye:stealth_descriptor,
    bye:stealth_descriptor
});
```
#### 6.3.4 限制对象修改
在ES3中，所有的对象都是可变的，只是在内建的对象中有少数例外。有时候，允许修改对象不是一个好主意，因为对象的用户可能不仅会修补对象，而且会改变对象。在ES5中，我们可以限制对对象的访问。例如，可以通过将对象的writable属性设置为false，从而使选定的属性变为只读的。
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
然而，如果阻止扩展，我们将不再能够添加属性。可以使用Object.isExtensible()来检查对象是否可以扩展，并且使用Object.preventExtensions()来阻止扩展。
```javascript
Object.isExtensible(pizza); // true
Object.preventExtensions(pizza); // 返回`pizza`对象
Object.isExtensiable(pizza); // false

pizza.broccoli = "eww"; // 错误，不再能够添加属性
typeof pizza.broccoli; // "undefined"
```
此外，我们可以使用seal()来阻止删除对象属性：
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
但是，一旦freeze()了一个对象，其所有属性都变成不可写了：
```javascript
Object.isFreezen(pizza); // false
Object.freeze(pizza); // 返回`pizza`对象
Object.IsFreezen(pizza); // true

pizza.cheese = "gorgonzola"; // 错误，`cheese`是只读
pizza.cheese; // "ricotta"
```
因此，概括起来：
+ freeze()做了seal()所有的事情，此外再将所有的属性的writable特性设置为false。
+ seal()做了preventExtensions()所有事情，此外将所有属性的configurable特性设置为false。
+ preventExtensions()没有设置任何特性，但是，它不允许你再此之后添加更多的属性。
+ 这些操作都是不可逆的（例如，没有unfreeze(),defrost(),allowExtensions()等方法）。

#### 6.3.5 循环替代
再ES3中，如果想要得到所有的属性列表（就像是PHP中的array_keys()），那么，必须执行一个for-in循环。在ES5中，我们可以使用Object.keys()或Object.getOwnPropertyNames()。keys()方法给出了所有可枚举的属性（那些将会出现在一个for-in循环中的属性），而getOwnPropertyNames()返回了所有的自身属性，包括可以枚举和不可枚举的。
如果你不是用描述符来设置enumerable属性的话，这两个方法是相同的：
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
