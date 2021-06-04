## 事 件

**内容**

- 设计公开事件的类型
- 编译器如何实现事件
- 设计侦听事件的类型
- 显示实现事件

事件，这是在类型中定义的一种成员。定义了事件成员的类型允许类型(或类型的实例)通知其他对象发生了特定的事情。例如，**Button** 类提供了 **Click** 事件。应用程序中的一个或多个对象可以接受关于该事件的通知，以便在 **Button** 被单击之后采取特定操作。我们用事件这种类型成员来实现这种交互。具体地说，定义了事件成员的类型能提供以下功能。

- 方法能登记它对事件的关注。
- 方法能注销它对事件的关注。
- 事件发生时，登记了的方法将受到通知。

类型之所以能提供事件通知功能，是因为类型维护了一个已登记方法的列表。事件发生后，类型将通知列表中所有已登记的方法。

**CLR** 事件模型以 **委托** 为基础。委托是[调用][1]回调方法的一种类型安全的方式。对象凭借回调方法接收它们订阅的通知。这里会开始使用委托，但委托的完整会在其他地方详细讲述。

为了帮你完整地理解事件在 **CLR** 中的工作机制，先来描述事件很有用的一个场景。假定要设计一个电子邮件应用程序。电子邮件到达时，用户可能希望将该邮件转发给传真或寻呼机。先设计名为 **MailManager** 的类型来接收传入的电子邮件，它公开 **NewMail** 事件。其他类型(如 **Fax** 和 **Pager** )的对象登记对于该事件的关注。**MailManager** 收到新电子邮件会引发该事件，造成邮件分发给每个已登记的对象。每个对象都用它们自己的方式处理邮件。

应用程序初始化时只实例化一个 **MailManager** 实例，然后可以实例化任意数量的 **Fax** 和 **Pager** 对象。下图展示了应用程序如何初始化，以及新电子邮件到达时发生的事情。



![image-20210515120125564](C:\Users\LuoLian\AppData\Roaming\Typora\typora-user-images\image-20210515120125564.png)

图1的应用程序首先构造 **MailManager** 的一个实例。**MailManager** 提供了 **NewMail** 事件。构造 **Fax** 和 **Pager** 对象时，它们向 **MailManager** 的 **NewMail** 事件登记自己的一个实例方法。这样当新邮件达到时，**MailManager** 就知道通知 **Fax** 和 **Pager** 对象。**MailManager** 将来收到新邮件时会引发 **NewMail** 事件，使所有已登记的方法都有机会以自己的方式处理邮件。

### 1 设计要公开事件的类型

开发人员通过连续几个步骤定义公开了一个或多个事件成员的类型。这里描述了每个必要的步骤。**MailManager**示例应用程序展示了**MailManager**类型，**Fax**类型和**Pager**类型的所有源代码。注意，**Pager**类型和**Fax**类型几乎完全相同。

#### 1.1 第一步：定义类型来容纳所有需要发送给事件通知接收者的附加信息

事件引发时，引发事件的对象可能希望向接收事件通知的对象传递一些附加信息。这些附加信息需要封装到它自己的类中，该类通常包含一组私有字段，以及一些用于公开这些字段的只读共有属性。根据约定，这种类型应该从**System.EventArgs**派生，而且类名以**EventArgs**结束。本例将该类名名为**NewMailEventArgs**类，它的各个字段分别标识了发件人(**m_from**)，收件人(**m_to**)和主题(**m_subject**)。

```c#
internal class NewMailEventArgs : EventArgs
{
    private readonly string m_from, m_to, m_subject;
    public NewMailEventArgs(string from, string to, string subject)
    {
        m_from = from;
        m_to = to;
        m_subject = subject;
    }
    public string From{get{return m_from;}}
    public string To {get{return m_to;}}
    public string Subject{get{return m_subject;}}
}
```

> **注意** **EventArgs**类在Microsoft .NET Framework 类库（FCL）中定义，其实现如下:
>
> ```c#
> [ComVisible(true),Serializable]
> public class EventArgs
> {
>     public EventArgs(){}
>     public static readonly EventArgs Empty = new EventArgs();
> }
> ```
>
> 可以看出，该类型的实现非常简单，就是一个让其他类型继承的基类型。许多事件都没有附加信息需要传递。例如，当一个**Button**向已登记的接收者通知自己被单击时，调用回调方法就可以了。定义不需要传递附加数据的事件时，可以直接使用**EventArgs.Empty**，不用构造新的**EventArgs**对象。

