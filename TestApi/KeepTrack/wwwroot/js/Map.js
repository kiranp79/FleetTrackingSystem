// Initialize and add the map 
var map;
var markers = [];
function initMap() {

    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: -34.397, lng: 150.644 },
        zoom: 12
    });
    infoWindow = new google.maps.InfoWindow;

    // Try HTML5 geolocation.
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            map.setCenter(pos);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleLocationError(false, infoWindow, map.getCenter());
    }
}

function handleLocationError(browserHasGeolocation, infoWindow, pos) {
    infoWindow.setPosition(pos);
    infoWindow.setContent(browserHasGeolocation ?
        'Error: The Geolocation service failed.' :
        'Error: Your browser doesn\'t support geolocation.');
    infoWindow.open(map);
}
function getfleet() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5002/api/fleet',
        contentType: 'application/Json',
        datatype: 'Json',
        crossDomain: true,
        success: function (data) {
            $.each(data, function (id, val) {

                $('#workingfleet').append('<p><button onClick="fleetLocation(' + val.fleetID + ');" class="agents" data-id="' + val.fleetID + '">' + val.fleetRCNo + '</button></p>');
            });

        },
        error: function (request) {
            var msg = "Code : " + request.status + "\n" + "Text : " + request.statusText + "\n";
            if (request.responseJSON != null) {
                msg += "Message" + request.responseJSON.Message + "\n";
            }
            alert(msg);
        }
    });
}
function fleetLocation(id) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5004/api/location/' + id,
        contentType: 'application/Json',
        datatype: 'Json',
        crossDomain: true,
        success: function (data) {
            var fleetid = id;
            var lati;
            var longi;
            $.each(data, function (index, value) {
                if (index == "latitude")
                    lati = value;
                if (index == "longitude")
                    longi = value;
            })
            center(lati, longi);
            addMarker(lati, longi);
        },
        error: function (request) {
            var msg = "Code : " + request.status + "\n" + "Text : " + request.statusText + "\n";
            if (request.responseJSON != null) {
                msg += "Message" + request.responseJSON.Message + "\n";
            }
            alert(msg);
        }
    });
}
function addMarker(lati, longi) {
    var marker = new google.maps.Marker({
        position: { lat: lati, lng: longi },
        map: map
    });
    markers.push(marker);
    marker.setAnimation(google.maps.Animation.BOUNCE);
}
function center(lati, longi) {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: lati, lng: longi },
        zoom: 12
    });
}
function setMapOnAll(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}
function clearMarkers() {
    setMapOnAll(null);
}
function showMarkers() {
    setMapOnAll(map);
}
function toggleBounce() {
    if (marker.getAnimation() !== null) {
        marker.setAnimation(null);
    } else {
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }
}
function allfleet() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:5004/api/location',
        contentType: 'application/Json',
        datatype: 'Json',
        crossDomain: true,
        success: function (data) {
            var lati;
            var longi;
            $.each(data, function (index, value) {
                //alert(value.locationID + " " + value.latitude + " " + value.longitude);
                addMarker(value.latitude, value.longitude);
                lati = value.latitude;
                longi = value.longitude;
            });
            zoomout(lati, longi);
            showMarkers();
        },
        error: function (request) {
            var msg = "Code : " + request.status + "\n" + "Text : " + request.statusText + "\n";
            if (request.responseJSON != null) {
                msg += "Message" + request.responseJSON.Message + "\n";
            }
            alert(msg);
        }
    });
}
function zoomout(lati, longi) {
    map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: lati, lng: longi },
        zoom: 1
    });
}

//var Daiict = new google.maps.Marker({ position: { lat: 23.187320, lng: 72.627999 }, map: map });
//var Sargasan = new google.maps.Marker({ position: { lat: 23.185640, lng: 72.602837 }, map: map });

////For Daiict
//var ContDaiict = '<div id="content">' +
//    '<div id="siteNotice">' +
//    '</div>' +
//    '<h1 id="firstHeading" >DAIICT</h1>' +
//    '<div id="bodyContent">' +
//    '<p><b>DAIICT</b>, also referred to as <b>Ayers Rock</b>, is a large ' +
//    'sandstone rock formation in the southern part of the ' +
//    'Northern Territory, central Australia. It lies 335&#160;km (208&#160;mi) ' +
//    'south west of the nearest large town, Alice Springs; 450&#160;km ' ;

//var DaWin = new google.maps.InfoWindow({
//    content: ContDaiict
//});

//Daiict.addListener('mouseover', function () {
//    DaWin.open(map, Daiict);
//});

//Daiict.addListener('mouseout', function () {
//    DaWin.close();
//});

////Saragasan

//var ContSargasan= '<div id="content">' +
//    '<div id="siteNotice">' +
//    '</div>' +
//    '<h1 id="firstHeading" >Sargasan</h1>' +
//    '<div id="bodyContent">' +
//    '<p><b>Sargasan</b>, also referred to as <b>Ayers Rock</b>, is a large ' +
//    'sandstone rock formation in the southern part of the ' +
//    'Northern Territory, central Australia. It lies 335&#160;km (208&#160;mi) ' +
//    'south west of the nearest large town, Alice Springs; 450&#160;km ';

//var SargasanWin = new google.maps.InfoWindow({
//    content: ContSargasan
//});

//Sargasan.addListener('mouseover', function () {
//    SargasanWin.open(map, Sargasan);
//});

//Sargasan.addListener('mouseout', function () {
//    SargasanWin.close();
//});