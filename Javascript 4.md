## 面向对象编程
本章介绍JavaScript面向对象特性，包括对象，构造器函数和原型。本章还将讨论代码重用和继承。
### 4.1 构造器和类
在PHP种，如果有一个Dog类，可以使用如下代码创建这个类的一个$fido实例：
```php
// PHP
$fido = new Dog();
```
JavaScript有一个类似的语法：
```javascript
// JavaScipt
var fido = new Dog();
```
一个重要的区别是，Dog在JavaScript种不是一个类，因为该语言种没有类。Dog只是一个函数。但是，用来创建对象的函数称为构造函数（constructor functions）。
从语法上看，一般的函数和一个构造器函数之间并没有区别。区别在于其用途。因此，为了实现可读性，构造器函数名称的首字母通常大写。
当你使用new运算符调用一个函数的时候，它总是返回一个对象。在函数体内部，这个对象称为this。即便在函数种不做任何特殊的事情，也会有this对象。记住，如果不使用new调用的话，没有一条显式的return语句的每个函数都会返回undefined：
```javascript
function Dog(){
    this.name = "Fido";

    this.sayName = function(){
        return "Woof! "+ this.name;
    }
}

var fido = new Dog();
fido.sayName();// "Woof! Fido"
```
---
**注意：** 在JavaScript种，与在PHP中一样，当你没有给构造器函数传递参数的时候，圆括号是可选的，因此，var fido = new Dog;也是有效的。

---
如果在控制台输入fido，将会看到它有两个属性：name和sayName。有些控制台，还会给出一个名为\_\_proto\_\_的特殊属性，但你现在可以忽略它。
看一下sayName属性，它指向一个函数。在JavaScript中，函数是对象，因此，可以将它们分配给属性，在这种情况下，我们也可以称其为方法（method）。在JavaScript中，属性和方法之间真的没有区别。方法只不过是可以调用的属性。
#### 4.1.1 返回对象
当使用new调用任何函数的时候，会发生如下的事情：
1. 在后台自动创建一个“空”的对象，通过this引用该对象：
```javascript
    var this = {}; // 伪代码，如果你使用它，建辉产生一个语法错误
```
2. 程序员可以任意地给this添加属性：
```javascript
    this.name = "Fido";
```
3. 在函数的末尾，隐式地返回this：
```javascipt
    return this; // 不是一个错误，到那时你不需要使用它
```

程序员可以通过返回一个不同的对象，从而改变步骤3：
```javascript
function Dog(){
    var nothis = {
        noname:"Anonymous"
    };
    this.name = "Fido";
    return nothis;
}

var fido = new Dog();
fido.name; // undefined
fido.noname; // "Anonymous"
```
在这个示例中，我们添加给this的任何内容，在函数返回的时候都直接销毁了。你也可以删除它，在这种情况下，你真的不需要new所提供的魔力，可以像对待一般函数一样调用它并实现同样的效果：
```javascript
function Dog(){
    return {
        noname: "Anonymous"
    };
}

var fido = Dog(); // 没有new，但是这一次需要()
fido.name; // undefined
fido.noname; // "Anonymous"
```
然而，请注意，返回任何this以外的内容，都将会导致instanceof运算符和constructor属性无法像预期的那样工作：
```javascript
function Dog(){
    return {
        noname:"Anonymous"
    };
}

var fido = new Dog();
fido instanceof Dog; // false
fido.constructor === Object; // true
```
当使用new的时候，你可以返回一个定制的对象（而不是this），但是，它必须是一个对象。尝试返回一个非对象（一个标量），将会导致返回值被忽略，并且最终任然会得到this：
```javascript
function Dog(){
    this.name = "Fido";
    return 1;
}

var fido = new Dog();
typeof fido; // "object"
fido.name; // "Fido"
```
#### 4.1.2 关于this的更多内容
正如你所知道的，构造函数和常规函数之间没有区别，只不过二者的用途不同。因此，如果在一个非构造器函数中给this添加属性，会发生什么事情呢？换句话说，当你调用一个构造器函数（它添加给了this）并且忘记使用new调用它的时候，会发生什么事情？
```javascript
function Dog(){
    this.thisIsTheName = "Fido";
    return 1;
}

var fido = new Dog();
var one = Dog();

// fido是一个常规对象
typeof fido;// "object"
fido.thisIsTheName; // "Fido"

// one是1，作为一个非构造器的返回值
typeof one; // "number"
one.thisIsTheName;// undefined

// 什么？
thisIsTheName;// "Fido"
```
这里令人惊讶之处在于，通过调用Dog()而不使用new，创建了全局变量thisIsTheName。这是因为，省略了new意味着这是一次常规函数调用，并且现在this指向了全局对象。添加给该全局对象的属性，可以用作全局变量（稍后会更多地介绍全局对象）。
这是危险的行为，因为你不想要污染全局命名空间。这就是为什么这点很重要：在应该使用new的时候一定要使用new。命名构造器的时候，遵从首字母大写的惯例很重要，因为这样你可以给代码阅读者一个提示，以便他们知道函数的目标用途：
```javascript
function Request(){} // 哈！这是一个构造器函数
function request(){} // 只是一个普通函数
```
---
**注意：** 在ECMAScript 5的严格模式中，这一危险的行为得到了修正