#### 1.2 第二步：定义事件成员

事件成员使用C#关键字**event**定义。每个事件成员都要指定以下内容：可访问性标识符(几乎肯定是**public**，这样其他代码才能访问该事件成员)；委托类型，指出要调用的方法的原型：以及名称（可以是任何有效的标识符）。以下是我们的**MailManager**类中的事件成员：

```c#
internal class MailManager{
    public event EventHandler<NewMailEventArgs> NewMail;
}
```

**NewMail**是事件名称。事件成员的类型是 **EventHandler\<NewMailEventArgs\>** ，意味着“事件通知”的所有接收者都必须提供一个原型和 **EventHandler\<NewMailEventArgs\>** 委托类型匹配的回调方法。由于泛型 **System.EventHandler** 委托类型的定义如下：

```c#
public delegate void EventHandler<TEventArgs>(Object sender, TEventArgs e);
```

所以方法原型必须具有以下形式：

```c#
void MethodName(object sender, NewMailEventArgs e);
```

> 注意 许多人奇怪事件模式为什么要求**sender**参数是**Object**类型。毕竟，只有**MailManager**才会引发传递了**NewMailEventArgs**对象的事件，所以回调方法更适合的原型似乎是下面这样：
>
> ```c#
> void MethodName(MailManager sender, NewMailEventArgs e);
> ```
>
> 要求**sender**是**Object**主要是因为继承。例如，假定**MailManager**成为**SmtpMailManager**的基类，那么回调方法的**sender**参数应该是**SmtpMailManager**类型而不是**MailManager**类型。但这不可能发生，因为**SmtpMailManager**继承了**NewMail**事件。所以，如果代码需要由**SmtpMailManager**引发事件，还是要将sender实参转化为**SmtpMailManager**。反正都要进行类型转化，这和将**sender**定义为**Object**类型没有什么区别。
>
> 将**sender**参数的类型定义为**Object**的另一个原因是灵活。它使用委托能由多个类型使用，只要类型提供了一个会传递**NewMailEventArgs**对象的事件。例如，即使**PopMailManager**类不是从**MailManager**类派生的，也能使用这个委托。
>
> 此外，事件模式要求委托定义和回调方法将派生自**EventArgs**的参数名为**e**。这个要求唯一的作用就是加强事件模式的一致性，使开发人员更容易学习和实现这个模式。注意，能自动生成源码的工具（Microsoft Visual Studio）也知道将参数名为**e**。
>
> 最后，事件模式要求所有事件处理程序的返回值都是**void**。这很有必要，因为引发事件后可能调用好几个回调方法，但没办法返回所有方法的返回值，将返回类型定为**void**，就不允许回调（方法）返回值。遗憾的是，FCL中的一些事件处理程序（比如**ResolveEventHandler**）没有遵循Microsoft自定的模式。例如，**ResolveEventHandler**事件处理程序会返回**Assembly**类型的对象。

#### 1.3 第三步：定义负责引发事件的方法来通知事件的登记对象

按照约定，类要定义一个受保护的虚方法。引发事件时，类以及派生类中的代码会调用该方法。方法只获取一个参数，即一个**NewMailEventArgs**对象，其中包含了传给接收通知的对象信息。方法的默认实现只是检查一下是否有对象登记了对事件的关注。如果有，就引发事件来通知事件的登记对象。该方法在**MailManager**类中看起来像下面这样：

```c#
internal class MailManager
{
    protected virtual void OnNewMail(NewMailEventArgs e)
    {
        EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);
        if(temp!=null)
        {
            temp(this, e);
        }
    }
}
```

