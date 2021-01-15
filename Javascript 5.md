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
> 这也不是一个构造器函数，而是包含了用于JSON字符串编码/解码的方法的一个对象。它是ECMAScript 5新添加的内容，并且，你将会在第6章中读到其更多内容。

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
或者是一种类似的“鸭子类型”模式，如果恰巧array_like对象拥有相同的属性，你可会得到一个错误的肯定。鸭子类型意味着根据一些期望的属性来猜测类型。正如那句俗话说的，“如果它像一只鸭子一样走路和鸣叫，那么，它必然是一只鸭子”。
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
注意使用PHP的区别。在PHP中实现前面的代码，会得到5个元素，并且不会改变count($a)所返回的值：
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
+ 如果认为第一个参数于第二个参数，将会返回一个正数。
+ 如果认为第一个参数小于第二个参数，将会返回一个负数。

那么，如何对一个数组进行混排或者随机排序呢？PHP有array_shuffle()，但是在JavaScript中没有对等的函数。由于随机排序可以看做是以任意的顺序排序，这意味着，你可以提供一个返回随机结果的回调函数。Math.random()返回0-1之间的一个随机数，但是，你也会需要负数。因此，可以用0.5减去这个随机数，从而各有50%的概率得到一个正数或负数作为结果：
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
如果在调用slice()的时候忽略了第二个参数，它默认地使用length:
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
Array.prototype.splice()是操作数组的强大函数。熟练掌握它是一个好主意。
splice()方法可以同时添加和删除元素。它通过给定的开始索引和长度来删除元素。然后，在删除后的元素所创建的“空白空间里”，可以插入其他元素。
它类似于PHP中的array_splice()。
然而，请注意Array.prototype.slice()的不同之处。splice()接受一个开始索引和一个长度（元素的数目）来进行删除，而slice()接受开始索引和结束索引。
```PHP
// php
$input = array("red","green","blue","yellow","purple");
$slice = array_splice($input,2,2,"orange");
print_r($input); // "red","green","orange","purple"
print_r($slice); // "blue","yellow"
```
```javascript
 // javascript
 var input = ["red","green","blue","yellow","purple"];
 var slice = input.slice(2,2,"orange");
 input.toString(); // "red,green,orange,purple"
 slice.toString(); // "blue,yellow"
```
可以添加多个元素以代替删掉的元素，如果这些元素不是数组，就把它们当做只有一个元素的数组：
```javascript
var input = ["red","green","blue","yellow","purple"];
 var slice = input.slice(2,2,["black","white"],"grey");
 input.toString(); // "red,green,black,white,grey"
```
**reverse()**
正如起名字所示，Array.prototype.reverse()将数组元素的顺序反转（最后一个元素变成第一个元素），这类似于PHP的array_reverse()：
```javascript
[1,2,3].reverse().toString();// "3,2,1"
```
**join()**
Array.prototype.join()类似于PHP的implode()。它返回数组的元素组成一个字符串。默认的分隔符是逗号：
```javascript
[5,4,3].join(" > "); // "5 > 4 > 3"
[5,4,3].join(); // "5,4,3" same as toString()
[5,4,3].join(''); // "543"
```
在PHP中，与implode()相反的函数是explode()；在JavaScript中，Array.prototype.join()的相反函数是String.prototype.split()，我们还将会介绍它。
目前，对于数组的介绍就到此为止。接下来，让我们看看正则表达式。
#### 5.4.3 RegExp
RegExp构造器函数创建正则表达式对象。它可以和new一起使用，也可以不使用new。它还有一种替代语法，就是使用一个正则表达式直接量：
```javascript
var re = new RegExp('[a-z]'); // 构造器函数
var re = RegExp('[a-z]'); // 不使用'new'的构造器函数
var re = /[a-z]/;
```
正如你所看到的，直接量的方式更加简短和容易。只有在通常连接字符串创建临时的正则表达式模式的时候，才需要使用构造器。

