#!/bin/bash

echo "=== Компиляция приложения ==="

# Компиляция приложения
mcs -target:winexe \
  -r:System.Windows.Forms.dll \
  -r:System.Drawing.dll \
  -out:TransparentForm.exe \
  TransparentForm.cs

# Проверка успешности компиляции
if [ $? -eq 0 ]; then
  echo "✓ Компиляция успешно завершена"
  echo "Файл: TransparentForm.exe"

  echo ""
  echo "=== Запуск приложения ==="

  # Запуск приложения через Mono
  mono TransparentForm.exe

  if [ $? -ne 0 ]; then
    echo ""
    echo "Для запуска убедитесь, что установлены необходимые библиотеки:"
    echo "sudo apt install mono-devel mono-runtime libmono-winforms2.0-cil"
  fi
else
  echo "✗ Ошибка компиляции"
  exit 1
fi