---
#### 4.1.3 增强构造器
如果你有点偏执狂，可以通过编程来确保即便调用者忘记了new，函数也会像构造器函数一样工作。可以使用instanceof运算符，它接受一个对象和一个构造器函数引用，并且返回true或false：
```javascript
fido instanceof Do; // true
```
如下是实现自行强化的构造器的一种方式：
```javascript
function Dog(){
    // 检查调用者是否忘记了'new'
    if(!(this instanceof Dog)){
        return new Dog();
    }
    // 真正的工作开始了...
    this.thisIsTheName = "Fido";
    // 真正的工作结束

    // 暗含的工作在此结束...
    // 返回this
}

var newFido = new Dog();
var fido = Dog();

newfido.thisIsTheName; // "Fido"
fido.thisIsTheName; // "Fido"
```
this instanceof Dog这一行检查新创建的this对象是否是由Dog创建的。var fido = Dog();一行没有使用new，因此，this指向了全局对象。全局对象肯定不是由Dog创建的。毕竟，它甚至在Dog之前就存在了，因此，检查失败并且执行到return new Dog();这一行。

---
**注意：** 你其实并不知道使用哪个构造函数创建了全局对象，因为，这是依赖于环境的一个内部类实现。

---
查询和咨询”谁创建了对象“的另一种方法是，使用多有对象都有的constructor属性。它也是一个可写的属性，因此，它并真的可靠，参见下面的示例：
```javascript
function Dog(){}
var fido = new Dog();

fido.constructor === Dog; // true，像预料的一样
fido.constructor = "I like potatoes";
fido.constructor === Dog; // false，...等等，什么？
fido.constructor; // "I like potatoes"
```
### 4.2 原型
PHP中并没有原型（prototypes）的概念，但是，在JavaScript中，这却是一个重要的概念。
让我们来看一个示例：
```javascript
function Dog(name){ // 构造器函数
    this.name = name;
}
// 给‘prototype’属性添加一个成员
Do.prototype.sayName = function(){
    return this.name;
}

var fido - new Dog("Fluff");
fido.sayName(); // "Fluff"
```
这里发生了什么情况？
1. 由一个常用的函数Dog，显然它创建用来作为一个构造器函数，因为它一首字母D开头，并且在函数体中引用了this。
2. 在幕后，Dog()函数和任何其他的函数一样，自动得到一个叫做prototype的属性（我们知道，函数是对象，因此，它们可以由属性）。总是会为每个函数，构造器，以及其他对象创建prototype属性。
3. 给prototype属性添加一个新的属性，该属性名为sayName。这个属性恰好是一个函数，因此，我们可以说它是一个方法。
4. sayName()访问了this。
5. 使用new Dog()创建一个fido对象，这使得fido可以访问添加给prototype属性的所有属性。否则的话，如果我们没有使用new调用Dog()，其中的prototype和所有内容都将忽略。
6. 即便sayName不是fido对象的属性，fido.sayName()也工作得很好。

