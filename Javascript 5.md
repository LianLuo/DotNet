## 内建API
JavaScript有少许内建的API。本章将介绍其几乎全部内容。其中只有3个全局属性，9个全局函数和一些全局对象，并且大多数都是构造器函数。大多数有用的内容，都在构造器的原型中，或者直接作为构造器的属性。
### 5.1 全局对象
我们已经认识了全局对象，这里在回顾一下。每个JavaScript环境都有一个全局对象，类似于在PHP中的$GLOBAL数组。
一些环境（但并非所有的环境），都有一个全局变量，该变量引用全局对象。浏览器称为window。我们可以在全局程序代码中或一个函数中使用this来访问它，只要这个函数不是使用new调用的，并且不是处于ES5严格模式中（稍后将更详细地介绍ES5严格模式）。
也可以把全局变量看做是全局对象的属性，唯一的不同之处在于，你无法删除它们。在浏览器中，尝试如下的代码：
```javascript
// 创建一个全局变量
var john = "Jo";
john; // "Jo"
window.john; // "Jo",还是像一个属性一样的工作

// 创建全局对象的一个属性
window.jane = "JJ";
jane; // "JJ"，还是像变量一样工作
window.jane; // "JJ"

// 删除它们

delete window.john; // false
delete window.jane; // true

john; // "Jo"
jane; // undefined

this === window; // true
```
---
**注意：** 当你看见和window.something一起使用的BOM属性的时候，你可以将其缩短为仅仅只有something的形式（例如，window.navigator和navigator是相同的）。当然，除非你有一个相同名称的局部变量。

---
### 5.2 全局属性
全局对象有3个内建属性
+ NaN是一个特殊的值，可以作为算术运算出错而得到的结果。
```javascript
1 * 'a'; // NaN
```
+ Infinity是除以0的时候将会得到的结果。
```javascript
1/ 0; // Infinity
```
+ undefined你应该已经知道了。

这3个特殊值都是全局对象的属性，这有点意思。但是，ES3中存在一个奇怪的问题（这在ES5中修正了），即你可以覆写它们（例如，Infinity = 1）。这当然是一种可怕的思路，但是，它就是这样“任其自然”地发生了。如下的这种模式，库采用来防止人们搬起石头砸自己的脚：
```javascript
// 全局程序代码
(function(window, undefined){
    // window 和 undefined是其应有的样子

    // ... 库在这里 ...
}(this/*, 没有第2个参数*/))
```
### 5.3 全局函数
有9个全局函数（其中4个与数字有关，另外4个与URL编码/解码相关，然后还有一个eval()）。就像在PHP中一样，eval()接受一个字符串并将其作为代码计算。遗憾的是，它通常以危险且不安全的方式使用，并且实际上很少需要使用它。
#### 5.3.1 数字
与数字相关的4个函数如下：
+ isNaN()
> 如果参数是NaN值的话，会告诉你。PHP有is_nan()。
+ isFinite()
> 如果参数不是Infinity值的话，会告诉你。类似PHP中的is_finite()。
+ parseInt()
> 接受一个字符串并返回一个整数，类似于PHP的intval()。
+ parseFloat()
> 把字符串解析为浮点数，类似于PHP的floatval()。

我们使用isNaN()来确定算术运算的结果是否成功，因为NaN值无法与任何内容进行比较，包括其自身：
```javascript
NaN === NaN; // false
1 * 'two' === NaN; // false
isNaN(1 * 'two'); // true
```
parseInt()接受一个要解析的参数和另一个参数，后者指明了想要如何解析字符串。可以总是传递一个10，以确保输入被当做十进制数对待；否则的话，解析器可能必须自行猜测：
```javascript
parseInt(08); // 8
parseInt("08"); // 0
parseInt("08",10); // 8
```
---
**注意：** 在严格模式中，ES5 parseInt("08") 现在返回8

---
让我们来看看使用parseInt()的另外一个示例。假设你想要将CSS十六进制颜色定义转化为rgb()：
```javascript
var red = '#ff0000',r,g,b;
r = red[1]+red[2]; // ff
g = red[3] + red[4]; // 00
b = red[5]+red[6]; // 00
r = parseInt(r,16); // 解析为十六进制数
g = parseInt(g,16); // hex
b = parseInt(b,16); // hex
"rgb("+r+","+g+","+b+")"; // "rgb(255,0,0)"
```
---
**注意：** ES5定义了访问字符串的数组（例如，red[1]），但是，在旧的IE中它是无效的。

