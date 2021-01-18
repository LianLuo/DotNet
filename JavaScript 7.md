## JavaScript 模式
既然我们已经了解了JavaScript语法和内建的API，并且了解了函数和已有的原型的特殊处理方法，现在，让我们来看一些常用的JavaScript模式。尽管四人组的书中的设计模式在书本中不是必须的（尽管在最后会提及一些），但是，大多数模式都特定于我们在创建一个较大的应用程序时候用来组织代码。
例如，JavaScript没有命名空间，模块或私有属性，但是，所有这些功能都很容易复制。
你还将会注意到，大多数时候，很多问题的解决方法归结为使用函数，这就是为了什么理解函数，闭包和作用域对于掌握JavaScript很关键。
### 7.1 私有属性
在ES5中，我们可以使用属性描述符来限制属性的访问，但是，在ES3中，我们却做不到任何这样的事情。那么，如何创建不允许任何人触及的私有属性呢？
解决方案是使用一个闭包并且不暴露你想要让其保持私有的那些变量。这些变量实际上不会是一个对象的私有属性，但是，我们也是私有的。
我们在3.11节讨论了为了私有性而使用闭包的一个示例。但是，这一话题是值得回顾和扩展的。使用闭包来定义一个对象的常用模式如下：
```javascript
var my = (function(){
    return {
        hi: 1,
        bye: 2
    };
}());
```
my.hi;// 2
咋一看，最终的结果和如下代码的结果没有区别：
```javascript
var my = {
    hi: 1,
    bye: 2
};
my.hi; // 1
```
对于简单的对象，这两个示例是相同的。但是，对于第一个示例，我们可以在闭包中隐藏重要的数据：
```javascript
var my = (function(){
    var hidden_private = 42;
    return {
        hi: 1 + hidden_private,
        bye: 2 + hidden_private
    };
}());

my.bye; // 44
```
这里的hidden_private变量压入闭包之中（立即函数），并且，从外部无法访问它。对于任何的意图和作用，它都可以看做是对象my的一个私有属性。
#### 7.1.1 私有方法
和常规变量一样，我们也可以将函数放入到闭包中。它们能够访问闭包中的一起，因此，我们可以访问公开返回的属性以及局部（私有的）变量。你可以认为就像PHP的私有方法（private method）一样地使用这些函数。
如下这个示例中，我们有一个sepecial()函数，它可以访问hidden_private的值以及public_api对象，后者是在闭包之外返回的，并且可以访问。
```javascript
var my = (function(){
    var hidden_private = 42;
    function special(){
        return Number(public_api.hi) + hidden_private;
    }

    var public_api = {
        hi:1,
        get:function(){
            return special();
        }
    };
    return public_api;
}());

my.hi; // 1
my.get(); // 43
my.hi = 100; // 100
my.get(); // 142
```
正如你所看到的，在闭包之外修改了属性hi，并且专门用来调用special()的get()方法，仍然对更新后的值起作用。
#### 7.1.2 暴露私有对象
在前面一节的示例中，私有函数special()允许公开访问：
```javascript
var public_api = {
    hi:1,
    get:function(){
        return special();
    }
};
```
这样做的另一种方式如下所示：
```javascript
var public_api = {
    hi: 1,
    get:special
};
```
第二个示例简单一些，并且在大多数使用情况下都工作得很好，但是，它确实带有一定的风险。由于special()是一个函数，它也是一个对象，并且由于对象是按照引用传递的，这意味着，闭包之外的代码可以修改该对象的属性。
让我们来看看一个较为简单的示例
```javascript
var my = (function(){
    function special(){
        return "ohai";
    }
    var public_api = {
        get:special
    };
    return public_api;
}());
```
可以直接调用get()方法，或者通过其call方法调用：
```javascript
my.get(); // "ohai"
my.get.call(); // "ohai"
```
然而，用某些其他内容来覆盖call方法也是完全合法的，用来覆盖的内容甚至不是一个方法：
```javascript
my.get.call = "not so special";
```
下一次尝试调用call()的时候，会得到一个错误，因为它不再是可以调用的了：
```javascript
my.get.call(); // TypeError: call is not a function
```
因此，当公开地暴露私有对象的时候，要小心。
#### 7.1.3 返回私有数组
前面的示例介绍了如何暴露一个函数，但是，你也可以暴露数组（也是对象）或其他对象。
假设有一个私有数组，并且你想要允许对其读取（但不能写入）访问。按照如下方式进行，看上去似乎是让其得到了足够的保护：
```javascript
var my = (function(){
    var days = ["Mon","Tur","Wed","Thu","Fri","Sat","Sun"];
    return {
        getDays:function(){
            return days;
        }
    };
}());
```
在闭包之外，我们很好地得到了days的数据，但是，没有一种直接的方式访问私有的days变量：
```javascript
my.getDays(); // ["Mon","Tur","Wed","Thu","Fri","Sat","Sun"]
```
然而，由于数组也是对象并且是按照引用传递的，我们可以间接访问它，并可以通过这种方式给数组添加另一个元素：
```javascript
my.getDays.push('js'); // We need one JavaScript day each week.
```
这很奏效
```javascript
my.getDays(); // ["Mon","Tur","Wed","Thu","Fri","Sat","Sun","js"]
```
保护数组的另一种方式是不要直接返回它，而是返回其副本。slice()将返回一个新的数组，利用这一实际情况，我么可以将其用做一个通过的副本生成工具：
```javascript
var my = (function(){
    var days = ["Mon","Tur","Wed","Thu","Fri","Sat","Sun"];
    return {
        getDays:function(){
            return days.slice();
        }
    };
}());
```
现在，试图在周末插入一个特殊的日子，将不会成功：
```javascript
my.getDays().push("js");
my.getDays(); // ["Mon","Tur","Wed","Thu","Fri","Sat","Sun"]
```
如果days不是一个数组，而是带有某些未知的属性的一个对象（一些属性可以是其他的对象，一些属性可能是数组），你可能需要创建它的一个深拷贝并且返回它。
#### 7.1.4 通过JSON的深拷贝
创建一个深拷贝的最简单的方式是，使用JSON编码随后再解码该对象。这可能不是最高效的方式，特别是再不能本地支持JSON的浏览器中，但是，这种方式肯定比较简短：
```javascript
var my = (function(){
    var stuff = {
        a:{
            b:[1,2]
        }
    };

    return {
        getStuff:function(){
            return JSON.parse(JSON.stringify(stuff));
        }
    };
}());
```
访问stuff是为了读取，而不是为了写入：
```javascript
my.getStuff().a.b.toString(); // "1,2"

// 修改
my.getStuff().a.b.push(3);
my.getStuff().a.c = "Ch-ch-changin";

// 测试修改
my.getStuff().a.b.toString(); // "1,2"
typeof my.getStuff().a.c; // undefined
```
为了让getStuff()更为高效，可以使用一个立即函数，它预先计算JSON编码/解码，并且在定义的时候返回stuff的一个快照：
```javascript
var my = (function(){
    var stuff = {
        a:{
            b:[1,2]
        }
    };

    return {
        getStuff:function(){
            var snap = JSON.parse(JSON.stringify(stuff));
            return function(){
                return snap;
            }();
        },
        getRealStuff:function(){
            return JSON.parse(JSON.stringify(stuff));
        }
    };
}());
```
这里有一个立即匿名函数（注意，getStuff()后面的()），它把stuff克隆到snap中。然后，这个函数返回了一个新的函数，该函数直接返回已有的snap。随后，当你执行my.getStuff()的时候，执行了其内部的函数，并且它能够访问snap，因为snap及其内部函数都是在由立即（包装器）函数所创建的闭包的内部创建的。
现在调用getStuff()返回snap，它不是通过一个克隆来保护的。因此，可以操作snap，但重要的是保证stuff是安全的：
```javascript
my.getStuff().a.b.push(3);
my.getStuff().a.b.toString(); // "1,2,3"
my.getRealStuff().a.b.toString(); // "1,2"
```
当然，由于在ES3中一起都是可变的，真的没有什么能够阻止你覆盖甚至完全清除公共的API getStuff()和getRealStuff()，并销毁为了仔细保护私有属性和方法而做的所有艰苦工作。换句话说，如果要想搬起石头砸自己的脚，肯定很容易做到这点：
```javascript
my.getRealStuff = function(){
    return "or don't!";
};

delete my.getStuff; // true
my.getRealStuff(); // "or don't!"
my.getStuff(); // Error: no such method
```
### 7.2 揭示模式
和私密性相关的问题就是所谓的揭示模式（revealing pattern）。其思路是，当你提供一个对象，可以默认地让一起变得私有，并且在最后决定让哪个部分变为共有以揭示（reveal）它们。
如果使用揭示模式来重新编写前面的例子，最终会得到类似如下代码段的内容：
```javascript
var my = (function(){
    var stuff = {
        a:{
            b:[1,2]
        }
    };

    function encodeStuff(){
        return JSON.parse(JSON.stringify(stuff));
    }

    var getStuff = function(){
        var snap = encodeStuff();
        return function(){
            return snap;
        };
    }();
    // 揭示在这里进行
    return {
        getStuff:getStuff,
        getRealStuff:encodeStuff
    };
}());
```
这里有些事情需要注意：
+ 所有的一起都是私有的，直到最后的return语句，在这条语句中，你可以确定想要以共有API的形式揭示多少内容。
+ 你不需要对共有/私有使用相同的函数名称，共有的getRealStuff实际上是私有的encodeStuff。
+ 一个私有函数可以在内部使用另一个私有函数。
+ 由你来决定如何对待你所揭示的函数的name属性。