一个对象可以访问的属性和方法不属于它自己，而是属于创建该对象的构造器函数的prototype所引用的对象。
### 4.3 对象直接量
在本书中，我们已经见过几次对象直接的使用（例如，讨论在JavaScript表示PHP的关联数组的时候）。
对象直接量其实就是键——值对，它们用逗号隔开，并且用花括号包围起来。
```javascript
var obj{
    name : "Fluffy",
    legs : 4,
    tail : 1
}
```
---
**注意：** 在最后一个属性的后面保留结尾的逗号，这是不好的做法，因为某些环境（早期Internet Explorer）无处理它，并且会导致严格错误。

---
可以一开始带有一些属性（或者根本就没有属性），并且随后在添加一些属性：
```javascript
var obj = {};
obj.name = 4;
obj.tall = a;
```
#### 4.3.1 访问属性
使用对象量表示法创建一个对象之后，可以使用点号表示法（dot notation)来访问这些属性。
```javascript
var desc = typeof +"Has +" obj.legs + "leds and"+obj.till,
doc;// "Fluffy is 4 lengs and i (tail);
```
此外不太常见，因为将属性名当做字符串传递有点长且笨拙。然而，当实现穿不知道，它很有用。例如，当遍历素有的属性的时候：
```javascript
var obj = [];
for(var property in obj){
    all.push(property+":"+obj[property]);
}
var desc = all.join(',');
desc; // "Name:Fluffy,legs:4, tail:1"
```
或者，另一个例子是，当在运行时计算属性名的时候：
```javascript
var obj = {
    foo: "Foo",
    bar: "Bar",
    foobar: "Foo + Bar = BFF"
};
var fprop = "foo",bprop = "bar";
obj[fprop]; // "Foo"
obj[bprop]; // "Bar"
obj[fprop + bprop]; // "Foo + Bar = BFF"
```
当属性不是一个有效的标识符的时候，方括号表示法时必需的（对象直接量中包含属性名的引号也是必需的）：
```javascript
var fido = {};
fido.number-of-paws = 4; // ReferenceError
fido['number-of-paws'] = 4; // This is OK
```
#### 4.3.2 令人混淆的点号
在JavaScript中，点号用来访问属性，但是在PHP中，它们用来连接字符串。当你内心还处在PHP模式中，但是却要用JavaScript来编写代码的时候，你往往会按照习惯把点号的用法搞混淆了：
```javascript
// javascript
var world = "wrrld";
var result = "Hello ". world;
```
这很有趣，这在JavaScript中不是语法错误。result包含了值undefined。这是因为点号前后的空格时可选的，因此，如下这样也是有效：
```javascript
"hello".world; // undefined
```
换句话说，你想要访问字符串对象"hello"的属性world。字符串直接量在幕后转换为对象，就好像你执行了new String("hello")（后面很快将更详细地介绍它）。由于这个对象没有这样一个属性，结果是undefined.
#### 4.3.3 对象直接量中的方法
我们可以使用对象直接量表示法给一个对象添加方法吗？绝对可以。方法只不过是属性，而该属性恰好指向函数对象：
```javascript
var obj = {
    name :"Fluffy",
    legs:4,
    tail:1,
    getDescription:function(){
        return obj.name+" has " + obj.legs + " legs and " + obj.tail + " tail(s)";
    }
};

obj.getDescription(); // "Fluffy has 4 legs and 1 tial(s)"
```
---
**注意：** 在getDescription()中，我们可以使用this来替换obj。