---
另一个示例：传统的笑话说万圣节实际上是圣诞节，因为每个人都知道Oct 31 = Dec 25。使用JavaScript控制台，你可以检查这个笑话是否成立。October = Oct = Octal = 8, December = Dec = Decimal = 10，因此：
```javascript
parseInt(31, 8) === parseInt(25, 10); // true
```
#### 5.3.2 编码URL
另外4个全局函数处理URL编码：
+ encodeURIComponent()和decodeURIComponent()
> 这两个函数类似于PHP的urlencode()和urldecode()。
+ encodeURI()和decodeURI()
> 这类似于encodeURIComponent()和decodeURIComponent()，但是，它们生成有效的URL，而只是编码需要编码的部分，将类似http://的部分保留不动。
```javascript
var url = 'http://phpied.com/?search=js php';
encodeURIComponent(url); // "http%3A%2F%2Fphpied.com%2F%3Fsearch-js%20php"
encodeURI(url); // "http://phpied.com/?search-js%20php"
```
注意，encodeURI()并没有编码“&”，根据你想要用查询字符串做些什么，这可能是一个问题，也可能是一项功能。
```javascript
var qs = 'hello=world&jello=moon';
encodeURIComponent(qs); // "hello%3Dworld%26jello%3Dmoon"
encodeURI(qs); // "hello=world&jello=moon"
```
---
**注意：** 你可能还会遇到函数escape()和unescape()。它们不是ECMAScript的一部分，它们来自于BOM。它们的工作方式与encodeURI()和encodeURIComponent()略为不同，并且不应该使用它们。

---
### 5.4 内建构造器
JavaScript中的大多数内建的，随时备用的功能，都是在全局构造器函数中以及两个“其中的”全局对象中实现的：要么是作为构造器函数自身的属性和方法，要么是作为其prototype属性的部分。构造器可以分为4组：
+ Object(), Array(), RegExp()和Function()
> 它们很少用来创建对象，因为它们有更加简短的直接量语法版本。然而，不管你如何创建对象，它们的原型都带有很多可用的属性。
+ String()，Number()和Boolean()
> 这些也很少直接用来创建对象，因为它们只是原始类型的包装器。在JavaScript中，你可以在原始类型以及对象化的包装器之间自由切换，并且，你可以直接在原始类型上调用方法。
+ Date()
> 拥有很多的方法来操作日期。
+ Error()
> 创建错误对象。错误对象很简单，并且你可以选择抛出自己的错误对象，而忘掉有关Error()构造器函数的一起。Error()是一个泛型，还有很多具体的错误构造器（例如，SyntaxError()，ReferenceError()等）。

还有另外两个全局对象值得介绍：
+ Math
> 这不是一个构造器（因此，你不能执行var m = new Math();），但是，这是一个全局对象，其中你可以找到很多有用的数学相关的属性和方法。例如：
```javascript
Math.min(3,5); // 3
Math.E; // 2.718281828459045
```
+ JSON
> 这也不是一个构造器函数，而是包含了用于JSON字符串编码/解码的方法的一个对象。它是ECMAScript 5新添加的内容，并且，你将会在第6章中督导其更多内容。

让我们来更详细地看看所有这些构造器。
#### 5.4.1 Object
Object构造器函数像这样创建对象：
```javascript
var o = new Object();
```
这等同于对象直接量的表示法：
```javascript
var o = {};
```
既然直接量较短，没有理由直接使用构造器。

---
**注意：** 在使用Object()的时候，new可以省略，因此var o = Object();与var o = new Object();是相同的。