测试：
```javascript
// 使用匿名函数表达式定义getStuff
my.getStuff.name; // ""
// 用一个函数声明定义encodeStuff，因此，它泄露为共有API，这可能是一个问题，也可能不是问题
my.getRealStuff.name; // "encodeStuff"
```
这一模式的一个缺点是，在阅读代码的时候，很难将私有方法和共有方法区分开。必须向下滚动看看暴露了哪个方法。可能的解决方法包括，在创建函数之后就暴露它，或者使用方法注释来表明你让函数称为共有的意图。
### 7.3 常量
一些JavaScript环境提供了一条特殊的const语句，它可以用来取代var:
```javascript
const PI = 3.14;
```
但是，即便在ES5中，也没有常量这样的内容。我们可以使用一种惯例或者引入一种工具，从而绕开这种限制。然而，这两种方法都有确定（惯例是不能强制实行的，而工具对于大多数的任务来说是多余的）。如果你在考虑使用惯例的方法，注意，常用的惯例是对常量采用全部大写的方式。如果使用一个常量工具，我们可以使用一个闭包，而闭包中针对所有的常量定义了你自己的私有库。
让我们创建一个对象constant，它实现了如下的方法（模拟PHP中用来处理常量的那些函数）：
+ define()
+ defined()
+ constant()
```javascript
var constant = (function(){
    var constants = {}, // 所有的常量在这里
        ownProp = Object.prototype.hasOwnProperty, // 简写
        allowed = { // 只接受原始类型
            string:1,
            number:1,
            boolean:1
        };

    return {
        define:function(name,value){
            if(this.defined(name)){
                return false;
            }
            if(!ownProp.call(allowed, typeof value)){
                return false;
            }
            constants[name] = value;
            return true;
        },
        defined:function(name){
            return ownProp.call(constants,name);
        },
        constant:function(name){
            if(this.defined(name)){
                return constants[name];
            }
            return null;
        }
    };
}());
```
使用constants对象：
```javascript
constant.constant('hi'); // null, 它不存在
constant.defined('hi'); // false
constant.define('hi', "ho"); // true

// 试图重新定义一个常量应该会失败
constant.define("hi","hoho"); // false
constant.constant("hi"); // ho
```
define()检查作为常量存储的值的类型，并且只允许原始类型。这使得该函数较为简单，不必处理复制问题，并且和PHP中不允许将对象或数组存储为常量的情况一致。
### 7.4 命名空间
JavaScript中没有命名空间，但是，你可以直接使用一个对象的属性来做到这点。
一种常见的方法是，在应用程序或库中定义一个单个的全局变量。然后，所做的一切其他事情都变成了全局对象的一个属性。
让我们将该全局对象称为APP。

