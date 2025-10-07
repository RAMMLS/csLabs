#!/bin/bash

echo " === Text changer application build script ==="

#Проверка наличия .NET Sdk
if ! command -v dotnet &>/dev/null; then
  echo "Ошибка: .NET Sdk не установлен!"
  echo "Установите .NET Sdk для продолжения: "
  echo "Для Ubuntu/Debian: sudo apt install dotnet-sdk-6.0"
  echo "Для Fedora: sudo dnf install dotnet-sdk-6.0"
  exit 1
fi

#Проверка наличия mono
if ! command -v mono &>/dev/null; then
  echo "Ошибка: Mono не установлен!"
  echo "Установите Mono для продолжения: "
  echo "Для Ubuntu/Debian; sudo apt-get install mono-complete"
  echo "Для Fedora: sudo dnf install mono-complete"
  ecit 1
fi

echo "Очистка предыдущей сборки..."
dotnet clean

echo "Восстановления пакетов..."
dotnet restore

echo "Сборка приложения..."
dotnet build --configuration Release

if [ $? -eq 0 ]; then
  echo "=== Сборка успешно завершена! ==="
  echo ""
  echo "Запуск приложения"
  echo "+++++++++++++++++++++++++++++++++++++++"
  dotnet run --configuration Release
else
  echo "=== Ошибка сборки! ==="
  exit 1
fi