---
Object构造器也接受一个参数。根据参数的类型，Object()充当一个工厂，并且把对象创建委托给另一个构造器函数（例如，String()或Boolean()）：
```javascript
var s = new Object("hello");
s.constructor === String; // true
```
这是避免直接调用new Object()的另一个原因。有时候，你不知道将要得到的对象的类型。
**toString()**
toString()方法存在于Object.prototype之上，因此，你可以像下面这样使用它：
```javascript
var o = {};
o.toString(); // "[object Object]"
```
或者也可以这样：
```javascript
var o = {};
Object.prototype.toString.call(o); // "[object Object]"
```
这个方法给出了对象的一个字符串表示。
字符串“[object Object]”对于任何对象来说都是相同的，因此：
```javascript
Object.prototype.toString({}) === Object.prototype.toString({a:1}); // true
```
toString()方法通常用来测试一个对象是否是一个数组。事实上，要测试某个对象是否是一个数组，是需要一些技巧的（毕竟，数组是对象）。尽管这似乎有点技巧，但一种较好的并且健壮的模式是使用toString()。
考虑如下代码：
```javascript
var a = [];
var array_like = {
    length:1,
    o:1
};
```
如果你使用下面的代码进行测试：
```javascript
if('length' in array_like){}
```
或者使用如下代码：
```javascript
if(array_like.hasOwnPrototype('o')){}
```
或者是一种类似的“鸭子类型”模式，如果恰巧array_like对象拥有相同的属性，你可会得到一个错误的肯定。鸭子类型意味着根据一些期望的属性来猜测类型。真如那句俗话说的，“如果它像一只鸭子一样走路和鸣叫，那么，它必然是一只鸭子”。
另一种选择是使用instanceof运算符。这在大多数情况下有效，但是，当设计iframe的时候，会在IE中引起混淆：
```javascript
a instanceof Array; // true
array_like instanceof Array; // false
```
使用toString()，我们可以避免混淆：
```javascript
function isArray(a){
    return Object.prototype.toString.call(a) === "[object Array]";
}

isArray(a); // true
isArray(array_like); // false
```
注意，toString()是作为Object.prototype的而不是Array.protoType的一个成员使用的。这是因为，数组有它们自己定制的toString()，该方法返回表示该数组的一个字符串。
```javascript
var a = [a,2,'a'];
a.toString(); // '1,2,a'
```
---
**注意：** toString()返回了用来创建对象的内部类。这里，它用来将数组与对象区分开，但是，当typeof不够的时候，你可以使用它来进行更详细的内省。例如：
```javascript
typeof(/[a-z]/); // "object"
({}).toString.call(/[a-z]/); // "[object Object]"

// 内省DOM对象
({}).toString.call(document.images); // "[object HTMLCollection]"
({}).toString.call(document.querySelectorAll('*')); // "[object NodeList]"

// 将本地JSON和"shim"实现区分开
// "[object JSON]" (native)
// "[object Object]" (user-land)
({}).toString.call(JSON); // "[object JSON]"
```