---
**注意：** 使用大写是针对全局变量所采用的一种惯例，以便使其更为突出。这和PHP使用大写便是常量的惯例由冲突。

---
如果想要定义constants和my，使其称为APP的属性。
```javascript
var APP = {};
APP.my = {
    // ...
};
APP.constant = {
    define:function(){
        // ...
    }
};

// 其他内容
APP.my.more = {
    // ...
};
```
由于APP.my和APP.constant是截然不同的，并且潜在有大量的功能，为简单起见，将其实现到不同的文件中才是明智的（你的构建过程是，随后再合并文件，并进行精简以提高产品的性能）。在不同的条件下，这些代码段可能动态地包含，例如，你可能不知道constant是否已经定义了。如果你盲目地执行APP.constant={}，那么，将会消除之前使用相同的名称创建的任何其他的属性（并且在这个例子中，你会丢掉所有的常量）。这就是为什么在添加重要的新属性之前进行检查时如此的重要。
```javascript
if(!APP.constant){
    APP.constant = {
        // ...
    };
}
```
但是，由于总是检查，很快变得繁琐，特别时对于深入嵌套的属性更是如此，因此，有一个通用用途的函数namespace()将会更好：
```javascript
 // bad
 if(APP && APP.my && !APP.my.more){
     APP.my.more = {};
 }

 // good
 APP.namespace("APP.my.more");
```
如下是通用的namespace()函数的一个实现示例：
```javascript
var APP = {
    namespace:function(ns){
        var parts = ns.split('.'),
            parent = APP,
            i;

        // 去除冗余的全局变量
        if(parts[0] === "APP"){
            parts = parts.slice(1);
        }

        for(i = 0;i<parts.length;i++){
            // 如果一个属性不存在的话，创建它
            if(typeof parent[parts[i]] === "undefined"){
                parent[parts[i]] = {};
            }
            parent = parent[parts[i]];
        }
        return parent;
    }
};
```
现在，我们可以这样做：
```javascript
var my = APP.namespace("APP.my");
my === APP.my; // true

APP.namespace("my.more");
typeof APP.my.more; // "object"
```
### 7.5 模块
JavaScript中没有模块的概念，但是模块模式（module pattern）这个名称常常用来表示本章中已经讨论的几项技术的综合，包括：
+ 命名空间将每个模块定义为一个单独的全局对象的一个属性。
+ 一个立即函数，它将整个模块定义包装起来并提供私有性，如果需要的话，定义和初始化该模块所需的任何临时变量也可以放在这里。
+ 该立即函数返回一个对象（或者如果你愿意，可以是一个构造器函数），它揭示了一个共有的API。

