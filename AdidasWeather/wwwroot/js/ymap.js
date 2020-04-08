ymaps.ready(init);
var map, suggestView;

// Найденный Гео объект.
var findedObject;

var currentCoordinates;

function init() {
    currentCoordinates = {
        Lon: 55.75,
        Lat: 37.56
    };

    map = new ymaps.Map("map", {
        center: [55.76, 37.56],
        zoom: 7
    });

    map.events.add('click', function (e) {
        find(e.get('coords'), false);
    })

    suggestView = new ymaps.SuggestView('search');
    suggestView.events.add('select', function (event) {
        find(event.get('item').value, true);
    });

    find('Россия, Москва', true);
}

function find(obj, checkZoom) {
    var geo = ymaps.geocode(obj, { results: 1 });
    geo.then(function (res) {
        if (findedObject != null) {
            map.geoObjects.remove(findedObject);
        }

        // Выбираем первый результат геокодирования.
        var firstGeoObject = res.geoObjects.get(0),
            // Координаты геообъекта.
            coords = firstGeoObject.geometry.getCoordinates(),
            // Область видимости геообъекта.
            bounds = firstGeoObject.properties.get('boundedBy');

        firstGeoObject.options.set('preset', 'islands#darkBlueDotIconWithCaption');
        // Получаем строку с адресом и выводим в иконке геообъекта.
        firstGeoObject.properties.set('iconCaption', firstGeoObject.getAddressLine());
        // Добавляем первый найденный геообъект на карту.
        map.geoObjects.add(firstGeoObject);

        if (checkZoom) {
            // Масштабируем карту на область видимости геообъекта.
            map.setBounds(bounds, {
                // Проверяем наличие тайлов на данном масштабе.
                checkZoomRange: checkZoom
            });
        }
        findedObject = firstGeoObject;
        currentCoordinates.Lon = coords[0];
        currentCoordinates.Lat = coords[1];

        Initialize(coords[1], coords[0]);
    });
}