---
稍后，可以给一个已有的对象添加方法：
```javascript
obj.getAllProps = function(){
    var all = [];
    for(var property in obj){
        if(typeof obj[property] !== "function"){
            all.push(property + ": "+ obj[property]);
        }
    }
    return all.join(', ');
};

obj.getAllProps(); // "name: Fluffy, legs: 4, tail: 1
```
是否注意到，使用如下的代码过滤掉了一些属性？
```javascript
typeof obj[property] !== "function"
```
情况很可能是这样，你不想让函数出现在属性的列表中，但是，由于函数就像是所有其他属性一样，如果你没有过滤它们的话，它们将会出现。可以尝试删除掉这个过滤器，看看会发生什么情况。

---
**警告：** 在字符串连接环境中访问一个函数对象，将会把函数对象转换为一个字符串。这通过调用toString()方法而实现，继承至Object的所有对象都会响应该方法调用。函数对象通过返回函数的源码，从而实现toString()，尽管这不是标准的实现方法，并且不同引擎的实现会在换行和空白上有所不同。

---
### 4.4 奇特的数组
总的来说，obj现在看上去就像是一个有趣的数组，或者说像是一个PHP的关联数组，其中，它的一些属性像函数一样起作用。实际上，早期的PHP版本根本没有对象的概念。当对象随后添加进来之后，人们称其为“奇特的数组”（fancy array）。如今，在PHP中，很容易在一个对象和一个关联数组之间来回切换：
```PHP
// PHP
$num = array(
    'name'=>"Fluffy",
    'legs'=>4,
    'tail'=>1,
);
echo $num['name']; // "Fluffy"
var_dump($num->name); // NULL，这不是一个对象
```
这里\$num是一个数组，因此，将name当做一个属性访问是行不通的。然而，我们可以把\$num转换为一个对象：
```php
// PHP
$num = (object)$num; // $num 现在是一个对象
echo $num['name']; // 重大的错误，这不再是一个数组
echo $num->name; // "Fluffy"
```
正如你所看到的，关联数组和对象是如此的接近，因此，JavaScript决定合二为一，仅仅使用对象来表示两种概念。
要继续对PHP和JavaScript进行类比，你可以把JavaScript的对象直接量想象成是幕后转换为对象的关联数组。就好像你在PHP中做了如下的事情一样：
```php
// PHP
$mutt = (object)array(
    'name'=>"Fluffy"
);

echo $mutt->name; // "Fluffy"
```
这等同于JavaScript中的：
```javascript
// javascript
var mutt = {
    name:"Fluffy"
};

mutt.name; // "Fluffy"
```
### 4.5 自身属性
在JavaScript中，对象所拥有的属性和继承自prototype对象的属性之间，有一个明确的区别。访问这二者的语法是相同的，但是，有时候你需要知道，一个属性是属于你的对象还是来自于其他某个地方。
自身属性是指使用对象直接量表示法或通过一次赋值添加给对象的那些属性：
```javascript
var literal = {
    mine:"I pwn you"
};
literal.mine; // "i pwn you"
var assigned = {};
assigned.min = "I pwn you";
```
自身属性还包括添加给this以及由构造器函数返回的属性：
```javascript
function Builder(what){
    this.mine = what;
}

var constructed = new Builder("pwned");
constructed.mine; // "pwned"
```
然而，请注意，这两个对象都访问了方法toString()，而它们都没有定义该方法：
```javascript
literal.toString(); // "[object Object]"
constructed.toString(); // "[object Object]"
```
toString()方法对于这两个对象来说，都不是自身方法。它是来自于一个prototype的方法。
如果你想要分辨出自身属性和prototype属性之间的区别，你可以使用另外一个名为的hasOwnProperty()方法，它接受一个属性/方法的名称的字符串的形式：
```javascript
literal.hasOwnProperty("mine"); // true
constructed.hasOwnProperty('mine'); // true
literal.hasOwnProperty('toString'); // false
constructed.hasOwnProperty('toString'); // false

literal.hasOwnProperty('hasOwnProperty'); // false
```
让我们做更多一些思考。toString()方法来自何处？我们如何才能够搞清楚谁是原型？
#### 4.5.1 __proto__
对象拥有原型，但是，它们没有prototype属性，只有函数才会有这个属性。然而，很多环境为每个对象提供了一个特殊的\_\_proto\_\_属性。\_\_proto\_\_并不是随处都可用的，因为它只是对于调试和学习有用。
\_\_proto\_\_是一个属性，它表明了对象以及创建该对象的构造器函数的prototype属性之间的秘密关系：
```javascript
constructed.prototype; // 为定义，对象没有这个属性
constructed.constructor === Builder; // true，"Who's your constructors?"

// 秘密联系以暴漏了
constructed.constructor.prototype === constructed.__proto__; // true
```
链式的\_\_proto\_\_调用允许你刨根问底。这个根底就是内建的Object()构造器函数。
Object.prototype是所有对象的父对象。所有对象都继承它。这就是定义toString之处：
```javascript
Object.prototype.hasOwnProperty("toString"); // true
```
可以从constructed对象开始追踪toString：
```javascript
constructed.__proto__.__proto__.hasOwnProperty("toString"); // true
```
那么literal对象呢？它的链条稍微短一些：
```javascript
literal.__proto__.hasOwnProperty("toString"); // true
```
这是因为literal并不是一个定制的构造器创建的，这意味着，它是由Object()幕后创建的，而不是由继承自Object()的别的方法（例如，Builder()）创建的。
当你临时需要一个简单的对象的时候，可以使用({})，如下的语法也有效：
```javascript
({}).__proto__.hasOwnProperty('toString'); // true
```
---
**注意：** 前面提到了，像var o = {}这样的对象直接量，创建了“空”对象。“空”这个单词之所以放在引号中，是因为对象实际上并不是空的或空白的。每个对象，即便它没有任何自身属性，它也已经有一些属性和方法是可用的，这就是从它的原型链继承而来的那些属性和方法。