新模块的整体框架如下所示：
```javascript
APP.namespace("my.shiny").module = (function(){
    // 简短的名称以避免依赖性
    var shiny = APP.my.shiny;
    // 局部/私有变量
    var i,j;

    // 私有函数
    function hidden(){

    }

    // 共有API
    return {
        willYouUseMe:function(){
            return "Yups";
        }
    };
}());
```
使用这个新的模块：
```javascript
APP.my.shiny.module.willYouUseMe(); // "Yups"
```
### 7.6 CommonJS 模块
将代码组织到模块中的另一种方法是，使用CommonJS规范。CommonJS并非由ECMA International或W3C这样的标准组织建立的一个标准，但是，它是由社区驱动的项目，其目标是让开发者对编写跨环境的JavaScript的常见做法达成一致。模块规范只是CommonJS中的子项目之一（尽管这是其中最流行的一个）。
当前没有浏览器在本地实现CommonJS模块，但是，有一些环境和框架提供了模块支持。支持CommonJS的一个最为显著的环境就是NodeJS。
#### 7.6.1 定义一个CommonJS 模块
如下的代码段定义了一个基本的CommonJS模块。
```javascript
// 私有变量
var i,j;

// 私有函数
function hidden(){

}

// 共有API
exports.sayHi = function(){
    return "hi";
};
```
我们在这里有些什么？
+ 不需要一个立即函数包装器。
+ 私有变量和函数直接定义，就好像你在定义一个全局的变量和函数。然而，CommonJS实现负责让这些变量成为局部的，因此，你所做的一切默认是局部的。
+ 给一个特殊的exports对象添加属性。添加给exports的任何内容，变成了你的模块的公开访问的API。
#### 7.6.2 使用一个CommonJS 模块
如何在你的程序或其他模块中使用这个模块？在NodeJS中，该模块的文件名充当一个模块标示符。因此，如果将之前代码段中的定义保存到一个名为*hi.js*的文件中，随后可以像下面这样使用它：
```javascript
var hi = require('./hi.js');
hi.sayHi();
```
正如你所看到的，CommonJS的另一魔力（除了exports）是名为require()的函数。它接收一个模块标示符，找到并计算所需要的模块，并且从该模块返回exports对象。