---
**注意：** 在ES3中，用直接量表示法定义的正则表达式对象，在解析阶段只会创建一次：
```javascript
function gimme(){
    return /a-z/;
}

var a = gimme();
var b = gimme();
a === b; // false.但是在ES3中为真
```
---
我们可以指定3种regex限定符中的任意一种：
+ global（使用g），匹配所有出现，而不只是第一次出现。
+ multiline（使用m）。
+ ignoreCase（i）。

可以用任意的顺序来设置它们。默认情况下，它们都是false：
```javascript
var re = new RegExp('[a-z]','gmi');
var re = /[a-z]/ig;

// 测试
re.ignoreCase; // true
re.multiline; // false
```
**test()**
在创建了regex对象之后，你可以使用exec()和test()来匹配字符串。如果至少找到一个匹配的话，exec()返回匹配，而test()只是返回true/false。
```javascript
re.exec("something"); // 返回匹配
re.test("something"); // 返回true|false
```
regex对象的其他属性如下所示：
```javascript
re.lastIndex; // 最后一次匹配的索引
re.source; // 作为一个字符串的regex模式（例如，"[a-z]"）
re.global; // 是否设置了g标识
re.multiline; // 是否设置了 m 标识
re.ignoreCase; // 是否设置了 i 标识
```
**exec()**
当你使用re.exec()的时候，返回值是一个数组，其中包括所有的匹配以及另外两个属性：input和index，这两个属性分别是要匹配的输入字符串，以及匹配的索引。
我们来更详细地看一个例子：
```javascript
var re = /([dn])(o+)/;
var result = re.exec("doodle noodle");
result.join(', '); // "doo, d, oo"
```
正如你所看到的，result是一个数组。它包含了regex模式中的完整匹配(doo)以及分组匹配()。还可以看到result数组有额外的属性input和index。
```javascript
result.input; // "doodle noodle"
result.index; // 0
```
如果再次调用re.exec()，将会得到完全相同的结果。但是，regex模式还应该匹配“noo”。要获得所有的匹配，我们需要g修饰符：
```javascript
var re = /(dn)(o+)/g;
```
然后，在一个循环中调用exec()并获得下一个匹配。在每次匹配中，都使用匹配结束的索引字符来更新re.lastIndex属性。当re.exec()返回null（这也再次导致re.lastIndex变为0），就告诉你不再有其他匹配：
```javascript
var re = /(dn)(o+)/g;
var str = "doodle noodle";
re.lastIndex; // 0

re.exec(str); // ["doo","d","oo"]
re.lastIndex; // 3

re.exec(str); // ["noo","n","oo"]
re.lastIndex; // 10

re.exec(str); // null
re.lastIndex; // 0
```
如下是以循环形式实现的相同示例：
```javascript
var re = /([dn])(o+)/g;
var str = "doodle noodle";

var match;
while(match = re.exec(str)){
    console.log(match);
    console.log(re.lastIndex);
}
```
#### 5.4.4 Function
可以使用Function构造函数来创建函数对象：
```javascript
var f = new Function('a','b',"return a+b");
f(4,5); // 9
```
正如你所看见的，这种创建函数的方式很难看，并且有eval()的味道，因此应该尽可能地避免这样做。尽管可以很聪明滴把Function()用于一些元编程任务，但对于更为常见的问题，JavaScript足够动态了，因此，我们很少需要把代码编写为一个字符串。
Function()的用法之一是替代eval()，因为Function()创建了一个本地作用域，并且在计算变量之后不会将其泄露。
```javascript
var code = "var tmp = 1;console.log(tmp)";
Function(code)();// Logs 1
typeof tmp; // undefined;

eval(code); // Logs 1
typeof tmp; // "number"
```
正如你所看到的，使用Function的时候也可以省略new。
Function()不仅不会把变量泄露到全局作用域，而且在其作用域链中除了全局作用域链再没有其他内容：
```javascript
// 全局命名空间
var global = "round";
(function(){
    var global = "flat";
    (new Function("return global;"))(); // "round"

    eval("return global;"); // "flat"
}());
```
**函数属性**
我们已经了解过有关函数对象的所有属性和方法：
+ **length**
期待的参数的数目。
+ **name**
函数的名称，它不是ECMAScript标准的一部分。
+ **call()**
执行传递单个参数的函数
+ **apply()**
执行将所有参数当做数组传递的一个函数。