> ​                                                                     **以线程安全的方式引发事件**
>
> .NET Framework刚发布时建议开发者用以下方式引发事件：
>
> ```c#
> protected virtual void OnNewMail(NewMailEventArgs e)
> {
>     if(NewMail != null) NewMail(this, e);
> }
> ```
>
> **OnNewMail**方法的问题在于，虽然线程检查出**NewMail**不为**null**，但就在调用**NewMail**之前，另一个线程可能从委托链中移除一个委托，使**NewMail**成了**null**。这会抛出**NullReferenceException**异常。为了修正这个竞态问题，许多开发者都像下面这样写**OnNewMail**方法：
>
> ```c#
> protected virtual void OnNewMail(NewMailEventArgs e)
> {
>     EventHandler<NewMailEventArgs> temp = NewMail;
>     if(temp != null) temp(this, e);
> }
> ```
>
> 它的思路是，将对**NewMail**的引用复制到临时变量**temp**中，后者引用赋值发生时的委托链。然后，方法比较**temp**和**null**，并调用（invoke）**temp**；所以，向**temp**赋值后，即使另一个线程更改为**NewMail**也没有关系。委托是不可变(immutable)，所以这个技术理论上行得通。但许多开发者没有意识到的是，编译器可能“擅做主张”，通过完全移除局部变量temp的方式对上述代码进行优化。如果发生这种情况，上面两者就没有任何区别。所以，仍有可能抛出**NullReferenceException**异常。
>
> 想要这个修正这个问题，应该像下面这样重写**OnNewMail**:
>
> ```c#
> protected virtual void OnNewMail(NewMailEventArgs e)
> {
>     EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);
>     if(temp != null) temp(this, e);
> }
> ```
>
> 对**Volatile.Read**的调用强迫**NewMail**在这个调用发生时读取，引用真的必须复制到**temp**变量中（编译器别想走捷径）。然后，**temp**变量只有在不为**null**时才会被调用（invoke）。在“基元线程同步构造”将会详细讨论**Volatile.Read**方法。
>
> 虽然最后一个版本很完美，是技术正确的版本，但版本2实际也是可以使用的，因为JIT编译器理解这个模式，知道自己不该将局部变量**temp**“优化”掉。具体地说，Microsoft的所有JIT编译器都“尊重”那些不会造成对堆内存的新的读取动作的不变量（invariant）。所以，在局部变量中缓存一个引用，可确保堆引用只被访问一次。这一点并未在文中反映，理论上说将来可能改变，这正是为什么应该使用最后一个版本的原因。但实际上，Microsoft的JIT编译器永远没有可能真的进行修改来破坏这个模式，否则太多的应用程序都会“遭殃”。此外，事件主要在单线程的情形（WPF和Windows Store）中使用，所以线程安全不是问题。
>
> 还要注意，考虑到线程竞态条件，方法有可能在从事件的委托链中移除之后得到调用。

为了方便起见，可定义扩展方法来封装这个线程安全逻辑。如下所示：

```c#
public static class EventArgExtension
{
    public static void Raise<TEventArgs>(this TEventArgs e, Object sender, 
                                         Ref EventHandler<TEventArgs> eventDelegate)
    {
        EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);
        if(temp != null) temp(sender, e);
    }
}
```

现在可以像下面这样重写**OnNewMail**方法：

以**MailManager**作为基类的类可自由重写**OnNewMail**方法。这使派生类能控制事件的引发，以自己的方式处理新邮件。一般情况下，派生类会调用基类的**OnNewMail**方法，使登记的方法能接收到通知。但是，派生类也可以不允许事件转发。

#### 1.4 第四步：定义方法将输入转化为期望事件

类还必须有一个方法获取输入并转化为事件的引发。在**MailManager**的例子中，是调用**SimulateNewMail**方法来指出一封新的电子邮件已到达**MailManager**:

```c#
internal class MailManager
{
    public void SimulateNewMail(string from, string to, string subject)
    {
        NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
        OnNewMail(e);
    }
}
```

**SimulateNewMail**接收关于邮件的信息并构造**NewMailEventArgs**对象，将邮件信息传给它的构造器。然后调用**MailManager**自己的虚方法**OnNewMail**来正式通知**MailManager**对象收到了新的电子邮件。这通常会导致事件的引发，从而通知所有已登记的方法。（如前所述，以**MailManager**为基类的类可以重写这个行为。）

### 2 编译器如何实现事件

知道如何定义提供了事件成员的类之后，接着研究一下事件是什么，以及它是如何工作的。**MailManager**类用一行代码定义了事件成员本身:

```c#
public event EventHandler<NewMailEventArgs> NewMail;
```

C#编译器编译时把它转换为以下3个构造：

