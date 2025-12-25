## Создание меню

Для создания используются MainMenu, ContextMenu, MenuItem, порожденные от абстрактного класса Menu;

## Создание главного меню

```cs
public MainMenu()
public MainMenu(MenuItem[] menuItems)
public MainMenu(Icontainer container)
```

После создания MainMenu, необходимо вызвать свойство формы Menu и передать ему имя объекта MainMenu

Свойство Menu доступно как для записи, так и для чтения.

## Контекстное меню

```cs
public ContextMenu()
public ContextMenu(MenuItem[] menuItems)
```

Контекстное меню можно вызвать в любом обработчике события, используя 
```cs
public void Show(Control control, Point pos)
```

где первый параметр - ссылка на элемент управления, к к-му относится контекстное меню, а второй - координата точки, где будет выведено меню.

## Конечные пункты меню
### Конструкторы

```cs
public MenuItem()
public MenuItem(string text)
public MenuItem(string text, EventHandler onClick)
public MenuItem(string text, MenuItem[] items)
public MenuItem(string text, EventHandler onClick, Shortcut shortcut)
```



Аргументы конструкторов

text - название пунка меню
onClick - объект типа EventHandler, который является делегатом. 
shortcut - комбинация клавишь
Shortcut - перечисление допустимых клавиатурных сочетаний для меня (150 сочетаний)



Задание: создать приложение виндовс форм, где есть главное меню из двух пунктов и каждый пункт содержит два подпункта. При выборе любого пункта подменю на экран выводится окно сообщения MessageBox текст, которого соответствует названия пункта. Подменю первого пункта меню верхнего уровня может вызываться с помощью быстрых клавишь ALT1 и ALT2