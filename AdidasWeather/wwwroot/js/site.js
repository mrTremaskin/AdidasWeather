var currentLang = "ru";

var app = new Vue({
    el: '#vueApp',
    data: {
        locale: locale,
        model: {
        }
    },
    methods: {
        searchFormSubmit: function (e) {
            find($('#search').val(), true);
            e.preventDefault();
        }
    }
});



function Initialize(lon, lat) {
    $('#loadSpinner').css('display', 'block');
    $.get('/Weather/GetWeather?Lon=' + lon + '&Lat=' + lat, function (data) {
        if (data != null) {
            data.temp = data.temperature.celsius.toFixed(0);
            data.fLike = data.feelLikes.celsius.toFixed(0);
            data.pressure = data.pressure.toFixed(0);

            if (currentLang == "ru") {
                var reqStr = 'https://translate.yandex.net/api/v1.5/tr.json/translate?' +
                    'key=trnsl.1.1.20200408T111952Z.f349a183e8200267.2d406e73b16e0b1a37d662e61a309fe7f6e4fae8' +
                    '&text=' + data.description +
                    '&lang=en-ru';

                $.get(reqStr, function (translate) {
                    data.description = translate.text[0];
                });
            }
            
            app.model = data;
            $('#loadSpinner').css('display', 'none');
        }
    });
}