一个示例：
```javascript
// 定义一个函数
function sum(){
    var res = 0;
    for(var i=0;i<arguments.length;i++){
        res += arguments[i];
    }
    return res;
}

// 测试属性
sum.length; //0
sum.name; // "sum"

// 测试方法
sum.call(null,1,2,3); // 6
sum.apply(null,[1,2,3]); // 6
```
传递给call()和apply()的第一个参数，是要赋值给函数体中的this的对象。当你不关心this的时候，可以传递null。
#### 5.4.5 String
与new一起使用的时候，String()作为构造器函数，创建字符串对象。不使用new的时候，String()用作一个函数，将参数强制转换为原始类型的字符串。字符串对象和字符串原始类型是不同的，但是，你可以访问一个原始类型字符串（以及布尔和数字）的属性和方法，就好像它是一个对象一样。直接使用new String()的理由实在不多了。
```javascript
// 构造器函数，创建字符串对象
var s = new String("hello");
typeof s; // "object"

// 没有new 它创建字符串原始类型
var s = String("hello");
typeof s; // "string"

// 最好用做一个原始类型
var s = "hello";
typeof s; // "string"

// 你也可以在原始类型上调用方法和属性
s.length; // 5
"hi".length; // 2

// 但是不能给原始类型添加属性
var sp = "primitive";
sp.linke_caves = true;
sp.length; //9
sp.like_caves; // undefined
```
表5-1列出了String.prototype的基本的属性和方法，并于PHP函数进行比对。
| JavaScript | PHP | Result |
| ---- | ---- | ---- |
| var s = "javascript" | $s = "javascript" | |
| s.length | echo strlen($s) | 10 |
| s.indexOf('a') | echo strpos($s,'a') | 1 |
| s.lastIndexOf('a') | echo strrpos($s,'a') | 3 |
| s.charAt(0) | echo $s[0] | "j" |
| s.charCodeAt(0) | echo ord($s[0]) | 74 |
| s.toLowerCase() | echo strtolower($s) | "javascript" |
| s.toLocaleLowerCase() | | |
| s.toUpperCase() | echo strtoupper($s) | "JAVASCRIPT" |
| s.toLocaleUpperCase() | | |
| s.concat(" rulz","!") | echo $s." rulz"."!" | "javascript rulz!" |
这些是最简单的方法，现在，让我们来更详细地看看其他的方法。

**substring()**
有3个方法允许我们提取一段字符串：
```javascript
var s = "JavaScript";
s.slice(4,7); // "Scr"
s.substring(4,7); // "Scr"
s.substr(4,3); // "Scr"
```
前两个方法是slice()和substring()，它们类似于PHP的substr()，只不过它们接受一个开始索引和一个结束索引，而不是开始索引和长度。JavaScript中非标准的substr()则接受开始索引和长度，所以，它就像PHP中的substr()一样。