---
**toLocaleString()**
toLocaleString()方法和toString()方法相同，只不过它返回本地区域的字符串。
```javascript
({}).toLocaleString(); // "[object Object]"
```
**valueOf**
这个方法取决于对象的类型。对于数组，正则表达式和函数这样的常规对象，它返回对象自身：
```javascript
var o = {};
o.valueOf() === o;// true
a.valueOf() === a; // true
```
对于原始类型包装器Number()，Boolean和String()所创建的对象，它返回原始类型的值。对于Date对象，它返回一个时间戳（与getTime()方法相同）：
```javascript
new Number(9).valueOf === 9;// true
new String("boo").valueOf === "bool"; // true
typeof(new Date().ValueOf()) === "number"; // true
```
**hasOwnProperty()**
我们已经了解了关于hasOwnProperty()方法的一些知识。它使我们可以区分自身方法和那些沿着原型链继承的方法：
```javascript
({}).hasOwnProperty('toString'); // false
({}).constructor.prototype.hasOwnProperty('toString'); // true
```
如下是使用自有对象的另一个例子：
```javascript
var papa = {name:'Papa'};
var KiddoContructor = function(){};
KiddoConstructor.prototype = papa;

var kiddo = new KiddoConstructor();
kiddo.name; // "Papa"
kiddo.hasOwnProperty("name"); // false
papa.hasOwnProperty("name"); // true
```
**propertyIsEnumerable()**
propertyIsEnumrable()方法允许我们内省一个对象，看看一个属性是否是在for-in循环中出现。
例如，数组有一个length属性，它不会在for-in循环中出现：
```javascript
[].hasOwnProperty('length'); // true
[].propertyIsEnumerable('length'); // false
```
要避免使用一个for-in循环迭代的时候混淆，最常见的做法是在循环内部检查hasOwnProperty()，以确保不会获得任何不可预期的属性（例如，添加给Object.prototype的属性）：
```javascript
var obj = {};
for(var prop in obj){
    if(!obj.hasOwnProperty(prop)){
        continue; // 过滤掉
    }
    // 真正的工作在这里...
}
```
**isPrototypeOf()**
正如其名称所示，isPrototypeOf()方法帮助我们内省对象：
```javascript
Array.isPrototypeOf({}); // false
Array.prototype.isPrototypeOf({}); // false
Array.prototype.isPrototypeOf([]); // true
```
该方法也遵从继承链：
```javascript
Object.prototype.isPrototypeof([]); // true, 数组对象
```
**constructor**
constructor正如前面所介绍的，它是这样一个属性，帮你搞清楚使用哪个构造器函数来创建对象：
```javascript
({}).constructor === Object; // true
({}).constructor === Array; // false
```
由于只有一个特定的构造器用来创建对象，我们不能按照isPrototypeOf()那种方式，使用constructor属性来查找继承链：
```javascript
([]).constructor === Array; // true
([]).constructor === Object; // false
```
Object()构造器的讨论就到此为止。接下来看看数组。
#### 5.4.2 Array
Array()构造器使用传递给它的参数作为数组的元素，从而创建数组：
```javascript
var a = new Array(1,2,'boom!');
a.length; // 3
a[0]; // 1
a[1]; // 2
a[2]; // "boom!"
```
省略掉new的话，也是有效的：
```javascript
var a = Array(1,2);
a.length; // 2
```
如果只是传递一个参数，并且这个参数是一个整数，你将会得到这样一个数组，其length等于参数的数目。
```javascript
var a = new Array(12);
a.length; // 12
a[0]; // undefined
```
传递一个浮点数，会导致一个错误：
```javascript
var a = new Array(1.2); // RangeError: Invalid array length
```
传递一个字符串，则会正常工作：
```javascript
var a = new Array("12");
a.length;// 1
a[0]; // "12"
```
更好的方式是使用数组直接量，而不是使用new Array()。数字直接量的方式更加简短，而且在创建只有一个元素的数组的时候，避免了二义性：
```javascript
var a = []; // 没有元素的数组
var a = [1,2,'boom!']; // 三个元素
var a = [12]; // 一个元素
```
因此，当你在内心里由PHP代码转换过来的时候，可以这么考虑：
```php
// PHP < 5.4
$a = array(1,2);
// PHP 5.4
$a = [1,2];
```
```javascript
// javascript
var a = [1,2]
```
我们来看一下Array.prototype所提供的属性和方法
**length**
```javascript
[1,2,3,4].length; // 4
```
但是要注意，length是可以修改的：
```javascript
var a = [1,2,3,4];
a.length; // 4
a.length = 100;
a.length; // 100
```
在这个例子中，元素a[4]-a[99]是不存在的，并且，如果你请求它们的值的话，例如，在0到a.length的一个循环中这么做，那么，将会得到undefined。
接下来考虑：
```javascript
var a = [1,2,3,4];
a.length = 100;
a[10]; // undefined
99 in a;// false
```
下面这个例子有点类似：
```javascript
var a = [1,2,3,4];
a[99] = undefined;
a.length; // 100
```
不同之处在于，这里的元素a[99]存在，因为你已经创建了它，即便它拥有的是undefined的值。而从a[4]到a[98]的所有其他元素，则是不存在的：
```javascript
var a = [1,2,3,4];
a[99] = undefined;
99 in a; // true
98 in a; // false
a.length; // 100
```
注意使用PHP的区别。在PHP中实现前面的代码，会得到5个元素，并且不糊改变count($a)所返回的值：
```php
// PHP
$a = array(1,2,3,4);
$a[99] = null;
echo count($a); // 5
```
**push()**
就像PHP的array_push()一样，Array.prototype.push()在数组的末尾添加一个元素：
```php
$a = array(1,2);
array_push($a,3,4);
```
```javascript
var a = [1,2];
a.push(3,4);
a.toString(); // "1,2,3,4"
```
Array.prototype.push()返回了更新后的数组长度：
```javascript
[1,2].push('a','b'); // 4
```
**pop()**
与push()相反的就是pop()。它从数组中删除最后的一个元素，并且返回该元素：
```php
// PHP
$a = array(1,2);
$what = array_pop($a);
echo count($a); // 2
echo $what; // 3
```
```javascript
// javascript
var a= [1,2,3];
var what = a.pop();
a.toString(); // "1,2"
what; // 3
```
**unshift()**
Array.prototype.unshift()类似于Array.prototype.push()，只不过它在数组的开始处添加新元素。它也会返回新的长度。PHP中对等的函数是array_unshift():
```PHP
// PHP
$a = array(1,2);
$count = array_unshift($a, 3, 4);
print_r($a); // Array([0]=>3 [1]=>4 [2]=>1 [3]=> 2)
echo $count; // 4
```
```javascript
// javascript
var a = [1,2];
var count = a.unshift(3,4);
a.toString(); // "3,4,1,2"
count; // 4
```
**shift()**
shift()与unshift()相反。它会删掉数组的第一个元素并且将其返回。其中PHP中的对等函数是array_shift()：
```php
// PHP
$a = array(1,2,3);
$first = array_shift($a);
print_r($a); // Array([0]=>2 [1]=> 3)
echo $first; // 1
```
```javascript
// javascript
var a = [1,2,3];
var first = a.shift();
a.toString(); // "1,2"
first; // 1
```
**concat()**
Array.prototype.concat()类似于PHP中的array_merge()。它把一个数组的元素都附加到另一个元素的末尾，从而创建一个新的数组。两个输入数组都保持不变：
```javascript
var a = [1,2,3];
var b = ['one','two','three'];
var c = c.concat(b);

a.toString(); // "1,23"
b.toSting(); // "one,two,three"
c.toString(); // "1,2,3,one,two,three"
```
也可以给concat()传递多个参数。如果它们不是数组的话，会将其当做是拥有单个值的数组来对待：
```javascript
var c = a.concat(b,'boo',['boom','vroom','oink'])
c.toString(); // "1,2,3,one,two,three,boo,boom,vroom,oink"
```
**sort()**
在PHP中，有很多函数可以用来排序数组，但是在JavaScript中，只有一个函数可以做到这点，那就是Array.prototype.sort()。它接受一个函数回调，该回调允许你实现自己的定制排序：
```javascript
var a = ['Paul','John','Ringo','George'];
a.sort().toString(); // "George,John,Paul,Ringo"
```
有一项常见的任务是sort()所不能直接拿来用就可以解决的，这就是对数字进行排序：
```javascript
var nums = [1,9,10.2,11];
nums.sort().toString(); // "1,10,11,2,9"
```
结果可能并不是你想要的：数字当做字符串出来排序了。这就像在PHP的sort()中使用了SORT_STRING：
```php
 // PHP
 $nums = array(1,9,10,2,11);
 sort($nums, SORT_STRING);
 print_r($nums); // Array([0]=>1 [1]=> 10 [2]=>11 [3]=>2 [4]=>9)
```
如果你需要SORT_NUMERIC的对等函数，将在JavaScript中实现自己的回调函数：
```javascript
var nums = [1,9,10,2,11];
nums.sort(function(a,b){
    return a-b;
});

nums.toString(); // "1,2,9,10,11"
```
正如你所看到的，这个回调函数就像是我们在PHP中传递给unsort()的回调函数一样工作。它返回：
+ 如果传递给它的两个元素相等的话，返回0。
+ 如果认为第一个参数大约第二个参数，将会返回一个正数。
+ 如果认为第一个参数小于第二个参数，将会返回一个负数。