```c#
private EventHandler<NewMailEventArgs> NewMail = null;

public void add_NewMail(EventHandler<EventArgs> value)
{
    EventHandler<NewMailEventArgs> prevHandler;
    EventHandler<NewMailEventArgs> newMail = this.NewMail;
    do{
        prevHandler = newMail;
        EventHandler<NewMailEventArgs> newHandler = (EventHandler<NewMailEventArgs>) Delegate.Combine(prevHandler, value);
        newMail = Interlocked.CompareExchange<EventHandler<NewMailEventArgs>>(ref this.NewMail, newHandler, prevHandler);
    }while(newMail != prevHandler);
}

public void remove_NewMail(EventHandler<EventArgs> value)
{
    EventHandler<NewMailEventArgs> prevHandler;
    EventHandler<NewMailEventArgs> newMail = this.NewMail;
    do{
        prevHandler = newMail;
        EventHandler<NewMailEventArgs> newHandler = (EventHandler<NewMailEventArgs>) Delegate.Remove(prevHandler, value);
        newMail = Interlocked.CompareExchange<EventHandler<NewMailEventArgs>>(ref this.NewMail, newHandler, prevHandler);
    }while(newMail != prevHandler);
}
```

第一个构造是具有恰当委托类型的字段。该字段是对一个委托列表的头部的引用。事件发生时会通知这个列表中的委托。字段初始化为**null**，表明无侦听者（listener）登记对该事件的关注。一个方法登记对事件的关注时，该字段会引用 **EventHandler\<NewMailEventArgs\>** 委托的实例，后者可能引用更多的 **EventHandler\<NewMailEventArgs\>** 委托。侦听者登记对事件的关注时，只需将委托类型的一个实例添加到列表中。显然，注销（对事件的关注）意味着从列表中移除委托。

注意，即使原始代码行将事件定义为public，委托字段（本例是**NewMail**）也始终是**private**。将委托字段定义为**private**，目的是防止类外部的代码不正确地操作它。如果字段是**public**，任何代码都能更改字段中的值，并可能删除已登记了对事件的关注的委托。

C#编译器生成的第二个构造是一个方法，允许其他对象登记对事件的关注。C#编译器在事件名（**NewMail**）之前附加了Interlock Anything 模式前缀，从而自动命名该方法。C#编译器还自动为方法生成代码。生成的代码总是调用**System.Delegate**的静态**Combine**方法，它将委托实例添加到委托列表中，返回新的列表头（地址），并将这个地址存回字段。

C#编译器生成的第三个构造是一个方法，允许对象注销对事件的关注。同样地，C#编译器在事件名（**NewMail**）之前附加Interlock Anything 模式前缀，从而自动命名该方法。方法中的代码总是调用**Delegate**的静态**Remove**方法，将委托实例从委托列表中删除，返回新的列表头（地址），并将这个地址存回字段。

> **警告** 试图删除从未添加过的方法，Delegate的Remove方法在内部不做任何事情。也就是说，不会抛出任何异常，可不会显示任何警告；事件的方法集合保持不变。

> 注意 **add** 和 **remove** 方法以线程安全的一种模式更新值。该模式的详情将在后面 “Interlock Anything 模式”讨论。

在本例中，**add**和**remove**方法的可访问性都是**public**。这是因为源代码将事件声明为**public**。如果事件声明为**protected**，编译器生成的**add** 和 **remove** 方法也会被声明为**protected**。因此，在类型中定义事件时，事件的访问行决定了什么代码能够登记和注销事件的关注。但无论如何，只有类型本身才能直接访问委托字段。事件成员也可声明为**static**或者**virtual**。在这种情况下，编译器生成的**add**和**remove**方法分别标记为**static** 或**virtual**。

除了生成上述3个构造，编译器还会在托管程序集的元数据中生成一个事件定义记录项。这个记录项包含了一些标志（flag）和基础委托类型（underlying delegate type），还引用了**add** 和 **remove**访问器方法。这些信息的作用很简单，就是建立“事件”的抽象概念和它的访问器方法之间的联系。编译器和其他工具可利用这些元数据信息，并可通过**System.Reflection.EventInfo**类获取这些信息。但是，CLR本身并不使用这些元数据信息，它在运行时只需要访问器方法。

### 3 设计侦听事件的类型

最难的部分已经完成了，接下来是一些简单的事情。这里将演示如何定义一个类型来使用另一个类型提供的事件。先来看看**Fax**类型代码：