**localeCompare()**
String.prototype.localeCompare()就像是PHP的strcmp()。它允许你根据字符串的排序方式比较字符串：
```javascript
"JavaScript".localeCompare("Java") > 0; // true
```
如果两个字符串相等，它返回0；如果参数较小的话，它返回一个正的整数（这意味着参数将会排序在最初的字符串之前）；否则的话，返回一个负数。
```javascript
"JavaScript".localeCompare("JavaScipz") < 0; // true
```
**split()**
String.prototype.split()类似于PHP的explode()。它根据一个分隔符字符串，将字符串分割到一个数组中：
```javascript
'a,b,c'.split(','); // ["a","b","c"]
```
它还允许分隔符是一个正则表达式；
```javascript
var s = "JavaScript";
s.split(/a/); // ["J","v","Script"]
```
正则表达式可以帮助你解析随意分割的CSV（Common-separated values，逗号分隔开的值）数据。例如：
```javascript
"a, b, c".split(/\s*,\s*/); // ["a","b","c"]
```
**search()**
正如其名称所示，String.prototype.search()在一个字符串中查找一个字符串的存在。它在功能上类似于PHP的strstr()，但是，它在实现上接近于PHP的strpos()：
```javascript
var s = "JavaScript";
s.search(/ava/); // 1
s.search("Java"); // 0
```
这里需要指出两点：
+ 可以使用一个正则表达式或一个字符串来搜索。
+ 要注意为0的结果，这是在索引0的一个匹配；如果没有找到匹配的话，将会得到-1：
```javascript
// 糟糕
if(!s.search("Java")){
    // 错误的否定，将执行这里
    alert("not found");
}
// 较好
if(s.search("Java") === -1){
    alert("not found")
}
```
**replace()**
PHP拥有str_replace()，而JavaScript则有String.prototype.replace()，二者都是用来查找替换字符串的内容。然而，它们的工作方式有很大不同。
首先，replace()接受要查找的一个正则表达式：
```javascript
"JavaScript".replace(/a/g, "@"); // "J@v@Script"
```
如果只是传递一个字符串，其内容会用作一个正则表达式的模式。但是，由于在这个例子中，我们无法设置正则表达式模式的g模式，因此，只有一次出现被替换了：
```javascript
"JavaScript".replace("a","@"); // "J@vaScript"
```
这是常见的错误原因。即便你只是想要替换第一次出现，也总是使用正则表达式"needle"来搜索，这是一个好习惯。
其次，replace()不会像是PHP代码那样接受数组作为输入，因此，我们必须将方法调用链接起来：
```PHP
// PHP
$s = "JavaScript";
$s = str_repace(array("a","S"),array("@","$"),$s);
echo $s; // "J@v@$script"
```
```javascript
// javascript
var s = "JavaScript";
s = s.replace("a","@").replace("S","$");
s; // "J@v@$script"
```
最后，replace()可以接受一个回调函数，而不是一个直接量字符串做替换。匹配，匹配的索引，以及最初的输入字符串，作为参数传递给回调函数，并且回调可以根据匹配进行有意义的或带条件的替换。
如下的示例会使用HTML实体代码来替换大小写字母：
```javascript
var ents = "JavaScript".replace(/[a-z]/g,function(match,index,input){
    // `match` 是a，然后是v，接着是a，以此类推
    // `index` 是match的索引:1,2,3,4,5,6...
    // `input` 是"JavaScript"
    return "&#".concat(match.charCodeAt(0),";");
});
ents;// "J&#97;&#118;&#97;S&#99;&#114;&#105;&#112;&#116;"
```
**match()**
String.prototype.match()匹配一个正则表达式模式，类似于PHP的preg_match()和preg_match_all()：
```php
// PHP
$s = "JavaScript";
preg_match("/[A-Z]/",$s, $matches);
preg_match_all("/[A-Z]/",$s, $matches_all);
print_r($matches); // matches J
print_r($matches_all); // mathes J和S
```
```javascript
// JavaSCript
var s = "JavaScript";
s.match(/A-Z/); // ["J"]
s.match(/[A-Z]/g); // ["J","S"]
```
当该正则表达式没有使用全局g修饰符的时候，该方法和正则表达式对象的exec()方法的工作方式相同：
```javascript
"string".match(/[a-z]/); // ["s"]
/[a-z]/.exec("string"); // ["s"]
```
当没有找到匹配的时候，你将会得到null，而不是一个空数组：
```javascript
"string".match(/[0-9]/); // null
/[0-9]/.exec("string"); // null
```
#### 5.4.6 Number
Number()构造器函数包装了原始数字类型。它可以用来将字符串转换为数字：
```javascript
Number("1.1"); // 1.1
```
它比parseInt()或parseFloat()更加严格些：
```javascript
Number("3,14"); // NaN
parseInt("3,14",10); // 3
parseFloat("3,14",10); // 3
```
和String()一样，new Number()创建数字对象，而不使用new的时候，Number()返回原始类型数字：
```javascript
typeof Number("1.1"); // "number"
typeof new Number("1.1"); // "object"
```
有如下几个常量，定义为Number()函数的属性：
```javascript
Number.MAX_VALUE; // 1.7976931348623157e+308
Number.MIN_VALUE; // 5e-324
Number.POSITIVE_INFINITY; // Infinity
Number.NEGATIVE_INFINITY; // -Infinity
Number.NaN; // NaN
```
最后，还有Number.prorotype的三个方法：
```javascript
Number(123).toFixed(2); // 123.00
(1000000000000).toExponential(); // "1e+12"
(1000000000000).toPrecision(3); // "1.00e+12"
```
#### 5.4.7 Boolean
在3个原始类型包装器构造器中，Boolean()是用途最少的一个。它没有其他的属性或方法。它也可能会造成混淆，new Boolean()返回一个对象，而所有的对象都为真。
```javascript
!!new Boolean(true); // true
!!new Boolean(false); // true
```
#### 5.4.8 Math
Math不是一个构造器，而是一个对象（全局对象的一个属性），它用作一个命令空间，以包含有用的常量和方法。
有如下一些常量：
```javascript
Math.E; // 2.718281828459045
Math.LN2; // 0.6931471805599453
Math.LN10; // 2.302585092994046
Math.LOG2E; // 1.4426950408889634
Math.LOG10E; // 0.4342944819032518
Math.PI; // 3.141592653589793
Math.SQRT1_2; // 0.7071067811865476
Math.SQRT2; // 1.4142135623730951
```
而大多数方法的作用也是一目了然：
```javascript
// 舍入
Math.round(5.6); // 6
Math.floor(5.6); // 5
Math.ceil(5.1); // 5

// 几何
Math.sin();
Math.cos();
Math.tan();
Math.asin();
Math.acos();
Math.atan();
Math.atan2();

// min/max
Math.max(1,2,3,-1); // 3
Math.min(1,2,3,-1); // -1

// 平方和开方
Math.sqrt(49); // 7
Math.pow(7,2); // 49

// 0和1之间随机数
Math.random(); // 0.8354906368561055

// log/exp
Math.exp();
Math.log();
```
#### 5.4.9 Error
你可以使用new Error()或者任何其他的错误构造器函数来抛出自己的错误。这些对象只有两个标准的跨浏览器属性可供使用，这就是name和message。
name属性包含了构造器的名称（作为一个字符串），例如，“Error”，“ReferenceError”等。
你也可以忘掉有关内建错误构造器函数的一切，并且抛出你自己的对象：
```javascript
if(2+2 > 4){
    throw{
        name:'CrazyError',
        message:"It's the end of the world as we know it"
    }
}
```
为了完整起见，这里给出其他的错误构造器函数：
+ EvalError
+ RangeError
+ ReferenceError
+ SyntaxError
+ TypeError
+ URIError