那么，如何对一个数组进行混排或者随机排序呢？PHP有array_shuffle()，但是在JavaScript中没有对等的函数。由于随机排序可以看做是以任意的顺序排序，这意味着，你可以提供一个返回随即结果的回调函数。Math.random()返回0-1之间的一个随机数，但是，你也会需要负数。因此，可以用0.5减去这个随机数，从而各有50%的概率得到一个正数或负数作为结果：
```javascript
var nums = [1,2,9,10,11];
nums.sort(function(a,b){
    return 0.5 - Math.random();
});

nums.toString(); // "11,1,9,2,10"
```
**slice()**
Array.prototype.slice()在最初的数组中截取从给定的开头的索引到结束的索引的一段，从而创建一个新的数组并返回它。
```javascript
var a = ['one','and','two','and','three','and','four'];
var b = a.slice(2,5);
b.toString();// "two,and,three"
```
---
**注意：** Array.prototype.slice()类似于PHP的array_slice()，但是又并不完全相同，因为PHP的array_slice()接受一个开始索引和一个长度，而不是一个结束索引。

---
如果在调用slice()的时候忽略了第二个参数，它默认第使用length:
```javascript
var a = ['one','and','two','and','three','and','four'];
var b = a.slice(2);
b.toString(); // "two,and,three,and,four"
```
如果传递一个负数索引i，那么，这个参数的值将变成a.length+i。因此，如果你需要最后的3个元素，可以像下面这样做：
```javascript
var a = ['one','and','two','and','three','and','four'];
a.slice(-3).toString(); // "three,and,four"
```
这是因为a.length是7，因此，这个参数变成了7+(-3)。
这就等同于：
```javascript
var a = ['one','and','two','and','three','and','four'];
a.slice(4).toString(); // "three,and,four"
```
**splice()**