```c#
internal sealed class Fax
{
    public Fax(MailManager mm)
    {
        mm.NewMail += FaxMsg;
    }
    
    private void FaxMsg(object sender, NewMailEventArgs e)
    {
        Console.WriteLine("Faxing mail message:");
        Console.WriteLine(" From = {0}, To={1}, Subject={2}",e.From, e.To, e.Subject);
    }
    
    public void Unregister(MailManager mm)
    {
        mm.NewMail -= FaxMsg;
    }
}
```

电子邮件应用程序初始化时首先构造**MailManager**对象，并将对该对象的引用保存到变量中。然后构造**Fax**对象，并将**MailManager**对象引用作为实参传递。在**Fax**构造器中，Fax对象使用C#的+=操作符登记它对**MailManager**的**NewMail**事件的关注:

```c#
mm.NewMail += FaxMail;
```

C#编译器内建了对事件的支持，它会+=操作符翻译成以下代码来添加对象对事件的关注：

```c#
mm.add_NewMail(new EventHandler<NewMailEventArgs>(this.FaxMsg));
```

C#编译器生成的代码构造一个 **EventHandler\<NewMailEventArgs\>** 委托对象，其中包装了**Fax**类的**FaxMsg**方法。接着，C#编译器调用**MailManager**类的**add_NewMail**方法，向它传递新的委托对象。为了对此进行验证，可编译代码并用ILDasm.exe这样的工具查看IL代码。

即使使用恶道编程语言不能直接支持事件，可以显示调用Add访问器向事件登记委托。两者效果一样，只是后者的源代码看起来没有那么优雅。两者最终都是用**add**访问器将委托添加到事件的委托列表中，从而完成委托向事件的登记。

**MailManager**对象引发事件时，Fax对象的**FaxMsg**方法会被调用。调用这个方法时，会传递**MailManager**对象引用作为它的第一个参数，即**sender**。该参数大多数时候会被忽略。但如果**Fax**对象希望在响应事件时访问**MailManager**对象的成员，它就能派上用场了。第二个参数是**NewMailEventArgs**对象引用。对象中包含了**MailManager**和**NewMailEventArgs**的设计者认为对事件接收者来说有用的附加信息。

**FaxMsg**方法可从**NewMailEventArgs**对象中轻松访问邮件的发件人，收件人以及主题。真实的Fax对象应该将这些信息传真到某处。本例只是在控制台窗口显示。

对象不再希望接收事件通知，应注销对事件的关注。例如，如果不再希望将电子邮件转发到一台传真机，**Fax**对象就应该注销它对**NewMail**事件的关注。对象只要向事件登记了它的一个方法，便不能被垃圾回收。所以，如果你的类型要实现**IDisposable**的**Dispose**方法，就应该在实现中注销对所有事件的关注。**IDisposable**的详情参见"托管堆和垃圾回收"。

**Fax**的**Unregister**方法示范了如何注销对事件的关注。该方法和**Fax**构造器中的代码十分相似。唯一区别是使用-=和+=。C#编译器看到代码使用-=操作符向事件注销委托时，会生成对事件的**remove**方法的调用：

```c#
mm.remove_NewMail(new EventHandler<NewMailEventArgs>(FaxMsg));
```

和+=操作符一样，即使编程语言不直接支持事件，也可显示调用**remove**访问器向事件注销委托。**remove**方法为了向事件注销委托，需要扫描委托列表来寻找一个恰当的委托（其中包装的方法和传递的方法相同）。找到匹配，现有委托从事件的委托列表中删除。没有找到也不会报错，列表不会发生任何变动。

随便说一下，C#要求代码使用+=和-=操作符在列表中增删委托。如果显示调用**add** 和 **remove**方法，C#编译器会报告以下错误信息：**CS0571：无法显示调用运算符或访问器。**

### 4 显示实现事件

**System.Windows.Froms.Control**类型定义了大约70个事件。假如**Control**类型在实现事件时，运行编译其隐式生成**add**和**remove**访问器方法以及委托字段，那么每个**Control**对象仅为事件就要准备70个委托字段！由于大多数程序员只关心少数几个事件，所以每个从**Control**派生类型创建的对象都要浪费大量内存。顺便说一下，ASP.NET的**System.Web.UI.Control**类型和WPF的**System.Windows.UIElement**类型也提供了大多数程序员都用不上的大量事件。

