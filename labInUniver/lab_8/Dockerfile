FROM mono:latest 

# Установка зависимостей для работы с X11
RUN apt-get update && apt-get install -y \
  x11-apps \
  libglib2.0-0 \
  libc6-dev \
  && rm -rf /var/lib/apt/lists/*

# Создание рабочей директории 
WORKDIR /app 

# Копирование исходного кода 
COPY MouseTracker.cs /app/

# Компиляция приложения 
RUN mcs -r:System.Windows.Forms -r:System.Drawing -r:System.Data MouseTracker.cs 

# Установка переменной окружения для X11
ENV DISPLAY =: 0
# Команда запуска 
CMD ["mono", "MouseTracker.exe"]