#### 5.4.10 Date
Date()创建date对象：
```javascript
var d = new Date(2021,1,13); // Januray 13, 2021
```
你也可以指定可选的小时，分钟，秒钟和毫秒：
```javascript
new Date(2021,12,30,23,59,59,999); // 2021年前的一毫秒
```
此外，你可以从一个时间戳或一个字符串创建一个date对象
```javascript
new Date(0); // Dec 31, 1969
new Date("December 31, 1969");
```
传递一个字符串类似于有意使用PHP的strtime()，尽管没有该函数功能强大。有两个方法作为构造器Date()的属性：
+ parse()
+ UTC()
parse()等同于给new Date()传递一个字符串，只不过它返回一个时间戳，而不是一个对象。Date.UTC()就像是带有一个长长参数列表（年，月以及可选的日期，小时，分钟，秒钟和毫秒）的Date()构造器。只不过UTC()返回通用时间格式的一个时间戳，而不是本地时间的一个对象。
Date.prototype上有很多方法。它们的作用一目了然，因此，这里不会详细介绍它们。完整的列表如下所示：
```javascript
var d = new Date(0); // Dec 31, 1969, 本地时间
// 我的计算机上本地时间是GMT
// 标识比UTC先前的8个小时（480分钟）
d.getTimezoneOffset(); // -480;

// get/set date
d.setYear(2020); // 1577836800000
d.getYear(); // 120, year counted from 1900

d.setFullYear(2020); // 1577836800000
d.setUTCFullYear(2020); // 1577836800000
d.getFullYear(); // 2020
d.getUTCFullYear(); // 2020

d.setMonth(11); // 1606780800000
d.setUTCMonth(11); // 1606780800000
d.getMonth(); // 11, Dec
d.getUTCMonth(); // 11 December

// Wed Jan 13 2021 21:51:36 GMT+0800"
d.getDay(); // 3
d.getUTCDay(); // 3
d.setHours(0); // 1610470296291
d.setUTCHours(0); //1610412696291
d.getHours(); // 24-(-8) = 8
d.getUTCHours(); // 0

d.setMinutes(30); // 1610411436291
d.setUTCMinutes(30); // 1610411436291
d.getMinutes(); // 30
d.getUTCMinutes(); // 30

d.setSeconds(30); // 1610411430291
d.setUTCSeconds(30); // 1610411430291
d.getSeconds(); // 30
d.getUTCSeconds(); // 30


d.setMilliseconds(1000); // 1610411431000
d.setUTCMilliseconds(1000); // 1610411432000
d.getMilliseconds(0); 
d.getUTCMilliseconds(0);

d.setTime(0); // Unix时间戳
d.getTime(); // 0

// 各种toString变体
d.toString(); // "Thu Jan 01 1970 08:00:00 GMT+0800 (China Standard Time)"
d.toLocaleString(); // "1/1/1970, 8:00:00 AM"
d.toUTCString(); // "Thu, 01 Jan 1970 00:00:00 GMT"
d.toGMTString(); // "Thu, 01 Jan 1970 00:00:00 GMT"

d.toDateString(); // "Thu Jan 01 1970"
d.toLocaleDateString(); // "1/1/1970"

d.toTimeString(); // "08:00:00 GMT+0800 (China Standard Time)"
d.toLocaleTimeString(); // "8:00:00 AM"
```