这里讨论C#编译器如何运行类的开发人员显示实现一个事件，使开发人员能够控制add和remove方法处理回调委托的方式。我要演示如何通过显示实现事件来高效率地实现提供大量事件的类，但肯定还有其他情形也需要显示实现事件。

为了高效率存储事件委托，公开了事件的每个对象都要维护一个集合（通常是字典）。集合将某种形式的事件标识符为键（key），将委托列表作为值（value）。新对象构造时，这个集合是空白的。登记对一个事件的关注时，会在集合中查找事件的标识符。如果事件标识符已在其中，新委托就和这个事件的委托列表合并。如果事件标识符不在集合中，就添加事件标识符和委托。

对象需要引发事件时，会在集合中查找事件标识符。如果集合中没有找到事件标识符，表明没有任何对象登记对这个事件的关注，所以没有任何委托需要回调。如果事件标识符在集合中，就调用与它关联的委托列表。具体怎么实现这个设计模式，是定义的那个类型的开发人员的责任；使用类型的开发人员不知道事件在内部如何实现。

下例展示了如何完成这个模式。首先实现一个**EventSet**类，它代表一个集合，其中包含事件以及每个事件的委托列表。

```c#
using System;
using System.Collections.Generic;
using System.Threading;

public sealed class EventKey{}

public sealed class EventSet{
    private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

    public void Add(EventKey eventKey, Delegate handler)
    {
        Monitor.Enter(m_events);
        Delegate d;
        m_events.TryGetValue(eventKey, out d);
        m_events[eventKey] = Delegate.Combine(d, handler);
        Monitor.Exit(m_events);
    }

    public void Remove(EventKey eventKey, Delegate handler)
    {
        Monitor.Enter(m_events);
        Delegate d;
        if(m_events.TryGetValue(eventKey, out d))
        {
            d = Delegate.Remove(d, handler);
            if(d!=null) m_events[eventKey] = d;
            else m_events.Remove(eventKey);
        }
        Monitor.Exit(m_events);
    }

    public void Raise(EventKey eventKey, Object sender, EventArgs e)
    {
        Delegate d;
        Monitor.Enter(m_events);
        m_events.TryGetValue(eventKey, out d);
        Monitor.Exit(m_events);
        if(d!=null)
        {
            d.DynamicInvoke(new Object[]{ sender, e});
        }
    }
}
```

接着定义一个类来使用**EventSet**类。在这个类中，一个字段引用了一个**EventSet**对象，而且这个类的每个事件都是显示实现的，使每个事件的add方法都将指定的回调委托存储到**EventSet**对象中，而且每个事件的**remove**方法都删除指定的回调委托（如果找得到的话）。

```c#
using System;

public class FooEventArgs : EventArgs { }

public class TypeWithLotsOfEvents
{
	private readonly EventSet m_eventSet = new EventSet();

	protected EventSet EventSet { get { return m_eventSet;}}
	
	protected static readonly EventKey s_fooEventKey = new EventKey();

	public event EventHandler<FooEventArgs> Foo
	{
		add { m_eventSet.Add(s_fooEventKey, value); }
		remove {m_eventSet.Remove(s_fooEventKey, value);}
	}
	
	protected virtual void OnFoo(FooEventArgs e)
	{
		m_eventSet.Raise(s_fooEventKey, this, e);
	}
	
	public void SimulateFoo()
	{
		OnFoo(new FooEventArgs());
	}
}
```

使用**TypeWithLotsOfEvents**类型的代码不知道事件是由编译器隐式实现，还是由开发人员显示实现。它们只需要用标准的语法向事件登记即可。以下代码进行了演示。

```c#
public sealed class Program
{
	public static void Main()
	{
		TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();
		twle.Foo += HandleFooEvent;
		twle.Simulate();
	}
	
	private static void HandleFooEvent(object sender, FooEventArgs e)
	{
		Console.WriteLine("Handling Foo Event here...");
	}
}
```



[1]:这个“调用” (invoke)理解为“唤出”更恰当。它和普通的“调用”(call)稍有不同。在英语的语境中，invoke和call的区别在于，在执行一个所有信息都已知的方法时，用call比较恰当。这些信息包括要引用的类型，方法的签名以及方法名。但是，在需要先“唤出”某个东西来帮你调用一个信息不明的方法时，用invoke就比较恰当。