---
**注意：** 根据环境的不同，你可以不同的方式来指定模块标示符（例如，在NodeJS中，.js是可选的）。在其他环境中，模块标示符可能只是一个字符串，而不是文件路径。当你用exports定义了模块，就有了对象module，并且可以指定一个module.id来标识该模块。

---
使用require()，你可以获取模块的exports对象，并且将其分配给一个局部变量，这个变量不需要用相同的名称。下面这样也是问题的：
```javascript
var bye = require('./hi');
```
当你使用require()的时候，可以导出几个属性并且获取一个特定属性的句柄。例如，你可以将sayHi()直接赋值给一个变量：
```javascript
var hey = require('./hi').sayHi;
hey(); // "hi!"
```
正如你所看到，使用CommonJS比模块模式的命令空间和闭包要简单很多，也友好很多。所有的麻烦都已经替你考虑到了，你可以随意处理require()函数和export对象。
#### 7.6.3 使用一个未知的模块
如果你想要创建一段可移植的JavaScript代码（假设是一个开源的库），并且你不知道是否会在CommonJS环境中使用它，你仍然可以通过如下做法来做到这两方面：
+ 定义一个简单的命名空间/对象。
+ 在这里添加所有的内容。
+ 查看exports并让你在公有的API成为exports的一个属性。
例如，可以像下面这样做：
```javascript
// 单个全局变量/命名空间
var JS4PHP = JS4PHP || {};

// 定义你的utils模块的功能
JS4PHP.utils = {
    isOdd:function(){
        return num%2 !== 0;
    }
};

// CommonJS
if(typeof exports === "object"){
    exports.utils = JS4PHP.utils;
}
```
通过这种方式，非CommonJS环境可以直接加载你的代码并且使用较长的命名空间的方法调用：
```javascript
JS4PHP.utils.isOdd(10); // false
```
这种命名空间比仅仅用utils.isOdd()要长一些，但是，它提供了某种程度的确定性，即你的JS4PHP工具的用户在他们的代码中并不具有相同名称的一个变量。
在CommonJS环境中，可以使用模块而不用担心全局性和命名空间。例如：
```javascript
require('./utils').utils.isOdd(11); // true
```
### 7.7 AMD
JavaScript中另一种实现模块的思路叫做AMD，即异步模块定义（Asynchronous Module Definition）。它类似于CommonJS，因为它使用require()函数将一个模块包含到另一个模块或程序中。
尽管CommonJS不会干涉如何定义模块的细节（这是环境的任务），但AMD模块描述了一个名为define()的函数。
因此，像下面这样来定义一个模块：
```javascript
define('hi',['hello'],function(){
    // private variable
    var i,j;
    // private method
    function hidden(){}
    return {
        sayHi:function(){
            return "Hi!";
        }
    };
});
```
定义该模块的函数于CommonJS相同，只不过你直接return公有的API，而不是将其赋值给一个exports对象。
define()的第一个参数是新模块的名称，第二个参数是一个依赖性的数组（是新模块所需的其他模块）。
在你的程序中使用hi模块，如下所示：
```javascript
require(['hi'],function(hi){
    hi.sayHi(); // "Hi!"
});
```
require()的第一个参数是所需的模块的一个列表，第二个参数是一个回调函数，当该模块可用的时候，调用该回调函数。
“当可用的时候”，是因为AMD担心异步加载模块（其名称中的A就是表示异步）。建设你载入仅需要3个模块的一个页面。然后，用户与该页面交互，并且你的程序所需要的另一个模块当前并没有加载。AMD辅助函数库会负责将引入额外的模块，并且当该模块可用的时候调用回调函数。
在编写本书的时候，最流行的开源AMD工具是RequireJS。
### 7.8 设计模式
作为附加的内容，我们来介绍Gang of Four的书中所提到的一些设计模式。记住，这些设计模式对于静态的，强类型的，基于类的语言来说是很容易实现的，对于JavaScript这样的语言来说，可以是微不足道的或不必要的。
#### 7.8.1 单例
单例模式确保某个类只有一个对象，并且提供对其单独的全局访问。JavaScript没有类，因此，类的一个单个实例没有意义的。此外，所有的对象都是独特的，因此，JavaScript中的术语单例可能只是“一个对象”的另一种说法。
```javascript
var singleton = {a:1};
var another = {a:1};
singleton === another; // false
```
正如你所看到的，单例已经是一个独特的对象。