---
#### 4.5.2 this或prototype
当使用构造器函数的收，你可以给this或构造器函数的prototype添加属性。你可能会问应该使用哪一个。
添加给prototype要更为高效一些，并且占用内存较少一些，因为这些属性和函数仅创建一次，并且可以供使用相同构造器所创建的所有对象来重用。添加给this的任何内容，都会在你每次实例化一个新对象的时候创建一次。
因此，你打算重用或者在示例之间共享的任何成员，都应该添加给prototype；而在每个实例中都拥有不同的值的任何属性，都应该是添加给this的自身属性。更为常见的做法时，方法归于原型，而属性归于this，除非这些属性在实例中都是保持一致的。
谈到代码重用，这又引发下一个问题：可以重用那些使用了继承的代码吗？
### 4.6 继承
到目前为止，我们已经学习了：
+ 如何用直接量表示法或构造器函数来创建对象。
+ 原型是什么（每个函数的一个属性）。
+ 自身属性和原型属性。
+ 对象从其原型以及其原型的原型那里继承属性等。

现在，我们来讨论一下继承，因为你可能会感到奇怪，在没有类的语言中，继承如何工作呢？事实上，根据我们的目标和喜好，有另外的方法来实现继承。
#### 4.6.1 通过原型继承
实现继承的默认方法是使用原型，我们使用一个父构造器创建一个对象，并且将其设置为子构造器的一个原型：
如下是将要作为父构造器的一个构造器函数：
```javascript
function NormalObject(){
    this.name = 'normal';
    this.getName = function(){
        return this.name;
    };
}
```
还有一个构造器：
```javascript
function PreciousObject(){
    this.shiny = true;
    this.round = true;
}
```
继承的部分如下：
```javascript
PreciousObject.prototype = new NormalObject();
```
好了，现在你可以创建Precious对象了，它具备Normal对象的所有功能：
```javascript
var crystal_ball = new PreciousObject();
crystal_ball.name = "Ball, Crystal Ball.";
crystal_bal_round; // true
crystal_bal.getName(); // "Ball, Crystal Ball."
```
---
**注意：** 本章中的示例受到了Jim Bumgardner博客帖子“Theory of the Precious Object”（[http://krazydad.com/blog/2008/07/31/theory-of-the-precious-object/](http://krazydad.com/blog/2008/07/31/theory-of-the-precious-object/)）的启发，而不是常见的“将汽车扩展为交通工具”。这是一篇很有趣的帖子，它阐明了对象的宝贵之处，就像是J. R.R Tolkien的科幻小说<<魔界>>或者像iPhone一样，具有某种公共的品质。

---
注意，你需要使用new NormalObject()来创建一个对象，并且将其赋值给PreciousObject函数的prototype属性，因为原型只是一个对象。如果想到了类，你知道，一个类总是继承自另一个来。并且，如果考虑到JavaScript的情况，你可能会期望一个构造器函数继承自另一个构造器函数。但是，情况并非如此。在JavaScript中，你继承了一个对象。
如果有几个继承了NormalObject对象的构造器函数，你可能每次会创建new NormalObject()，但这并非必须的。你可以创建一个Normal对象，并且将其作为子对象的原型重用。甚至开始的时候，并不需要整个NormalObject构造器函数。既然你继承了一个对象，所需要的只是一个对象，而不管它是如何创建的。
做同样的事情的另一种方式是，用对象直接量表示法来创建一个（单体）的Normal对象，并且将其用作其他对象的基类对象：
```javascript
var normal = {
    name:'normal',
    getName:function(){
        return this.name;
    }
};
```
然后，由PreciousObject()创建的对象可以像下面这样继承normal：
```javascript
PreciousObject.prototype = normal;
```
#### 4.6.2 通过复制属性来继承
由于继承都是关于代码重用的，实现它的另一种方式是，直接将一个对象的属性复制到另一个对象。
假设有下面这些对象：
```javascript
var shiny = {
    shiny: true,
    round: true
};

var normal = {
    name: 'name me',
    getName: function(){
        return this.name;
    }
};
```
shiny如何得到normal的属性？这里有一个简单的extend()函数，它遍历并复制属性：
```javascript
function extend(parent, child){
    for(var i in parent){
        if(parent.hasOwnProperty(i)){
            child[i] = parent[i];
        }
    }
}

extend(normal, shiny); // 继承
shiny.getName(); // "name me"
```
复制属性看上去好像代价太高，并且可能会影响到性能，但是，相对于众多人物来说，它还是不错的选择。你还可以看到，这是实现混合继承和多继承的一种很容易的方式。

---
**注意：** 使用这种模式，instanceof和isPrototypeOf()不会像预期的那样工作。

---
#### 4.6.3 Beget对象
JavaScript的杰出人物，JSON的发明者Douglas Crockford，提供了另一种方式，使用一个仅仅能够设置其prototype的临时构造器函数，来实现了继承。
```javascript
function begetObject(o){
    function F(){}
    f.prototype = o;
    return new F();
}
```
你创建了一个新的对象，但不是从头开始创建的，它是从另一个已有的对象继承了一些功能。
例如，假设你有如下父对象：
```javascript
var normal = {
    name: 'name me',
    getName: function(){
        return this.name;
    }
};
```
然后，可以有一个新的对象，它继承自该父对象：
```javascript
var shiny = begetObject(normal);
```
可以给新的对象添加额外的功能：
```javascript
shiny.round = true;
shiny.preciousness = true;
```
正如你所看到的，这里没有属性赋值，也没有看到任何构造器函数。一个新的对象继承自一个已有的对象。这实际上是社区支持的一种好思路，现在，它以Object.create()的形式称为 ECMAScript 5的一部分，我们将会在第6章中看到这点。
作为闭包和优化的一个练习，你能否修改begetObject()以使得不会每次都要创建F()。
#### 4.6.4 “经典的”extend()
让我们用另外一种方式来实现继承，以此作为本章的结束。这种方法可能是最接近PHP的，因为这看上去就像是继承自另外一个构造器函数的一个构造器函数。因此，它看上去有点像是继承自另一个类的一个类。
主要内容如下：
```javascript
function extend(child, parent){
    var F = function(){};
    F.prototype = parent.prototype;
    child.prototype = new F();
}
```
通过这种方法，我们传递了两个构造器函数给extend()。在extend()执行之后，使用第一个构造器（子构造器函数）创建的任何新的对象，都通过prototype属性，得到了第二个构造器（父构造器函数）的所有属性和方法。

---
**注意：** 这种方法通常称为“经典的”，因为它看上去和类的思想最为接近。

---
只需要给extend添加两个小内容：
+ 让子构造器函数保留对夫构造器函数的一个引用，以备不时之需。
+ 重置子构造器函数的constructor属性，使其指向子构造器函数，以防在自省的时候需要（你将会在第5章看到关于这一属性的更多介绍）。
```javascript
function extend(child, parent){
    var F = function(){};
    F.prototype = parent.prototype;
    child.prototype = new F();
    child.prototype.parent = parent;
    child.prototype.constructor = child;
}
```
在这个方法中，没有涉及new Parent()的实例。这意味着，在父构造器函数中添加给this的自身属性将不会被继承。只有添加给父对象的原型属性，才会被继承。并且这在很多情况下都是成立的。通常，我们会将想要重用的属性添加给原型。
考虑如下的设置：
```javascript
function Parent(){
    this.name = "Papa";
}
Parent.prototype.family = "Bear";
function Child(){}
extend(Child, Parent);
```
Name属性是不会被继承的，但是family属性会被继承。
```javascript
new Child().name; // undefined
new Child().family; // "Bear"
```
并且，子对象可以访问父对象：
```javascript
Child.prototype.parent === Parent; // true
```
#### 4.6.5 借用方法
使用call()和apply()使得我们有机会重用代码，而根本不必处理继承。毕竟，继承本就是用来帮助我们重用代码的。
如果你看到了想要一个方法，可以临时借用它，传递自己的对象在需要this的位置取代它：
```javascript
var object = {
    name: 'normal',
    sayName: function(){
        return "My name is " + this.name;
    }
};

var precious = {
    shiny: true,
    name: "iPhone"
};
```
如果precious想要获得object.sayName()的益处并且不想扩展任何内容，它可以直接像下面这样使用：
```javascript
object.sayName.call(precious); // "My name is iPhone"
```
如果将方法借用和经典的继承结合起来，那么，可以你既获得自身属性，也可以胡德原型属性：
```javascript
function Parent(name){
    this.name = name;
}

Parent.prototype.family = "Bear";

function Child(){
    Child.prototype.parent.apply(this, arguments);
}

extend(Child, Parent);
```
所有this属性变成了子对象的自身属性。并且，通过arguments和apply()的魔力，如果愿意的话，我们也可以让参数传递给构造器函数：
```javascript
var bear = new Child("Cub");
bear.name; // "Cub"
bear.family; // "Bear"
bear.hasOwnProperty("name"); // true
bear.hasOwnProperty("family"); // false
```
#### 4.6.6 结论
正如你所看到的，很多种选项可以用来实现继承。你可以根据手边的任务，个人的偏好或团队的偏好来选择一种方法。你甚至可以构建自己的解决方法，或者使用你所选择的库自带的方案。然而，注意，深继承链在JavaScript项目种并不常见，因为这种语言允许你直接复制其他对象的属性和方法，或者“借用”这些属性和方法实现自己的任务。或者说，就像四人组在<\<Design Pattern\>>一书中所说的：“对象组合优先于类继承”。