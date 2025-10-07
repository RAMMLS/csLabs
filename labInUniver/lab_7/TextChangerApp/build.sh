#!/bin/bash

echo "=== Text Changer Application - Windows Forms ==="

# Проверка наличия mcs
if ! command -v mcs &>/dev/null; then
  echo "Ошибка: mcs (Mono C# Compiler) не установлен!"
  echo "Установите mono-complete:"
  echo "sudo apt install mono-complete"
  exit 1
fi

echo "Компиляция приложения..."
mcs -r:System.Windows.Forms -r:System.Drawing -out:TextChangerApp.exe *.cs

if [ $? -eq 0 ]; then
  echo "=== Компиляция успешно завершена! ==="
  echo ""
  echo "Запуск приложения..."
  echo "----------------------------------------"
  mono TextChangerApp.exe
else
  echo "=== Ошибка компиляции! ==="
  echo "Убедитесь, что установлены библиотеки Windows Forms для Mono"
  exit 1
fi
