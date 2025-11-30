Запуск приложения
1. Разрешите доступ к X11 серверу
bash
xhost +local:docker
2. Соберите Docker образ
bash
docker build -t mono-winforms-app .
3. Запустите контейнер
bash
docker run -it --rm \
    -e DISPLAY=$DISPLAY \
    -v /tmp/.X11-unix:/tmp/.X11-unix \
    mono-winforms-app
