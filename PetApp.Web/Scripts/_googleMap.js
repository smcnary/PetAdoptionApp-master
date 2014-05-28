var geocoder;
var map;
function initialize() {
    geocoder = new google.maps.Geocoder();

        var mapOptions = {
            center: new google.maps.LatLng(29.7628, -95.3831),
            zoom: 9,
            mapTypeId: google.maps.MapTypeId.HYBRID,
            disableDefaultUI: true
        };
        map = new google.maps.Map(document.getElementById("map"),
             mapOptions);
    }
initialize();

$.getJSON("/api/Shelters", function (data) {
    var position = 0;
    geocodeLocations(data, position);
});

var geocodeLocations = function (data) {
    for (var x in data) {
        
        geocoder.geocode({'address': data[x].Location}, function(results, status){
            if (status == google.maps.GeocoderStatus.OK) {
                var marker = new google.maps.Marker({
                    map: map,
                    position: results[0].geometry.location
                });
                console.log(results)
            } else {
                alert('Geocode was not successful for the following reason: ' + status);
            }
        });
    }
}