---
**注意：** 有时候，当人们提到JavaScript中的“单例”的时候，他们的意思是使用模块模式创建的一个对象。

---
**带有构造器的单例**
但是，如果你的团体由此把想要创建的所有的对象的类的概念，与构造器函数联系到一起，该怎么办呢？换句话说，你要找到像下面这样操作的内容：
```javascript
function Single(){
    // 魔术
}
var a = new Single();
var b = new Single();

a === b; // true
```
由于目标是拥有一个单个的隐藏的实例（对象），我们可以从一个老朋友那里获取帮助，即一个立即函数所创建的闭包：
```javascript
var Single = (function(){
    var instance;
    function Single(){
        this.say_what = "Hi";
    }
    Single.prototype.say = function(){
        return this.say_what;
    };

    return function(){
        if(!instance){
            instance = new Single();
        }
        return instance;
    };
}());
```
这里的instance保护在一个闭包的内部。同一闭包包含了局部的Single构造器函数，它就像一个常规的构造器一样工作，在其中，我们可以给this或Single.prototype添加属性。你选择那种方式真的无所谓，原型的好处在于针对所有的实例使用一个单个的定义，但是，在这个例子中，你只有一个单个的实例。
立即函数返回一个函数，它赋值给全局的Single变量。然后，我可以使用new来调用这个全局变量。
```javascript
// 获得一个实例
var a = new Single();
a.say(); // "Hi"
```
只有第一次调用new Single的时候创建一个新的对象。从那以后，会返回私有的instance：
```javascript
// 获得另一个实例，它应该是相同的
var b = new Single();
s.say(); // "Hi"

// 检查单体是否起作用
a === b; // true
a.say === b.say; // true
```
为了简单起见，这里有一个全局的Single，但是，它不需要是全局的。你总是可以在类似APP.Single的一个命名空间中创建该构造器：
```javascript
APP.Single = (function(){

    // ...
}());
var mySingle = new APP.Single();
mySingle.say();// "Hi"
```
#### 7.8.2 工厂
工厂方法模式允许你将对象的创建延迟到更加具体的子类/构造器。这允许你在运行时确定使用哪个类/构造器来创建一个对象。通常，我们将一个字符串传递给静态的factory()或build()方法，并且，该方法负责找到要实例化的正确类。在PHP中，我们通常为类的命名空间使用一个前缀，或者，在新版中，我们使用一个真实的命名空间。例如：
```javascript
```
#### 7.8.3 装饰者
### 7.9 文档和测试
#### 7.9.1 手册
#### 7.9.2 为自己的代码编制文档
#### 7.9.3 单元测试
#### 7.9.4 JSlint