将一个date对象强制转型为一个数字（例如，使用number()或算术运算），会得到UNIX时间戳，就像getTime()所得到的结果一样。

```javascript
var d = new Date();
Number(d) === d.getTime(); // true
new Date().getTime() === +new Date(); // true
```

### 5.5 构造器概述
到目前为止，你已经看到过了JavaScript的构造器，以及它们的属性和它们的原始的属性。对于它们中的大多数来说，直接将其用做构造器的意义并不大，因为还有一种较短的直接量的版本要更好。
如下是一个快速概览列表：
+ Object()
> 使用对象直接量{}替代更好。
+ Array()
> 使用直接量[]替代。
+ RegExp()
> 当模式是静态的时候，使用直接量/[a-z]/。
+ Function()
> 使用函数声明或者函数表达式。
+ String()
> 只是定义一个常规的原始类型的“string”，并且只有在强制类型转换的时候才使用这个构造器。
+ Number()
> 只用于强制类型转换；否则，将数字定义为原始类型要更好。
+ Error()
> 只是抛出你自己的错误（例如，SyntaxError()等）。
+ Boolean()
> 无用，直接使用true和false。
+ Date()
> 唯一且必须用它获取对象的构造器函数。
+ Math
> 不是一个构造器，但是对于数学常量和静态方法来说是一个有用的命名空间。
+ JSON
> 也不是一个构造器，我们将在第6章再次见到它，那时候，它作为一个全局对象出现。